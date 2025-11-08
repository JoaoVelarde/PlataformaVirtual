using PlataformaVirtual.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Domain.Entities
{
    public class Operador : BaseEntity
    {
        //public string NroDocumento { get; private set; }
        public string FotoOperador { get; private set; }
        public Guid PersonaId { get; private set; }
        public Persona Persona { get; private set; }
        public string Correo { get; private set; }
        public ICollection<OperadorCredencial> Credenciales { get; private set; } = new List<OperadorCredencial>();
        public ICollection<OperadorEntidad> OperadorEntidades { get; private set; } = new List<OperadorEntidad>();
        public Operador()
        {

        }

        public Operador(Guid personaId, string fotoOperador, string correo)
        {
            FotoOperador = fotoOperador;
            PersonaId = personaId;
            Correo = correo;
        }

        public static Operador Create(Guid personaId, string fotoOperador, string correo)
        {
            if (fotoOperador == null)
                throw new DomainException("Foto de operador es requerido");

            if (personaId == Guid.Empty)
                throw new DomainException("La Persona es requerida");

            if (string.IsNullOrEmpty(correo) || !correo.Contains("@"))
                throw new DomainException("El correo es requerido");

            return new Operador(personaId, fotoOperador, correo);
        }
    }
}
