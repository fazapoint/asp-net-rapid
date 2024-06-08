using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public interface ICategory : ICrud<Category>
    {
        IEnumerable<Category> GetCategoriesByName(string categoryName);
    }
}
