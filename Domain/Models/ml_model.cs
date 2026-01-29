using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

public partial class ml_model
{
    [Key]
    public Guid id { get; set; }

    [StringLength(100)]
    public string name { get; set; } = null!;

    [StringLength(20)]
    public string? version { get; set; }

    [Column(TypeName = "jsonb")]
    public string? config { get; set; }

    public bool? active { get; set; }

    [InverseProperty("model")]
    public virtual ICollection<alert> alerts { get; set; } = new List<alert>();
}
