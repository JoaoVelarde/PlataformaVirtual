using PlataformaVirtual.Application.Dto.Persona;
using PlataformaVirtual.Application.Ports.Input.Personas;
using PlataformaVirtual.Domain.Entities;
using PlataformaVirtual.Domain.Ports.Output.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Application.Ports.Implementations
{
    public class CreatePersonaUseCase : ICreatePersonaUseCase
    {
        private readonly IPersonaRepository _personaRepository;
        //private readonly IRabbitPublisherService _rabbitPublisher;

        public CreatePersonaUseCase(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
            //_rabbitPublisher = rabbitPublisherService;
        }

        public async Task<Guid> ExecuteAsync(CreatePersonaRequest request)
        {
            var existings = await _personaRepository.GetByDocumentoAsync(request.NroDocumento.NroDocumento, request.IdTipoDocumento);

            if (existings != null)
                throw new ApplicationException($"Persona con documento '{request.NroDocumento}' ya esta registrado.");

            var customer = Persona.Create(request.NroDocumento, request.IdTipoDocumento, request.Nombres, request.PrimerApellido, request.SegundoApellido, request.Direccion, request.Correo, request.Celular);

            await _personaRepository.AddAsync(customer);

            return customer.Id;
        }
    }
}
