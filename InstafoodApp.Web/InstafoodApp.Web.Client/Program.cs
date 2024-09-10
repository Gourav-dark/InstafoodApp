using InstafoodApp.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//Base Uri Access Code
builder.Services.AddScoped(sp =>new HttpClient {
    BaseAddress=new Uri(builder.HostEnvironment.BaseAddress)
});
builder.Services.AddAuthorizationCore();
//builder.Services.AddAuthorization();
//Clinet Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IOrderService, OrderService>();

await builder.Build().RunAsync();
