using CBSMonitoring.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CBSMonitoring.Services
{
    public class GenericRepository : IGenericRepository
    {
        private readonly AppDbContext _context;


        public GenericRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null) where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (include != null)
            {
                query = include(query);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync<TEntity>(int id) where TEntity : class
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetByParameterAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null) where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }


    }
}
