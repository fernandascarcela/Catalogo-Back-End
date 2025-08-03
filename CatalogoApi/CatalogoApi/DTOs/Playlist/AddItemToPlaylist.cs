using System.ComponentModel.DataAnnotations;

namespace CatalogoApi.DTOs.Playlist
{
    public class AddItemToPlaylist
    {
        public enum ItemType
        {
            Filme,
            Livro
        }

        public class AddItemToPlaylistDto
        {
            [Required]
            public int ItemId { get; set; }

            [Required]
            public ItemType Tipo { get; set; }
        }
    }
}
