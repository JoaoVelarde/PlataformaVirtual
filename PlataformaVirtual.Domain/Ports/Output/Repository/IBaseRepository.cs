using PlataformaVirtual.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Domain.Ports.Output.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync();
        Task DeleteAsync(Guid id);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<ICollection<TEntity>> ListAsync();
        Task<(ICollection<TResultado> Collection, int TotalCount)> ListAsync<TResultado>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TResultado>> selector,
            int page = 1, int rows = 10
        );
    }
}
