using System.ComponentModel.DataAnnotations;

namespace CatalogoApi.DTOs.Filme
{
    public class UpdateFilmeDto
    {
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public int Ano { get; set; }
        [Required]
        public string Diretor { get; set; } = string.Empty;
        public string UrlCapa { get; set; } = string.Empty;
    }
}
