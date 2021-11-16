using AutoMapper;
using CostTracker.Application.IUOW;
using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain;
using CostTracker.Domain.Models;
using System;

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

        public Material InsertMaterial(MaterialModel materialModel)
        {
            var newMaterial = _mapper.Map<Material>(materialModel);
            _uow.Material.Add(newMaterial);
            _uow.Complete();

            return newMaterial;
        }
    }
}
