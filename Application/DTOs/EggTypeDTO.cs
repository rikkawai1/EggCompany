using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EggTypeDTO
    {
        public int EggTypeId { get; set; }

        public string? EggName { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<EggSession> EggSessions { get; set; } = new List<EggSession>();
    }
    public class EggTypeCreateRequest
    {
        public string? EggName { get; set; }
        public string? Description { get; set; }
    }
    public class EggTypeResposne
    {
        public string? EggName { get; set; }
        public string? Description { get; set; }
    }
}
