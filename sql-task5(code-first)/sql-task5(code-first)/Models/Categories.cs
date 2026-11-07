namespace sql_task5_code_first_.Models
{
    public class Categories
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public List<Products> Products { get; set; } = new();
    }
}