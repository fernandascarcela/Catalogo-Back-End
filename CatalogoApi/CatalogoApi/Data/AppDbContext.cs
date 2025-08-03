using CatalogoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistItem> PlaylistItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
            });


            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasOne(p => p.Usuario)      
                      .WithMany(u => u.Playlists)   
                      .HasForeignKey(p => p.UsuarioId) 
                      .OnDelete(DeleteBehavior.Cascade); 
            });


            modelBuilder.Entity<PlaylistItem>(entity =>
            {
                entity.HasOne(pi => pi.Playlist)
                      .WithMany(p => p.Itens)
                      .HasForeignKey(pi => pi.PlaylistId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pi => pi.Filme)
                      .WithMany() 
                      .HasForeignKey(pi => pi.FilmeId)
                      .IsRequired(false) 
                      .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(pi => pi.Livro)
                      .WithMany() 
                      .HasForeignKey(pi => pi.LivroId)
                      .IsRequired(false) 
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
        }
}
