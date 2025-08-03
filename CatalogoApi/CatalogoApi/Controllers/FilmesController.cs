using CatalogoApi.DTOs.Filme;
using CatalogoApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmesController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var filmes = await _filmeService.GetAllAsync();
            return Ok(filmes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var filme = await _filmeService.GetByIdAsync(id);
            if(filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFilmeDto createDto)
        {
            var novoFilme = await _filmeService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetAll), new { id = novoFilme.Id }, novoFilme);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateFilmeDto updateDto)
        {
            var filmeUpdate = await _filmeService.UpdateAsync(id, updateDto);
            if(filmeUpdate == null)
            {
                return NotFound();
            }
            return Ok(filmeUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var filme = await _filmeService.GetByIdAsync(id);
            if (filme == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
