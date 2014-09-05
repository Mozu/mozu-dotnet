using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Test.Factories;
using Mozu.Api.Test.Helpers;

namespace Mozu.Api.Test.MsTestCases
{
    /// <summary>
    /// Summary description for DocumentTest
    /// </summary>
    [TestClass]
    public class DocumentTest : MozuApiTestBase
    {
         #region NonTestCaseCode

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
        [TestCategory("Mozu SDK Sample")]
        public void GetDocumentsTest1()
        {
            var documentfactory = DocumentFactory.GetDocuments(ApiMsgHandler, "files");
            Assert.IsNotNull(documentfactory.Items);
            Assert.IsTrue(documentfactory.Items.Count > 0);
            foreach (var item in documentfactory.Items)
            {
               var s = DocumentFactory.GetDocumentContent(ApiMsgHandler, "files", item.Id);
               Assert.IsNotNull(s);
               Assert.IsTrue(s.GetType() == typeof(System.IO.MemoryStream));

               using (FileStream file = new FileStream(@"D:\"+item.Name, FileMode.Create, System.IO.FileAccess.Write))
               {
                   byte[] bytes = new byte[s.Length];
                   s.Read(bytes, 0, (int)s.Length);
                   file.Write(bytes, 0, bytes.Length);
                   s.Close();
               }
            }
        }
    }
}
