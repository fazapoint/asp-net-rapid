using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.Models;
using RapidBootcamp.BackendAPI.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHeadersController : ControllerBase
    {
        private readonly IOrderHeader _orderHeader;
        public OrderHeadersController(IOrderHeader orderHeader)
        {
            _orderHeader = orderHeader;
        }

        // GET: api/<OrderHeaderController>
        [HttpGet]
        public IEnumerable<OrderHeader> Get()
        {
            var orderHeaders = _orderHeader.GetAll();
            return orderHeaders;
        }

        [HttpGet("View")]
        public IEnumerable<ViewOrderHeaderInfo> GetWithView()
        {
            var results = _orderHeader.GetAllWithView();
            return results;
        }

        // GET api/<OrderHeaderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderHeaderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderHeaderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderHeaderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
