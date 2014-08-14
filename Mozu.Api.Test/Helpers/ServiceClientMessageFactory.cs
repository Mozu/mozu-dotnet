using System.Net.Http.Headers;

namespace Mozu.Api.Test.Helpers
{
    /// <summary>
    /// Each API message needs to be sent with a http header containing data pertaining to which tenantId and/or siteId that needs to be in context.
    /// </summary>
    public static class ServiceClientMessageFactory
    {
        /// <summary>
        /// This is a sample of how to input the IApiContext interface and create the MessageHandler's correct http header.
        /// </summary>
        /// <param name="apiContext"></param>
        /// <returns></returns>
        public static ServiceClientMessageHandler GetServiceClientMessageFactory(IApiContext apiContext)
        {
            var msgHandler = new ServiceClientMessageHandler(apiContext);
            return msgHandler;
        }

        /// <summary>
        /// This is a sample of how to quickly generate a blank ApiContext with no data for the MessageHandler's correct http header.
        /// </summary>
        /// <returns></returns>
        public static ServiceClientMessageHandler GetTestClientMessage()
        {
            var apiContext = new ApiContext();
            var msgHandler = new ServiceClientMessageHandler(apiContext);
            return msgHandler;
        }

        /// <summary>
        /// This is a sample of how to quickly generate a context for a particular Catalog.  
        /// Tenant > MasterCatalog > Catalog > Site(storefront calls only)
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public static ServiceClientMessageHandler GetTestClientMessage(int tenantId, int catalogId)
        {
            var apiContext = new ApiContext(tenantId: tenantId, catalogId: catalogId);
            var msgHandler = new ServiceClientMessageHandler(apiContext);
            return msgHandler;
        }

        /// <summary>
        /// This is a sample of how to quickly generate a context for any api request you wish.
        /// Some api requests may need the CatalogId context set, some may need the siteId.    
        /// Tenant > MasterCatalog > Catalog > Site(storefront calls only)
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="masterCatalogId"></param>
        /// <param name="catalogId"></param>
        /// <param name="siteId"></param>
        /// <returns>
        ///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Location.Location"/>}
        /// </returns>
        public static ServiceClientMessageHandler GetTestClientMessage(int tenantId, int? masterCatalogId = null, int? catalogId = null, int? siteId = null)
        {
            var apiContext = new ApiContext(tenantId: tenantId,siteId: siteId,masterCatalogId: masterCatalogId, catalogId: catalogId);
            var msgHandler = new ServiceClientMessageHandler(apiContext);
            return msgHandler;
        }

        /// <summary>
        /// This is a sample of how to quickly generate a blank ApiContext with no data for the MessageHandler's correct http header.
        /// Tenant > MasterCatalog > Catalog > Site(storefront calls only)
        /// </summary>
        /// <param name="requestHeaders"></param>
        /// <returns></returns>
        public static ServiceClientMessageHandler GetTestClientMessage(HttpRequestHeaders requestHeaders)
        {
            var apiContext = new ApiContext(requestHeaders);
            var msgHandler = new ServiceClientMessageHandler(apiContext);
            return msgHandler;
        }

        /// <summary>
        /// This is a sample of how to quickly generate a ApiContext with data only for the site the user is shopping in the MessageHandler's correct http header.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public static ServiceClientMessageHandler GetTestShopperMessage(int tenantId = 0, int? siteId = null)
        {
            var apiContext = new ApiContext(tenantId: tenantId, siteId: siteId);
            var msgHandler = new ServiceClientMessageHandler(apiContext);
            return msgHandler;
        }

    }

}