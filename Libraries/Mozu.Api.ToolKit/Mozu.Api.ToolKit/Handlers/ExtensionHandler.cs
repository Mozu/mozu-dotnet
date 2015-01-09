using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.MZDB;
using Mozu.Api.Resources.Commerce.Settings;
using Mozu.Api.Resources.Platform.Entitylists;
using Mozu.Api.ToolKit.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Mozu.Api.ToolKit.Handlers
{

    public enum Parent
    {
        Orders,
        Catalog,
        Customers
    }

    public interface IExtensionHandler
    {

        Task AddUpdateExtensionLinkAsync(int tenantId, Parent parent, string href, string windowTitle, String[] path);
        Task AddUpdateExtensionLinkAsync(int tenantId, SubnavLink subnavLink);
        Task Delete(int tenantId);

    }

    public class ExtensionHandler : IExtensionHandler
    {
        private const string SubnavLinkEntityName = "subnavlinks@mozu";


        public async Task AddUpdateExtensionLinkAsync(int tenantId, Parent parent, string href, string windowTitle, String[] path )
        {

            var link = new SubnavLink
            {
                ParentId = parent,
                WindowTitle = windowTitle,
                Href = href,
                Path = path
            };
            await AddUpdateExtensionLinkAsync(tenantId, link);
        }
        
        public async Task AddUpdateExtensionLinkAsync(int tenantId, SubnavLink subnavLink)
        {
            var apiContext = new ApiContext(tenantId);
            subnavLink.AppId = await GetAppId(apiContext);
            await AddUpdateSubNavLink(apiContext, subnavLink);
        }

        public async Task Delete(int tenantId)
        {
            var apiContext = new ApiContext(tenantId);
            var entityContainerResource = new EntityContainerResource(apiContext);
            var collection = await entityContainerResource.GetEntityContainersAsync(SubnavLinkEntityName, 200);
            var entityResource = new EntityResource(apiContext);

            var appId = await GetAppId(apiContext);
            foreach (var item in collection.Items.Where(subnavLink => subnavLink.Item.ToObject<SubnavLink>().AppId.Equals(appId)))
            {
                await entityResource.DeleteEntityAsync(SubnavLinkEntityName, item.Id);
            }

        }

        private async Task<EntityContainer> GetExistingLink(IApiContext apiContext, SubnavLink subnavLink)
        {
            var entityContainerResource = new EntityContainerResource(apiContext);
            var collection = await entityContainerResource.GetEntityContainersAsync(SubnavLinkEntityName, 200);

            /*foreach (var item in collection.Items)
            {
                var obj = item.Item.ToObject<SubnavLink>();
                var sameParent = obj.ParentId == subnavLink.ParentId;
                var samePath = subnavLink.Path.SequenceEqual(obj.Path);
            }*/

            var existing = collection.Items.SingleOrDefault(x => subnavLink.Path.SequenceEqual(x.Item.ToObject<SubnavLink>().Path)
                && subnavLink.ParentId == x.Item.ToObject<SubnavLink>().ParentId);
            return existing;
        } 

        private async Task<SubnavLink> AddUpdateSubNavLink(IApiContext apiContext, SubnavLink subnavLink)
        {
            var entityResource = new EntityResource(apiContext);
            JObject jObject = null;
            if (subnavLink.Path == null || !subnavLink.Path.Any()) return null;

            var existing = await GetExistingLink(apiContext, subnavLink);

            jObject = FromObject(subnavLink);

            if (existing == null)
                jObject = await entityResource.InsertEntityAsync(jObject, SubnavLinkEntityName);
            else
                jObject = await entityResource.UpdateEntityAsync(jObject, SubnavLinkEntityName, existing.Id);

            return jObject.ToObject<SubnavLink>();
        }

        private async Task<string> GetAppId(IApiContext apiContext)
        {

            var applicationResource = new ApplicationResource(apiContext);
            var app = await applicationResource.ThirdPartyGetApplicationAsync();
            return app.AppId;
        }

        private JObject FromObject<T>(T value)
        {
            var serializer = new JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                
            };
            return JObject.FromObject(value, serializer);
        }
        
      
    }
}
