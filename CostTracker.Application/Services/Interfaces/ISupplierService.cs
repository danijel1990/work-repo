using CostTracker.Application.Models;
using CostTracker.Domain.Models;

namespace CostTracker.Application.Services.Interfaces
{
    public interface ISupplierService
    {
        Supplier InsertSupplier(SupplierModel supplierModel);
    }
}
