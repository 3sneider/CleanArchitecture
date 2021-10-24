using solicitudes.Domain;
using Microsoft.EntityFrameworkCore;
using solisitudes.Persistence.Database.Configuracion;

namespace solisitudes.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Solicitud> Solicitudes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new SolicitudConfiguracion(modelBuilder.Entity<Solicitud>());
        }
    }
}
