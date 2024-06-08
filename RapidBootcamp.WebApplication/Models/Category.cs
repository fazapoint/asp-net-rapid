namespace RapidBootcamp.WebApplication.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // navigation property (one to many / one category, many products) ** Check Models.Product
        public IEnumerable<Product>? Products { get; set; }
    }
}
