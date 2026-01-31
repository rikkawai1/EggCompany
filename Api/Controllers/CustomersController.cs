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
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomersController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetAll()
        {
            var result = await _service.GetAllCustomersAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> Create(CustomerRequest request)
        {
            var result = await _service.CreateCustomerAsync(request);
            return Ok(result);
        }
    }
}
