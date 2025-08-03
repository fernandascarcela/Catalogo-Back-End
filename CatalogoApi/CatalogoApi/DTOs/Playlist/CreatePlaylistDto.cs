using System.ComponentModel.DataAnnotations;

namespace CatalogoApi.DTOs.Playlist
{
    public class CreatePlaylistDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
    }
}
