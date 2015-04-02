using System;

namespace Mozu.Api.Test.Helpers
{
    public class ServiceClientMessageHandler
    {
        protected readonly IApiContext _ctx;

        public ServiceClientMessageHandler(IApiContext context)
        {
            _ctx = context;
        }

        public IApiContext ApiContext { get { return _ctx; } }
    }


    [Flags]
    public enum ContextLevelType
    {
        NotSpecified = 0,
        Tenant = 1,
        Site = 2,
        MasterCatalog = 4,
        Catalog = 8,
    }
}
