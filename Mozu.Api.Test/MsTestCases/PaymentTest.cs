using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Test.Factories;
using Mozu.Api.Test.Helpers;

namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class PaymentTest : MozuApiTestBase
    {
       #region NonTestCaseCode
        private static List<string> productCode1 = new List<string>();
        private static List<int> productTypeId1 = new List<int>();
        private static List<string> attributeFQN1 = new List<string>();

       
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
            siteId = TestBaseTenant.Sites.First().Id;

            ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId:tenantId,siteId:siteId);
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
            CleanUpData.CleanUpProducts(ApiMsgHandler, productCode1);
            CleanUpData.CleanUpProductTypes(ApiMsgHandler, productTypeId1);
            CleanUpData.CleanUpAttributes(ApiMsgHandler, attributeFQN1);
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
        public void GetPaymentsTest()
        {
            var paymentFactory = PaymentFactory.GetPayments(ApiMsgHandler, "032a54b34fdce037d040d67800001e7c");
            Assert.IsTrue(paymentFactory.Items.Count > 0);
        }
    }
}
