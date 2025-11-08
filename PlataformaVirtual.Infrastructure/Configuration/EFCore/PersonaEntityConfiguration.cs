using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaVirtual.Domain.Entities;

namespace PlataformaVirtual.Infrastructure.Configuration.EFCore
{
    public class PersonaEntityConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("persona", schema: "tramite");

            builder.Property(p => p.IdTipoDocumento)
             .HasColumnName("id_tipo_documento")
             .IsRequired();

           
            builder.Property(p => p.Nombres)
                .HasColumnName("nombres")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.PrimerApellido)
                .HasColumnName("primer_apellido")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.SegundoApellido)
                .HasColumnName("segundo_apellido")
                .HasMaxLength(100);

            builder.Property(p => p.Direccion)
                .HasColumnName("direccion")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Correo)
                .HasColumnName("correo")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Celular)
                .HasColumnName("celular")
                .HasMaxLength(20)
                .IsRequired();

            builder.OwnsOne(p => p.NroDocumento, nroDoc =>
            {
                nroDoc.Property(d => d.NroDocumento)
                    .HasColumnName("nro_documento")
                    .HasMaxLength(20)
                    .IsRequired();
            });

        }
    }
}
