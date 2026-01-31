using Domain.Models;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class IncubatorRepository : BaseRepo<incubator>
    {
        private readonly IncubatorDbContext _context;

        public IncubatorRepository(IncubatorDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<incubator>> GetAllWithDetailsAsync()
        {
            return await _context.incubators
                .Include(i => i.model)
                .Include(i => i.customer)
                .ToListAsync();
        }

        public async Task<incubator?> GetByIdWithDetailsAsync(Guid id)
        {
            return await _context.incubators
                .Include(i => i.model)
                .Include(i => i.customer)
                .Include(i => i.warranty)
                .FirstOrDefaultAsync(i => i.id == id);
        }
    }
}
