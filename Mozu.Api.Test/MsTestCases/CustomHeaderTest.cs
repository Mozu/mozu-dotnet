using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Test.Helpers;
using System;
using System.Collections.Generic;

namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class CustomHeaderTest: BaseDataFactory
    {
        int tenantId = 0;

        [TestInitialize]
        public void TestMethodInit()
        {
            tenantId = Convert.ToInt32(Mozu.Api.Test.Helpers.Environment.GetConfigValueByEnvironment("TenantId"));
        }

        [TestMethod]
        [Description("Custom Headers test")]
        public void Http_Request_Contains_Custom_Header()
        {
            var customHeaders = new Dictionary<string, string>()
            {
                {"x-vol-cluster","unified" }
            };
            var baseUrlAddress = Helpers.Environment.GetConfigValueByEnvironment(Environment, "BaseAuthAppUrl");
            SetSdKparameters();
            var ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, customHeaders);
            var client = Mozu.Api.Clients.Commerce.Catalog.Admin.ProductClient.GetProductClient(DataViewMode.Live, "test").WithBaseAddress(baseUrlAddress);
            var request = client.WithContext(ApiMsgHandler.ApiContext).RequestMessage;

            Assert.IsTrue(request.Headers.Contains("x-vol-cluster"));
        }

        [TestMethod]
        [Description("Cloning ApiContext with custom headers")]
        public void Clone_ApiContext_With_Custom_Header()
        {
            var customHeaders = new Dictionary<string, string>()
            {
                {"x-vol-cluster","unified" }
            };
            var ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId,null);
            var cloneApiContext = ApiMsgHandler.ApiContext.CloneWith(x => x.CustomHeaders = customHeaders);

            Assert.IsTrue(cloneApiContext.CustomHeaders.ContainsKey("x-vol-cluster"));
        }

        [TestMethod]
        [Description("ApiContext does not change upon editing its clone")]
        public void ApiContext_does_not_change_upon_editing_its_clone()
        {
            var customHeaders = new Dictionary<string, string>()
            {
                {"x-vol-cluster","unified" }
            };
            var ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, null);
            var cloneApiContext = ApiMsgHandler.ApiContext.CloneWith(x => x.CustomHeaders = customHeaders);

            Assert.IsTrue(ApiMsgHandler.ApiContext.CustomHeaders == null);
        }

    }
}
