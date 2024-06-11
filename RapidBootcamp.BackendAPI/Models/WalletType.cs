namespace RapidBootcamp.BackendAPI.Models
{
    public class WalletType
    {
        public int WalletTypeId { get; set; }
        public string WalletName { get; set; }

        public IEnumerable<Wallet> Wallets { get; set; }
    }
}
