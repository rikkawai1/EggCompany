using Domain.Models;
using Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EggTypeRepository : BaseRepo<EggType>
    {
        public EggTypeRepository(EggDbContext context) : base(context) { }
    }
}
