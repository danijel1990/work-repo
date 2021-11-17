using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CostTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet()]
        public ActionResult<Material> Get()
        {
            var data = _materialService.GetMaterialData();
            return Ok(data);
        }

        [HttpPost()]
        public ActionResult Insert([FromBody] MaterialModel model)
        {
            var result = _materialService.InsertMaterial(model);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] MaterialModel model, int id)
        {
            _materialService.UpdateMaterial(id, model);

            return Ok();
        }
    }
}