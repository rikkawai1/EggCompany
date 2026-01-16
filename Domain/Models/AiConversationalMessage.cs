using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AiConversationalMessage
{
    public int MessageId { get; set; }

    public int? SessionId { get; set; }

    public string? MessageText { get; set; }

    public DateTime? Timestamp { get; set; }

    public virtual AiConversationalSession? Session { get; set; }
}
