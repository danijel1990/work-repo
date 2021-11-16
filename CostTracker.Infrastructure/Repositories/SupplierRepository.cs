using CostTracker.Application.Context;
using CostTracker.Application.IRepositories;
using CostTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CostTracker.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public ICostTrackerDbContext CostTrackerDbContext => _context as ICostTrackerDbContext;

        public SupplierRepository(DbContext context)
            : base(context)
        {
        }

        public void Add(Supplier supplier)
        {
            _context.Set<Supplier>().Add(supplier);
        }

        public void Update(Supplier invoice)
        {
            _context.Set<Supplier>().Update(invoice);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Set<Supplier>().ToList();
        }

    }
}
