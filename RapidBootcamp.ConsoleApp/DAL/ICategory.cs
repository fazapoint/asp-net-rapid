using RapidBootcamp.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.ConsoleApp.DAL
{
    public interface ICategory : ICrudDal<Category>
    {
        IEnumerable<Category> GetByCategoryName(string categoryName);
    }
}
