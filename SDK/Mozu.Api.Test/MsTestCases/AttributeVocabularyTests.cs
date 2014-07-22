using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Test.Factories;
using Mozu.Api.Test.Helpers;

namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class AttributeVocabularyTests : MozuApiTestBase
    {

        #region NonTestCaseCode
        public AttributeVocabularyTests()
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
            ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId:masterCatalogId, catalogId:catalogId);
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
            // Populate Test Data.
            //Generator.PopulateProductsToCatalog(TestBaseTenant.Id, TestBaseTenant.MasterCatalogs.First().Id,
            //    TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
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
        public void GetAttributeVocabularyValuesTest1()
        {

            var values = AttributeVocabularyValueFactory.GetAttributeVocabularyValues(handler: ApiMsgHandler, dataViewMode: DataViewMode.Pending, attributeFQN: "tenant~availability");
            Assert.IsTrue(values.Count > 0);
        }
    }
}
