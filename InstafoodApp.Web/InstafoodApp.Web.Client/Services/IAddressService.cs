using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;

namespace InstafoodApp.Web.Client.Services
{
    public interface IAddressService
    {
        Task<DeliveryAddress> GetById(string Id);
        Task<string> Set(DeliveryAddressDTO obj);
        Task<string> Update(DeliveryAddressDTO obj);
    }
}
