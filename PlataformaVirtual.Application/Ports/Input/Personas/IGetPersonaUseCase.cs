using PlataformaVirtual.Application.Dto.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Application.Ports.Input.Personas
{
    public interface IGetPersonaUseCase
    {
        Task<List<GetPersonaResponse>> ExecuteAsync();
        //IQueryable<GetPersonaResponse> Execute();
        //Task<List<GetPersonaResponse>> ExecuteAsync(PersonaFilterRequest request);
    }
}
