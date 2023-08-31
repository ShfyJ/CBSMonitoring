using System.Linq.Expressions;
namespace CBSMonitoring.Services
{
    public interface IGenericRepository
    {
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null) where TEntity : class;
        Task<TEntity?> GetByIdAsync<TEntity>(int id) where TEntity : class;
        Task<TEntity?> GetByParameterAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null) where TEntity : class;
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
