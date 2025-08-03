using CatalogoApi.DTOs.Playlist;
using CatalogoApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CatalogoApi.DTOs.Playlist.AddItemToPlaylist;
using System.Security.Claims;

namespace CatalogoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;
        private int UsuarioId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        public PlaylistsController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserPlaylists()
        {
            var playlists = await _playlistService.GetAllByUserIdAsync(UsuarioId);
            return Ok(playlists);
        }

        [HttpGet("{playlistId}")]
        public async Task<IActionResult> GetPlaylistById(int playlistId)
        {
            var playlist = await _playlistService.GetByIdAsync(playlistId, UsuarioId);
            if (playlist == null)
            {
                return NotFound("Playlist não encontrada ou não pertence ao usuário.");
            }
            return Ok(playlist);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist(CreatePlaylistDto createDto)
        {
            var novaPlaylist = await _playlistService.CreateAsync(createDto, UsuarioId);
            return CreatedAtAction(nameof(GetPlaylistById), new { playlistId = novaPlaylist.Id }, novaPlaylist);
        }

        [HttpDelete("{playlistId}")]
        public async Task<IActionResult> DeletePlaylist(int playlistId)
        {
            var success = await _playlistService.DeleteAsync(playlistId, UsuarioId);
            if (!success)
            {
                return NotFound("Playlist não encontrada ou não pertence ao usuário.");
            }
            return NoContent();
        }

        [HttpPost("{playlistId}/items")]
        public async Task<IActionResult> AddItemToPlaylist(int playlistId, AddItemToPlaylistDto itemDto)
        {
            var success = await _playlistService.AddItemAsync(playlistId, itemDto, UsuarioId);
            if (!success)
            {
                return BadRequest("Não foi possível adicionar o item. Verifique se a playlist e o item existem.");
            }
            return Ok("Item adicionado com sucesso.");
        }

        [HttpDelete("{playlistId}/items/{itemType}/{itemId}")]
        public async Task<IActionResult> RemoveItemFromPlaylist(int playlistId, string itemType, int itemId)
        {
            if (!itemType.Equals("filme", StringComparison.OrdinalIgnoreCase) && !itemType.Equals("livro", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("O tipo do item deve ser 'filme' ou 'livro'.");
            }

            var success = await _playlistService.RemoveItemAsync(playlistId, itemId, itemType, UsuarioId);
            if (!success)
            {
                return NotFound("Item ou playlist não encontrado para este usuário.");
            }
            return NoContent();
        }
    }
}
