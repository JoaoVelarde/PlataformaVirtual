using PlataformaVirtual.Domain.Entities;
using PlataformaVirtual.Domain.Ports.Output.Repository;
using PlataformaVirtual.Infrastructure.Configuration.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PlataformaVirtual.Infrastructure.Adapter.Output.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly TramiteDbContext _context;
        public BaseRepository(TramiteDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> AddAsync(TEntity entity)
        {
            var response = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.Set<TEntity>()
                 .Where(p => p.Id == id)
                 .ExecuteUpdateAsync(p =>
                 p.SetProperty(p => p.EstadoId, Estado.Eliminado));
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<ICollection<TEntity>> ListAsync()
        {
            return await _context.Set<TEntity>()
                .Where(p => p.EstadoId == Estado.Activo)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<(ICollection<TResultado> Collection, int TotalCount)> ListAsync<TResultado>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TResultado>> selector,
            int page = 1, int rows = 10)
        {
            var response = await _context.Set<TEntity>()
                .Where(predicate)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * rows)
                .Take(rows)
                .Select(selector)
                .ToListAsync();

            var total = await _context.Set<TEntity>()
                .Where(predicate)
                .CountAsync();

            return (response, total);
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
