using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Domain.Models;

namespace CostTracker.Application.Mappings
{
    public class InvoiceModels : Profile
    {
        public InvoiceModels()
        {
            CreateMap<Invoice, InvoiceQueryModel>();
            CreateMap<InvoiceModel, Invoice>();
        }
    }
}
