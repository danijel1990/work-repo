﻿using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Domain.Models;

namespace CostTracker.Application.Mappings
{
    public class MaterialModels : Profile
    {
        public MaterialModels()
        {
            CreateMap<Material, MaterialModel>();
            CreateMap<MaterialModel, Material>();
        }
    }
}
