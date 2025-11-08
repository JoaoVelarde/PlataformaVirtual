using PlataformaVirtual.Domain.Exceptions;
using System.Text.Json.Serialization;

namespace PlataformaVirtual.Domain.ValueObjects
{
    public record DocumentoIdentidad
    {
        public int TipoDocumentoId { get; private init; }
        public string NroDocumento { get; private init; }
        
        [JsonConstructor]
        private DocumentoIdentidad(int tipoDocumentoId, string nroDocumento)
        {
            TipoDocumentoId = tipoDocumentoId;
            NroDocumento = nroDocumento;
        }
        private DocumentoIdentidad() { }

        public static DocumentoIdentidad Create(int tipoDocumentoId, string nroDocumento)
        {
            if (tipoDocumentoId == 0)
                throw new DomainException("El tipo de documento es obligatorio.");

            if (string.IsNullOrWhiteSpace(nroDocumento))
                throw new DomainException("El número de documento es obligatorio.");

            switch (tipoDocumentoId)
            {
                case 1: //DNI
                    if (nroDocumento.Length != 8 || !nroDocumento.All(char.IsDigit))
                        throw new DomainException("El DNI debe tener exactamente 8 dígitos.");
                    break;

                case 2: //CE
                    if (nroDocumento.Length < 9 || nroDocumento.Length > 12)
                        throw new DomainException("El CE debe tener entre 9 y 12 caracteres.");
                    break;

                case 3: //PTP
                    if (nroDocumento.Length != 11 || !nroDocumento.All(char.IsDigit))
                        throw new DomainException("El PTP debe tener exactamente 11 dígitos.");
                    break;

                default:
                    throw new DomainException($"Tipo de documento {tipoDocumentoId} no soportado.");
            }

            return new DocumentoIdentidad(tipoDocumentoId, nroDocumento);

        }
        //public override string ToString() => $"{tipoDocumentoId}: {nroDocumento}";

    }
}
