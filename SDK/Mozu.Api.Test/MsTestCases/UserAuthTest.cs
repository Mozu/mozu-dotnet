using System.Linq;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Contracts.Core;
using Mozu.Api.Resources.Commerce.Catalog.Admin;
using Mozu.Api.Resources.Commerce.Settings;
using Mozu.Api.Resources.Platform;
using Mozu.Api.Resources.Platform.Developer;
using Mozu.Api.Security;
using System;
using Mozu.Api.Test.Factories;
using Mozu.Api.Test.Helpers;

namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class UserAuthTest : MozuApiTestBase
    {
        #region NonTestCaseCode
        public UserAuthTest()
        {
        }
       
        #region Initializers

        /// <summary>
        /// This will run once before each test.
        /// </summary>
        [TestInitialize]
        public void TestMethodInit()
        {

            tenantId = Convert.ToInt32(Mozu.Api.Test.Helpers.Environment.GetConfigValueByEnvironment("TenantId"));
            ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage();
            TestBaseTenant = TenantFactory.GetTenant(handler: ApiMsgHandler,tenantId: tenantId);
            masterCatalogId = TestBaseTenant.MasterCatalogs.First().Id;
            catalogId = TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id;

            HttpRequestMessage msg = new HttpRequestMessage();
            msg.Headers.Add(Headers.X_VOL_TENANT, TestBaseTenant.Id.ToString());
            msg.Headers.Add(Headers.X_VOL_TENANT_DOMAIN, TestBaseTenant.Domain);
            msg.Headers.Add(Headers.X_VOL_SITE, TestBaseTenant.Sites[0].Id.ToString());

            ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(msg.Headers);
        }

        /// <summary>
        /// Runs once before any test is run.
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize]
        public static void InitializeBeforeRun(TestContext testContext)
        {
            //Call the base class's static initializer.
            MozuApiTestBase.TestClassInitialize(testContext);
        }

        #endregion

        #region CleanupMethods

        /// <summary>
        /// This will run once after each test.
        /// </summary>
        [TestCleanup]
        public void TestMethodCleanup()
        {
            //Calls the base class's Test Cleanup
            base.TestCleanup();
        }

        /// <summary>
        /// Runs once after all of the tests have run.
        /// </summary>
        [ClassCleanup]
        public static void TestsCleanup()
        {
            //Calls the Base class's static cleanup.
            MozuApiTestBase.TestClassCleanup();
        }

        #endregion

        #endregion

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Simpliest way of testing Auth and checking for correct user/pass")]
        public void SimpleAuthLoginTest()
        {
             var emailAddress = Mozu.Api.Test.Helpers.Environment.GetConfigValueByEnvironment("devOwnerEmail");
            var password = Mozu.Api.Test.Helpers.Environment.GetConfigValueByEnvironment("devOwnerPassword");

            var userAuthInfo = new UserAuthInfo { EmailAddress = emailAddress, Password = password };

            var userInfo = UserAuthenticator.Authenticate(userAuthInfo, AuthenticationScope.Developer);

            Assert.IsNotNull(userInfo);
            Assert.IsNotNull(userInfo.AuthTicket);
            Assert.IsNotNull(userInfo.AuthTicket.AccessToken);

            if (userInfo.ActiveScope == null)
            {
                userInfo = UserAuthenticator.SetActiveScope(userInfo.AuthTicket, userInfo.AuthorizedScopes.First());

                Assert.IsNotNull(userInfo);
                Assert.IsNotNull(userInfo.ActiveScope);
            }
        }
    }
}
