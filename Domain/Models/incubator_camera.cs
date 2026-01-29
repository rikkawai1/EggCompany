using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

public partial class incubator_camera
{
    [Key]
    public Guid id { get; set; }

    public Guid incubator_id { get; set; }

    [StringLength(255)]
    public string? stream_url { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? created_at { get; set; }

    [ForeignKey("incubator_id")]
    [InverseProperty("incubator_cameras")]
    public virtual incubator incubator { get; set; } = null!;
}
