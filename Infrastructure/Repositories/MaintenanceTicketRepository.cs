using Domain.Models;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MaintenanceTicketRepository : BaseRepo<maintenance_ticket>
    {
        private readonly IncubatorDbContext _context;

        public MaintenanceTicketRepository(IncubatorDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<maintenance_ticket>> GetAllWithDetailsAsync()
        {
            return await _context.maintenance_tickets
                .Include(t => t.incubator)
                .Include(t => t.technician)
                .Include(t => t.maintenance_logs)
                .ToListAsync();
        }

        public async Task<maintenance_ticket?> GetByIdWithDetailsAsync(Guid id)
        {
            return await _context.maintenance_tickets
                .Include(t => t.incubator)
                .Include(t => t.technician)
                .Include(t => t.maintenance_logs)
                .FirstOrDefaultAsync(t => t.id == id);
        }
    }
}
