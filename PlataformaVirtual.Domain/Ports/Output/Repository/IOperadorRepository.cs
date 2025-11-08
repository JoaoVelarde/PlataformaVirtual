using PlataformaVirtual.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Domain.Ports.Output.Repository
{
    public interface IOperadorRepository : IBaseRepository<Operador>
    {
        Task<Operador?> GetByIdPersonaAsync(Guid personaId);
    }
}
