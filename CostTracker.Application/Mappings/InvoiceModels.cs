using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Domain;

namespace CostTracker.Application.Mappings
{
    public class InvoiceModels : Profile
    {
        public InvoiceModels()
        {
            CreateMap<Invoice, InvoiceModel>();
        }
    }
}
