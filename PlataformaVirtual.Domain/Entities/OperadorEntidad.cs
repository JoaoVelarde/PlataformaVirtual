using PlataformaVirtual.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Domain.Entities
{
    public class OperadorEntidad : BaseEntity
    {
        public Guid ExpedienteId { get; private set; }
        public Expediente Expediente { get; private set; }
        public Guid OperadorId { get; private set; }
        public Operador Operador { get; private set; }

        private OperadorEntidad() { }

        public OperadorEntidad(Guid expedienteId, Guid operadorId)
        {
            if (expedienteId == Guid.Empty)
                throw new DomainException("El expediente es obligatorio.");

            if (operadorId == Guid.Empty)
                throw new DomainException("El operador es obligatorio.");

            ExpedienteId = expedienteId;
            OperadorId = operadorId;
        }
    }
}
