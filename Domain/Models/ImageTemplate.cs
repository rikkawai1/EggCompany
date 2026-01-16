using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ImageTemplate
{
    public int TemplateId { get; set; }

    public string? TemplateName { get; set; }

    public byte[]? TemplateData { get; set; }

    public decimal? MatchingThreshold { get; set; }

    public virtual ICollection<ImageMatch> ImageMatches { get; set; } = new List<ImageMatch>();
}
