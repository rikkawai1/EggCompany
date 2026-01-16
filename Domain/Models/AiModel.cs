using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AiModel
{
    public int ModelId { get; set; }

    public string? ModelName { get; set; }

    public string? Version { get; set; }

    public string? DataInputType { get; set; }
}
