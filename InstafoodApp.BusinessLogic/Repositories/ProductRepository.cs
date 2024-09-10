using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Data;
using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.BusinessLogic.Repositories
{
    public class ProductRepository : Repository<Product>, IProduct
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
