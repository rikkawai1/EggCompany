using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class IncubatorDevice
{
    public int DeviceId { get; set; }

    public int? ModelId { get; set; }

    public virtual ICollection<IncubationBatch> IncubationBatches { get; set; } = new List<IncubationBatch>();

    public virtual IncubatorModel? Model { get; set; }
}
