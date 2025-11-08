using PlataformaVirtual.Domain.Exceptions;
using PlataformaVirtual.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Domain.Entities
{
    public class Expediente : BaseEntity
    {
        public NumeroExpediente NroExpediente { get; private set; }
        public Guid ProcedimientoId { get; private set; }
        public Procedimiento Procedimiento { get; private set; }
        public ICollection<OperadorCredencial> Credenciales { get; private set; } = new List<OperadorCredencial>();
        public Expediente()
        {

        }

        public Expediente(NumeroExpediente nroExpediente, Guid procedimientoId)
        {
            NroExpediente = nroExpediente;
            ProcedimientoId = procedimientoId;
        }

        public static Expediente Create(Guid procedimientoId, int correlativo)
        {
            if (procedimientoId == Guid.Empty)
                throw new DomainException("El Expediente es requerido");

            var nroExpediente = NumeroExpediente.Create(correlativo);
            return new Expediente(nroExpediente, procedimientoId);
        }
    }


}
