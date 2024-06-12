using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.DTO;
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
        public IEnumerable<ProductDTO> Get()
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            var products = _product.GetProductsWithCategory();

            foreach (var product in products)
            {
                ProductDTO productDTO = new ProductDTO
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Stock = product.Stock,
                    Price = product.Price,
                    Category = new CategoryDTO
                    {
                        CategoryId = product.Category.CategoryId,
                        CategoryName = product.Category.CategoryName
                    }
                };
                productDTOs.Add(productDTO);
                //var products = _product.GetProductsWithCategory();
                //return products;
            }
            return productDTOs;
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
        public ActionResult Post(Product product)
        {
            try
            {
                var result = _product.Add(product);
                return CreatedAtAction(nameof(Get), new { id = result.ProductId }, result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Product product)
        {
            try
            {
                var updateData = _product.GetById(id);
                if (updateData != null)
                {
                    updateData.CategoryId = product.CategoryId;
                    updateData.ProductName = product.ProductName;
                    updateData.Stock = product.Stock;
                    updateData.Price= product.Price;

                    var result = _product.Update(updateData);
                    return Ok(result);
                }
                return BadRequest($"Product {product.ProductName} not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var deleteData = _product.GetById(id);
                if (deleteData != null)
                {
                    _product.Delete(deleteData.ProductId);
                    return Ok($"Data product id {id} berhasil di delete");
                }
                return BadRequest($"Data product id {id} not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"could not delete {ex.Message}");
            }
        }
    }
}
