using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncubatorsController : ControllerBase
    {
        private readonly IncubatorService _service;

        public IncubatorsController(IncubatorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncubatorResponse>>> GetAll()
        {
            var result = await _service.GetAllWithDetailsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncubatorResponse>> GetById(Guid id)
        {
            var result = await _service.GetByIdWithDetailsAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IncubatorResponse>> Create(IncubatorRequest request)
        {
            var result = await _service.CreateIncubatorAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.id }, result);
        }
    }
}
