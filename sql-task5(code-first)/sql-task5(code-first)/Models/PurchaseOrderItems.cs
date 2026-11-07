namespace sql_task5_code_first_.Models
{
    public class PurchaseOrderItems
    {
        public int ID { get; set; }
        public int PurchaseOrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public PurchaseOrders PurchaseOrder { get; set; } = null!;
        public Products Product { get; set; } = null!;
    }
}