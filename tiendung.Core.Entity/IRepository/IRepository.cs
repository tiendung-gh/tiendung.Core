using tiendung.Core.Entity.Entity;

namespace tiendung.Core.Entity.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChange();
    }
}
