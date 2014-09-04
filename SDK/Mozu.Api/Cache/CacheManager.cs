using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Cache
{
    public class CacheManager
    {
        private readonly ObjectCache _cache;
        private static readonly object _lockObj = new Object();
        private static volatile CacheManager instance;

        private CacheManager()
        {
            _cache = MemoryCache.Default;
        }

        public static CacheManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lockObj)
                    {
                        if (instance == null)
                            instance = new CacheManager();
                    }
                }
                return instance;
            }
        }

        public T Get<T>(string id)
        {
            return (T)_cache[id];
        }

        public void Add<T>(T obj, string id)
        {
            if (!MozuConfig.EnableCache) return;
            if (_cache.Contains(id))
                _cache.Remove(id);
            var policy = new CacheItemPolicy();

            policy.SlidingExpiration = new TimeSpan(1, 0, 0);
            _cache.Set(id, obj, policy);
        }

        public void Update<T>(T obj, string id)
        {
            if (!MozuConfig.EnableCache) return;
            _cache.Remove(id);
            Add(obj, id);
        }
    }
}
