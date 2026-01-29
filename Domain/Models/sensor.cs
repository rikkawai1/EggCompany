using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

public partial class sensor
{
    [Key]
    public Guid id { get; set; }

    public Guid masterboard_id { get; set; }

    public Guid config_instance_id { get; set; }

    [StringLength(50)]
    public string? hardware_code { get; set; }

    public int? pin_number { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? created_at { get; set; }

    [ForeignKey("config_instance_id")]
    [InverseProperty("sensors")]
    public virtual incubator_config_instance config_instance { get; set; } = null!;

    [ForeignKey("masterboard_id")]
    [InverseProperty("sensors")]
    public virtual masterboard masterboard { get; set; } = null!;

    [InverseProperty("sensor")]
    public virtual ICollection<sensor_reading> sensor_readings { get; set; } = new List<sensor_reading>();
}
