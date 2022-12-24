using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using tiendung.Core.Entity.Data;
using tiendung.Core.Entity.Entity;
using tiendung.Core.Entity.IRepository;

namespace tiendung.Core.Entity.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private DataContext _context;
        private DbSet<T> _dbSet;
        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task CreateMore(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteMore(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> Query(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateMore(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
