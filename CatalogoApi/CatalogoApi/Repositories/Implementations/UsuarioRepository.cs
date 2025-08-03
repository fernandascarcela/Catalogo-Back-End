using CatalogoApi.Data;
using CatalogoApi.Entities;
using CatalogoApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogoApi.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
    }
}
