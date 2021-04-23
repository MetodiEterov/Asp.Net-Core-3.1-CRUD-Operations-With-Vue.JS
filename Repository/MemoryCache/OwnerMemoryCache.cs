using System;
using System.Collections.Generic;

using Entities.Contracts;
using Entities.Models;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Repository.Layer
{
    /// <summary>
    /// OwnerMemoryCache class is an implentation of IOwnerMemoryCache interface
    /// Provides in memory caching for the service
    /// </summary>
    public class OwnerMemoryCache : IOwnerMemoryCache
    {
        private MemoryCacheEntryOptions _cacheExpirationOptions;
        private readonly int _defaultCacheExpirationTime;
        private readonly string _keyEntry = "OwnersCache";
        private readonly IMemoryCache _ownersCache;

        public OwnerMemoryCache(IMemoryCache memoryCache, IConfiguration configuration)
        {
            _defaultCacheExpirationTime = configuration.GetValue("Windows:GroupsCacheMinutes", 30);
            _ownersCache = memoryCache;
        }

        /// <summary>
        /// GetOwnerMemoryCache method gets all owners from the cache, if there are
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Owner> GetOwnerMemoryCache()
        {
            if(_ownersCache != null && _ownersCache.TryGetValue(_keyEntry, out IEnumerable<Owner> obj))
                return obj;

            return null;
        }

        /// <summary>
        /// SetOwnerMemoryCache method stores all owners to memory cache
        /// </summary>
        /// <param name="owners"></param>
        public void SetOwnerMemoryCache(IEnumerable<Owner> owners)
        {
            if(owners != null)
            {
                _cacheExpirationOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(_defaultCacheExpirationTime),
                    Priority = CacheItemPriority.Normal
                };

                _ownersCache.Set(_keyEntry, owners, _cacheExpirationOptions);
            }
        }
    }
}
