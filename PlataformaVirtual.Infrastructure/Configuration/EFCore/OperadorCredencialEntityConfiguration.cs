using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaVirtual.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Infrastructure.Configuration.EFCore
{
    public class OperadorCredencialEntityConfiguration : IEntityTypeConfiguration<OperadorCredencial>
    {
        public void Configure(EntityTypeBuilder<OperadorCredencial> builder)
        {
            builder.ToTable("operador_credencial", schema: "tramite");

            builder.Property(oc => oc.NumeroCredencial)
                .HasColumnName("numero_credencial")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(oc => oc.FechaVencimiento)
                .HasColumnName("fecha_vencimiento")
                .IsRequired();

            builder.Property(oc => oc.OperadorId)
                .HasColumnName("operador_id")
                .IsRequired();

            builder.HasOne(oc => oc.Operador)
                .WithMany(o => o.Credenciales)
                .HasForeignKey(oc => oc.OperadorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(oc => oc.ExpedienteId)
                .HasColumnName("expediente_id")
                .IsRequired();

            builder.HasOne(oc => oc.Expediente)
                .WithMany(o => o.Credenciales)
                .HasForeignKey(oc => oc.ExpedienteId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
