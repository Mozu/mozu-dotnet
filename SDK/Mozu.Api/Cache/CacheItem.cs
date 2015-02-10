using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Cache
{
    public class CacheItem
    {
        public String Uri { get; set; }
        public HttpResponseMessage Item { get; set; }
        public string ETag { get; set; }
    }
}
