namespace CatalogoApi.DTOs.Playlist
{
    public class PlaylistDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ICollection<PlaylistItemDto> Itens { get; set; } = new List<PlaylistItemDto>();
    }
}

