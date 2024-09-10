using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;
using System.Net.Http.Json;

namespace InstafoodApp.Web.Client.Services
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;
        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DeliveryAddress> GetById(string Id)
        {
            var response = await _httpClient.GetAsync($"/api/deliveryaddresses/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<DeliveryAddress>();
                return result;
            }
            else
            {
                // Log the error response
                var error = await response.Content.ReadAsStringAsync();
                return null;
            }
        }

        public async Task<string> Set(DeliveryAddressDTO obj)
        {
            var response = await _httpClient.PostAsJsonAsync<DeliveryAddressDTO>($"/api/deliveryaddresses", obj);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else
            {
                // Log the error response
                var error = await response.Content.ReadAsStringAsync();
                return error;
            }
        }

        public async Task<string> Update(DeliveryAddressDTO obj)
        {
            var response = await _httpClient.PutAsJsonAsync<DeliveryAddressDTO>($"/api/deliveryaddresses", obj);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else
            {
                // Log the error response
                var error = await response.Content.ReadAsStringAsync();
                return error;
            }
        }
    }
}
