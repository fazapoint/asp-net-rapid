using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public interface IProduct : ICrud<Product>
    {
        IEnumerable<Product> GetProductsByName(string productName);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
    }
}
