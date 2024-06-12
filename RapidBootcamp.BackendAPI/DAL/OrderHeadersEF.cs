using Microsoft.EntityFrameworkCore;
using RapidBootcamp.BackendAPI.Models;
using RapidBootcamp.BackendAPI.ViewModel;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class OrderHeadersEF : IOrderHeader
    {
        private readonly AppDbContext _dbContext;
        public OrderHeadersEF(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OrderHeader Add(OrderHeader entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetAll()
        {
            var results = _dbContext.OrderHeaders
                .Include(oh => oh.Wallet).ThenInclude(w => w.Customer)
                .Include(oh => oh.Wallet).ThenInclude(w => w.WalletType)
                .Include(oh => oh.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.Category).ToList();
            return results;
        }

        public IEnumerable<ViewOrderHeaderInfo> GetAllWithView()
        {
            throw new NotImplementedException();
        }

        public OrderHeader GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string GetOrderLastHeaderId()
        {
            throw new NotImplementedException();
        }

        public OrderHeader Update(OrderHeader entity)
        {
            throw new NotImplementedException();
        }
    }
}
