using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstafoodApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByOrderId(string Id)
        {
            try
            {
                IEnumerable<OrderDetail> details = await _unitOfWork.orderDetail.GetAllAsync(x=>x.OrderId==Id);
                if (details.Count() > 0)
                {
                    foreach (OrderDetail detail in details) 
                    {
                        detail.Product=await _unitOfWork.product.GetAsync(x=>x.ProductId==detail.ProductId);
                    }
                    return Ok(details);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
