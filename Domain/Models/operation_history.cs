using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

[Table("operation_history")]
public partial class operation_history
{
    [Key]
    public Guid id { get; set; }

    public Guid incubator_id { get; set; }

    public Guid mode_id { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime start_time { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? end_time { get; set; }

    [ForeignKey("incubator_id")]
    [InverseProperty("operation_histories")]
    public virtual incubator incubator { get; set; } = null!;

    [ForeignKey("mode_id")]
    [InverseProperty("operation_histories")]
    public virtual operation_mode mode { get; set; } = null!;
}
