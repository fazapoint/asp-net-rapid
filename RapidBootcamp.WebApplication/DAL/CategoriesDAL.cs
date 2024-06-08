using Dapper;
using RapidBootcamp.WebApplication.Models;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CategoriesDAL : ICategory
    {
        private readonly IConfiguration _configuration;

        public CategoriesDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnStr()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }


        public Category Add(Category entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                try
                {
                    string query = @"insert into Categories(CategoryName)
                                    values(@CategoryName)";
                    var param = new { CategoryName = entity.CategoryName };
                    int newId = conn.ExecuteScalar<int>(query, param);
                    entity.CategoryId = newId;
                    return entity;
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException(sqlEx.Message);
                }

            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Categories
                                     order by CategoryName asc";
                var categories = conn.Query<Category>(query);
                return categories;
            }
        }

        public Category GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Categories
                                 where CategoryId = @CategoryId";
                var param = new { CategoryId = id };
                var category = conn.QuerySingleOrDefault<Category>(query, param);
                if (category == null)
                {
                    throw new ArgumentException("Data not found");
                }
                return category;
            }
        }

        public Category Update(Category entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                try
                {
                    string query = @"update Categories set CategoryName = @CategoryName
                                                where CategoryId = @CategoryId";
                    var param = new { CategoryName = entity.CategoryName, CategoryId = entity.CategoryId };
                    conn.Execute(query, param);
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
                string query = @"delete from Categories
                                   where CategoryId = @CategoryId";
                var param = new { CategoryId = id };
                conn.Execute(query, param);   
            }
        }

        public IEnumerable<Category> GetCategoriesByName(string categoryName)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Categories
                                    where CategoryName like @CategoryName
                                    order by CategoryName asc";
                var param = new { CategoryName = "%" + categoryName + "%" };
                var categories = conn.Query<Category>(query, param);
                return categories;
            }
        }
    }
}
