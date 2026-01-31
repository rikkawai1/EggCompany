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
    public class SalesOrderService : BaseService<sales_order>
    {
        private readonly SalesOrderRepository _repo;
        private readonly IMapper _mapper;

        public SalesOrderService(SalesOrderRepository repo, IMapper mapper) : base(repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<SalesOrderResponse>> GetAllWithDetailsAsync()
        {
            var entities = await _repo.GetAllWithDetailsAsync();
            return _mapper.Map<List<SalesOrderResponse>>(entities);
        }

        public async Task<SalesOrderResponse?> GetByIdWithDetailsAsync(Guid id)
        {
            var entity = await _repo.GetByIdWithDetailsAsync(id);
            return _mapper.Map<SalesOrderResponse>(entity);
        }

        public async Task<SalesOrderResponse> CreateOrderAsync(SalesOrderRequest request)
        {
            var entity = _mapper.Map<sales_order>(request);
            var created = await _repo.CreateAsync(entity);
            return _mapper.Map<SalesOrderResponse>(created);
        }
    }
}
