using Domain.Models;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ConfigRepository : BaseRepo<config>
    {
        private readonly IncubatorDbContext _context;

        public ConfigRepository(IncubatorDbContext context) : base(context)
        { }
        public async Task<List<config>> GetAll()
        {
            return await _context.configs.ToListAsync();
        }
    }
}
