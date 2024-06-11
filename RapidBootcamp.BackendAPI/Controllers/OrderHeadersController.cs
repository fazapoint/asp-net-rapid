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
        private readonly IOrderDetail _orderDetail;

        public OrderHeadersController(IOrderHeader orderHeader, IOrderDetail orderDetail)
        {
            _orderHeader = orderHeader;
            _orderDetail = orderDetail;
        }

        // GET: api/<OrderHeaderController>
        [HttpGet]
        public IEnumerable<OrderHeader> Get()
        {
            var results = _orderHeader.GetAll();
            foreach (var item in results)
            {
                item.OrderDetails = _orderDetail.GetDetailsByHeaderId(item.OrderHeaderId);
            }

            return results;
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
        public ActionResult Post(OrderHeader orderHeader)
        {
            try
            {
                // ambil last orderheaderid
                string lastOrderHeaderId = _orderHeader.GetOrderLastHeaderId();
                lastOrderHeaderId = lastOrderHeaderId.Substring(4, 4);
                int newOrderHeaderId = Convert.ToInt32(lastOrderHeaderId) + 1;
                string newOrderHeaderIdString = "INV-" + newOrderHeaderId.ToString().PadLeft(4, '0');

                orderHeader.OrderHeaderId = newOrderHeaderIdString;

                var result = _orderHeader.Add(orderHeader);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
