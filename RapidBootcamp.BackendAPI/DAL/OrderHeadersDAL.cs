using RapidBootcamp.BackendAPI.Models;
using System.Data.SqlClient;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class OrderHeadersDAL : IOrderHeader
    {
        private readonly IConfiguration _config;
        private string? _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public OrderHeadersDAL(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }

        public OrderHeader Add(OrderHeader entity)
        {
            throw new NotImplementedException();
        }

        //public OrderHeader Add(OrderHeader entity)
        //{
        //try
        //{
        //    string query = @"INSERT INTO OrderHeaders(OrderHeaderId) 
        //                     VALUES(@CategoryName);select @@identity";
        //    _command = new SqlCommand(query, _connection);
        //    _command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
        //    _connection.Open();

        //    //menjalankan perintah insert
        //    int lastCategoryId = Convert.ToInt32(_command.ExecuteScalar());
        //    entity.CategoryId = lastCategoryId;

        //    return entity;
        //}
        //catch (SqlException sqlEx)
        //{
        //    throw new ArgumentException(sqlEx.Message);
        //}
        //finally
        //{
        //    _command.Dispose();
        //    _connection.Close();
        //}
        //}

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetAll()
        {
            try
            {
                //poco object untuk menampung data dari database
                List<OrderHeader> orderHeaders= new List<OrderHeader>();

                string query = @"SELECT * FROM OrderHeaders
                                 order by OrderHeaderId desc";
                _command = new SqlCommand(query, _connection);

                //buka koneksi
                _connection.Open();

                //baca data
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        orderHeaders.Add(new OrderHeader
                        {
                            OrderHeaderId = _reader["OrderHeaderId"].ToString(),
                            CustomerId = Convert.ToInt32(_reader["CategoryName"].ToString()),
                            TransactionDate = Convert.ToDateTime(_reader["OrderDate"]),
                            WalletId = Convert.ToInt32(_reader["WalletId"])
                        });
                    }
                }
                _reader.Close();

                return orderHeaders;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException($"Kesalahan: {sqlEx.Message}");
            }
            finally
            {
                _connection.Close();
                _command.Dispose();
            }
        }

        public OrderHeader GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OrderHeader Update(OrderHeader entity)
        {
            throw new NotImplementedException();
        }
    }
}
