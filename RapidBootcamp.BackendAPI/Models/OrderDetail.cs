namespace RapidBootcamp.BackendAPI.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public OrderHeader OrderHeader { get; set; }
        public Product Product { get; set; }
    }
}
