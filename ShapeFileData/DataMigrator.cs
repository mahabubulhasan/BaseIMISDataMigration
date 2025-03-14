using System.Data;
using Microsoft.EntityFrameworkCore;
using ShapeFileData.SourceEntities;
using ShapeFileData.TargetEntities;

namespace ShapeFileData;

public static class DataMigrator
{
    private static void AddContainmentTypes(DbSet<SourceBuilding> source, DbSet<ContainmentType> target)
    {
        var rows = source.Select(x => x.ConType).Distinct().ToList();
        var maxId = target.Any() ? target.Max(x => x.Id) : 0;
        AddRows(target, maxId, rows, (i, row) => new ContainmentType
        {
            Id = i,
            Type = row,
        }, (row) => {
            var exists = target.FirstOrDefault(x => x.Type == row);
            return exists != null;
        });
        Console.WriteLine("Containment Types added in list.");
    }

    private static void AddStructureType(DbSet<SourceBuilding> source, DbSet<StructureType> target)
    {
        var rows = source.Select(x => x.StructType).Distinct().ToList();
        var maxId = target.Any() ? target.Max(x => x.Id) : 0;
        AddRows(target, maxId, rows, (i, row) => new StructureType
        {
            Id = i,
            Type = row,
        }, (row) => {
            var exists = target.FirstOrDefault(x => x.Type == row);
            return exists != null;
        });
        Console.WriteLine("Structure Types added in list.");
    }

    private static void AddFunctionalUse(DbSet<SourceBuilding> source, DbSet<FunctionalUse> target)
    {
        var rows = source.Select(x => x.FuncUse).Distinct().ToList();
        var maxId = target.Any() ? target.Max(x => x.Id) : 0;
        rows.Add("N/A");

        AddRows(target, maxId, rows, (i, row) => new FunctionalUse
        {
            Id = i,
            Name = row,
        }, (row) => {
            var exists = target.FirstOrDefault(x => x.Name == row);
            return exists != null;
        });
        Console.WriteLine("Functional Uses added in list.");
    }

    // Must be called after FunctionalUse
    private static void AddUseCategory(TargetDbContext targetContext)
    {
        var maxId = targetContext.UseCategories.Any() ? targetContext.UseCategories.Max(x => x.Id) : 0;
        targetContext.FunctionalUses.ToList().ForEach(x => {
            var useCategory = new UseCategory
            {
                Id = maxId + 1,
                Name = "N/A",
                FunctionalUseId = x.Id
            };

            targetContext.UseCategories.Add(useCategory);
            maxId++;
        });

        targetContext.SaveChanges();
        Console.WriteLine("Use Categories added in list.");
    }

    private static void AddWaterSource(DbSet<SourceBuilding> source, DbSet<WaterSource> target)
    {
        var rows = source.Select(x => x.WaterSource).Distinct().ToList();
        var maxId = target.Any() ? target.Max(x => x.Id) : 0;

        AddRows(target, maxId, rows, (i, row) => new WaterSource
        {
            Id = i,
            Source = row,
        }, (row) => {
            var exists = target.FirstOrDefault(x => x.Source == row);
            return exists != null;
        });
        Console.WriteLine("Water Sources added in list.");
    }

    private static void AddRows<T>(DbSet<T> dbset, int maxId, List<string?> rows, Func<int, string, T> makeRow, Func<string, bool> exists) where T : class
    {
        int i = maxId + 1;
        foreach (var row in rows)
        {
            if (string.IsNullOrEmpty(row) || exists(row))
            {
                continue;
            }

            dbset.Add(makeRow(i++, row));
        }
    }

    private static void AddRows<TSource, TTarget>(Func<TSource, TTarget> makeRow, Func<DbSet<TSource>, int, int, List<TSource>> getBatch)
        where TSource : class
        where TTarget : class
    {
        using var sourceContext = new SourceDbContext();
        using var targetContext = new TargetDbContext();

        const int batchSize = 500;
        int skip = 0;
        int totalProcessed = 0;
        bool hasMoreRecords = true;

        while (hasMoreRecords)
        {
            var batch = getBatch(sourceContext.Set<TSource>(), skip, batchSize);

            if (batch.Count == 0)
            {
                hasMoreRecords = false;
                break;
            }

            foreach (var row in batch)
            {
                targetContext.Set<TTarget>().Add(makeRow(row));
            }

            targetContext.SaveChanges();

            totalProcessed += batch.Count;
            skip += batchSize;

            Console.WriteLine($"Processed {totalProcessed} {typeof(TTarget).Name} records so far...");
        }

        Console.WriteLine($"All {totalProcessed} {typeof(TTarget).Name} added successfully.");
    }

    private static void AddBuildToilets()
    {
        using var sourceContext = new SourceDbContext();
        using var targetContext = new TargetDbContext();

        var communityToiletBuildings = sourceContext.SourceBuildings
            .Where(x => x.ConType == "Community Toilet")
            .ToList();

        if (communityToiletBuildings.Count == 0)
        {
            Console.WriteLine("No community toilet buildings found.");
            return;
        }

        var bins = communityToiletBuildings.Select(x => x.Bin).ToList();

        var targetBuildingDict = targetContext.Buildings
            .Where(b => bins.Contains(b.Bin))
            .ToDictionary(b => b.Bin);

        int updatedCount = 0;
        var buildToilets = new List<BuildToilet>();

        foreach (var building in communityToiletBuildings)
        {
            if (building.Bin is not null && targetBuildingDict.TryGetValue(building.Bin, out var targetBuilding))
            {
                var buildToilet = EntityMapper.MapBuildToilet(building);
                buildToilets.Add(buildToilet);
                updatedCount++;
            }
        }

        targetContext.BuildToilets.AddRange(buildToilets);

        targetContext.SaveChanges();
        Console.WriteLine($"BuildToilet updated successfully: {updatedCount} records processed.");
    }

    private static void SaveTypes(){
        using var sourceContext = new SourceDbContext();
        using var targetContext = new TargetDbContext();

        AddWaterSource(sourceContext.SourceBuildings, targetContext.WaterSources);
        AddFunctionalUse(sourceContext.SourceBuildings, targetContext.FunctionalUses);
        AddStructureType(sourceContext.SourceBuildings, targetContext.StructureTypes);
        AddContainmentTypes(sourceContext.SourceBuildings, targetContext.ContainmentTypes);
        AddUseCategory(targetContext);

        targetContext.SaveChanges();
        Console.WriteLine("Types saved successfully.");
    }

    public static void Migrate()
    {
        SaveTypes();

        // Calling Order is important
        AddRows<SourceRoad, Road>(EntityMapper.MapRoad, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceDrain, Drain>(EntityMapper.MapDrain, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceWard, Ward>(EntityMapper.MapWard, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceWard, WardBoundary>(EntityMapper.MapWardBoundary, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceBuilding, Building>(EntityMapper.MapBuilding, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceBuilding, Owner>(EntityMapper.MapOwner, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceContainment, Containment>(EntityMapper.MapContainment, (source, skip, batchSize) => [.. source.Include(x => x.SourceBuilding).Skip(skip).Take(batchSize)]);
        AddRows<SourceLic, Lic>(EntityMapper.MapLic, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceTreatmentPlant, TreatmentPlant>(EntityMapper.MapTreatmentPlant, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceCommunityToilet, Toilet>(EntityMapper.MapToilet, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourcePublicToilet, Toilet>(EntityMapper.MapToilet, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);

        AddBuildToilets();
    }
}
