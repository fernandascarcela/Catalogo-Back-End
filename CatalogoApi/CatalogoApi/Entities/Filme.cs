namespace CatalogoApi.Entities
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Diretor { get; set; } = string.Empty;
        public string UrlCapa { get; set; } = string.Empty;
    }
}
