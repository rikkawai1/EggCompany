using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("code", Name = "operation_modes_code_key", IsUnique = true)]
public partial class operation_mode
{
    [Key]
    public Guid id { get; set; }

    [StringLength(30)]
    public string code { get; set; } = null!;

    public string? description { get; set; }

    [InverseProperty("mode")]
    public virtual ICollection<operation_history> operation_histories { get; set; } = new List<operation_history>();
}
