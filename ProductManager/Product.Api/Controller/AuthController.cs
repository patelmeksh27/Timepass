using Microsoft.AspNetCore.Mvc;
using Project.Application.Contract;
using Project.Application.DTOs;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
   private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var token = await _service.RegisterAsync(dto);
        return Ok(new { token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDtos dto)
    {
        var token = await _service.LoginAsync(dto);
        return Ok(new { token });
    }}
}