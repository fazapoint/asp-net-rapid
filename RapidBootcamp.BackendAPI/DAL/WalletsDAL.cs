using RapidBootcamp.BackendAPI.Models;
using System.Data.SqlClient;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class WalletsDAL : IWallet
    {
        private readonly IConfiguration _config;
        private string? _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public WalletsDAL(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }

        public Wallet Add(Wallet entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Wallet> GetAll()
        {
            throw new NotImplementedException();
        }

        public Wallet GetById(int id)
        {
            throw new NotImplementedException();
        }

        public decimal GetWalletSaldo(int walletId)
        {
            try
            {
                var query = @"select Saldo from Wallets 
                              where WalletId=@WalletId";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@WalletId", walletId);
                _connection.Open();
                decimal saldo = Convert.ToDecimal(_command.ExecuteScalar());
                return saldo;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }

        public Wallet Update(Wallet entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateWalletSaldo(int walletId, decimal amount)
        {
            try
            {
                var query = @"update Wallets set Saldo=@Saldo where WalletId=@WalletId";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@WalletId", walletId);
                _command.Parameters.AddWithValue("@Saldo", amount);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }
    }
}
