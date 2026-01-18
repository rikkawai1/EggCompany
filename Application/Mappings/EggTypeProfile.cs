using Application.DTOs;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class EggTypeProfile : Profile
    {
        public EggTypeProfile()
        {
            CreateMap<EggTypeCreateRequest, EggType>();
            CreateMap<EggType, EggTypeResposne>();
        }
    }
}
