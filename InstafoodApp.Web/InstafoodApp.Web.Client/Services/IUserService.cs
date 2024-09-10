using InstafoodApp.Web.Client.DTO;

namespace InstafoodApp.Web.Client.Services
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginDTO obj);
        Task<LoginResponse> SignUp(UserDTO obj);
    }
}
