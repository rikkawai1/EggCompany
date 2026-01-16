using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class EggSession
{
    public int SessionId { get; set; }

    public int? EggTypeId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual EggType? EggType { get; set; }
}
