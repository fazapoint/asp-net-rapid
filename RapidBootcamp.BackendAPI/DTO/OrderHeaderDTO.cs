using RapidBootcamp.BackendAPI.DAL;

namespace RapidBootcamp.BackendAPI.DTO { 

    public class OrderHeaderDTO
    {
        public string OrderHeaderId { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
        public int WalletId { get; set; }
        public decimal Saldo {  get; set; }
        public string WalletName { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public List<OrderDetaiDTO>? OrderDetails { get; set; }
    }
}
