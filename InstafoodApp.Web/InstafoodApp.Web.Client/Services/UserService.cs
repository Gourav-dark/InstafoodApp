//using InstafoodApp.BusinessLogic.Repositories.Abstract;
using Azure;
using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace InstafoodApp.Web.Client.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient= httpClient;
        }

        public async Task<LoginResponse> Login(LoginDTO obj)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/users/login", obj);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return loginResponse;
            }
            else
            {
                // Handle the error appropriately
                return null;
            }
        }
        public async Task<LoginResponse> SignUp(UserDTO obj)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/users", obj);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return loginResponse;
            }
            else
            {
                // Handle the error appropriately
                return null;
            }
        }
    }
}
