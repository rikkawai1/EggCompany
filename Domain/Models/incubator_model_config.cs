using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("model_id", "config_id", Name = "incubator_model_configs_model_id_config_id_key", IsUnique = true)]
public partial class incubator_model_config
{
    [Key]
    public Guid id { get; set; }

    public Guid model_id { get; set; }

    public Guid config_id { get; set; }

    public int? quantity { get; set; }

    public bool? required { get; set; }

    [ForeignKey("config_id")]
    [InverseProperty("incubator_model_configs")]
    public virtual config config { get; set; } = null!;

    [ForeignKey("model_id")]
    [InverseProperty("incubator_model_configs")]
    public virtual incubator_model model { get; set; } = null!;
}
