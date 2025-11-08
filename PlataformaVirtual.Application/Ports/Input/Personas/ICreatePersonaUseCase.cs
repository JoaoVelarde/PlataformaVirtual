using PlataformaVirtual.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Application.Ports.Input.Personas
{
    public interface ICreatePersonaUseCase
    {
        Task<Guid> ExecuteAsync(CreatePersonaRequest request);
    }
}
