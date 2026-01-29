using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("model_code", Name = "incubator_models_model_code_key", IsUnique = true)]
public partial class incubator_model
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string model_code { get; set; } = null!;

    [StringLength(100)]
    public string name { get; set; } = null!;

    public string? description { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? created_at { get; set; }

    [InverseProperty("model")]
    public virtual ICollection<anomaly_rule> anomaly_rules { get; set; } = new List<anomaly_rule>();

    [InverseProperty("model")]
    public virtual ICollection<incubator_model_config> incubator_model_configs { get; set; } = new List<incubator_model_config>();

    [InverseProperty("model")]
    public virtual ICollection<incubator> incubators { get; set; } = new List<incubator>();
}
