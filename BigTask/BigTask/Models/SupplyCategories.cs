namespace BigTask.Models
{
    public class SupplyCategories
    {

        public SupplyCategories(string category, string supplier, string offer)
        {
            Category = category;
            Supplier = supplier;
            Offer = offer;
        }

        public string Category { get; set; }
        public string Supplier {  get; set; }
        public string Offer {  get; set; }
    }
}
