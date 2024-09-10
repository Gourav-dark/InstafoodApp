using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Data;
using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.BusinessLogic.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetail
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
