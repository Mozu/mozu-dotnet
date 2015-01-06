using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Resources.Platform.Entitylists;
using Mozu.Api.ToolKit.Handlers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Mozu.Api.ToolKit.Readers
{
    public class EntityReader<T> : BaseReader
    {

        private EntityCollection<T> _results;

        public String ListName { get; set; }
        public String Namespace { get; set; }

        protected async override Task<bool> GetDataAsync()
        {
            var entityResource = new EntityResource(Context);
           
            if (String.IsNullOrEmpty(ListName) || (!ListName.Contains("@") && String.IsNullOrEmpty(Namespace)))
                throw new Exception("ListName or Namespace is missing");
            var fqn = ListName;
            if (!ListName.Contains("@"))
                fqn = ListName + "@" + Namespace;

            var entities = await entityResource.GetEntitiesAsync(fqn, PageSize, StartIndex, Filter, SortBy, ResponseFields);

            _results = new EntityCollection<T>
            {
                PageCount = entities.PageCount,
                PageSize = entities.PageSize,
                StartIndex = entities.StartIndex,
                TotalCount = entities.TotalCount
            };

            _results.Items = entities.Items.ConvertAll(JObjectConverter<T>);

            TotalCount = _results.TotalCount;
            PageCount = _results.PageCount;
            PageSize = _results.PageSize;
            return _results.Items != null && _results.Items.Count > 0;
        }

        private T JObjectConverter<T>(JObject input)
        {
            var obj = input.ToObject<T>(new JsonSerializer { ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        NullValueHandling = NullValueHandling.Ignore
                    });
            return obj;
        }


        public List<T> Items
        {
            get { return _results.Items; }
        } 
    }
}
