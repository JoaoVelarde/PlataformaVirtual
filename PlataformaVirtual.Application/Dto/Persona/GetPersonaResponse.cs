using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Application.Dto.Persona
{
    public class GetPersonaResponse
    {
        public string NroDocumento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
    }
}
