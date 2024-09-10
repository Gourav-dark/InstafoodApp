using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.BusinessLogic.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        IUser user {  get; }
        ICartItem cartItem { get; }
        IOrder order { get; }
        IOrderDetail orderDetail { get; }
        IDeliveryAddress deliveryAddress { get; }
        IProduct product { get; }
        IOrderStatus orderStatus { get; }
        Task Save();
    }
}
