using tiendung.Core.Entity.Entity;

namespace tiendung.Core.Entity.IRepository
{
    public interface ICacheRepository<T> where T : BaseEntity, IAsyncDisposable
    {
        Task<T> GetData(Guid key);
        Task<IEnumerable<T>> GetListData(Guid key);
        Task SetData(Guid key, T value, DateTimeOffset expirationTime);
        Task RemoveData(Guid key);
    }
}
