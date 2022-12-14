using Microsoft.EntityFrameworkCore;
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

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
