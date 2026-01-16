using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EggTypeService
    {
        private readonly EggTypeRepository _repo;
        
        public EggTypeService(EggTypeRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<EggType>> GetAllEgg()
        {
            return await _repo.GetAllAsync();
        }
        public async Task<EggType> CreateEgg(EggType request)
        {
            return await _repo.CreateAsync(request);
        }
        public async Task<EggType> UpdateEgg(EggType request)
        {
            return await _repo.UpdateAsync(request);
        }
        public async Task<bool> DeleteEgg(EggType request)
        {
            return await _repo.RemoveAsync(request);
        }
    }
}
