using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AnomalyRule
{
    public int RuleId { get; set; }

    public string? RuleName { get; set; }

    public int? AnomalyTypeId { get; set; }

    public decimal? Threshold { get; set; }

    public virtual AnomalyType? AnomalyType { get; set; }
}
