using AutoMapper;
using CostTracker.Application.IUOW;
using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain;
using CostTracker.Domain.Models;
using System;
using System.Collections.Generic;

namespace CostTracker.Application.Services.Implementation
{
    public class MaterialService : IMaterialService
    {
        public readonly IUow _uow;
        private readonly IMapper _mapper;

        public MaterialService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public int InsertMaterial(MaterialModel materialModel)
        {
            var newMaterial = _mapper.Map<Material>(materialModel);
            _uow.Material.Add(newMaterial);
            _uow.Complete();

            return newMaterial.Id;
        }

        public int UpdateMaterial(MaterialModel materialModel)
        {
            var newMaterial = _mapper.Map<Material>(materialModel);
            _uow.Material.Update(newMaterial);
            _uow.Complete();

            return newMaterial.Id;
        }

        public Material GetMaterialData(MaterialModel materialModel)
        {
            var materials = _uow.Material.GetAll();

            return (Material)_mapper.Map<IList<InvoiceMaterialQueryModel>>(materials);
        }
    }
}
