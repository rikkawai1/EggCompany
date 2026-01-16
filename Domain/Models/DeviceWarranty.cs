using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class DeviceWarranty
{
    public int Id { get; set; }

    public int? DeviceId { get; set; }

    public string? WarrantyStatus { get; set; }

    public virtual Device? Device { get; set; }
}
