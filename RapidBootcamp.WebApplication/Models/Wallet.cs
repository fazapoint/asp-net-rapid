namespace RapidBootcamp.WebApplication.Models
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public string WalletName { get; set; }
        public decimal? Saldo { get; set; }
        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }
        public IEnumerable<OrderHeader> OrderHeaders { get; set; }
        //public IEnumerable<Payment> Payments { get; set; }
    }

}
