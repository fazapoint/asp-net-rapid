using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class CategoriesEF : ICategory
    {
        private readonly AppDbContext _dbContext;
        public CategoriesEF(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            var result = _dbContext.Categories.OrderBy(c => c.CategoryName).ToList();
            return result;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategoriesByName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
