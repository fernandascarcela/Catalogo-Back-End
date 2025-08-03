using CatalogoApi.DTOs.Usuario;
using CatalogoApi.Entities;
using CatalogoApi.Helpers;
using CatalogoApi.Repositories.Interfaces;
using CatalogoApi.Services.Interfaces;

namespace CatalogoApi.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly TokenService _tokenService;

        public AuthService(IUsuarioRepository usuarioRepository, TokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<string?> LoginAsync(LoginDto loginDto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(loginDto.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginDto.Senha, usuario.SenhaHash))
            {
                return null;
            }

            var token = _tokenService.GenerateToken(usuario);
            return token;
        }

        public async Task<bool> RegisterAsync(RegisterUserDto registerDto)
        {
            var existingUser = await _usuarioRepository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return false;
            }

            var usuario = new Usuario
            {
                Nome = registerDto.Nome,
                Email = registerDto.Email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Senha)
            };

            await _usuarioRepository.CreateAsync(usuario);
            return true;
        }
    }
}
