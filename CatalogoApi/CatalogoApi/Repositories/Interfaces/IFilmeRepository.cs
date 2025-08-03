using CatalogoApi.Entities;

namespace CatalogoApi.Repositories.Interfaces
{
    public interface IFilmeRepository
    {
        Task<IEnumerable<Filme>> GetAllAsync();
        Task<Filme?> GetByIdAsync(int id);
        Task<Filme> CreateAsync(Filme filme);
        Task<Filme> UpdateAsync(Filme filme);
        Task<bool> DeleteAsync(int id);
    }
}
