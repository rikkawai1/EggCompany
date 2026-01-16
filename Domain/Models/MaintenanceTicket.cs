using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class MaintenanceTicket
{
    public int TicketId { get; set; }

    public int? DeviceId { get; set; }

    public DateTime? OpenedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public string? Description { get; set; }

    public virtual Device? Device { get; set; }

    public virtual ICollection<MaintenanceAction> MaintenanceActions { get; set; } = new List<MaintenanceAction>();
}
