using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstafoodApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryAddressesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeliveryAddressesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
                
        //        if ( != null)
        //        {
        //            return Ok();
        //        }
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByCustomerId(string customerId)
        {
            try
            {
                var obj = await _unitOfWork.deliveryAddress.GetAsync(x => x.CustomerId == customerId);
                if (obj != null)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(DeliveryAddressDTO obj)
        {
            try
            {
                DeliveryAddress newObj=new DeliveryAddress()
                {
                    CustomerId = obj.CustomerId,
                    Phone=obj.Phone,
                    Street=obj.Street,
                    City=obj.City,
                    PostalCode=obj.PostalCode,
                    State=obj.State,
                    LandMark=obj.LandMark,
                };
                await _unitOfWork.deliveryAddress.AddAsync(newObj);
                await _unitOfWork.Save();
                return Ok("Address Added.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(DeliveryAddressDTO obj)
        {
            try
            {
                var exist=await _unitOfWork.deliveryAddress.GetAsync(x=>x.CustomerId == obj.CustomerId);

                exist.Phone = obj.Phone;
                exist.Street = obj.Street;
                exist.City = obj.City;
                exist.PostalCode = obj.PostalCode;
                exist.State = obj.State;
                exist.LandMark = obj.LandMark;

                await _unitOfWork.deliveryAddress.Update(exist);
                await _unitOfWork.Save();
                return Ok("Address Updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
