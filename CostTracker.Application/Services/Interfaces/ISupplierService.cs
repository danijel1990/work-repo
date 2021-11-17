using CostTracker.Application.Models;
using System.Collections.Generic;

namespace CostTracker.Application.Services.Interfaces
{
    public interface ISupplierService
    {
        int InsertSupplier(SupplierModel supplierModel);
        void UpdateSupplier(int id, SupplierModel supplierModel);
        IEnumerable<SupplierModel> GetSupplierData();
    }
}
