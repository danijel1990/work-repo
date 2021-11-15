using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Domain;

namespace CostTracker.Application.Mappings
{
    public class InvoiceMaterialModels : Profile
    {
        public InvoiceMaterialModels()
        {
            CreateMap<InvoiceMaterial, InvoiceMaterialModel>();
        }
    }
}
