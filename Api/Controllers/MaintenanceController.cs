using Application.Services;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceController : ControllerBase
    {
        private readonly MaintenanceTicketRepository _repo;

        public MaintenanceController(MaintenanceTicketRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<maintenance_ticket>>> GetAll()
        {
            var result = await _repo.GetAllWithDetailsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<maintenance_ticket>> GetById(Guid id)
        {
            var result = await _repo.GetByIdWithDetailsAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<maintenance_ticket>> Create(maintenance_ticket entity)
        {
            var result = await _repo.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.id }, result);
        }
    }
}
