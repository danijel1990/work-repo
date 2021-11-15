using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Domain;

namespace CostTracker.Application.Mappings
{
    public class SupplierModels : Profile
    {
        public SupplierModels()
        {
            CreateMap<Supplier, SupplierModel>();
        }
    }
}
