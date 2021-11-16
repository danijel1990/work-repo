using CostTracker.Application.Context;
using CostTracker.Application.IRepositories;
using CostTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CostTracker.Infrastructure.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public ICostTrackerDbContext CostTrackerDbContext => _context as ICostTrackerDbContext;

        public InvoiceRepository(DbContext context)
            : base(context)
        {
        }

        public void Add(Invoice invoice)
        {
            _context.Set<Invoice>().Add(invoice);
        }

        public void Update(Invoice invoice)
        {
            _context.Set<Invoice>().Update(invoice);
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _context.Set<Invoice>().ToList();
        }
    }
}
