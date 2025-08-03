namespace CatalogoApi.Entities
{
    public class PlaylistItem
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; } = null;
        public int? FilmeId { get; set; }
        public Filme? Filme { get; set; }
        public int? LivroId { get; set; }
        public Livro? Livro { get; set; }
    }
}
