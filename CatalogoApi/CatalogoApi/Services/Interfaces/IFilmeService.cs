using CatalogoApi.DTOs.Filme;

namespace CatalogoApi.Services.Interfaces
{
    public interface IFilmeService
    {
        Task<IEnumerable<FilmeDto>> GetAllAsync();
        Task<FilmeDto?> GetByIdAsync(int id);
        Task<FilmeDto> CreateAsync(CreateFilmeDto createDto);
        Task<FilmeDto?> UpdateAsync(int id, UpdateFilmeDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
