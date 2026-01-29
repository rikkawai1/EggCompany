using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class control_device
{
    [Key]
    public Guid id { get; set; }

    public Guid masterboard_id { get; set; }

    [Column(TypeName = "character varying")]
    public string control_board_types_id { get; set; } = null!;

    public Guid config_id { get; set; }

    [StringLength(50)]
    public string? hardware_code { get; set; }

    public int? pin_number { get; set; }

    [StringLength(20)]
    public string? state { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? updated_at { get; set; }

    [ForeignKey("config_id")]
    [InverseProperty("control_devices")]
    public virtual config config { get; set; } = null!;

    [ForeignKey("control_board_types_id")]
    [InverseProperty("control_devices")]
    public virtual control_board_type control_board_types { get; set; } = null!;

    [ForeignKey("masterboard_id")]
    [InverseProperty("control_devices")]
    public virtual masterboard masterboard { get; set; } = null!;
}
