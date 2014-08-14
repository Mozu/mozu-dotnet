using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Contracts.AppDev;
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
            var baseAppAuthUrl = "http://aus02ndserv001.dev.volusion.com/Mozu.AppDev.WebApi/platform/applications/authtickets/";
            var appId = "158496f0ca114e0b88bda2ed011dc745";
            var sharedSecret = "3c9a6a0bd09b44d1a7c7a2ed011dc745";

            var appAuthInfo = new AppAuthInfo
                              {
                                  ApplicationId = appId,
                                  SharedSecret = sharedSecret
                              };

            var authenticator = AppAuthenticator.Initialize(appAuthInfo, baseAppAuthUrl);
            authenticator.EnsureAuthTicket();

            Assert.IsNotNull(appAuthInfo);
            Assert.IsNotNull(appAuthInfo.ApplicationId);
            Assert.IsNotNull(appAuthInfo.SharedSecret);            
        }
    }
}
