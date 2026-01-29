using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("email", Name = "users_email_key", IsUnique = true)]
//[Index("username", Name = "users_username_key", IsUnique = true)]
public partial class user
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string username { get; set; } = null!;

    [StringLength(255)]
    public string password_hash { get; set; } = null!;

    [StringLength(100)]
    public string? full_name { get; set; }

    [StringLength(100)]
    public string? email { get; set; }

    [StringLength(20)]
    public string? phone { get; set; }

    [StringLength(20)]
    public string? status { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? created_at { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? updated_at { get; set; }

    [InverseProperty("user")]
    public virtual ICollection<audit_log> audit_logs { get; set; } = new List<audit_log>();

    [InverseProperty("technician")]
    public virtual ICollection<maintenance_ticket> maintenance_tickets { get; set; } = new List<maintenance_ticket>();

    [ForeignKey("user_id")]
    [InverseProperty("users")]
    public virtual ICollection<role> roles { get; set; } = new List<role>();
}
