using CostTracker.Application.Context;
using CostTracker.Application.IRepositories;
using CostTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Infrastructure.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public ICostTrackerDbContext CostTrackerDbContext => _context as ICostTrackerDbContext;

        public InvoiceRepository(DbContext context)
            : base(context)
        {
        }

        public Invoice Get<T>(T key)
        {
            return Get(key, CostTrackerDbContext.Invoice);
        }
    }
}
