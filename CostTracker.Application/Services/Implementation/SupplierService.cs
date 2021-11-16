﻿using AutoMapper;
using CostTracker.Application.IUOW;
using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain;
using CostTracker.Domain.Models;
using System;
using System.Collections.Generic;

namespace CostTracker.Application.Services.Implementation
{
    public class SupplierService : ISupplierService
    {
        public readonly IUow _uow;
        private readonly IMapper _mapper;

        public SupplierService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public int InsertSupplier(SupplierModel supplierModel)
        {
            var newSupplier = _mapper.Map<Supplier>(supplierModel);
            _uow.Supplier.Add(newSupplier);
            _uow.Complete();

            return newSupplier.Id;
        }

        public int UpdateSupplier(SupplierModel supplierModel)
        {
            var newSupplier = _mapper.Map<Supplier>(supplierModel);
            _uow.Supplier.Update(newSupplier);
            _uow.Complete();

            return newSupplier.Id;
        }

        public Supplier GetSupplierData(SupplierModel supplierModel)
        {
            var suppliers = _uow.Supplier.GetAll();

            return (Supplier)_mapper.Map<IList<SupplierModel>>(suppliers);
        }
    }
}
