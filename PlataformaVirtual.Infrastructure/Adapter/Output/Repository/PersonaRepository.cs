using Microsoft.EntityFrameworkCore;
using PlataformaVirtual.Domain.Entities;
using PlataformaVirtual.Domain.Ports.Output.Repository;
using PlataformaVirtual.Infrastructure.Configuration.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Infrastructure.Adapter.Output.Repository
{
    public class PersonaRepository : BaseRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(TramiteDbContext contexto) : base(contexto)
        {
        }

        public async Task<Persona?> GetByDocumentoAsync(string nroDocumento, int idTipoDocumento)
        {
            return await _context.Personas
                .FirstOrDefaultAsync(p => p.NroDocumento.NroDocumento == nroDocumento && p.IdTipoDocumento == idTipoDocumento);
        }
    }
}
