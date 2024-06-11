using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public interface IOrderDetail : ICrud<OrderDetail>
    {
        public IEnumerable<OrderDetail> GetDetailsByHeaderId(string orderHeaderId);
    }
}
