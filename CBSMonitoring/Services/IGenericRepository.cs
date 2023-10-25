using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace CBSMonitoring.Services
{
    public interface IGenericRepository
    {
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null) where TEntity : class;
        Task<IEnumerable<TResult>> SelectAllAsync<TEntity, TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null) where TEntity : class where TResult : class;
        Task<TEntity?> GetByIdAsync<TEntity>(int id) where TEntity : class;
        Task<TResult?> SelectFirstByParameterAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null) where TEntity : class where TResult : class;
        Task<TEntity?> GetFirstByParameterAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null) where TEntity : class;       
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        void ChangeEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class;
        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
