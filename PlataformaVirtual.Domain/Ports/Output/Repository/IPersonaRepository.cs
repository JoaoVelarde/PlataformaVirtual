using PlataformaVirtual.Domain.Dto;
using PlataformaVirtual.Domain.Entities;
using System.Linq.Expressions;

namespace PlataformaVirtual.Domain.Ports.Output.Repository
{
    public interface IPersonaRepository : IBaseRepository<Persona>
    {
        Task<Persona?> GetByDocumentoAsync(string nroDocumento, int idTipoDocumento);
        Task<ICollection<TResult>> ListAsync<TResult>(
            PersonaFilter filter,
            Expression<Func<Persona, TResult>> selector
        );
    }
}
