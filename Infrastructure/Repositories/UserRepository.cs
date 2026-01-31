using Domain.Models;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepo<user>
    {
        private readonly IncubatorDbContext _context;

        public UserRepository(IncubatorDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<user?> GetByEmailAsync(string email)
        {
            return await _context.users
                .Include(u => u.roles)
                .FirstOrDefaultAsync(u => u.email == email);
        }

        public async Task<user?> GetByUsernameAsync(string username)
        {
            return await _context.users
                .Include(u => u.roles)
                .FirstOrDefaultAsync(u => u.username == username);
        }

        public async Task<List<user>> GetAllWithRolesAsync()
        {
            return await _context.users
                .Include(u => u.roles)
                .ToListAsync();
        }

        public async Task<List<role>> GetRolesByIdsAsync(List<short> roleIds)
        {
            return await _context.roles
                .AsTracking()
                .Where(r => roleIds.Contains(r.id))
                .ToListAsync();
        }
    }
}
