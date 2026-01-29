using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

public partial class maintenance_log
{
    [Key]
    public Guid id { get; set; }

    public Guid ticket_id { get; set; }

    public string? description { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? created_at { get; set; }

    [ForeignKey("ticket_id")]
    [InverseProperty("maintenance_logs")]
    public virtual maintenance_ticket ticket { get; set; } = null!;
}
