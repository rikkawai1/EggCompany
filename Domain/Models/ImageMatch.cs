using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ImageMatch
{
    public int MatchId { get; set; }

    public int? ImageId { get; set; }

    public int? TemplateId { get; set; }

    public decimal? MatchScore { get; set; }

    public virtual ImageTemplate? Template { get; set; }
}
