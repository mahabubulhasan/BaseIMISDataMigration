using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShapeFileData.SourceEntities;

namespace ShapeFileData;

public class SourceDbContext : DbContext
{
    public DbSet<SourceBuilding> SourceBuildings { get; set; }
    public DbSet<SourceContainment> SourceContainments { get; set; }
    public DbSet<SourceRoad> SourceRoads { get; set; }
    public DbSet<SourceDrain> SourceDrains { get; set; }
    public DbSet<SourceLic> SourceLics { get; set; }
    public DbSet<SourceCommunityToilet> SourceCommunityToilets { get; set; }
    public DbSet<SourcePublicToilet> SourcePublicToilets { get; set; }
    public DbSet<SourceTreatmentPlant> SourceTreatmentPlants { get; set; }
    public DbSet<SourceWard> SourceWards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("SourceConnection");
        optionsBuilder.UseNpgsql(connectionString, options => options.UseNetTopologySuite());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SourceContainment>()
            .HasOne(c => c.SourceBuilding)
            .WithMany(b => b.Containment)
            .HasForeignKey(c => c.Bin)
            .HasPrincipalKey(b => b.Bin);
    }
}
