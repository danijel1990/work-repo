using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Domain;

namespace CostTracker.Application.Mappings
{
    public class MaterialModels : Profile
    {
        public MaterialModels()
        {
            CreateMap<Material, MaterialModel>();
        }
    }
}
