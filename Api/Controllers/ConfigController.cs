using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly ConfigService _service;

        public ConfigController(ConfigService service)
        {
            _service = service;
        }

        // GET: api/Config
        [HttpGet]
        public async Task<ActionResult<List<config>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Config/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<config>> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/Config
        [HttpPost]
        public async Task<ActionResult<config>> Create([FromBody] config request)
        {
            if (request == null)
                return BadRequest();

            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        // PUT: api/Config
        [HttpPut]
        public async Task<ActionResult<config>> Update([FromBody] config request)
        {
            if (request == null)
                return BadRequest();

            var result = await _service.UpdateAsync(request);
            return Ok(result);
        }

        // DELETE: api/Config
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] config request)
        {
            if (request == null)
                return BadRequest();

            var success = await _service.RemoveAsync(request);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
