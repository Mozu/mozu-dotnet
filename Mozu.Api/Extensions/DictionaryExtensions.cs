using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Linq;

namespace Mozu.Api.Extensions
{
    public static class DictionaryExtensions
    {
        public static NameValueCollection DictionaryToNVCollection(this IHeaderDictionary headerDictionary)
        {
            return headerDictionary.Aggregate(new NameValueCollection(),
            (seed, current) => {
                seed.Add(current.Key, current.Value);
                return seed;
            });
        }

        public static NameValueCollection FormCollectionToNVCollection(this IFormCollection formCollection)
        {
            return formCollection.Aggregate(new NameValueCollection(),
            (seed, current) =>
            {
                seed.Add(current.Key, current.Value);
                return seed;
            });
        }
    }
}
