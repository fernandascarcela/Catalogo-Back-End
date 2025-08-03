using System.ComponentModel.DataAnnotations;

namespace CatalogoApi.DTOs.Usuario
{
    public class RegisterUserDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
