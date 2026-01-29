using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

public partial class maintenance_ticket
{
    [Key]
    public Guid id { get; set; }

    public Guid incubator_id { get; set; }

    public Guid? technician_id { get; set; }

    [StringLength(30)]
    public string? status { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? created_at { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? closed_at { get; set; }

    [ForeignKey("incubator_id")]
    [InverseProperty("maintenance_tickets")]
    public virtual incubator incubator { get; set; } = null!;

    [InverseProperty("ticket")]
    public virtual ICollection<maintenance_log> maintenance_logs { get; set; } = new List<maintenance_log>();

    [ForeignKey("technician_id")]
    [InverseProperty("maintenance_tickets")]
    public virtual user? technician { get; set; }
}
