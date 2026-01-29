using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

public partial class customer
{
    [Key]
    public Guid id { get; set; }

    [StringLength(100)]
    public string name { get; set; } = null!;

    [StringLength(100)]
    public string? email { get; set; }

    [StringLength(20)]
    public string? phone { get; set; }

    public string? address { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? created_at { get; set; }

    [InverseProperty("customer")]
    public virtual ICollection<incubator> incubators { get; set; } = new List<incubator>();

    [InverseProperty("customer")]
    public virtual ICollection<sales_order> sales_orders { get; set; } = new List<sales_order>();
}
