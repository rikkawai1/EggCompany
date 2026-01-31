using Domain.Models;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SalesOrderRepository : BaseRepo<sales_order>
    {
        private readonly IncubatorDbContext _context;

        public SalesOrderRepository(IncubatorDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<sales_order>> GetAllWithDetailsAsync()
        {
            return await _context.sales_orders
                .Include(o => o.customer)
                .Include(o => o.sales_order_items)
                    .ThenInclude(oi => oi.incubator)
                .ToListAsync();
        }

        public async Task<sales_order?> GetByIdWithDetailsAsync(Guid id)
        {
            return await _context.sales_orders
                .Include(o => o.customer)
                .Include(o => o.sales_order_items)
                    .ThenInclude(oi => oi.incubator)
                .FirstOrDefaultAsync(o => o.id == id);
        }
    }
}
