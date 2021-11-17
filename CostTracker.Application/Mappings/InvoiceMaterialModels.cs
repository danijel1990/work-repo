using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Domain.Models;

namespace CostTracker.Application.Mappings
{
    public class InvoiceMaterialModels : Profile
    {
        public InvoiceMaterialModels()
        {
            CreateMap<InvoiceMaterial, InvoiceMaterialQueryModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MaterialId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Material.Name));
            CreateMap<InvoiceMaterialModel, InvoiceMaterial>()
                .ForMember(dest => dest.MaterialId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
