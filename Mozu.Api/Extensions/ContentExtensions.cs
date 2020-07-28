using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mozu.Api.Extensions
{
    public static class ContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            return await Task.Run(async ()=> JsonConvert.DeserializeObject<T>(await content.ReadAsStringAsync()));
        }
        
    }
}
