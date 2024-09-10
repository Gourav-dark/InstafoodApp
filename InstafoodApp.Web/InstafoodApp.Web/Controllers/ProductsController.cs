using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstafoodApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Product> objs = await _unitOfWork.product.GetAllAsync();
                if (objs.Count() > 0)
                {
                    return Ok(objs);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("filter")]
        public async Task<IActionResult> GetByName([FromQuery] string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return BadRequest("Filter parameter is required.");
            }
            var products = await _unitOfWork.product.GetAllAsync(x => x.ProductName.ToLower().Contains(filter.ToLower()));
            if (products.Count() > 0)
            {
                return Ok(products);
            }
            else
            {
                return NotFound(new { message="Product not found."});
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            Product prodcut = await _unitOfWork.product.GetAsync(x => x.ProductId == id);
            if (prodcut != null) 
            {
                return Ok(prodcut);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO obj)
        {
            try
            {
                Product newProduct = new Product()
                {
                    ProductName = obj.ProductName,
                    ProductDescription = obj.ProductDescription,
                    UnitPrice = obj.UnitPrice,
                    ProductPicture=obj.ImageUrl
                };
                await _unitOfWork.product.AddAsync(newProduct);
                await _unitOfWork.Save();
                return Ok(new { message = "Product Added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductDTO obj)
        {
            Product existProduct = await _unitOfWork.product.GetAsync(x => x.ProductId == id);
            if (existProduct != null)
            {
                existProduct.ProductName = obj.ProductName;
                existProduct.ProductDescription = obj.ProductDescription;
                existProduct.UnitPrice = obj.UnitPrice;
                await _unitOfWork.product.Update(existProduct);
                await _unitOfWork.Save();
                return Ok(new { message = "Updated successfully." });
            }
            return BadRequest();
        }
        [HttpPut("image/{id}")]
        public async Task<IActionResult> ImageUplaod(int id,[FromForm]IFormFile file)
        {
            try
            {
                Product existProduct = await _unitOfWork.product.GetAsync(x => x.ProductId == id);
                if (file != null && file.Length > 0 && existProduct!=null) 
                {
                    string fileName = "product_" + id.ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "product", fileName);
                    if (System.IO.File.Exists(productPath))
                    {
                        System.IO.File.Delete(productPath);
                    }
                    using (var stream = new FileStream(productPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    existProduct.ProductName = fileName;
                    await _unitOfWork.product.Update(existProduct);
                    await _unitOfWork.Save();
                    return Ok(new { message = "Image Uploaded successfully." });
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product existProduct = await _unitOfWork.product.GetAsync(x => x.ProductId == id);
            if (existProduct != null)
            {
                await _unitOfWork.product.RemoveAsync(existProduct);
                await _unitOfWork.Save();
                return Ok(new { message = "Product is Removed." });
            }
            return BadRequest();
        }
    }
}
