using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.BusinessLogic.Repositories.Abstract
{
    public interface ICartItem:IRepository<CartItem>
    {
        Task Update(CartItem cartItem);
    }
}
