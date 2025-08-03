using CatalogoApi.DTOs.Filme;
using CatalogoApi.DTOs.Livro;

namespace CatalogoApi.Services.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroDto>> GetAllAsync();
        Task<LivroDto?> GetByIdAsync(int id);
        Task<LivroDto> CreateAsync(CreateLivroDto createDto);
        Task<LivroDto?> UpdateAsync(int id, UpdateLivroDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
