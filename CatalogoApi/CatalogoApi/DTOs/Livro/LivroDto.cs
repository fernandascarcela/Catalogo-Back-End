namespace CatalogoApi.DTOs.Livro
{
    public class LivroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Autor { get; set; } = string.Empty;
        public string UrlCapa { get; set; } = string.Empty;
    }
}
