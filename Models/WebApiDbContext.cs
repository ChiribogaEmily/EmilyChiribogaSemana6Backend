using Microsoft.EntityFrameworkCore;

namespace EmilyChiribogaSemana6Backend.Models
{
    public class WebApiDbContext: DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EventoModel> Eventos { get; set; }
        public DbSet<FacturaModel> Facturas { get; set; }
    }
}
