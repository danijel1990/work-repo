using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CostTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }
  
        [HttpGet("invoice")]
        public ActionResult<Invoice> GetAllInvoiceData(InvoiceModel invoice)
        {
            var data = _invoiceService.GetAllInvoiceData(invoice);
            return data;
        }

        [HttpPost]
        public ActionResult Insert([FromBody] InvoiceModel model)
        {
            var result = _invoiceService.InsertInvoiceData(_mapper.Map<InvoiceModel>(model));

            return CreatedAtAction(nameof(Insert), result);
        }
    }
}