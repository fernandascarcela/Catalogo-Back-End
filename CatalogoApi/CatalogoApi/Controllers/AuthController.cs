using CatalogoApi.DTOs.Usuario;
using CatalogoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerDto)
        {
            var success = await _authService.RegisterAsync(registerDto);
            if (!success)
            {
                return BadRequest("Usuário com este email já existe.");
            }
            return Ok("Usuário registrado com sucesso.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            if (token == null)
            {
                return Unauthorized("Email ou senha inválidos.");
            }
            return Ok(new { Token = token });
        }
    }
}
