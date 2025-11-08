using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaVirtual.Domain.Entities;

namespace PlataformaVirtual.Infrastructure.Configuration.EFCore
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.UsuarioCreaId)
                .IsRequired();

            builder.Property(e => e.FechaCrea)
                .IsRequired();

            builder.Property(e => e.UsuarioModificaId)
                .IsRequired(false);

            builder.Property(e => e.FechaModifica)
                .IsRequired(false);

            builder.Property(e => e.UsuarioEliminaId)
                .IsRequired(false);

            builder.Property(e => e.FechaElimina)
                .IsRequired(false);

            builder.Property(e => e.EstadoId)
                .HasColumnName("estado")
                .IsRequired()
                .HasConversion<string>() // Enum -> string (Activo/Eliminado)
                .HasMaxLength(20);
        }
    }
}
