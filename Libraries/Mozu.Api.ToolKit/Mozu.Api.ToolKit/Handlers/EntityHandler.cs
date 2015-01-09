using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Logging;
using Mozu.Api.Resources.Platform.Entitylists;
using Mozu.Api.ToolKit.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Mozu.Api.ToolKit.Handlers
{
    public interface IEntityHandler
    {
        Task<T> AddEntityAsync<T>(IApiContext apiContext, String listName, T obj);
        Task<T> UpdateEntityAsync<T>(IApiContext apiContext, object id, String listName, T obj);
        Task<T> UpsertEntityAsync<T>(IApiContext apiContext, object id, String listName, T obj);
        Task<T> GetEntityAsync<T>(IApiContext apiContext, object id, string listName);
        Task DeleteEntityAsync(IApiContext apiContext, object id, string listName);
        Task<EntityCollection<T>> GetEntitiesAsync<T>(IApiContext apiContext, string listName);
        Task<EntityCollection<T>> GetEntitiesAsync<T>(IApiContext apiContext, string listName, int? pageSize, int? startIndex, string filter, string sortBy, string responseFileds);
    }

    public class EntityHandler : IEntityHandler
    {

        private readonly IAppSetting _appSetting;
        private readonly ILogger _logger = LogManager.GetLogger(typeof(EntityHandler));

        public JsonSerializer SerializerSettings = new JsonSerializer
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public EntityHandler(IAppSetting appSetting)
        {
            _appSetting = appSetting;
        }

        public async Task<T> GetEntityAsync<T>(IApiContext apiContext, object id, string listName)
        {
            var entityResource = new EntityResource(apiContext);
            var listFQN = ValidateListName(listName);
            try
            {
                var jobject = await entityResource.GetEntityAsync(listFQN, id.ToString());
                if (jobject == null)
                    return default(T);
                return jobject.ToObject<T>(SerializerSettings);
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException.GetType() == typeof(ApiException)) throw;
                var aex = (ApiException)ae.InnerException;
                _logger.Error(aex.Message, aex);
                throw aex;
            }

            return default(T);
        }

        public async Task<T> AddEntityAsync<T>(IApiContext apiContext, String listName, T obj)
        {
            var entityResource = new EntityResource(apiContext);
            var jobject = JObject.FromObject(obj, SerializerSettings);
            var listFQN = ValidateListName(listName);
            jobject = await entityResource.InsertEntityAsync(jobject, listFQN);
            return jobject.ToObject<T>();
        }

        public async Task<T> UpdateEntityAsync<T>(IApiContext apiContext, object id, String listName, T obj)
        {
            var entityResource = new EntityResource(apiContext);
            var jobject = JObject.FromObject(obj, SerializerSettings);
            var listFQN = ValidateListName(listName);

            jobject = await entityResource.UpdateEntityAsync(jobject, listFQN, id.ToString());

            return jobject.ToObject<T>();
        }

        public async Task<T> UpsertEntityAsync<T>(IApiContext apiContext, object id, String listName, T obj)
        {
            var existing = await GetEntityAsync<T>(apiContext, id.ToString(), listName);

            return existing == null
                ? await AddEntityAsync(apiContext, listName, obj)
                : await UpdateEntityAsync(apiContext, id, listName, obj);
        }

        public async Task DeleteEntityAsync(IApiContext apiContext, object id, string listName)
        {
            var entityResource = new EntityResource(apiContext);
            var listFQN = ValidateListName(listName);
            await entityResource.DeleteEntityAsync(listFQN, id.ToString());
        }


        public async Task<EntityCollection<T>> GetEntitiesAsync<T>(IApiContext apiContext, string listName)
        {
            var entities = await GetEntitiesAsync<T>(apiContext, listName, null, null, null, null, null);
            return entities;
        }

        public async Task<EntityCollection<T>> GetEntitiesAsync<T>(IApiContext apiContext, string listName,int? pageSize, int? startIndex, string filter, string sortBy, string responseFileds)
        {
            var entityResource = new EntityResource(apiContext);
            var listFQN = ValidateListName(listName);
            var entities = await entityResource.GetEntitiesAsync(listFQN, pageSize, startIndex, filter, sortBy, responseFileds);

            var entityCollection = new EntityCollection<T>
            {
                PageCount = entities.PageCount,
                PageSize = entities.PageSize,
                StartIndex = entities.StartIndex,
                TotalCount = entities.TotalCount
            };

            entityCollection.Items = entities.Items.ConvertAll(JObjectConverter<T>);

            return entityCollection;
        }

        private T JObjectConverter<T>(JObject input)
        {
            var obj = input.ToObject<T>(SerializerSettings);
            return obj;
        }

        private string ValidateListName(String listName)
        {
            if (!listName.Contains("@")) listName = string.Format("{0}@{1}", listName, _appSetting.Namespace);
            return listName;
        }
    }


    public class EntityCollection<T>
    {
        public List<T> Items { get; set; }
        public int PageSize { get; set; }
        public int StartIndex { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
    }
}
