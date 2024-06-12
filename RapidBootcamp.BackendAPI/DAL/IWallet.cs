using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public interface IWallet : ICrud<Wallet>
    {
        decimal GetWalletSaldo(int walletId);
        void UpdateWalletSaldo(int walletId, decimal amount);
    }
}
