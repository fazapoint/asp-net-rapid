using Microsoft.EntityFrameworkCore;
using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            var results = _dbContext.Products.OrderBy(p => p.ProductName).ToList();
            return results;
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetByProductName(string productName)
        {
            throw new NotImplementedException();
        }

        public int GetProductStock(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsWithCategory()
        {
            var results = _dbContext.Products.Include(p => p.Category).OrderBy(p => p.ProductName).ToList();
            return results;
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
