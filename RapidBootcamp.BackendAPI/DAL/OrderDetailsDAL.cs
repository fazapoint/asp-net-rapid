using RapidBootcamp.BackendAPI.Models;
using System.Data.SqlClient;
using System.Transactions;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class OrderDetailsDAL : IOrderDetail
    {
        private readonly IConfiguration _config;
        private readonly IProduct _product;
        private string? _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public OrderDetailsDAL(IConfiguration config, IProduct product)
        {
            _config = config;
            _product = product;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }

        public OrderDetail Add(OrderDetail entity)
        {
            try
            {
                // cek stok apakah masih ada
                int stock = _product.GetProductStock(entity.ProductId);
                if (stock < entity.Qty)
                {
                    throw new ArgumentException("Stock is not enough");
                }

                string query = @"insert into OrderDetails(OrderHeaderId, ProductId, Qty, Price)
                            values(@OrderHeaderId, @ProductId, @Qty, @Price); select @@identity";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@OrderHeaderId", entity.OrderHeaderId);
                _command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                _command.Parameters.AddWithValue("@Qty", entity.Qty);
                _command.Parameters.AddWithValue("@Price", entity.Price);
                _connection.Open();
                int id = Convert.ToInt32(_command.ExecuteScalar());
                entity.OrderDetailId = id;

                // update stock di product
                string queryUpdate = @"update Products set Stock=Stock-@Qty where ProductId=@ProductId";
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, _connection);
                cmdUpdate.Parameters.AddWithValue("@Qty", entity.Qty);
                cmdUpdate.Parameters.AddWithValue("@ProductId", entity.ProductId);
                cmdUpdate.ExecuteNonQuery();

                return entity;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDetail Update(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetDetailsByHeaderId(string orderHeaderId)
        {
            try
            {
                string query = @"select * from ViewOrderDetail
                                    where OrderHeaderId=@OrderHeaderId
                                    order by ProductName asc";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@OrderHeaderId", orderHeaderId);
                _connection.Open();
                _reader = _command.ExecuteReader();
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailId = Convert.ToInt32(_reader["OrderDetailId"]);
                        orderDetail.OrderHeaderId = _reader["OrderHeaderId"].ToString();
                        orderDetail.ProductId = Convert.ToInt32(_reader["ProductId"]);
                        orderDetail.Product = new Product
                        {
                            ProductId = Convert.ToInt32(_reader["ProductId"]),
                            ProductName = _reader["ProductName"].ToString()
                        };
                        orderDetail.Qty = Convert.ToInt32(_reader["Qty"]);
                        orderDetail.Price = Convert.ToDecimal(_reader["Price"]);
                        orderDetails.Add(orderDetail);
                    }
                }
                _reader.Close();
                return orderDetails;

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

        public decimal GetTotalAmount(string orderHeaderId)
        {
            try
            {
                string query = @"select sum(Price*Qty) from OrderDetails
                                    where OrderHeaderId=@OrderHeaderId";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@OrderHeaderId", orderHeaderId);
                _connection.Open();
                decimal totalAmount = Convert.ToDecimal(_command.ExecuteScalar());
                return totalAmount;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
        }
    }
}
