using CostTracker.Domain.Models;
using System.Collections.Generic;

namespace CostTracker.Application.IRepositories
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetAll();
    }
}
