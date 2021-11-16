using CostTracker.Domain.Models;

namespace CostTracker.Application.IRepositories
{
    public interface ISupplierRepository
    {
        void Add(Supplier supplier);
    }
}
