using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

public partial class audit_log
{
    [Key]
    public Guid id { get; set; }

    public Guid? user_id { get; set; }

    [StringLength(100)]
    public string action { get; set; } = null!;

    [StringLength(50)]
    public string? entity { get; set; }

    public Guid? entity_id { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? created_at { get; set; }

    [ForeignKey("user_id")]
    [InverseProperty("audit_logs")]
    public virtual user? user { get; set; }
}
