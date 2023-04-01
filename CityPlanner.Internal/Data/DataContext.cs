namespace CityPlanner.Internal.Data
{
    public class DataContext : DbContext
    {
        public DbSet<InterestPoint> InterestPoints { get; set; } = null!;
        public DbSet<Building> Addresses { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Building>()
                .HasMany(x => x.NearInterestPoints)
                .WithMany(x => x.NearBuildings);
        }
    }
}
