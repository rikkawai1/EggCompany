using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("code", Name = "roles_code_key", IsUnique = true)]
public partial class role
{
    [Key]
    public short id { get; set; }

    [StringLength(30)]
    public string code { get; set; } = null!;

    [StringLength(50)]
    public string name { get; set; } = null!;

    [ForeignKey("role_id")]
    [InverseProperty("roles")]
    public virtual ICollection<user> users { get; set; } = new List<user>();
}
