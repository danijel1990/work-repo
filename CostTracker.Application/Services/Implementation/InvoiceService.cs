using AutoMapper;
using CostTracker.Application.IUOW;
using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain.Models;
using System.Collections.Generic;

namespace CostTracker.Application.Services.Implementation
{
    public class InvoiceService : IInvoiceService
    {
        public readonly IUow _uow;
        private readonly IMapper _mapper;

        public InvoiceService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public IEnumerable<InvoiceQueryModel> GetAllInvoiceData()
        {
            var invoices = _uow.Invoice.GetAllWithDetails();

            return _mapper.Map<IEnumerable<InvoiceQueryModel>>(invoices);
        }

        public int InsertInvoiceData(InvoiceModel invoiceModel)
        {
            var newInvoice = _mapper.Map<Invoice>(invoiceModel);

            _uow.Invoice.Add(newInvoice);
            _uow.Complete();

            return newInvoice.Id;
        }

        public void UpdateInvoiceData(int id, InvoiceModel invoiceModel)
        {
            var invoice = _uow.Invoice.GetWithDetails(id);
            invoice.Description = invoiceModel.Description;
            invoice.InvoiceDate = invoiceModel.InvoiceDate;
            invoice.SupplierId = invoiceModel.SupplierId;

            invoice.InvoiceMaterials.Clear();
            invoice.InvoiceMaterials = _mapper.Map<ICollection<InvoiceMaterial>>(invoiceModel.Materials);

            _uow.Complete();
        }
    }
}
