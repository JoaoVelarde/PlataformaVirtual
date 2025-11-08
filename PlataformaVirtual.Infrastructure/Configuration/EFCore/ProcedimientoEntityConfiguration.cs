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
    public class ProcedimientoEntityConfiguration : IEntityTypeConfiguration<Procedimiento>
    {
        public void Configure(EntityTypeBuilder<Procedimiento> builder)
        {
            builder.ToTable("procedimiento", schema: "tramite");

           builder.Property(p => p.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasMany(p => p.Expedientes)
               .WithOne(e => e.Procedimiento)
               .HasForeignKey(e => e.ProcedimientoId)
               .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
