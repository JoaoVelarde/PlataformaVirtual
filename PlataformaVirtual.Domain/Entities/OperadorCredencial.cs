using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Domain.Entities
{
    public class OperadorCredencial : BaseEntity
    {
        public string NumeroCredencial { get; private set; }
        public Guid OperadorId { get; private set; }
        public Operador Operador { get; private set; }
        public Guid ExpedienteId { get; private set; }
        public Expediente Expediente { get; private set; }
        public DateTime FechaVencimiento { get; private set; }

        public OperadorCredencial()
        {
        }

        public OperadorCredencial(string numeroCredencial, Guid operadorId, Guid expedienteId)
        {
            NumeroCredencial = numeroCredencial;
            OperadorId = operadorId;
            ExpedienteId = expedienteId;
            FechaVencimiento = DateTime.Now.AddYears(3);
        }


    }
}
