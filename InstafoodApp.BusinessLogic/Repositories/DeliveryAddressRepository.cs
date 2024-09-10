using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Data;
using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.BusinessLogic.Repositories
{
    public class DeliveryAddressRepository : Repository<DeliveryAddress>, IDeliveryAddress
    {
        private readonly ApplicationDbContext _db;
        public DeliveryAddressRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(DeliveryAddress obj)
        {
            _db.DeliveryAddresses.Update(obj);
        }
    }
}
