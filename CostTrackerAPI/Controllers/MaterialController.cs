using AutoMapper;
using CostTracker.Application.Models;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CostTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        private readonly IMapper _mapper;

        public MaterialController(IMaterialService materialService, IMapper mapper)
        {
            _materialService = materialService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Create([FromBody] MaterialModel model)
        {
            var result = _materialService.Insert(_mapper.Map<MaterialModel>(model));

            return CreatedAtAction(nameof(Create), result);
        }
    }
}