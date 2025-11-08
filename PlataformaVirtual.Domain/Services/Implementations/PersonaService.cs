using PlataformaVirtual.Domain.Entities;
using PlataformaVirtual.Domain.Ports.Output.Repository;
using PlataformaVirtual.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Domain.Services.Implementations
{
    public class PersonaService: IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

    }
}
