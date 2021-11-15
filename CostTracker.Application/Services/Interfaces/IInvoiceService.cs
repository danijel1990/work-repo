using CostTracker.Application.Models;
using CostTracker.Domain;
using CostTracker.Domain.Models;

namespace CostTracker.Application.Services.Interfaces
{
    public interface IInvoiceService
    {
        Invoice GetAllInvoiceData(InvoiceModel invoiceModel);
    }
}
