using CostTracker.Domain;
using CostTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Application.Context
{
    public interface ICostTrackerDbContext
    {
        DbSet<InvoiceMaterial> InvoiceMaterial { get; set; }

        DbSet<Invoice> Invoice { get; set; }

        DbSet<Material> Material { get; set; }

        DbSet<Supplier> Supplier { get; set; }
    }
}
