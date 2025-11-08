using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaVirtual.Domain.Entities;

namespace PlataformaVirtual.Infrastructure.Configuration.EFCore
{
    public class OperadorEntityConfiguration: IEntityTypeConfiguration<Operador>
    {
        public void Configure(EntityTypeBuilder<Operador> builder)
        {
            builder.ToTable("operador", schema: "tramite");

            builder.Property(o => o.PersonaId)
                .HasColumnName("persona_id")
                .IsRequired();

            builder.HasOne(o => o.Persona)
                .WithMany()
                .HasForeignKey(o => o.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.FotoOperador)
            .HasColumnName("foto_operador")
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(o => o.Correo)
                .HasColumnName("correo")
                .HasMaxLength(150)
                .IsRequired();

            builder.HasMany(o => o.OperadorEntidades)
            .WithOne(oe => oe.Operador)
            .HasForeignKey(oe => oe.OperadorId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
