using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

public partial class alert
{
    [Key]
    public Guid id { get; set; }

    public Guid incubator_id { get; set; }

    public Guid? model_id { get; set; }

    public Guid? config_id { get; set; }

    [StringLength(20)]
    public string? severity { get; set; }

    public string message { get; set; } = null!;

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? created_at { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? resolved_at { get; set; }

    [ForeignKey("config_id")]
    [InverseProperty("alerts")]
    public virtual config? config { get; set; }

    [ForeignKey("incubator_id")]
    [InverseProperty("alerts")]
    public virtual incubator incubator { get; set; } = null!;

    [ForeignKey("model_id")]
    [InverseProperty("alerts")]
    public virtual ml_model? model { get; set; }
}
