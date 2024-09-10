using InstafoodApp.DataAccess.Models;

namespace InstafoodApp.BusinessLogic.Repositories.Abstract
{
    public interface IProduct:IRepository<Product>
    {
        Task Update(Product obj);
    }
}
