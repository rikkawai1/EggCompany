using Domain.Models;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class IncubatorModelRepository : BaseRepo<incubator_model>
    {
        private readonly IncubatorDbContext _context;

        public IncubatorModelRepository(IncubatorDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<incubator_model>> GetAllAsync()
        {
            return await _context.incubator_models.ToListAsync();
        }
    }
}
