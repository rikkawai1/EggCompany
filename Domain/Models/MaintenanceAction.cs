using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class MaintenanceAction
{
    public int ActionId { get; set; }

    public int? TicketId { get; set; }

    public string? ActionDesc { get; set; }

    public DateTime? PerformedAt { get; set; }

    public virtual MaintenanceTicket? Ticket { get; set; }
}
