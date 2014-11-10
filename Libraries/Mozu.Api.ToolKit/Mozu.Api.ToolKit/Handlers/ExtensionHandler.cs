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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Mozu.Api.ToolKit.Handlers
{

    public enum Parent
    {
        Orders,
        Products,
        Customers
    }

    public interface IExtensionHandler
    {

        Task AddUpdateExtensionLinkAsync(int tenantId, Parent parent, string href, string windowTitle, String[] path);
        Task AddUpdateExtensionLinkAsync(int tenantId, SubnavLink subnavLink);
    }

    public class ExtensionHandler : IExtensionHandler
    {

        public async Task AddUpdateExtensionLinkAsync(int tenantId, Parent parent, string href, string windowTitle, String[] path )
        {

            var link = new SubnavLink
            {
                ParentId = parent.ToString().ToLower(),
                WindowTitle = windowTitle,
                Href = href,
                Path = path
            };
            await AddUpdateExtensionLinkAsync(tenantId, link);
        }
        
        public async Task AddUpdateExtensionLinkAsync(int tenantId, SubnavLink subnavLink)
        {
            var apiContext = new ApiContext(tenantId);

            var applicationResource = new ApplicationResource(apiContext);

            var app = await applicationResource.ThirdPartyGetApplicationAsync();
            subnavLink.AppId = app.AppId;
            await AddUpdateSubNavLink(apiContext, subnavLink);
        }

        private async Task<EntityContainer> GetExistingLink(IApiContext apiContext, SubnavLink subnavLink)
        {
            var entityContainerResource = new EntityContainerResource(apiContext);
            var collection = await entityContainerResource.GetEntityContainersAsync(GetSubnavLinkEntityName(), 200);
            var existing = collection.Items.SingleOrDefault(x => subnavLink.Path.SequenceEqual(x.Item.ToObject<SubnavLink>().Path));
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
                jObject = await entityResource.InsertEntityAsync(jObject, GetSubnavLinkEntityName());
            else
                jObject = await entityResource.UpdateEntityAsync(jObject, GetSubnavLinkEntityName(), existing.Id);

            return jObject.ToObject<SubnavLink>();
        }
        
        private JObject FromObject<T>(T value)
        {
            var serializer = new JsonSerializer();
            serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            return JObject.FromObject(value, serializer);
        }
        
        private string GetSubnavLinkEntityName()
        {
            return "subnavlinks@mozu";
        }
      
    }
}
