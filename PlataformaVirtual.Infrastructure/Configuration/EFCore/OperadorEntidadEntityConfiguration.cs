using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaVirtual.Domain.Entities;

namespace PlataformaVirtual.Infrastructure.Configuration.EFCore
{
    public class OperadorEntidadEntityConfiguration: IEntityTypeConfiguration<OperadorEntidad>
    {
        public void Configure(EntityTypeBuilder<OperadorEntidad> builder)
        {
            builder.ToTable("operador_entidad", schema: "tramite");

            builder.Property(oe => oe.ExpedienteId)
                .HasColumnName("expediente_id")
                .IsRequired();

            builder.HasOne(oe => oe.Expediente)
                .WithMany()
                .HasForeignKey(oe => oe.ExpedienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(oe => oe.OperadorId)
                .HasColumnName("operador_id")
                .IsRequired();

            builder.HasOne(oe => oe.Operador)
                .WithMany()
                .HasForeignKey(oe => oe.OperadorId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
