using AutoMapper;
using CostTracker.Application.IUOW;
using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain.Models;
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
        public IEnumerable<MaterialModel> GetMaterialData()
        {
            var materials = _uow.Material.GetAll();

            return _mapper.Map<IEnumerable<MaterialModel>>(materials);
        }

        public int InsertMaterial(MaterialModel materialModel)
        {
            var newMaterial = _mapper.Map<Material>(materialModel);
            _uow.Material.Add(newMaterial);
            _uow.Complete();

            return newMaterial.Id;
        }

        public void UpdateMaterial(int id, MaterialModel materialModel)
        {
            var material = _uow.Material.Get(id);
            material.Name = materialModel.Name;
            material.Price = materialModel.Price;

            _uow.Complete();
        }
    }
}
