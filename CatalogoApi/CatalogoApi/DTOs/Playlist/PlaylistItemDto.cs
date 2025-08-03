using CatalogoApi.DTOs.Filme;
using CatalogoApi.DTOs.Livro;
using System.Text.Json.Serialization;

namespace CatalogoApi.DTOs.Playlist
{
    public class PlaylistItemDto
    {
        public string Tipo { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FilmeDto? Filme { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LivroDto? Livro { get; set; }
    }
}
