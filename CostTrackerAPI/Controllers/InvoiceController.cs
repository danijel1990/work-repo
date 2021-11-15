using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain;
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

        [HttpGet("invoice")]
        public ActionResult<Invoice> GetAllInvoiceData(InvoiceModel invoice)
        {
            var data = _invoiceService.GetAllInvoiceData(invoice);
            return data;
        }
    }
}