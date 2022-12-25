﻿using System.Linq.Expressions;
using tiendung.Core.Entity.Entity;

namespace tiendung.Core.Entity.IRepository
{
    public interface IRepository<T> where T : BaseEntity, IAsyncDisposable
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task CreateMore(IEnumerable<T> entities);
        void UpdateMore(IEnumerable<T> entities);
        void DeleteMore(IEnumerable<T> entities);
        Task<IEnumerable<T>> Query(Expression<Func<T, bool>> expression);
        Task SaveChange();
    }
}
