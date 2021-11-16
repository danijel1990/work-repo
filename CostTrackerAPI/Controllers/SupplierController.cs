using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain;
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

        [HttpPost]
        public ActionResult Insert([FromBody] SupplierModel model)
        {
            var result = _supplierService.InsertSupplier(_mapper.Map<SupplierModel>(model));

            return Ok(result);
        }
    }
}