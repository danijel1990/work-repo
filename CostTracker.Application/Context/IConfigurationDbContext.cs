using CostTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Application.Context
{
    public interface IConfigurationDbContext
    {
        DbSet<InvoiceMaterial> InvoiceMaterial { get; set; }

        DbSet<Invoice> Invoice { get; set; }

        DbSet<Material> Material { get; set; }

        DbSet<Supplier> Supplier { get; set; }
    }
}
