using APIVisionary.Models;
using Microsoft.EntityFrameworkCore;

namespace APIVisionary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UsuariosModel> UsuariosTableContent { get; set; }
        public DbSet<ConteudoModel> ConteudoTableContent { get; set; }
        public DbSet<PlaylistItem> PlaylistItemsTableContent { get; set; }
        public DbSet<PlaylistVideos> PlaylisTableContent { get; set; }
    }
}
