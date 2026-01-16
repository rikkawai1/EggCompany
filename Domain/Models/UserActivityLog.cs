using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class UserActivityLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public string? ActivityType { get; set; }

    public DateTime? Timestamp { get; set; }

    public virtual User? User { get; set; }
}
