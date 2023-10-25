using CBSMonitoring.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata;

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

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null) where TEntity : class
        {
            return await GetQuery(include, predicate).ToListAsync();
        }
        public async Task<IEnumerable<TResult>> SelectAllAsync<TEntity, TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
            where TEntity : class
            where TResult : class
        {

            return await GetQuery(include, predicate).Select(selector).ToListAsync();

        }
        public async Task<TEntity?> GetByIdAsync<TEntity>(int id) where TEntity : class
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetFirstByParameterAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null) where TEntity : class
        {
           return await GetQuery(include).FirstOrDefaultAsync(predicate);
        }
        public async Task<TResult?> SelectFirstByParameterAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
             where TEntity : class
             where TResult : class
        {
            return await GetQuery(include, predicate).Select(selector).FirstOrDefaultAsync();
        }
        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public void ChangeEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class
        {
            _context.Entry(entity).State = state;
        }

        private IQueryable<TEntity> GetQuery<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null, Expression<Func<TEntity, bool>>? predicate = null)
            where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (include != null)
            {
                query = include(query);
            }

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }
    }
}
