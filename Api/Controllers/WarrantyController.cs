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
    public class WarrantiesController : ControllerBase
    {
        private readonly WarrantyService _service;

        public WarrantiesController(WarrantyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarrantyResponse>>> GetAll()
        {
            var result = await _service.GetAllWarrantiesAsync();
            return Ok(result);
        }

        [HttpGet("incubator/{incubatorId}")]
        public async Task<ActionResult<WarrantyResponse>> GetByIncubatorId(Guid incubatorId)
        {
            var result = await _service.GetByIncubatorIdAsync(incubatorId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<WarrantyResponse>> Create(WarrantyRequest request)
        {
            var result = await _service.CreateWarrantyAsync(request);
            return Ok(result);
        }
    }
}
