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
    public class IncubatorModelService : BaseService<incubator_model>
    {
        private readonly IncubatorModelRepository _repo;
        private readonly IMapper _mapper;

        public IncubatorModelService(IncubatorModelRepository repo, IMapper mapper) : base(repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<IncubatorModelResponse>> GetAllModelsAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<List<IncubatorModelResponse>>(entities);
        }

        public async Task<IncubatorModelResponse> CreateModelAsync(IncubatorModelRequest request)
        {
            var entity = _mapper.Map<incubator_model>(request);
            var created = await _repo.CreateAsync(entity);
            return _mapper.Map<IncubatorModelResponse>(created);
        }
    }
}
