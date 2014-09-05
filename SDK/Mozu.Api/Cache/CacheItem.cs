using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Cache
{
    public class CacheItem<T>
    {
        public string Id { get; set; }
        public T Item { get; set; }
        public string ETag { get; set; }
        public DateTime CreateDate { get; set; }
        public ApiContext ApiContext { get; set; }
    }
}
