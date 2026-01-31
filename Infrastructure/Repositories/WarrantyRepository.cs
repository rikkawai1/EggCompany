using Domain.Models;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class WarrantyRepository : BaseRepo<warranty>
    {
        private readonly IncubatorDbContext _context;

        public WarrantyRepository(IncubatorDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<warranty>> GetAllWithDetailsAsync()
        {
            return await _context.warranties
                .Include(w => w.incubator)
                .ThenInclude(i => i.customer)
                .ToListAsync();
        }

        public async Task<warranty?> GetByIncubatorIdAsync(Guid incubatorId)
        {
            return await _context.warranties
                .Include(w => w.incubator)
                .ThenInclude(i => i.customer)
                .FirstOrDefaultAsync(w => w.incubator_id == incubatorId);
        }
    }
}
