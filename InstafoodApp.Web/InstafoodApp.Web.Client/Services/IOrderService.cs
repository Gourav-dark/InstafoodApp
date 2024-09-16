using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.Web.Client.Services
{
    public interface IOrderService
    {
        Task<Order> PlaceOrder(string userID);
        Task<IEnumerable<Order>> GetOrderByUserId(string userID);
        Task<IEnumerable<Order>> GetAllOrder();
        Task<Order> GetOrderById(string orderId);
        Task UpdateOrderStatus(string orderId,string status);
        Task<IEnumerable<Order>> GetOrderByStatus(string status);

        Task<IEnumerable<OrderStatus>> GetAllStatus();
        Task<IEnumerable<OrderDetail>> GetOrderDetails(string orderId);
    }
}
