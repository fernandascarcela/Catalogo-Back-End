using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CatalogoApi.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
