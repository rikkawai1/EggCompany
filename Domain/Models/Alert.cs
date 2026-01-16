using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Alert
{
    public int AlertId { get; set; }

    public string? AlertType { get; set; }

    public string? AlertMessage { get; set; }
}
