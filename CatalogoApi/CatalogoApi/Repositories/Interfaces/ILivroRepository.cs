using CatalogoApi.Entities;

namespace CatalogoApi.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> GetAllAsync();
        Task<Livro?> GetByIdAsync(int id);
        Task<Livro> CreateAsync(Livro livro);
        Task<Livro> UpdateAsync(Livro livro);
        Task<bool> DeleteAsync(int id);
    }
}
