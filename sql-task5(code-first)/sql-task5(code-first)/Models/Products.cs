namespace sql_task5_code_first_.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }

        public Categories Category { get; set; } = null!;
        public Suppliers Supplier { get; set; } = null!;

        public List<PurchaseOrderItems> PurchaseOrderItems { get; set; } = new();
    }
}