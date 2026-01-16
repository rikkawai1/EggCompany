using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AnomalyType
{
    public int AnomalyTypeId { get; set; }

    public string? TypeName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<AnomalyEvent> AnomalyEvents { get; set; } = new List<AnomalyEvent>();

    public virtual ICollection<AnomalyRule> AnomalyRules { get; set; } = new List<AnomalyRule>();
}
