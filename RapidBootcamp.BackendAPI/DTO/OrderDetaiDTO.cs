namespace RapidBootcamp.BackendAPI.DTO
{
    public class OrderDetaiDTO
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}
