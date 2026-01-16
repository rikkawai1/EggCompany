using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class EggType
{
    public int EggTypeId { get; set; }

    public string? EggName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<EggSession> EggSessions { get; set; } = new List<EggSession>();
}
