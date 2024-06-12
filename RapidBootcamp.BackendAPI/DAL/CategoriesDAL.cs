using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class CategoriesDAL : ICategory
    {
        private readonly IConfiguration _config;
        private string? _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public CategoriesDAL(IConfiguration config) 
        {
            //Server=localhost,1433;Database=ProductDb;User=sa;Password=Indonesia@2023;TrustServerCertificate=True;MultipleActiveResultSets=true;
            // _connectionString = @"Server=.\SQLEXPRESS;Database=RapidDb;Trusted_Connection=True;";
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }

        public Category Add(Category entity)
        {
            try
            {
                string query = @"INSERT INTO Categories(CategoryName) 
                                 VALUES(@CategoryName);select @@identity";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
                _connection.Open();

                //menjalankan perintah insert
                int lastCategoryId = Convert.ToInt32(_command.ExecuteScalar());
                entity.CategoryId = lastCategoryId;

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

        public void Delete(int id)
        {
            try
            {
                // using ADO .net
                //string query = @"delete from Categories where CategoryId=@CategoryId";
                //_command = new SqlCommand(query, _connection);

                // using store procedure from sql server

                string query = @"sp_DeleteCategory";
                _command = new SqlCommand(query, _connection);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@CategoryId", id);
                _connection.Open();
                int result = _command.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new ArgumentException("Data gagal dihapus");
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

        public IEnumerable<Category> GetAll()
        {
            try
            {
                //poco object untuk menampung data dari database
                List<Category> categories = new List<Category>();

                // using ADO .net
                //string query = @"SELECT * FROM Categories 
                //                 order by CategoryName asc";
                //_command = new SqlCommand(query, _connection);

                // using store procedure in sql server
                string query = @"sp_GetAllCategories";
                _command = new SqlCommand(query, _connection);
                _command.CommandType = CommandType.StoredProcedure;

                //buka koneksi
                _connection.Open();

                //baca data
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        categories.Add(new Category
                        {
                            CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                            CategoryName = _reader["CategoryName"].ToString()
                        });
                    }
                }
                _reader.Close();

                return categories;
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

        public Category GetById(int id)
        {
            try
            {
                Category category = new Category();
                string query = @"SELECT * FROM Categories 
                                 WHERE CategoryId = @CategoryId";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryId", id);
                _connection.Open();
                _reader = _command.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        category.CategoryId = Convert.ToInt32(_reader["CategoryId"]);
                        category.CategoryName = _reader["CategoryName"].ToString();
                    }
                }

                _reader.Close();
                return category;
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

        public IEnumerable<Category> GetCategoriesByName(string categoryName)
        {
            try
            {
                string query = @"SELECT * FROM Categories 
                                     WHERE CategoryName like @CategoryName";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryName", "%" + categoryName + "%");
                _connection.Open();
                _reader = _command.ExecuteReader();
                List<Category> categories = new List<Category>();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        categories.Add(new Category
                        {
                            CategoryId = Convert.ToInt32(_reader["CategoryId"]),
                            CategoryName = _reader["CategoryName"].ToString()
                        });
                    }
                }
                _reader.Close();
                return categories;
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

        public Category Update(Category entity)
        {
            try
            {
                string query = @"update Categories set CategoryName=@CategoryName 
                                 where CategoryId=@CategoryId";
                _command = new SqlCommand(query, _connection);
                _command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
                _command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                _connection.Open();
                int result = _command.ExecuteNonQuery();
                if (result == 1)
                {
                    return entity;
                }
                else
                {
                    throw new ArgumentException("Data gagal diupdate");
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
    }
}
