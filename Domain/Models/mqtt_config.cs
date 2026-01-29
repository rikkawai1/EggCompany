using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

public partial class mqtt_config
{
    [Key]
    [Column(TypeName = "character varying")]
    public string id { get; set; } = null!;

    public int port { get; set; }

    [StringLength(255)]
    public string? broker_address { get; set; }

    public int qos { get; set; }

    public int keep_alive { get; set; }

    public bool clean_session { get; set; }

    [StringLength(50)]
    public string? user_name { get; set; }

    [StringLength(255)]
    public string? password { get; set; }

    [StringLength(2000)]
    public string? will_message { get; set; }

    public bool use_tls { get; set; }
}
