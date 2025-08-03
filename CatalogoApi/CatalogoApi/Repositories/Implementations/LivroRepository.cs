using CatalogoApi.Data;
using CatalogoApi.Entities;
using CatalogoApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogoApi.Repositories.Implementations
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Livro> CreateAsync(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task<Livro?> UpdateAsync(Livro livro)
        {
            var livroUpdate = await _context.Livros.FindAsync(livro.Id);
            if(livroUpdate == null)
            {
                return null;
            }
            _context.Entry(livroUpdate).CurrentValues.SetValues(livro);
            await _context.SaveChangesAsync();
            return livroUpdate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if(livro == null)
            {
                return false;
            }
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<IEnumerable<Livro>> GetAllAsync()
        {
            return await _context.Livros.AsNoTracking().ToListAsync();
        }

        public async Task<Livro?> GetByIdAsync(int id)
        {
            return await _context.Livros.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
