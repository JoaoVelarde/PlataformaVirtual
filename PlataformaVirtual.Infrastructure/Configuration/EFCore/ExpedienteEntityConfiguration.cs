using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaVirtual.Domain.Entities;
using PlataformaVirtual.Domain.ValueObjects;

namespace PlataformaVirtual.Infrastructure.Configuration.EFCore
{
    public class ExpedienteEntityConfiguration : IEntityTypeConfiguration<Expediente>
    {
        public void Configure(EntityTypeBuilder<Expediente> builder)
        {
            builder.ToTable("expediente", schema: "tramite");

            builder.OwnsOne(e => e.NroExpediente, nro =>
            {
                nro.Property(p => p.Valor)
                    .HasColumnName("nro_expediente")
                    .HasMaxLength(20)
                    .IsRequired();

                nro.HasIndex(p => p.Valor)
                    .IsUnique();
            });

            builder.Property(e => e.ProcedimientoId)
                .HasColumnName("procedimiento_id")
                .IsRequired();

            builder.HasOne(e => e.Procedimiento)
                .WithMany(p => p.Expedientes)
                .HasForeignKey(e => e.ProcedimientoId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
