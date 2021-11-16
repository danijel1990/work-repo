using CostTracker.Application.Models;
using CostTracker.Domain;
using CostTracker.Domain.Models;

namespace CostTracker.Application.Services.Interfaces
{
    public interface IInvoiceService
    {
        int InsertInvoiceData(InvoiceModel invoiceModel);
        int UpdateInvoiceData(InvoiceModel invoiceModel);
        Invoice GetAllInvoiceData(InvoiceModel invoiceModel);
    }
}
