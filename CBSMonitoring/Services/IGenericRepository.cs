namespace CBSMonitoring.Services
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
