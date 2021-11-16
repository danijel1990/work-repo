using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain;
using CostTracker.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CostTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        private readonly IMapper _mapper;

        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet("supplier")]
        public ActionResult<Supplier> Get(SupplierModel supplier)
        {
            var data = _supplierService.GetSupplierData(supplier);
            return data;
        }

        [HttpPost("{id}")]
        public ActionResult Insert([FromBody] SupplierModel model)
        {
            var result = _supplierService.InsertSupplier(_mapper.Map<SupplierModel>(model));

            return Ok(result);
        }        
        
        [HttpPost("{id}")]
        public ActionResult Update([FromBody] SupplierModel model)
        {
            var result = _supplierService.UpdateSupplier(_mapper.Map<SupplierModel>(model));

            return Ok(result);
        }
    }
}