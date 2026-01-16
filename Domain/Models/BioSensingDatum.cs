using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class BioSensingDatum
{
    public int DataId { get; set; }

    public int? DeviceId { get; set; }

    public DateTime? CapturedAt { get; set; }

    public decimal? Value { get; set; }

    public virtual Device? Device { get; set; }
}
