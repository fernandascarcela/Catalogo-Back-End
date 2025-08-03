namespace CatalogoApi.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null;
        public ICollection<PlaylistItem> Itens { get; set; } = new List<PlaylistItem>();
    }
}
