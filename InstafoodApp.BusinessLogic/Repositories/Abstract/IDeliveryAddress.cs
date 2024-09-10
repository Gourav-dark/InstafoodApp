using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.BusinessLogic.Repositories.Abstract
{
    public interface IDeliveryAddress:IRepository<DeliveryAddress>
    {
        Task Update(DeliveryAddress obj);
    }
}
