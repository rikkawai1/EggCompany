using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("model_id", "config_id", Name = "anomaly_rules_model_id_config_id_key", IsUnique = true)]
public partial class anomaly_rule
{
    [Key]
    public Guid id { get; set; }

    public Guid model_id { get; set; }

    public Guid config_id { get; set; }

    public decimal? min_value { get; set; }

    public decimal? max_value { get; set; }

    [ForeignKey("config_id")]
    [InverseProperty("anomaly_rules")]
    public virtual config config { get; set; } = null!;

    [ForeignKey("model_id")]
    [InverseProperty("anomaly_rules")]
    public virtual incubator_model model { get; set; } = null!;
}
