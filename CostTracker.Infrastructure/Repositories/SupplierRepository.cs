using CostTracker.Application.Context;
using CostTracker.Application.IRepositories;
using CostTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public ICostTrackerDbContext CostTrackerDbContext => _context as ICostTrackerDbContext;

        public SupplierRepository(DbContext context)
            : base(context)
        {
        }

        public Supplier Get<T>(T key)
        {
            return Get(key, CostTrackerDbContext.Supplier);
        }
    }
}
