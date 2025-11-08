using PlataformaVirtual.Application.Constants;
using PlataformaVirtual.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Application.Dto
{
    public class CreatePersonaRequest
    {
        //[Required(ErrorMessage = CatalogMessage.ERROR_MESSAGE_REQUIRED)]
        //public string Name { get; set; } = default!;

        //[Required(ErrorMessage = CatalogMessage.ERROR_MESSAGE_REQUIRED)]
        //[MaxLength(20, ErrorMessage = CatalogMessage.ERROR_MESSAGE_MAXLEN)]
        //public string DocumentNumber { get; set; } = default!;
        [Required(ErrorMessage = CatalogMessage.ERROR_MESSAGE_REQUIRED)]
        public int IdTipoDocumento { get; private set; }
        [Required(ErrorMessage = CatalogMessage.ERROR_MESSAGE_REQUIRED)]
        [MaxLength(20, ErrorMessage = CatalogMessage.ERROR_MESSAGE_MAXLEN)]
        public DocumentoIdentidad NroDocumento { get; set; }
        [Required(ErrorMessage = CatalogMessage.ERROR_MESSAGE_REQUIRED)]
        public string Nombres { get; set; } = default!;
        public string PrimerApellido { get; private set; } = default!;
        public string SegundoApellido { get; private set; } = default!;
        public string Direccion { get; set; } = default!;
        [Required(ErrorMessage = CatalogMessage.ERROR_MESSAGE_REQUIRED)]
        public string Correo { get; set; } = default!;
        [Required(ErrorMessage = CatalogMessage.ERROR_MESSAGE_REQUIRED)]
        public string Celular { get; set; } = default!;
    }
}
