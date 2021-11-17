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

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
  
        [HttpGet()]
        public ActionResult<Invoice> Get()
        {
            var data = _invoiceService.GetAllInvoiceData();
            return Ok(data);
        }

        [HttpPost()]
        public ActionResult Insert([FromBody] InvoiceModel model)
        {
            var result = _invoiceService.InsertInvoiceData(model);

            return Ok(result);
        }

        [HttpPost("{id}")]
        public ActionResult Update([FromBody] InvoiceModel model, int id)
        {
            var result = _invoiceService.UpdateInvoiceData(id, model);

            return Ok(result);
        }
    }
}