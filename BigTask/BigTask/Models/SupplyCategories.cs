namespace BigTask.Models
{
    public class SupplyCategories
    {

        public SupplyCategories(string category, string supplier, string offer, double unitPrices, int quantity)
        {
            Category = category;
            Supplier = supplier;
            Offer = offer;
            UnitPrices = unitPrices;
            Quantity = quantity;
        }

        public string Category { get; set; }
        public string Supplier {  get; set; }
        public string Offer {  get; set; }

        public double UnitPrices { get; set; }
        public int Quantity { get; set; }

    }
}
