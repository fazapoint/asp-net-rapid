using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoriesController(ICategory category)
        {
            _category = category;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var categories = _category.GetAll();
            return categories;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var category = _category.GetById(id);
            return category;
        }

        [HttpGet("ByName")]
        public IEnumerable<Category> GetByName(string name)
        {
            var categories = _category.GetCategoriesByName(name);
            return categories;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post(Category category)
        {
            try
            {
                var result = _category.Add(category);
                return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Category category)
        {
            var updateData = _category.GetById(id);
            try
            {
                if (updateData != null)
                {
                    updateData.CategoryName = category.CategoryName;
                    var result = _category.Update(updateData);
                    return Ok(result);
                }
                return BadRequest($"Category {category.CategoryName} not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            try
            {
                var deleteData = _category.GetById(id);
                if (deleteData != null)
                {
                    _category.Delete(deleteData.CategoryId);
                    return Ok($"Data Category id {id} berhasil di delete");
                }
                return BadRequest($"Data Category id {id} not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"could not delete {ex.Message}");
            }
        }
    }
}
