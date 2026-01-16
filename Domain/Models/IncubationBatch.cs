using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class IncubationBatch
{
    public int BatchId { get; set; }

    public int? IncubatorDeviceId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual IncubatorDevice? IncubatorDevice { get; set; }
}
