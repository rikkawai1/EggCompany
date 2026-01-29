using Domain.Models;
using Infrastructure;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ConfigService : BaseService<config>
    {
        private readonly ConfigRepository _repo;

        public ConfigService(ConfigRepository repo)
            : base(repo)
        {
            _repo = repo;
        }
    }
}
