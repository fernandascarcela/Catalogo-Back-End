using CatalogoApi.Data;
using CatalogoApi.Entities;
using CatalogoApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogoApi.Repositories.Implementations
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly AppDbContext _context;

        public PlaylistRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Playlist> CreateAsync(Playlist playlist)
        {
            await _context.Playlists.AddAsync(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }

        public async Task<IEnumerable<Playlist>> GetAllByUserIdAsync(int usuarioId)
        {
            return await _context.Playlists
                .Where(p => p.UsuarioId == usuarioId)
                .Include(p => p.Itens)
                    .ThenInclude(item =>item.Filme)
                .Include(p => p.Itens)
                    .ThenInclude(item => item.Livro)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Playlist?> GetByIdAsync(int playlistId, int usuarioId)
        {
            return await _context.Playlists
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == playlistId && p.UsuarioId == usuarioId);
        }

        public async Task<Playlist?> GetByIdWithItemsAsync(int playlistId, int usuarioId)
        {
            return await _context.Playlists
                .Include(p => p.Itens)
                    .ThenInclude(item => item.Filme)
                .Include(p => p.Itens)
                    .ThenInclude(item => item.Livro)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == playlistId && p.UsuarioId == usuarioId);
        }

        public async Task AddItemAsync(PlaylistItem item)
        {
            await _context.PlaylistItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemAsync(int playlistId, int itemId, string itemType, int usuarioId)
        {
            PlaylistItem? itemToRemove = null;
            if (itemType.Equals("Filme", StringComparison.OrdinalIgnoreCase))
            {
                itemToRemove = await _context.PlaylistItems
                    .FirstOrDefaultAsync(i => i.PlaylistId == playlistId && i.FilmeId == itemId && i.Playlist.UsuarioId == usuarioId);
            }
            else if (itemType.Equals("Livro", StringComparison.OrdinalIgnoreCase))
            {
                itemToRemove = await _context.PlaylistItems
                    .FirstOrDefaultAsync(i => i.PlaylistId == playlistId && i.LivroId == itemId && i.Playlist.UsuarioId == usuarioId);
            }

            if (itemToRemove != null)
            {
                _context.PlaylistItems.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int playlistId, int usuarioId)
        {
            var playlist = await _context.Playlists
                .FirstOrDefaultAsync(p => p.Id == playlistId && p.UsuarioId == usuarioId);

            if (playlist != null)
            {
                _context.Playlists.Remove(playlist);
                await _context.SaveChangesAsync();
            }
        }
    }
}
