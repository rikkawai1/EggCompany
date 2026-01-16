using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AnomalyEvent
{
    public int EventId { get; set; }

    public int? AnomalyTypeId { get; set; }

    public DateTime? OccurredAt { get; set; }

    public virtual AnomalyType? AnomalyType { get; set; }
}
