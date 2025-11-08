using PlataformaVirtual.Domain.Exceptions;
using PlataformaVirtual.Domain.ValueObjects;

namespace PlataformaVirtual.Domain.Entities
{
    public class Persona : BaseEntity
    {
        public int IdTipoDocumento { get; private set; }
        public DocumentoIdentidad NroDocumento { get; private set; }
        public string Nombres { get; private set; }
        public string PrimerApellido { get; private set; }
        public string SegundoApellido { get; private set; }
        public string Direccion { get; private set; }
        public string Correo { get; private set; }
        public string Celular { get; private set; }
        public Persona()
        {

        }
        public Persona(DocumentoIdentidad nroDocumento, int idTipoDocumento, string nombres, string primerApellido, string segundoApellido, string direccion, string correo, string celular)
        {
            NroDocumento = nroDocumento;
            IdTipoDocumento = idTipoDocumento;
            Nombres = nombres;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Direccion = direccion;
            Correo = correo;
            Celular = celular;
        }

        public static Persona Create(DocumentoIdentidad nroDocumento, int idTipoDocumento, string nombres, string primerApellido, string segundoApellido, string direccion, string correo, string celular)
        {
            if (string.IsNullOrEmpty(nroDocumento.NroDocumento))
                throw new DomainException("El número de documento es requerido");

            if (string.IsNullOrEmpty(nombres))
                throw new DomainException("El nombre de la persona es requerido");

            if (string.IsNullOrEmpty(direccion))
                throw new DomainException("La dirección de la persona es requerido");

            if (string.IsNullOrEmpty(correo))
                throw new DomainException("El correo de la persona es requerido");

            if (string.IsNullOrEmpty(celular))
                throw new DomainException("El celular de la persona es requerido");

            return new Persona(nroDocumento, idTipoDocumento, nombres, primerApellido, segundoApellido, direccion, correo, celular);
        }
    }
}
