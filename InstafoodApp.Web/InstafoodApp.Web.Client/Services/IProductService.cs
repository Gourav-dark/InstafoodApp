using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;

namespace InstafoodApp.Web.Client.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<string> Add(ProductDTO obj);
    }
}
