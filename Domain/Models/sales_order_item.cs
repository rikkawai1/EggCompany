using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("order_id", "incubator_id", Name = "sales_order_items_order_id_incubator_id_key", IsUnique = true)]
public partial class sales_order_item
{
    [Key]
    public Guid id { get; set; }

    public Guid order_id { get; set; }

    public Guid incubator_id { get; set; }

    [ForeignKey("incubator_id")]
    [InverseProperty("sales_order_items")]
    public virtual incubator incubator { get; set; } = null!;

    [ForeignKey("order_id")]
    [InverseProperty("sales_order_items")]
    public virtual sales_order order { get; set; } = null!;
}
