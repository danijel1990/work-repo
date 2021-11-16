﻿using AutoMapper;
using CostTracker.Application.IUOW;
using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain.Models;
using System;
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

        public Invoice GetAllInvoiceData(InvoiceModel invoiceModel)
        {
            var invoices = _uow.Invoice.GetAll();

            return (Invoice)_mapper.Map<IList<InvoiceQueryModel>>(invoices);
        }
    }
}
