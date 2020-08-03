using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Contracts.AppDev;
using Mozu.Api.Resources.Platform;
using Mozu.Api.Security;
using Mozu.Api.Test.Helpers;

namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class AppAuthTest : MozuApiTestBase
    {
        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Simpliest way of testing App Auth and checking for correct user/pass")]
        public void SimpleAppAuthLoginTest()
        {
            var baseAppAuthUrl = "https://home.dev01.kibo-dev.com";
            var appId = "mozuadmin.MIEA.1.0.0.Release";
            var sharedSecret = "c755147e6d4c4d95a359ab1775351b0a";

            var appAuthInfo = new AppAuthInfo
                              {
                                  ApplicationId = appId,
                                  SharedSecret = sharedSecret
                              };
            MozuConfig.BaseAppAuthUrl = baseAppAuthUrl;
            var authenticator = AppAuthenticator.Initialize(appAuthInfo);
            authenticator.EnsureAuthTicket();

            Assert.IsNotNull(appAuthInfo);
            Assert.IsNotNull(appAuthInfo.ApplicationId);
            Assert.IsNotNull(appAuthInfo.SharedSecret);            
        }

		[TestMethod]
		[TestCategory("Mozu SDK Sample")]
		[Timeout(TestTimeout.Infinite)]
		[Priority(2)]
		[Description("Simpliest way of testing App Auth and checking for correct user/pass")]
		public async Task AsyncTest()
		{
            var baseAppAuthUrl = "https://home.dev01.kibo-dev.com";
            var appId = "mozuadmin.MIEA.1.0.0.Release";
            var sharedSecret = "c755147e6d4c4d95a359ab1775351b0a";

            var appAuthInfo = new AppAuthInfo
			{
				ApplicationId = appId,
				SharedSecret = sharedSecret
			};

		    MozuConfig.BaseAppAuthUrl = baseAppAuthUrl;
			await AppAuthenticator.InitializeAsync(appAuthInfo);

			Assert.IsNotNull(AppAuthenticator.Instance);
			Assert.IsNotNull(AppAuthenticator.Instance.AppAuthTicket);
			Assert.IsNotNull(AppAuthenticator.Instance.AppAuthTicket.AccessToken);

			//var tenantResource = new TenantResource();
			//var tenant = await tenantResource.GetTenantAsync(9539);
			//Assert.IsNotNull(tenant);
			//Assert.AreEqual(tenant.Id, 9539);

		}


    }
}
