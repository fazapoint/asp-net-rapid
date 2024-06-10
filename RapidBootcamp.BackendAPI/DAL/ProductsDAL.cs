using RapidBootcamp.BackendAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class ProductsDAL : IProduct
    {
        private string? _connectionString;
        private readonly IConfiguration _config;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public ProductsDAL(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }

        public Product Add(Product entity)
        {
            try
            {
                string query = @"INSERT INTO Products(ProductName,CategoryId,Price,Stock) 
                                VALUES(@ProductName,@CategoryId,@Price,@Stock);SELECT @@identity";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                _command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                _command.Parameters.AddWithValue("@Price", entity.Price);
                _command.Parameters.AddWithValue("@Stock", entity.Stock);
                _connection.Open();
                entity.ProductId = Convert.ToInt32(_command.ExecuteScalar());
                return entity;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _connection.Close();
                _command.Dispose();
            }
        }

        public void Delete(int id)
        {
            try
            {
                string query = @"delete from Products where ProductId=@ProductId";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@ProductId", id);
                _connection.Open();
                int result = _command.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new ArgumentException("Delete failed");
                }
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

        public IEnumerable<Product> GetAll()
        {
            try
            {
                List<Product> products = new List<Product>();
                string query = @"SELECT * FROM Products order by ProductName asc";
                _command = new SqlCommand(query, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(_reader["ProductId"]),
                            ProductName = _reader["ProductName"].ToString(),
                            CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                            Price = Convert.ToDecimal(_reader["Price"]),
                            Stock = Convert.ToInt32(_reader["Stock"])
                        });
                    }
                }
                _reader.Close();
                return products;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                _command.Dispose();
                _connection.Close();
            }
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            try
            {
                string query = @"select * from Products where CategoryId=@CategoryId";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryId", categoryId);
                _connection.Open();
                _reader = _command.ExecuteReader();
                List<Product> products = new List<Product>();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(_reader["ProductId"]),
                            ProductName = _reader["ProductName"].ToString(),
                            CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                            Price = Convert.ToDecimal(_reader["Price"]),
                            Stock = Convert.ToInt32(_reader["Stock"])
                        });
                    }
                }
                _reader.Close();
                return products;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _connection.Close();
                _command.Dispose();
            }
        }

        public Product GetById(int id)
        {
            try
            {
                Product product = new Product();
                string query = @"select * from ViewProductsWithCategory 
                                 where ProductId=@ProductId";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@ProductId", id);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    _reader.Read();
                    product.ProductId = Convert.ToInt32(_reader["ProductId"]);
                    product.ProductName = _reader["ProductName"].ToString();
                    product.CategoryId = Convert.ToInt32(_reader["CategoryId"]);
                    product.Price = Convert.ToDecimal(_reader["Price"]);
                    product.Stock = Convert.ToInt32(_reader["Stock"]);
                    product.Category = new Category
                    {
                        CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                        CategoryName = _reader["CategoryName"].ToString()
                    };
                }
                else
                {
                    throw new ArgumentException($"ProductId {id} not found");
                }
                _reader.Close();
                return product;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _connection.Close();
                _command.Dispose();
            }
        }

        public IEnumerable<Product> GetByProductName(string productName)
        {
            try
            {
                List<Product> products = new List<Product>();
                string query = @"select * from ViewProductsWithCategory 
                                 where ProductName like @ProductName
                                 order by ProductName asc";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@ProductName", "%" + productName + "%");
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(_reader["ProductId"]),
                            ProductName = _reader["ProductName"].ToString(),
                            CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                            Price = Convert.ToDecimal(_reader["Price"]),
                            Stock = Convert.ToInt32(_reader["Stock"]),
                            Category = new Category
                            {
                                CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                                CategoryName = _reader["CategoryName"].ToString()
                            }
                        });
                    }
                }
                _reader.Close();
                return products;
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

        public IEnumerable<Product> GetProductsWithCategory()
        {
            try
            {
                string query = @"select p.ProductId,p.CategoryId,p.ProductName,p.Stock,p.Price,c.CategoryName
                                 from Products p inner join Categories c on p.CategoryId=c.CategoryId
                                 order by p.ProductName";
                //string query = @"select * from ViewProductsWithCategories";
                _command = new SqlCommand(query, _connection);
                _connection.Open();
                _reader = _command.ExecuteReader();
                List<Product> products = new List<Product>();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(_reader["ProductId"]),
                            ProductName = _reader["ProductName"].ToString(),
                            CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                            Price = Convert.ToDecimal(_reader["Price"]),
                            Stock = Convert.ToInt32(_reader["Stock"]),
                            Category = new Category
                            {
                                CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                                CategoryName = _reader["CategoryName"].ToString()
                            }
                        });
                    }
                }
                _reader.Close();
                return products;
            }
            catch (SqlException sqlEx)
            {
                throw new ArgumentException(sqlEx.Message);
            }
            finally
            {
                _connection.Close();
                _command.Dispose();
            }
        }

        public Product Update(Product entity)
        {
            try
            {
                string query = @"update Products set ProductName=@ProductName,CategoryId=@CategoryId,Price=@Price,Stock=@Stock
                                where ProductId=@ProductId";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                _command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                _command.Parameters.AddWithValue("@Price", entity.Price);
                _command.Parameters.AddWithValue("@Stock", entity.Stock);
                _command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                 
                _connection.Open();
                int result = _command.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new ArgumentException("Update failed");
                }

                return entity;
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