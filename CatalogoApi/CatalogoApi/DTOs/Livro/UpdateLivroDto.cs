using System.ComponentModel.DataAnnotations;

namespace CatalogoApi.DTOs.Livro
{
    public class UpdateLivroDto
    {
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public int Ano { get; set; }
        [Required]
        public string Autor { get; set; } = string.Empty;
        public string UrlCapa { get; set; } = string.Empty;
    }
}
