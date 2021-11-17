using AutoMapper;
using CostTracker.Application.IUOW;
using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain.Models;
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

        public IEnumerable<SupplierModel> GetSupplierData()
        {
            var suppliers = _uow.Supplier.GetAll();

            return _mapper.Map<IEnumerable<SupplierModel>>(suppliers);
        }

        public int InsertSupplier(SupplierModel supplierModel)
        {
            var newSupplier = _mapper.Map<Supplier>(supplierModel);
            _uow.Supplier.Add(newSupplier);
            _uow.Complete();

            return newSupplier.Id;
        }

        public void UpdateSupplier(int id, SupplierModel supplierModel)
        {
            var supplier = _uow.Supplier.Get(id);
            supplier.Name = supplierModel.Name;
            supplier.PhoneNumber = supplierModel.PhoneNumber;
            supplier.Address = supplierModel.Address;

            _uow.Complete();
        }
    }
}
