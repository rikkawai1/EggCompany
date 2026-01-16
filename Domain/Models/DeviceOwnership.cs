using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class DeviceOwnership
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? DeviceId { get; set; }

    public string? OwnershipType { get; set; }

    public virtual Device? Device { get; set; }

    public virtual User? User { get; set; }
}
