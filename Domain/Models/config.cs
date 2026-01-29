using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("code", Name = "configs_code_key", IsUnique = true)]
public partial class config
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string code { get; set; } = null!;

    [StringLength(100)]
    public string name { get; set; } = null!;

    [StringLength(30)]
    public string? type { get; set; }

    [StringLength(20)]
    public string? unit { get; set; }

    public string? description { get; set; }

    [InverseProperty("config")]
    public virtual ICollection<alert> alerts { get; set; } = new List<alert>();

    [InverseProperty("config")]
    public virtual ICollection<anomaly_rule> anomaly_rules { get; set; } = new List<anomaly_rule>();

    [InverseProperty("config")]
    public virtual ICollection<control_device> control_devices { get; set; } = new List<control_device>();

    [InverseProperty("config")]
    public virtual ICollection<incubator_config_instance> incubator_config_instances { get; set; } = new List<incubator_config_instance>();

    [InverseProperty("config")]
    public virtual ICollection<incubator_model_config> incubator_model_configs { get; set; } = new List<incubator_model_config>();
}
