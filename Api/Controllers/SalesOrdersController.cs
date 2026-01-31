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
    public class SalesOrdersController : ControllerBase
    {
        private readonly SalesOrderService _service;

        public SalesOrdersController(SalesOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrderResponse>>> GetAll()
        {
            var result = await _service.GetAllWithDetailsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesOrderResponse>> GetById(Guid id)
        {
            var result = await _service.GetByIdWithDetailsAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SalesOrderResponse>> Create(SalesOrderRequest request)
        {
            var result = await _service.CreateOrderAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.id }, result);
        }
    }
}
