using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CostTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet()]
        public ActionResult<Supplier> Get()
        {
            var data = _supplierService.GetSupplierData();
            return Ok(data);
        }

        [HttpPost()]
        public ActionResult Insert([FromBody] SupplierModel model)
        {
            var result = _supplierService.InsertSupplier(model);

            return Ok(result);
        }        
        
        [HttpPost("{id}")]
        public ActionResult Update([FromBody] SupplierModel model, int id)
        {
            var result = _supplierService.UpdateSupplier(id, model);

            return Ok(result);
        }
    }
}