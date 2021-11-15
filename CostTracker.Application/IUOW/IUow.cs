using CostTracker.Application.IRepositories;
using System;

namespace CostTracker.Application.IUOW
{
    public interface IUow : IDisposable
    {
        IInvoiceRepository Invoice { get; set; }
        IMaterialRepository Material { get; set; }
        ISupplierRepository Supplier { get; set; }

        void Complete();
	}
}
