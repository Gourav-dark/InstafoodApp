using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Data;
using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.BusinessLogic.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItem
    {
        private readonly ApplicationDbContext _db;
        public CartItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(CartItem obj)
        {
            _db.CartItems.Update(obj);
        }
    }
}
