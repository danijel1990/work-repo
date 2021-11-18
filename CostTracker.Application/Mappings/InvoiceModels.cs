using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Domain.Models;
using System.Linq;

namespace CostTracker.Application.Mappings
{
    public class InvoiceModels : Profile
    {
        public InvoiceModels()
        {
            CreateMap<Invoice, InvoiceQueryModel>()
                .ForMember(dest => dest.Materials, opt => opt.MapFrom(src => src.InvoiceMaterials))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.InvoiceMaterials.Sum(im => im.Material.Price * im.Quantity)));
            CreateMap<InvoiceModel, Invoice>()
                .ForMember(dest => dest.InvoiceMaterials, opt => opt.MapFrom(src => src.Materials));
        }
    }
}
