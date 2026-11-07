namespace sql_task5_code_first_.Models
{
    public class Suppliers
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";

        public List<Products> Products { get; set; } = new();

        public List<PurchaseOrders> PurchaseOrders { get; set; } = new();
    }
}