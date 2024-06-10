using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;

        public ProductsController(IProduct product)
        {
            _product = product;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _product.GetProductsWithCategory();
            return products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = _product.GetById(id);
            return product;
        }

        // GET api/<ProductsController>/5
        [HttpGet("ByCategory/{categoryId}")]
        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            var products = _product.GetByCategory(categoryId);
            return products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("ByProductName")]
        public IEnumerable<Product> GetByProductName(string name)
        {
            var products = _product.GetByProductName(name);
            return products;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
