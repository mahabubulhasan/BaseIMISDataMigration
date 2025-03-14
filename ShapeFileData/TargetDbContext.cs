using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShapeFileData.TargetEntities;

namespace ShapeFileData
{
    class TargetDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Containment> Containments { get; set; }
        public DbSet<ContainmentType> ContainmentTypes { get; set; }
        public DbSet<StructureType> StructureTypes { get; set; }
        public DbSet<FunctionalUse> FunctionalUses { get; set; }
        public DbSet<WaterSource> WaterSources { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Drain> Drains { get; set; }
        public DbSet<Lic> Lics { get; set; }
        public DbSet<Road> Roads { get; set; }
        public DbSet<Toilet> Toilets { get; set; }
        public DbSet<TreatmentPlant> TreatmentPlants { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<WardBoundary> WardBoundaries { get; set; }
        public DbSet<SanitationSystem> SanitationSystems { get; set; }
        public DbSet<BuildToilet> BuildToilets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("TargetConnection");
            optionsBuilder.UseNpgsql(connectionString, options => options.UseNetTopologySuite());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BuildToilet>()
                .HasOne(b => b.Building)
                .WithOne(b => b.BuildToilet)
                .HasForeignKey<BuildToilet>(b => b.Bin)
                .HasPrincipalKey<Building>(b => b.Bin);
        }
    }
}
