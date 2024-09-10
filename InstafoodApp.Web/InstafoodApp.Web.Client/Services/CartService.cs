using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System;
using System.Text.Json.Serialization;

namespace InstafoodApp.Web.Client.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        public CartService(HttpClient httpClient) { 
            _httpClient = httpClient;
        }
        public async Task<string> AddCartItem(CartItemDTO obj)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/cartitems", obj);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                return error;
            }
        }

        public async Task<string> DeleteCartItem(string customerId,int productId)
        {

            var response = await _httpClient.DeleteAsync($"/api/cartitems?customerId={customerId}&productId={productId}");

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

        public async Task<IEnumerable<CartItem>> GetallCarts()
        {
            var response = await _httpClient.GetAsync("/api/cartitems");

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<IEnumerable<CartItem>>();
                return loginResponse;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<CartItem>> GetByCustomerId(string customerId)
        {
            var response = await _httpClient.GetAsync($"/api/cartitems/{customerId}");

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<IEnumerable<CartItem>>();
                return loginResponse;
            }
            else
            {
                // Handle the error appropriately
                return null;
            }
        }

        public async Task<string> UpdateCartItem(CartItemDTO obj)
        {
            var response = await _httpClient.PutAsJsonAsync<CartItemDTO>($"/api/cartitems",obj);

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
