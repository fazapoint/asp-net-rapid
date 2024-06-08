using Dapper;
using RapidBootcamp.WebApplication.Models;
using System.Data.SqlClient;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CustomersDAL : ICustomer
    {
        private readonly IConfiguration _configuration;
        // CONSTRUCTOR
        public CustomersDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // METHOD GetConnStr()
        private string GetConnStr()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public Customer Add(Customer entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                try
                {
                    string query = @"insert into Customers(CustomerName, Address, City, Email, PhoneNumber)
                                       values(@CustomerName, @Address, @City, @Email, @PhoneNumber)";
                    var param = new 
                    { 
                        CustomerName = entity.CustomerName, 
                        Address = entity.Address,
                        City = entity.City,
                        Email = entity.Email,
                        PhoneNumber = entity.PhoneNumber
                    };
                    int newId = conn.ExecuteScalar<int>(query, param);
                    entity.CustomerId = newId;
                    return entity;
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException(sqlEx.Message);
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"delete from Customers
                                   where CustomerId = @CustomerId";
                var param = new { CustomerId = id };
                conn.Execute(query, param);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Customers
                                order by CustomerName asc";
                var customers = conn.Query<Customer>(query);
                return customers;
            }
        }

        public Customer GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Customers
                                 where CustomerId = @CustomerId";
                var param = new { CustomerId = id };
                var customer = conn.QuerySingleOrDefault<Customer>(query, param);
                if (customer == null)
                {
                    throw new ArgumentException("Data not found");
                }
                return customer;
            }
        }

        public Customer Update(Customer entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"update Customers set CustomerName = @CustomerName, Address = @Address, 
                                    City = @City, Email = @Email, PhoneNumber = @PhoneNumber
                                    where CustomerId = @CustomerId";
                var param = new
                {
                    CustomerId = entity.CustomerId,
                    CustomerName = entity.CustomerName,
                    Address = entity.Address,
                    City = entity.City,
                    Email = entity.Email,
                    PhoneNumber = entity.PhoneNumber
                };
                conn.Execute(query, param);
                return entity;
            }
        }

        public IEnumerable<Customer> GetCustomersByName(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Customers
                                    where CustomerName like @Keyword
                                    or City like @Keyword
                                    order by CustomerName asc";
                var param = new { Keyword = "%" + keyword + "%" };
                var customers = conn.Query<Customer>(query, param);
                return customers;
            }
        }
    }
}
