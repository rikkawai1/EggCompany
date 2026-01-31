using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : BaseService<customer>
    {
        private readonly CustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomerService(CustomerRepository repo, IMapper mapper) : base(repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CustomerResponse>> GetAllCustomersAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<List<CustomerResponse>>(entities);
        }

        public async Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request)
        {
            var entity = _mapper.Map<customer>(request);
            var created = await _repo.CreateAsync(entity);
            return _mapper.Map<CustomerResponse>(created);
        }
    }
}
