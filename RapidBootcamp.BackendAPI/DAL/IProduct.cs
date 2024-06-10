using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public interface IProduct : ICrud<Product>
    {
        IEnumerable<Product> GetByCategory(int categoryId);
        IEnumerable<Product> GetByProductName(string productName);
        IEnumerable<Product> GetProductsWithCategory();
    }
}
