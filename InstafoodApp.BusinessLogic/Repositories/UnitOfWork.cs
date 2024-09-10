using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Data;
using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.BusinessLogic.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        readonly ApplicationDbContext _db;
        public IUser user { get; private set; }
        public ICartItem cartItem { get; private set; }
        public IOrder order { get; private set; }
        public IOrderDetail orderDetail { get; private set; }
        public IDeliveryAddress deliveryAddress { get; private set; }
        public IProduct product { get; private set; }
        public IOrderStatus orderStatus { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            user=new UserRepository(_db);
            cartItem=new CartItemRepository(_db);
            order=new OrderRepository(_db);
            orderDetail=new OrderDetailRepository(_db);
            deliveryAddress=new DeliveryAddressRepository(_db);
            product=new ProductRepository(_db);
            orderStatus=new OrderStatusRepository(_db);
        }
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
