using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

public partial class control_board_type
{
    [Key]
    [Column(TypeName = "character varying")]
    public string id { get; set; } = null!;

    [StringLength(255)]
    public string name { get; set; } = null!;

    [StringLength(2000)]
    public string? description { get; set; }

    [InverseProperty("control_board_types")]
    public virtual ICollection<control_device> control_devices { get; set; } = new List<control_device>();
}
