using Microsoft.EntityFrameworkCore;
using ShapeFileData.SourceEntities;
using ShapeFileData.TargetEntities;

namespace ShapeFileData;

public static class DataMigrator
{
    private static void AddContainmentTypes(DbSet<SourceBuilding2> source, DbSet<ContainmentType> target)
    {
        var rows = source.Select(x => x.ConType).Distinct().ToList();
        AddRows(target, rows, (i, row) => new ContainmentType
        {
            Id = i,
            Type = row,
        });
        Console.WriteLine("Containment Types added in list.");
    }

    private static void AddStructureType(DbSet<SourceBuilding2> source, DbSet<StructureType> target)
    {
        var rows = source.Select(x => x.StructType).Distinct().ToList();
        AddRows(target, rows, (i, row) => new StructureType
        {
            Id = i,
            Type = row,
        });
        Console.WriteLine("Structure Types added in list.");
    }

    private static void AddFunctionalUse(DbSet<SourceBuilding2> source, DbSet<FunctionalUse> target)
    {
        var rows = source.Select(x => x.FuncUse).Distinct().ToList();
        AddRows(target, rows, (i, row) => new FunctionalUse
        {
            Id = i,
            Name = row,
        });
        Console.WriteLine("Functional Uses added in list.");
    }

    private static void AddWaterSource(DbSet<SourceBuilding2> source, DbSet<WaterSource> target)
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

            Console.WriteLine($"Processed {totalProcessed} {typeof(TTarget).Name} records so far...");
        }

        Console.WriteLine($"All {totalProcessed} {typeof(TTarget).Name} added successfully.");
    }

    private static void SaveTypes(){
        using var sourceContext = new SourceDbContext();
        using var targetContext = new TargetDbContext();

        AddWaterSource(sourceContext.SourceBuildings, targetContext.WaterSources);
        AddFunctionalUse(sourceContext.SourceBuildings, targetContext.FunctionalUses);
        AddStructureType(sourceContext.SourceBuildings, targetContext.StructureTypes);
        AddContainmentTypes(sourceContext.SourceBuildings, targetContext.ContainmentTypes);

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
        AddRows<SourceBuilding2, Building>(EntityMapper.MapBuilding, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceBuilding2, Owner>(EntityMapper.MapOwner, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceContainment2, Containment>(EntityMapper.MapContainment, (source, skip, batchSize) => [.. source.Include(x => x.SourceBuilding).Skip(skip).Take(batchSize)]);
        AddRows<SourceLic, Lic>(EntityMapper.MapLic, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceTreatmentPlant, TreatmentPlant>(EntityMapper.MapTreatmentPlant, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourceCommunityToilet, Toilet>(EntityMapper.MapToilet, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
        AddRows<SourcePublicToilet, Toilet>(EntityMapper.MapToilet, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
    }
}
