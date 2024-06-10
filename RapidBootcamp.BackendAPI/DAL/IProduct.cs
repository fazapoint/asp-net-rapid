using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public interface IProduct : ICrud<Product>
    {
        IEnumerable<Product> GetProductsByName(string productName);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
    }
}
