using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("sensor_id", "recorded_at", Name = "idx_sensor_readings_sensor_time", IsDescending = new[] { false, true })]
public partial class sensor_reading
{
    [Key]
    public Guid id { get; set; }

    public Guid sensor_id { get; set; }

    public decimal value { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? recorded_at { get; set; }

    [ForeignKey("sensor_id")]
    [InverseProperty("sensor_readings")]
    public virtual sensor sensor { get; set; } = null!;
}
