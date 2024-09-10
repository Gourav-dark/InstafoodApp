using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.BusinessLogic.Repositories.Abstract
{
    public interface IOrder:IRepository<Order>
    {
        Task UpdateStatus(string id,string orderStatus);
    }
}
