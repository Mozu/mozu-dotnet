using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Resources.Platform.Entitylists;
using Mozu.Api.ToolKit.Config;
using Newtonsoft.Json.Linq;

namespace Mozu.Api.ToolKit.Handlers
{
    public interface IEntityHandler
    {
        Task<T> UpsertEntityAsync<T>(IApiContext apiContext, String id, String listName, T obj);
        Task<T> GetEntityAsync<T>(IApiContext apiContext, String id, string listName);
        Task DeleteEntityAsync(IApiContext apiContext, String id, string listName);
        Task<EntityCollection<T>> GetEntitiesAsync<T>(IApiContext apiContext, string listName);
        Task<EntityCollection<T>> GetEntitiesAsync<T>(IApiContext apiContext, string listName, int? pageSize, int? startIndex, string filter, string sortBy, string responseFileds);
    }

    public class EntityHandler : IEntityHandler
    {

        private readonly IAppSetting _appSetting;
        public EntityHandler(IAppSetting appSetting)
        {
            _appSetting = appSetting;
        }

        public async Task<T> GetEntityAsync<T>(IApiContext apiContext, String id, string listName)
        {
            var entityResource = new EntityResource(apiContext);
            var listFQN = ValidateListName(listName);
            try
            {
                var jobject = await entityResource.GetEntityAsync(listFQN, id);
                return jobject.ToObject<T>();
            }
            catch (ApiException apiExc)
            {
                if (apiExc.HttpStatusCode != HttpStatusCode.NotFound)
                    throw apiExc;
            }

            return default(T);
        }

        public async Task<T> UpsertEntityAsync<T>(IApiContext apiContext, String id, String listName, T obj)
        {
            var entityResource = new EntityResource(apiContext);
            var jobject = JObject.FromObject(obj);
            var listFQN = ValidateListName(listName);
            var existing = await GetEntityAsync<T>(apiContext, id, listName);

            if (existing == null)
                jobject = await entityResource.InsertEntityAsync(jobject, listFQN);
            else
                jobject = await entityResource.UpdateEntityAsync(jobject, listFQN, id);

            return jobject.ToObject<T>();
        }

        public async Task DeleteEntityAsync(IApiContext apiContext, String id, string listName)
        {
            var entityResource = new EntityResource(apiContext);
            var listFQN = ValidateListName(listName);
            await entityResource.DeleteEntityAsync(listFQN, id);
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

        private static T JObjectConverter<T>(JObject input)
        {
            var obj = input.ToObject<T>();
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
