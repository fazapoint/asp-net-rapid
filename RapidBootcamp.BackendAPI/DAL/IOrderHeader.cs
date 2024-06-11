using RapidBootcamp.BackendAPI.Models;
using RapidBootcamp.BackendAPI.ViewModel;

namespace RapidBootcamp.BackendAPI.DAL
{
    public interface IOrderHeader : ICrud<OrderHeader>
    {
        public IEnumerable<ViewOrderHeaderInfo> GetAllWithView();
        public string GetOrderLastHeaderId();
    }
}
