namespace RapidBootcamp.BackendAPI.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Stock { get; set; }
        public decimal Price { get; set; }

        public CategoryDTO? Category { get; set; }
    }
}
