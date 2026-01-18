using Application.DTOs;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EggTypeController : ControllerBase
    {
        private readonly EggTypeService _service;

        public EggTypeController(EggTypeService service)
        {
            _service = service;
        }

        // GET: api/EggType
        [HttpGet]
        public async Task<ActionResult<List<EggType>>> GetAll()
        {
            var result = await _service.GetAllEgg();
            return Ok(result);
        }

        // POST: api/EggType
        [HttpPost]
        public async Task<ActionResult<EggType>> Create([FromBody] EggTypeCreateRequest request)
        {
            if (request == null)
                return BadRequest();

            var result = await _service.CreateEgg(request);
            return Ok(result);
        }

        // PUT: api/EggType
        [HttpPut]
        public async Task<ActionResult<EggType>> Update([FromBody] EggType request)
        {
            if (request == null)
                return BadRequest();

            var result = await _service.UpdateEgg(request);
            return Ok(result);
        }

        // DELETE: api/EggType
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] EggType request)
        {
            if (request == null)
                return BadRequest();

            var success = await _service.DeleteEgg(request);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
