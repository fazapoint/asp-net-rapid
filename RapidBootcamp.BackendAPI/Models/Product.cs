namespace RapidBootcamp.BackendAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int? Stock { get; set; }
        public decimal Price { get; set; }


        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        // navigation property (one to many / one category, many products) **Check Models.Category
        public Category? Category { get; set; }
    }
}
