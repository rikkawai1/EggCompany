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
    public class WarrantyService : BaseService<warranty>
    {
        private readonly WarrantyRepository _repo;
        private readonly IMapper _mapper;

        public WarrantyService(WarrantyRepository repo, IMapper mapper) : base(repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<WarrantyResponse>> GetAllWarrantiesAsync()
        {
            var entities = await _repo.GetAllWithDetailsAsync();
            return _mapper.Map<List<WarrantyResponse>>(entities);
        }

        public async Task<WarrantyResponse?> GetByIncubatorIdAsync(Guid incubatorId)
        {
            var entity = await _repo.GetByIncubatorIdAsync(incubatorId);
            return _mapper.Map<WarrantyResponse>(entity);
        }

        public async Task<WarrantyResponse> CreateWarrantyAsync(WarrantyRequest request)
        {
            var entity = _mapper.Map<warranty>(request);
            var created = await _repo.CreateAsync(entity);
            return _mapper.Map<WarrantyResponse>(created);
        }
    }
}
