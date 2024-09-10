using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.DataAccess.Models;
using InstafoodApp.Web.Client.DTO;

namespace InstafoodApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public UsersController(IUnitOfWork unitOfWork,IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }
        [HttpGet]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<User> objs = await _unitOfWork.user.GetAllAsync();
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                User user = await _unitOfWork.user.GetAsync(x => x.UserId == id);
                if (user !=null)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserDTO user)
        {
            User existUser=await _unitOfWork.user.GetAsync(x=>x.Email==user.Email);
            string? AdminCode = _config["SecureAdmin:Code"];
            if (existUser == null)
            {
                User newUser = new User() {
                     Email = user.Email,
                     Name = user.Name,
                     Password = user.Password,
                     Role = (AdminCode==user.AdminCode)?"Admin":"Customer"
                };
                await _unitOfWork.user.AddAsync(newUser);
                await _unitOfWork.Save();
                return Ok(new {
                    message = "Account successfully created.",
                    userId = newUser.UserId,
                    role = newUser.Role,
                    name = newUser.Name
                });
            }
            return BadRequest(new { message="Already have Account."});

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO l)
        {
            User existUser = await _unitOfWork.user.GetAsync(x => x.Email == l.Email);
            if (existUser != null && existUser.Password == l.Password) 
            {
                return Ok(new 
                { 
                    message = "Login Successfully.", 
                    userId=existUser.UserId,
                    role=existUser.Role,
                    name = existUser.Name
                });
            }
            return BadRequest(new { message = "Account not Found." });
        }        
    }
}
