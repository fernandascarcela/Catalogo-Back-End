using CatalogoApi.DTOs.Usuario;

namespace CatalogoApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterUserDto registerDto);
        Task<string?> LoginAsync(LoginDto loginDto);
    }
}
