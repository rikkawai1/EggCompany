using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncubatorModelsController : ControllerBase
    {
        private readonly IncubatorModelService _service;

        public IncubatorModelsController(IncubatorModelService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncubatorModelResponse>>> GetAll()
        {
            var result = await _service.GetAllModelsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IncubatorModelResponse>> Create(IncubatorModelRequest request)
        {
            var result = await _service.CreateModelAsync(request);
            return Ok(result);
        }
    }
}
