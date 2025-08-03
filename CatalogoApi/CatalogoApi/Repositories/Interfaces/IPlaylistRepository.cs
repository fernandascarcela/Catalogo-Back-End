using CatalogoApi.Entities;

namespace CatalogoApi.Repositories.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> GetAllByUserIdAsync(int usuarioId);
        Task<Playlist?> GetByIdAsync(int playlistId, int usuarioId);
        Task<Playlist?> GetByIdWithItemsAsync(int playlistId, int usuarioId);
        Task<Playlist> CreateAsync(Playlist playlist);
        Task AddItemAsync(PlaylistItem item);
        Task RemoveItemAsync(int playlistId, int itemId, string itemType, int usuarioId);
        Task DeleteAsync(int playlistId, int usuarioId);
    }
}
