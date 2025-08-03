using CatalogoApi.Entities;

namespace CatalogoApi.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario> CreateAsync(Usuario usuario);

    }
}
