using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Data;
using InstafoodApp.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace InstafoodApp.BusinessLogic.Repositories
{
    public class OrderRepository : Repository<Order>, IOrder
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateStatus(string id, string orderStatus)
        {
            Order obj = await _db.Orders.Where(x=>x.OrderId==id).FirstOrDefaultAsync();
            if (obj != null)
            {
                obj.OrderStatusId=_db.OrderStatus.Where(x=>x.Status.ToLower() == orderStatus.ToLower()).First().OrderStatusId;
                _db.Orders.Update(obj);
            }
        }
    }
}
