using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("qr_code", Name = "incubators_qr_code_key", IsUnique = true)]
//[Index("serial_number", Name = "incubators_serial_number_key", IsUnique = true)]
public partial class incubator
{
    [Key]
    public Guid id { get; set; }

    [StringLength(100)]
    public string serial_number { get; set; } = null!;

    [StringLength(255)]
    public string? qr_code { get; set; }

    public Guid model_id { get; set; }

    public Guid? customer_id { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? activated_at { get; set; }

    [StringLength(30)]
    public string? status { get; set; }

    [InverseProperty("incubator")]
    public virtual ICollection<alert> alerts { get; set; } = new List<alert>();

    [ForeignKey("customer_id")]
    [InverseProperty("incubators")]
    public virtual customer? customer { get; set; }

    [InverseProperty("incubator")]
    public virtual ICollection<incubator_camera> incubator_cameras { get; set; } = new List<incubator_camera>();

    [InverseProperty("incubator")]
    public virtual ICollection<incubator_config_instance> incubator_config_instances { get; set; } = new List<incubator_config_instance>();

    [InverseProperty("incubator")]
    public virtual ICollection<maintenance_ticket> maintenance_tickets { get; set; } = new List<maintenance_ticket>();

    [InverseProperty("incubator")]
    public virtual masterboard? masterboard { get; set; }

    [ForeignKey("model_id")]
    [InverseProperty("incubators")]
    public virtual incubator_model model { get; set; } = null!;

    [InverseProperty("incubator")]
    public virtual ICollection<operation_history> operation_histories { get; set; } = new List<operation_history>();

    [InverseProperty("incubator")]
    public virtual ICollection<sales_order_item> sales_order_items { get; set; } = new List<sales_order_item>();

    [InverseProperty("incubator")]
    public virtual warranty? warranty { get; set; }
}
