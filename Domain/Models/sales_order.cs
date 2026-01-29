using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models;

//[Index("order_code", Name = "sales_orders_order_code_key", IsUnique = true)]
public partial class sales_order
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string order_code { get; set; } = null!;

    public Guid customer_id { get; set; }

    public DateOnly order_date { get; set; }

    [StringLength(30)]
    public string? status { get; set; }

    [ForeignKey("customer_id")]
    [InverseProperty("sales_orders")]
    public virtual customer customer { get; set; } = null!;

    [InverseProperty("order")]
    public virtual ICollection<sales_order_item> sales_order_items { get; set; } = new List<sales_order_item>();
}
