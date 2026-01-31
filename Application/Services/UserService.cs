using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : BaseService<user>
    {
        private readonly UserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(UserRepository repo, IMapper mapper) : base(repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<UserResponse>> GetAllWithRolesAsync()
        {
            var entities = await _repo.GetAllWithRolesAsync();
            return _mapper.Map<List<UserResponse>>(entities);
        }

        public async Task<UserResponse?> GetByIdAsync(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<UserResponse>(entity);
        }

        public async Task<UserResponse> CreateUserAsync(UserCreateRequest request)
        {
            var entity = _mapper.Map<user>(request);
            // Trong thực tế sẽ hash password ở đây
            entity.password_hash = request.password; 
            entity.status = "ACTIVE";

            // Map Roles
            if (request.role_ids != null && request.role_ids.Any())
            {
                var roleIdsShort = request.role_ids.Select(id => (short)id).ToList();
                var roles = await _repo.GetRolesByIdsAsync(roleIdsShort);
                entity.roles = roles;
            }
            
            var created = await _repo.CreateAsync(entity);
            return _mapper.Map<UserResponse>(created);
        }

        public async Task<UserResponse?> LoginAsync(LoginRequest request)
        {
            // Check by username first
            var user = await _repo.GetByUsernameAsync(request.username);
            
            // If not found, check by email
            if (user == null)
            {
                user = await _repo.GetByEmailAsync(request.username);
            }

            if (user == null) return null;

            // Simple password check (In production, use hashing!)
            if (user.password_hash != request.password) return null;

            return _mapper.Map<UserResponse>(user);
        }
    }
}
