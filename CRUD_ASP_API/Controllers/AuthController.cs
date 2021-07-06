using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD_ASP_API.Services;
using CRUD_DAL.Entities;
using CRUD_Logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ASP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;

        public AuthController(IUserService userService, ISessionService sessionService)
        {
            _userService = userService;
            _sessionService = sessionService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(User user)
        {
            await _userService.AddUserAsync(user);
            return Created("success", user.Id);//TODO introduce consts
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(User user)
        {
            var validationResult = await _userService.ValidateUserAsync(user);
            if (!validationResult.IsSuccessful)
            {
                return BadRequest("Invalid Credentials");
            }

            var authCookie = await _sessionService.CreateAuthCookieAsync(validationResult.Id);
            Response.Cookies.Append("jwt", authCookie, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok("Success");
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult LogoutAsync()
        {
            Response.Cookies.Delete("jwt");

            return Ok("Success");
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUserAsync()
        {
            var cookie = Request.Cookies["jwt"];

            var id = await _sessionService.GetIdFromAuthCookieAsync(cookie);

            if (id != -1) //TODO remove implicit contract
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user != null)
                {
                    return Ok(user.Email);
                }
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("products")]
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
          return await _userService.GetAllProductsAsync();
        }
    }
}