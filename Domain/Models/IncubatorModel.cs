using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class IncubatorModel
{
    public int ModelId { get; set; }

    public string? Manufacturer { get; set; }

    public string? ModelNumber { get; set; }

    public int? Capacity { get; set; }

    public virtual ICollection<IncubatorDevice> IncubatorDevices { get; set; } = new List<IncubatorDevice>();
}
