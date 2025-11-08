using Microsoft.EntityFrameworkCore;
using PlataformaVirtual.Domain.Dto;
using PlataformaVirtual.Domain.Entities;
using PlataformaVirtual.Domain.Ports.Output.Repository;
using PlataformaVirtual.Infrastructure.Configuration.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<ICollection<TResult>> ListAsync<TResult>(PersonaFilter filter, Expression<Func<Persona, TResult>> selector)
        {
            var query = _context.Personas.AsQueryable();

            if (!string.IsNullOrEmpty(filter.NroDocumento))
                query = query.Where(p => p.NroDocumento.NroDocumento == filter.NroDocumento);

            if (!string.IsNullOrEmpty(filter.Nombre))
                query = query.Where(p => p.Nombres == filter.Nombre);

            if (!string.IsNullOrEmpty(filter.Correo))
                query = query.Where(p => p.Correo == filter.Correo);

            return await query
                .OrderBy(p => p.Id)
                .Select(selector)
                .ToListAsync();
        }
    }
}
