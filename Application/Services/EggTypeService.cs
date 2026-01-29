//using Application.DTOs;
//using AutoMapper;
//using Domain.Models;
//using Infrastructure.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Services
//{
//    public class EggTypeService
//    {
//        private readonly EggTypeRepository _repo;
//        private readonly IMapper _mapper;
        
//        public EggTypeService(EggTypeRepository repo, IMapper mapper)
//        {
//            _repo = repo;
//            _mapper = mapper;
//        }
//        public async Task<List<EggTypeResposne>> GetAllEgg()
//        {
//            var entityL = await _repo.GetAllAsync();
//            var responseL = _mapper.Map<List<EggTypeResposne>>(entityL);
//            return responseL;
//        }
//        public async Task<EggType> CreateEgg(EggTypeCreateRequest request)
//        {
//            var entity = _mapper.Map<EggType>(request);
//            return await _repo.CreateAsync(entity);
//        }

//        //public async Task<EggType> CreateEgg(EggType request)
//        //{
//        //    //var entity = _mapper.Map<EggType>(request);
//        //    return await _repo.CreateAsync(request);
//        //}
//        public async Task<EggType> UpdateEgg(EggType request)
//        {
//            return await _repo.UpdateAsync(request);
//        }
//        public async Task<bool> DeleteEgg(EggType request)
//        {
//            return await _repo.RemoveAsync(request);
//        }
//    }
//}
