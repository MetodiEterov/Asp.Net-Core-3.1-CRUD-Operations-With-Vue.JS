using System;
using System.Collections.Generic;

using Entities.Contracts;
using Entities.Models;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Repository.Layer
{
    public class OwnerMemoryCache : IOwnerMemoryCache
    {
        private readonly IMemoryCache _ownersCache;
        private readonly string _keyEntry = "OwnersCache";
        private readonly int _defaultCacheExpirationTime;

        private MemoryCacheEntryOptions _cacheExpirationOptions;

        public OwnerMemoryCache(IMemoryCache memoryCache, IConfiguration configuration)
        {
            _defaultCacheExpirationTime = configuration.GetValue("Windows:GroupsCacheMinutes", 30);
            _ownersCache = memoryCache;
        }

        public IEnumerable<Owner> GetOwnerMemoryCache()
        {
            if (_ownersCache != null && _ownersCache.TryGetValue(_keyEntry, out IEnumerable<Owner> obj)) return obj;

            return null;
        }

        public void SetOwnerMemoryCache(IEnumerable<Owner> owners)
        {
            if (owners != null)
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
