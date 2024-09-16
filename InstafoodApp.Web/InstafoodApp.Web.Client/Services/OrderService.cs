using InstafoodApp.DataAccess.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace InstafoodApp.Web.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            var response = await _httpClient.GetAsync($"/api/orders");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<Order>>();
                return result;
            }
            else
            {
                // Log the error response
                var error = await response.Content.ReadAsStringAsync();
                return null;
            }
        }

        public async Task<IEnumerable<OrderStatus>> GetAllStatus()
        {
            var response = await _httpClient.GetAsync($"/api/orderstatus");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<OrderStatus>>();
                return result;
            }
            else
            {
                // Log the error response
                var error = await response.Content.ReadAsStringAsync();
                return null;
            }
        }

        public async Task<Order> GetOrderById(string orderId)
        {
            var response = await _httpClient.GetAsync($"/api/orders/{orderId}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Order>();
                return result;
            }
            else
            {
                // Log the error response
                var error = await response.Content.ReadAsStringAsync();
                return null;
            }
        }

        public async Task<IEnumerable<Order>> GetOrderByStatus(string status)
        {
            var response = await _httpClient.GetAsync($"/api/orders/status?type={status}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<Order>>();
                return result;
            }
            else
            {
                // Log the error response
                var error = await response.Content.ReadAsStringAsync();
                return null;
            }
        }

        public async Task<IEnumerable<Order>> GetOrderByUserId(string customerId)
        {
            var response = await _httpClient.GetAsync($"/api/orders/customer/{customerId}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<Order>>();
                return result;
            }
            else
            {
                // Log the error response
                var error = await response.Content.ReadAsStringAsync();
                return null;
            }
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetails(string orderId)
        {
            var response = await _httpClient.GetAsync($"/api/orderdetails/{orderId}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<OrderDetail>>();
                return result;
            }
            else
            {
                // Log the error response
                var error = await response.Content.ReadAsStringAsync();
                return null;
            }
        }

        public async Task<Order> PlaceOrder(string customerId)
        {
            
            var response = await _httpClient.GetAsync($"/api/orders/placeOrder/{customerId}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Order>();
                return result;
            }
            else
            {
                // Log the error response
                var error = await response.Content.ReadAsStringAsync();
                return null;
            }
        }

        public async Task UpdateOrderStatus(string orderId, string status)
        {
            await _httpClient.DeleteAsync($"/api/orders/{orderId}?type={status}");
        }
    }
}
