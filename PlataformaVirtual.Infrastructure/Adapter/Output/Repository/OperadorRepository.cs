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
    public class OperadorRepository : BaseRepository<Operador>, IOperadorRepository
    {
        public OperadorRepository(TramiteDbContext context) : base(context)
        {
        }

        public async Task<Operador?> GetByIdPersonaAsync(Guid personaId)
        {
            return await _context.Operadores
                .FirstOrDefaultAsync(p => p.PersonaId == personaId);
        }
    }
}
