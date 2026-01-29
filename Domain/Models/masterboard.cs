using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("incubator_id", Name = "masterboards_incubator_id_key", IsUnique = true)]
//[Index("serial_number", Name = "masterboards_serial_number_key", IsUnique = true)]
public partial class masterboard
{
    [Key]
    public Guid id { get; set; }

    public Guid incubator_id { get; set; }

    [StringLength(100)]
    public string? serial_number { get; set; }

    [StringLength(50)]
    public string? firmware_version { get; set; }

    [StringLength(50)]
    public string? mac_address { get; set; }

    [StringLength(50)]
    public string? ip_address { get; set; }

    [StringLength(30)]
    public string? status { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? last_seen_at { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? created_at { get; set; }

    [InverseProperty("masterboard")]
    public virtual ICollection<control_device> control_devices { get; set; } = new List<control_device>();

    [ForeignKey("incubator_id")]
    [InverseProperty("masterboard")]
    public virtual incubator incubator { get; set; } = null!;

    [InverseProperty("masterboard")]
    public virtual ICollection<sensor> sensors { get; set; } = new List<sensor>();
}
