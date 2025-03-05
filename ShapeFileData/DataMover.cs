using Microsoft.EntityFrameworkCore;
using ShapeFileData.SourceEntities;
using ShapeFileData.TargetEntities;

namespace ShapeFileData;

public static class DataMover
{
    private static void AddContainmentTypes(DbSet<SourceBuilding> source, DbSet<ContainmentType> target)
    {
        var rows = source.Select(x => x.ConType).Distinct().ToList();
        AddRows(target, rows, (i, row) => new ContainmentType
        {
            Id = i,
            Type = row,
        });
        Console.WriteLine("Containment Types added in list.");
    }

    private static void AddStructureType(DbSet<SourceBuilding> source, DbSet<StructureType> target)
    {
        var rows = source.Select(x => x.StructType).Distinct().ToList();
        AddRows(target, rows, (i, row) => new StructureType
        {
            Id = i,
            Type = row,
        });
        Console.WriteLine("Structure Types added in list.");
    }

    private static void AddFunctionalUse(DbSet<SourceBuilding> source, DbSet<FunctionalUse> target)
    {
        var rows = source.Select(x => x.FuncUse).Distinct().ToList();
        AddRows(target, rows, (i, row) => new FunctionalUse
        {
            Id = i,
            Name = row,
        });
        Console.WriteLine("Functional Uses added in list.");
    }

    private static void AddWaterSource(DbSet<SourceBuilding> source, DbSet<WaterSource> target)
    {
        var rows = source.Select(x => x.WaterSource).Distinct().ToList();
        AddRows(target, rows, (i, row) => new WaterSource
        {
            Id = i,
            Source = row,
        });
        Console.WriteLine("Water Sources added in list.");
    }

    private static void AddRows<T>(DbSet<T> dbset, List<string?> rows, Func<int, string, T> makeRow) where T : class
    {
        int i = 1;
        foreach (var row in rows)
        {
            if (string.IsNullOrEmpty(row))
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

            Console.WriteLine($"Processed {totalProcessed} {typeof(TTarget)} records so far...");
        }

        Console.WriteLine($"All {totalProcessed} {typeof(TTarget)} added successfully.");
    }

    private static void SaveTypes(){
        using var sourceContext = new SourceDbContext();
        using var targetContext = new TargetDbContext();

        AddWaterSource(sourceContext.SourceBuildings, targetContext.WaterSources);
        AddFunctionalUse(sourceContext.SourceBuildings, targetContext.FunctionalUses);
        AddStructureType(sourceContext.SourceBuildings, targetContext.StructureTypes);
        AddContainmentTypes(sourceContext.SourceBuildings, targetContext.ContainmentTypes);
    }

    public static void SaveInDatabase()
    {
        SaveTypes();

        AddRows<SourceRoad, Road>(EntityBuilder.BuildRoad, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceDrain, Drain>(EntityBuilder.BuildDrain, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceWard, Ward>(EntityBuilder.BuildWard, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceWard, WardBoundary>(EntityBuilder.BuildWardBoundary, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceBuilding, Building>(EntityBuilder.BuildBuilding, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceBuilding, Owner>(EntityBuilder.BuildOwner, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceContainment, Containment>(EntityBuilder.BuildContainment, (source, skip, batchSize) => [.. source.Include(x => x.SourceBuilding).Skip(skip).Take(batchSize)]);
        AddRows<SourceLic, Lic>(EntityBuilder.BuildLic, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceTreatmentPlant, TreatmentPlant>(EntityBuilder.BuildTreatmentPlant, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceCommunityToilet, Toilet>(EntityBuilder.BuildToilet, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourcePublicToilet, Toilet>(EntityBuilder.BuildToilet, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
    }
}
