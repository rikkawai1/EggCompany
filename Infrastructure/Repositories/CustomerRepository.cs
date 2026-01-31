using Domain.Models;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepo<customer>
    {
        private readonly IncubatorDbContext _context;

        public CustomerRepository(IncubatorDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
