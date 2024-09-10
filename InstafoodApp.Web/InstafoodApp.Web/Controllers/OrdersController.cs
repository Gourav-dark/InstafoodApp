using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstafoodApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _unitOfWork.order.GetAllAsync();
            if (orders.Count() > 0)
            {
                foreach (Order order in orders)
                {
                    order.OrderStatus = await _unitOfWork.orderStatus.GetAsync(x => x.OrderStatusId == order.OrderStatusId);
                    order.Customer = await _unitOfWork.user.GetAsync(x => x.UserId == order.CustomerId);
                }
                return Ok(orders);
            }
            return NotFound();
        }
        [HttpGet("status")]
        public async Task<IActionResult> GetOrderType([FromQuery] string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return BadRequest("Filter parameter is required.");
            }
            OrderStatus status = await _unitOfWork.orderStatus.GetAsync(x => x.Status.ToLower() == type.ToLower());
            var orders = await _unitOfWork.order.GetAllAsync(x => x.OrderStatusId == status.OrderStatusId);
            if (orders.Count() > 0)
            {
                foreach (Order order in orders)
                {
                    //order.OrderStatus = await _unitOfWork.orderStatus.GetAsync(x => x.OrderStatusId == order.OrderStatusId);
                    order.Customer = await _unitOfWork.user.GetAsync(x => x.UserId == order.CustomerId);
                }
                return Ok(orders);
            }
            else
            {
                return NotFound(new { message = "Order not found." });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {

            Order order = await _unitOfWork.order.GetAsync(x => x.OrderId == id);
            if (order != null)
            {
                order.Customer = await _unitOfWork.user.GetAsync(x => x.UserId == order.CustomerId);
                order.OrderStatus = await _unitOfWork.orderStatus.GetAsync(x => x.OrderStatusId == order.OrderStatusId);
                return Ok(order);
            }
            return NotFound();
        }
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomerId(string customerId)
        {

            var orders = await _unitOfWork.order.GetAllAsync(x => x.CustomerId == customerId);
            if (orders.Count() > 0)
            {
                foreach (Order order in orders)
                {
                    order.OrderStatus = await _unitOfWork.orderStatus.GetAsync(x => x.OrderStatusId == order.OrderStatusId);
                    order.Customer = await _unitOfWork.user.GetAsync(x => x.UserId == order.CustomerId);
                }
                return Ok(orders);
            }
            return NotFound();
        }
        [HttpGet("placeOrder/{customerId}")]
        public async Task<IActionResult> PlaceOrder(string customerId)
        {
            try
            {
                var cartItems = await _unitOfWork.cartItem.GetAllAsync(x => x.CustomerId == customerId);
                float totalCost = 0;
                if (cartItems.Count() > 0)
                {
                    foreach(var cartItem in cartItems)
                    {
                        Product product=await _unitOfWork.product.GetAsync(x=>x.ProductId == cartItem.ProductId);
                        totalCost += cartItem.Quantity * product.UnitPrice;
                    }
                }
                Order newOrder=new Order() 
                {
                    CustomerId = customerId,
                    TotalCost = totalCost,
                };
                await _unitOfWork.order.AddAsync(newOrder);
                await _unitOfWork.Save();
                if (cartItems.Count() > 0)
                {
                    foreach (var cartItem in cartItems) 
                    {
                        OrderDetail detail = new OrderDetail()
                        {
                            OrderId=newOrder.OrderId,
                            ProductId=cartItem.ProductId,
                            Quantity = cartItem.Quantity
                        };
                        await _unitOfWork.orderDetail.AddAsync(detail);
                    }
                }
                await _unitOfWork.cartItem.RemoveRangeAsync(cartItems);
                await _unitOfWork.Save();
                return Ok("Ordered successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id,[FromQuery]string type)
        {
            try
            {
                await _unitOfWork.order.UpdateStatus(id, type);
                await _unitOfWork.Save();
                return Ok("Order status updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPut("cancel/{id}")]
        //public async Task<IActionResult> Put(string id)
        //{
        //    try
        //    {
        //        await _unitOfWork.order.UpdateStatus(id, "Cancelled");
        //        await _unitOfWork.Save();
        //        return Ok("Order Cancelled.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
