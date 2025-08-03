using CatalogoApi.DTOs.Livro;
using CatalogoApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var livros = await _livroService.GetAllAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var livro = await _livroService.GetByIdAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLivroDto createDto)
        {
            var novoLivro = await _livroService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = novoLivro.Id }, novoLivro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateLivroDto updateDto)
        {
            var livroAtualizado = await _livroService.UpdateAsync(id, updateDto);
            if (livroAtualizado == null)
            {
                return NotFound();
            }
            return Ok(livroAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _livroService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
