using Microsoft.AspNetCore.Mvc;
using Project.Application.Contract;
using Project.Application.DTOs;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDtos loginDto)
        {
            // Hardcoded users for demonstration as requested
            if (loginDto.Username == "admin" && loginDto.Password == "admin123")
            {
                var token = _authService.GenerateToken("1", "admin", "Admin");
                return Ok(new { Token = token });
            }
            else if (loginDto.Username == "user" && loginDto.Password == "user123")
            {
                var token = _authService.GenerateToken("2", "user", "User");
                return Ok(new { Token = token });
            }

            return Unauthorized(new { message = "Invalid username or password" });
        }
    }
}