using Comeback.Api.Models;
using Comeback.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Comeback.Api.Data
{
    public class ComebackDbContext : DbContext, IComebackDbContext
    {
        public DbSet<DailyMeasurement> DailyMeasurements { get; private set; }
        public DbSet<Goal> Goals { get; private set; }
        public ComebackDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComebackDbContext).Assembly);
        }

    }
}
