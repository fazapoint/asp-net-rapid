namespace RapidBootcamp.BackendAPI.DTO
{
    public class UpdateProductDTO
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int? Stock { get; set; }
        public decimal Price { get; set; }
    }
}
