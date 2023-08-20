using CBSMonitoring.Data;
using Microsoft.EntityFrameworkCore;

namespace CBSMonitoring.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        private DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {            
            return await _dbSet.FindAsync(id);
        }

        public async Task Update(T entity)
        {            
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        
    }
}
