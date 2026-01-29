using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("incubator_id", Name = "warranties_incubator_id_key", IsUnique = true)]
public partial class warranty
{
    [Key]
    public Guid id { get; set; }

    public Guid incubator_id { get; set; }

    public DateOnly start_date { get; set; }

    public DateOnly end_date { get; set; }

    [StringLength(20)]
    public string? status { get; set; }

    [ForeignKey("incubator_id")]
    [InverseProperty("warranty")]
    public virtual incubator incubator { get; set; } = null!;
}
