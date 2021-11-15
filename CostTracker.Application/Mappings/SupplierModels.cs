using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Domain.Models;

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
