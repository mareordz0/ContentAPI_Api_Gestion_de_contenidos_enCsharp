using Microsoft.EntityFrameworkCore;    
namespace ContentAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Contenido> Contenidos { get; set; } // Representa la tabla "Contenidos"
    }
}
