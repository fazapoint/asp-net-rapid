using Microsoft.EntityFrameworkCore;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class ProductsEF : IProduct
    {
        private readonly AppDbContext _dbContext;
        public ProductsEF(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Add(Product entity)
        {
            try
            {
                _dbContext.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            var results = _dbContext.Products.Include(c => c.Category).ToList();
            return results;
        }

        public Product GetById(int id)
        {
            var result = _dbContext.Products.Include(p => p.Category)
                         .FirstOrDefault(c => c.ProductId == id);

            if (result == null)
            {
                throw new ArgumentException("Product not found");
            }
            return result;
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByName(string productName)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
