
using CatalogoApi.DTOs.Livro;
using CatalogoApi.Entities;
using CatalogoApi.Repositories.Interfaces;
using CatalogoApi.Services.Interfaces;

namespace CatalogoApi.Services.Implementations
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<LivroDto> CreateAsync(CreateLivroDto createDto)
        {
            var livro = new Livro
            {
                Titulo = createDto.Titulo,
                Ano = createDto.Ano,
                Autor = createDto.Autor,
                UrlCapa = createDto.UrlCapa
            };

            var novoLivro = await _livroRepository.CreateAsync(livro);
            return MapToDto(novoLivro);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var livro = await _livroRepository.GetByIdAsync(id);
            if (livro == null) return false;

            await _livroRepository.DeleteAsync(id);
            return true;
        }
        public async Task<LivroDto?> UpdateAsync(int id, UpdateLivroDto updateDto)
        {
            var livroUpdate = await _livroRepository.GetByIdAsync(id);
            if (livroUpdate == null)
            {
                return null;
            }
            livroUpdate.Titulo = updateDto.Titulo;
            livroUpdate.Ano = updateDto.Ano;
            livroUpdate.Autor = updateDto.Autor;
            livroUpdate.UrlCapa = updateDto.UrlCapa;

            var livroUpdated = await _livroRepository.UpdateAsync(livroUpdate);
            return livroUpdated == null ? null : MapToDto(livroUpdated);
        }

        public async Task<IEnumerable<LivroDto>> GetAllAsync()
        {
            var livros = await _livroRepository.GetAllAsync();
            return livros.Select(MapToDto);
        }

        public async Task<LivroDto?> GetByIdAsync(int id)
        {
            var livro = await _livroRepository.GetByIdAsync(id);
            return livro == null ? null : MapToDto(livro);
        }
        private LivroDto MapToDto(Livro livro)
        {
            return new LivroDto
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Ano = livro.Ano,
                Autor = livro.Autor,
                UrlCapa = livro.UrlCapa
            };
        }
    }
}
