using System;
using System.Collections.Generic;

namespace sql_task5.Models;

public partial class PurchaseOrder
{
    public int Id { get; set; }

    public DateOnly OrderDate { get; set; }

    public bool OrderStatus { get; set; }

    public int SupplierId { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual Supplier Supplier { get; set; } = null!;
}
