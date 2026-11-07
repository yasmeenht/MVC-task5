namespace sql_task5_code_first_.Models
{
    public class PurchaseOrders
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = "";
        public int SupplierID { get; set; }

        public Suppliers supplier { get; set; } = null!;

        public List<PurchaseOrderItems> PurchaseOrderItems { get; set; } = new();
    }
}