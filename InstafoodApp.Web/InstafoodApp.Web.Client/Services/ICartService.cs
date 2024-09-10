using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;

namespace InstafoodApp.Web.Client.Services
{
    public interface ICartService
    {
        Task<IEnumerable<CartItem>> GetallCarts();
        Task<IEnumerable<CartItem>> GetByCustomerId(string customerId);
        Task<string> AddCartItem(CartItemDTO obj);
        Task<string> DeleteCartItem(string customerId, int productId);
        Task<string> UpdateCartItem(CartItemDTO obj);
    }
}
