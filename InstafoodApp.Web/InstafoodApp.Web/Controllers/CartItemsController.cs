using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InstafoodApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<CartItem> cartItems = await _unitOfWork.cartItem.GetAllAsync();
                if (cartItems.Count() > 0) {
                    return Ok(cartItems);
                }
                return NoContent();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByCustomerId(string customerId)
        {
            try
            {
                IEnumerable<CartItem> cartItems = await _unitOfWork.cartItem.GetAllAsync(x => x.CustomerId == customerId);
                if (cartItems.Count() > 0)
                {
                    foreach(var cartItem in cartItems)
                    {
                        cartItem.Product=await _unitOfWork.product.GetAsync(x=>x.ProductId==cartItem.ProductId);
                    }
                    return Ok(cartItems);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }  
        [HttpPost]
        public async Task<IActionResult> Post(CartItemDTO item)
        {
            CartItem existItem = await _unitOfWork.cartItem.GetAsync(x => x.ProductId == item.ProductId && x.CustomerId == item.CustomerId);
            if (existItem == null)
            {
                CartItem newItem = new CartItem()
                {
                    ProductId = item.ProductId,
                    CustomerId = item.CustomerId,
                    Quantity = item.Quantity
                };
                await _unitOfWork.cartItem.AddAsync(newItem);
                await _unitOfWork.Save();
                return Ok("Item successfully Added in Cart.");
            }
            return BadRequest("Item already in Cart.");
        }
        [HttpPut]
        public async Task<IActionResult> Put(CartItemDTO item)
        {
            CartItem existItem = await _unitOfWork.cartItem.GetAsync(x => x.ProductId == item.ProductId && x.CustomerId == item.CustomerId);
            if (existItem != null && item.Quantity > 0)
            {
                existItem.Quantity = item.Quantity;
                await _unitOfWork.cartItem.Update(existItem);
                await _unitOfWork.Save();
                return Ok("Updated successfully.");
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]string customerId,[FromQuery]int productId)
        {
            CartItem existItem = await _unitOfWork.cartItem.GetAsync(x => x.ProductId == productId && x.CustomerId == customerId);
            if (existItem != null)
            {
                await _unitOfWork.cartItem.RemoveAsync(existItem);
                await _unitOfWork.Save();
                return Ok("Item Removed from Cart.");
            }
            return BadRequest();
        }
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteAll(string customerId)
        {
            if (!customerId.IsNullOrEmpty())
            {
                IEnumerable<CartItem> existItems = await _unitOfWork.cartItem.GetAllAsync(x => x.CustomerId == customerId);
                await _unitOfWork.cartItem.RemoveRangeAsync(existItems);
                await _unitOfWork.Save();
                return Ok("All Item Removed from Cart.");
            }
            return BadRequest();
        }
    }
}
