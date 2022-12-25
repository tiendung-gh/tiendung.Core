using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;
using tiendung.Core.Entity.Entity;
using tiendung.Core.Entity.IRepository;

namespace tiendung.Core.Entity.Repository
{
    public class CacheRepository<T> : ICacheRepository<T> where T : BaseEntity, IAsyncDisposable
    {
        private readonly IDistributedCache _cache;
        private readonly IMapper _mapper;
        public CacheRepository(IDistributedCache cache, IMapper mapper)
        {
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<T> GetData(Guid key)
        {
            byte[] cachedData = await _cache.GetAsync(key.ToString());
            T value = null;
            if (cachedData != null)
            {
                var cacheData = Encoding.UTF8.GetString(cachedData);
                value = _mapper.Map<T>(JsonSerializer.Deserialize<T>(cacheData));
            }
            return value;
        }

        public async Task<IEnumerable<T>> GetListData(Guid key)
        {
            byte[] cachedData = await _cache.GetAsync(key.ToString());
            List<T> values = new();
            if (cachedData != null)
            {
                var cacheData = Encoding.UTF8.GetString(cachedData);
                values = _mapper.Map<List<T>>(JsonSerializer.Deserialize<List<T>>(cacheData));
            }
            return values;
        }

        public async Task RemoveData(Guid key)
        {
            await _cache.RemoveAsync(key.ToString());
        }

        public async Task SetData(Guid key, T data, DateTimeOffset expirationTime)
        {
            string cachedDataString = JsonSerializer.Serialize(data);
            var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(3));

            await _cache.SetAsync(key.ToString(), dataToCache, options);
        }
    }
}
