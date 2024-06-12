using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.DTO;
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
        public IEnumerable<CategoryDTO> Get()
        {
            //var categories = _category.GetAll();
            //return categories;

            // convert to DTO (have to convert to DTO in API)
            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
            var categories = _category.GetAll();
            foreach (var category in categories)
            {
                CategoryDTO categoryDTO = new CategoryDTO
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                };
                categoryDTOs.Add(categoryDTO);
            }
            return categoryDTOs;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryDTO Get(int id)
        {
            // without DTO
            //var category = _category.GetById(id);
            //return category;

            var category = _category.GetById(id);
            CategoryDTO categoryDTO = new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
            };

            return categoryDTO;
        }

        [HttpGet("ByName")]
        public IEnumerable<Category> GetByName(string name)
        {
            var categories = _category.GetCategoriesByName(name);
            return categories;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public ActionResult Post(CreateCategoryDTO createCategoryDTO)
        {
            try
            {
                // convert to DTO
                Category category = new Category
                {
                    CategoryName = createCategoryDTO.CategoryName
                };
                var result = _category.Add(category);

                CategoryDTO categoryDTO = new CategoryDTO
                {
                    CategoryId = result.CategoryId,
                    CategoryName = result.CategoryName
                };

                return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, categoryDTO);

                // without using dto
                //var result = _category.Add(category);
                //return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, category);

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
            try
            {
                var updateData = _category.GetById(id);
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
