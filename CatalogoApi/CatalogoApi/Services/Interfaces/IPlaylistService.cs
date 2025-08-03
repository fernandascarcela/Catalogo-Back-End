using CatalogoApi.DTOs.Playlist;
using static CatalogoApi.DTOs.Playlist.AddItemToPlaylist;

namespace CatalogoApi.Services.Interfaces
{
    public interface IPlaylistService
    {
        Task<IEnumerable<PlaylistDto>> GetAllByUserIdAsync(int usuarioId);
        Task<PlaylistDto?> GetByIdAsync(int playlistId, int usuarioId);
        Task<PlaylistDto> CreateAsync(CreatePlaylistDto createDto, int usuarioId);
        Task<bool> AddItemAsync(int playlistId, AddItemToPlaylistDto itemDto, int usuarioId);
        Task<bool> RemoveItemAsync(int playlistId, int itemId, string itemType, int usuarioId);
        Task<bool> DeleteAsync(int playlistId, int usuarioId);
    }
}
