using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("incubator_id", "config_id", "instance_index", Name = "incubator_config_instances_incubator_id_config_id_instance__key", IsUnique = true)]
public partial class incubator_config_instance
{
    [Key]
    public Guid id { get; set; }

    public Guid incubator_id { get; set; }

    public Guid config_id { get; set; }

    public int instance_index { get; set; }

    public decimal? target_value { get; set; }

    public decimal? min_value { get; set; }

    public decimal? max_value { get; set; }

    [StringLength(20)]
    public string? unit { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? updated_at { get; set; }

    [ForeignKey("config_id")]
    [InverseProperty("incubator_config_instances")]
    public virtual config config { get; set; } = null!;

    [ForeignKey("incubator_id")]
    [InverseProperty("incubator_config_instances")]
    public virtual incubator incubator { get; set; } = null!;

    [InverseProperty("config_instance")]
    public virtual ICollection<sensor> sensors { get; set; } = new List<sensor>();
}
