using CatalogoApi.DTOs.Filme;
using CatalogoApi.DTOs.Livro;
using CatalogoApi.DTOs.Playlist;
using CatalogoApi.Entities;
using CatalogoApi.Repositories.Interfaces;
using CatalogoApi.Services.Interfaces;
using static CatalogoApi.DTOs.Playlist.AddItemToPlaylist;

namespace CatalogoApi.Services.Implementations
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IFilmeRepository _filmeRepository;
        private readonly ILivroRepository _livroRepository;

        public PlaylistService(IPlaylistRepository playlistRepository, IFilmeRepository filmeRepository, ILivroRepository livroRepository)
        {
            _playlistRepository = playlistRepository;
            _filmeRepository = filmeRepository;
            _livroRepository = livroRepository;
        }

        public async Task<bool> AddItemAsync(int playlistId, AddItemToPlaylistDto itemDto, int usuarioId)
        {
            var playlist = await _playlistRepository.GetByIdAsync(playlistId, usuarioId);
            if (playlist == null)
            {
                return false;
            }

            var item = new PlaylistItem { PlaylistId = playlistId };
            if (itemDto.Tipo == ItemType.Filme)
            {
                var filme = await _filmeRepository.GetByIdAsync(itemDto.ItemId);
                if (filme == null) return false;
                item.FilmeId = itemDto.ItemId;
            }
            else if (itemDto.Tipo == ItemType.Livro)
            {
                var livro = await _livroRepository.GetByIdAsync(itemDto.ItemId);
                if (livro == null) return false;
                item.LivroId = itemDto.ItemId;
            }
            else
            {
                return false;
            }

            await _playlistRepository.AddItemAsync(item);
            return true;
        }

        public async Task<PlaylistDto> CreateAsync(CreatePlaylistDto createDto, int usuarioId)
        {
            var playlist = new Playlist
            {
                Nome = createDto.Nome,
                UsuarioId = usuarioId
            };
            var novaPlaylist = await _playlistRepository.CreateAsync(playlist);
            return MapToDto(novaPlaylist);
        }

        public async Task<bool> DeleteAsync(int playlistId, int usuarioId)
        {
            var playlist = await _playlistRepository.GetByIdAsync(playlistId, usuarioId);
            if (playlist == null) return false;

            await _playlistRepository.DeleteAsync(playlistId, usuarioId);
            return true;
        }

        public async Task<IEnumerable<PlaylistDto>> GetAllByUserIdAsync(int usuarioId)
        {
            var playlists = await _playlistRepository.GetAllByUserIdAsync(usuarioId);
            return playlists.Select(MapToDto);
        }

        public async Task<PlaylistDto?> GetByIdAsync(int playlistId, int usuarioId)
        {
            var playlist = await _playlistRepository.GetByIdWithItemsAsync(playlistId, usuarioId);
            return playlist == null ? null : MapToDto(playlist);
        }

        public async Task<bool> RemoveItemAsync(int playlistId, int itemId, string itemType, int usuarioId)
        {
            await _playlistRepository.RemoveItemAsync(playlistId, itemId, itemType, usuarioId);
            return true;
        }
        private PlaylistDto MapToDto(Playlist playlist)
        {
            return new PlaylistDto
            {
                Id = playlist.Id,
                Nome = playlist.Nome,
                Itens = playlist.Itens?.Select(item => new PlaylistItemDto
                {
                    Tipo = item.FilmeId.HasValue ? "Filme" : "Livro",
                    Filme = item.FilmeId.HasValue ? new FilmeDto
                    {
                        Id = item.Filme!.Id,
                        Titulo = item.Filme.Titulo,
                        Ano = item.Filme.Ano,
                        Diretor = item.Filme.Diretor,
                        UrlCapa = item.Filme.UrlCapa
                    } : null,
                    Livro = item.LivroId.HasValue ? new LivroDto
                    {
                        Id = item.Livro!.Id,
                        Titulo = item.Livro.Titulo,
                        Ano = item.Livro.Ano,
                        Autor = item.Livro.Autor,
                        UrlCapa = item.Livro.UrlCapa
                    } : null
                }).ToList() ?? new List<PlaylistItemDto>()
            };
        }
    }
}
