using CatalogoApi.DTOs.Filme;
using CatalogoApi.Entities;
using CatalogoApi.Repositories.Interfaces;
using CatalogoApi.Services.Interfaces;

namespace CatalogoApi.Services.Implementations
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<FilmeDto> CreateAsync(CreateFilmeDto createDto)
        {
            var filme = new Filme
            {
                Titulo = createDto.Titulo,
                Ano = createDto.Ano,
                Diretor = createDto.Diretor,
                UrlCapa = createDto.UrlCapa
            };

            var novoFilme = await _filmeRepository.CreateAsync(filme);
            return MapToDto(novoFilme);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var filme = await _filmeRepository.GetByIdAsync(id);
            if (filme == null) return false;

            await _filmeRepository.DeleteAsync(id);
            return true;
        }
        public async Task<FilmeDto?> UpdateAsync(int id, UpdateFilmeDto updateDto)
        {
            var filmeUpdate = await _filmeRepository.GetByIdAsync(id);
            if(filmeUpdate == null)
            {
                return null;
            }
            filmeUpdate.Titulo = updateDto.Titulo;
            filmeUpdate.Ano = updateDto.Ano;
            filmeUpdate.Diretor = updateDto.Diretor;
            filmeUpdate.UrlCapa = updateDto.UrlCapa;

            var filmeUpdated = await _filmeRepository.UpdateAsync(filmeUpdate);
            return filmeUpdated == null ? null : MapToDto(filmeUpdated);
        }

        public async Task<IEnumerable<FilmeDto>> GetAllAsync()
        {
            var filmes = await _filmeRepository.GetAllAsync();
            return filmes.Select(MapToDto);
        }

        public async Task<FilmeDto?> GetByIdAsync(int id)
        {
            var filme = await _filmeRepository.GetByIdAsync(id);
            return filme == null ? null : MapToDto(filme);
        }
        private FilmeDto MapToDto(Filme filme)
        {
            return new FilmeDto
            {
                Id = filme.Id,
                Titulo = filme.Titulo,
                Ano = filme.Ano,
                Diretor = filme.Diretor,
                UrlCapa = filme.UrlCapa
            };
        }
    }
}
