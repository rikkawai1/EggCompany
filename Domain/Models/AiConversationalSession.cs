using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AiConversationalSession
{
    public int SessionId { get; set; }

    public int? UserId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual ICollection<AiConversationalMessage> AiConversationalMessages { get; set; } = new List<AiConversationalMessage>();

    public virtual User? User { get; set; }
}
