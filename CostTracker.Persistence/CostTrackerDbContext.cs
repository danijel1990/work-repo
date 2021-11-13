using CostTracker.Application.Context;
using CostTracker.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CostTracker.Persistence
{
    public class CostTrackerDbContext : DbContext, IConfigurationDbContext
    {
        public DbSet<InvoiceMaterial> InvoiceMaterial { get; set; }

        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<Material> Material { get; set; }

        public DbSet<Supplier> Supplier { get; set; }

        public CostTrackerDbContext() { }

        public CostTrackerDbContext(DbContextOptions<CostTrackerDbContext> contextOptions) : base(contextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
