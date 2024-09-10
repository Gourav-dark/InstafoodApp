using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Data;
using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.BusinessLogic.Repositories
{
    public class OrderStatusRepository:Repository<OrderStatus>,IOrderStatus
    {
        private readonly ApplicationDbContext _db;
        public OrderStatusRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
