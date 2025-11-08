using Mapster;
using PlataformaVirtual.Application.Dto.Persona;
using PlataformaVirtual.Application.Ports.Input.Personas;
using PlataformaVirtual.Domain.Dto;
using PlataformaVirtual.Domain.Ports.Output.Repository;
using System.Threading.Tasks;

namespace PlataformaVirtual.Application.Ports.Implementations
{
    internal class GetPersonaUseCase : IGetPersonaUseCase
    {
        private readonly IPersonaRepository _personaRepository;
        public GetPersonaUseCase(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<List<GetPersonaResponse>> ExecuteAsync()
        {
            var result = await _personaRepository.ListAsync();
            return result.Adapt<List<GetPersonaResponse>>();
        }

    }
}
