using CostTracker.Domain.Models;
using System.Collections.Generic;

namespace CostTracker.Application.IRepositories
{
    public interface IInvoiceRepository: IRepository<Invoice>
    {
        IEnumerable<Invoice> GetAllWithDetails();
        Invoice GetWithDetails(int id);
    }
}
