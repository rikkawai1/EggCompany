using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Device
{
    public int DeviceId { get; set; }

    public string? SerialNumber { get; set; }

    public virtual ICollection<BioSensingDatum> BioSensingData { get; set; } = new List<BioSensingDatum>();

    public virtual ICollection<DeviceOwnership> DeviceOwnerships { get; set; } = new List<DeviceOwnership>();

    public virtual ICollection<DeviceWarranty> DeviceWarranties { get; set; } = new List<DeviceWarranty>();

    public virtual ICollection<MaintenanceTicket> MaintenanceTickets { get; set; } = new List<MaintenanceTicket>();
}
