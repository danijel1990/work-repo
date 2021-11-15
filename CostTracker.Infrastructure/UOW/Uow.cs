using CostTracker.Application.IRepositories;
using CostTracker.Application.IUOW;
using CostTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CostTracker.Application.UOW
{
    public class Uow : IUow
    {
        private readonly DbContext _context;

        public IInvoiceRepository Invoice { get; set; }
        public IMaterialRepository Material { get; set; }
        public ISupplierRepository Supplier { get; set; }

        public Uow(DbContext context)
        {
            _context = context;

            Invoice = new InvoiceRepository(_context);
            Material = new MaterialRepository(_context);
            Supplier = new SupplierRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
