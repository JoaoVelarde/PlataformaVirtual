using Microsoft.EntityFrameworkCore;
using PlataformaVirtual.Domain.Entities;

namespace PlataformaVirtual.Infrastructure.Configuration.Context
{
    public class TramiteDbContext(DbContextOptions<TramiteDbContext> options) : DbContext(options)
    {
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Operador> Operadores { get; set; }
        public DbSet<OperadorCredencial> OperadorCredenciales { get; set; }
        public DbSet<OperadorEntidad> OperadorEntidades { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("tramite");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TramiteDbContext).Assembly);
        }
    }
}
 