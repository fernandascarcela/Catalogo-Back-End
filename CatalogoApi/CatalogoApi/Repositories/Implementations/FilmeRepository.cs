using CatalogoApi.Data;
using CatalogoApi.Entities;
using CatalogoApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogoApi.Repositories.Implementations
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly AppDbContext _context;

        public FilmeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Filme> CreateAsync(Filme filme)
        {
            await _context.Filmes.AddAsync(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
            {
                return false;
            }
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Filme?> UpdateAsync(Filme filme)
        {
            var filmeUpdate = await _context.Filmes.FindAsync(filme.Id);
            if(filmeUpdate == null)
            {
                return null;
            }
            _context.Entry(filmeUpdate).CurrentValues.SetValues(filme);
            await _context.SaveChangesAsync();
            return filmeUpdate;
        }

        public async Task<IEnumerable<Filme>> GetAllAsync()
        {
            return await _context.Filmes.AsNoTracking().ToListAsync();
        }

        public async Task<Filme?> GetByIdAsync(int id)
        {
            return await _context.Filmes.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
