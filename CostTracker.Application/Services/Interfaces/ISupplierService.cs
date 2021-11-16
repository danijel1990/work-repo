using CostTracker.Application.Models;
using CostTracker.Domain.Models;

namespace CostTracker.Application.Services.Interfaces
{
    public interface ISupplierService
    {
        int InsertSupplier(SupplierModel supplierModel);
    }
}
