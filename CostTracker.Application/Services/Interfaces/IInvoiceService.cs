using CostTracker.Application.Models;
using System.Collections.Generic;

namespace CostTracker.Application.Services.Interfaces
{
    public interface IInvoiceService
    {
        int InsertInvoiceData(InvoiceModel invoiceModel);
        void UpdateInvoiceData(int id, InvoiceModel invoiceModel);
        IEnumerable<InvoiceQueryModel> GetAllInvoiceData();
    }
}
