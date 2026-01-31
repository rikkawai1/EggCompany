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
    public class IncubatorService : BaseService<incubator>
    {
        private readonly IncubatorRepository _repo;
        private readonly IMapper _mapper;

        public IncubatorService(IncubatorRepository repo, IMapper mapper) : base(repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<IncubatorResponse>> GetAllWithDetailsAsync()
        {
            var entities = await _repo.GetAllWithDetailsAsync();
            return _mapper.Map<List<IncubatorResponse>>(entities);
        }

        public async Task<IncubatorResponse?> GetByIdWithDetailsAsync(Guid id)
        {
            var entity = await _repo.GetByIdWithDetailsAsync(id);
            return _mapper.Map<IncubatorResponse>(entity);
        }

        public async Task<IncubatorResponse> CreateIncubatorAsync(IncubatorRequest request)
        {
            var entity = _mapper.Map<incubator>(request);
            var created = await _repo.CreateAsync(entity);
            return _mapper.Map<IncubatorResponse>(created);
        }
    }
}
