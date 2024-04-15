using Elections.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }

        public DbSet<ElectoralJourney> ElectoralJourneys { get; set; }

        public DbSet<ElectoralPosition> ElectoralPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ElectoralJourney>().HasIndex(x => x.Date).IsUnique();
            modelBuilder.Entity<ElectoralPosition>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
