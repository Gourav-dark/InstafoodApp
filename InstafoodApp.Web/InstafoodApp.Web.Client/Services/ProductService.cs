using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace InstafoodApp.Web.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Add(ProductDTO obj)
        {
            var response = await _httpClient.PostAsJsonAsync<ProductDTO>($"/api/products", obj);

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

        public async Task<string> Delete(int productId)
        {
            var response = await _httpClient.DeleteAsync($"/api/products/{productId}");

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

        public async Task<IEnumerable<Product>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("/api/products");
            return result;
        }

        public async Task<string> IsAvailable(int productId)
        {
            var response = await _httpClient.DeleteAsync($"/api/products/isavailable/{productId}");

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
