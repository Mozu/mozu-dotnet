using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Test.Helpers;
using Mozu.Api.Test.Factories;
using System.Threading;

namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class ProductPublishingTests : MozuApiTestBase
    {

        #region NonTestCaseCode

        public ProductPublishingTests()
        {

        }

        private static List<string> productCode1 = new List<string>();
        private static List<int> productTypeId1 = new List<int>();

        private static List<int> cateIds1 = new List<int>();


        #region Initializers

        /// <summary>
        /// This will run once before each test.
        /// </summary>
        [TestInitialize]
        public void TestMethodInit()
        {
            tenantId = Convert.ToInt32(Mozu.Api.Test.Helpers.Environment.GetConfigValueByEnvironment("TenantId"));
            ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage();
            TestBaseTenant = TenantFactory.GetTenant(handler: ApiMsgHandler, tenantId: tenantId);
            masterCatalogId = TestBaseTenant.MasterCatalogs.First().Id;
            catalogId = TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id;
            ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId: masterCatalogId,
                catalogId: catalogId);
            ShopperMsgHandler = ServiceClientMessageFactory.GetTestShopperMessage(tenantId,
                siteId: TestBaseTenant.Sites.First().Id);
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

        /// <summary>
        /// PublishDrafts
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AllPending is true, should ignore productcode in the list")]
        public void ProductPublishingTests_PublishDrafts1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);            
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            var createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro2.ProductCode);
            Thread.Sleep(3000);
            var getPro1 = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            var getPro2 = ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            getPro1 = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.OK);
            getPro2 = ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.OK);

            //AllPending is true
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(false, new List<string>() { createdPro1.ProductCode }));
            getPro1 = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.OK);
            getPro2 = ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);

            getPro1 = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.OK);
            getPro2 = ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.OK);
        }

        /// <summary>
        /// PublishDrafts
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AllPending is false")]
        public void ProductPublishingTests_PublishDrafts2()
        {
            var masterCatalog = Generator.SetMasterCatalogLiveMode(ApiMsgHandler, masterCatalogId);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            var createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro2.ProductCode);
            Thread.Sleep(3000);
            //Validation Error: Cannot publish drafts for masterCatalog in Live publishingMode
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(false, new List<string>() { createdPro1.ProductCode }), expectedCode: HttpStatusCode.Conflict);
            MasterCatalogFactory.UpdateMasterCatalog(ApiMsgHandler, masterCatalog: masterCatalog, masterCatalogId: masterCatalogId, dataViewMode: DataViewMode.Pending );
            createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro2.ProductCode);
            Thread.Sleep(5300);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(false, new List<string>() { createdPro1.ProductCode }));
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.OK);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.OK);
        }

        /// <summary>
        /// PublishDrafts
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AllPending is null")]
        public void ProductPublishingTests_PublishDrafts3()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            var createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro2.ProductCode);
            Thread.Sleep(3000);
            //AllPending is false
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.OK);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.OK);
        }

        /// <summary>
        /// PublishDrafts
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductCodes: not found ProductCode")]  //bug 21199
        public void ProductPublishingTests_PublishDrafts5()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            var createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro2.ProductCode);
            Thread.Sleep(3000);
            //Nonexisting product code //
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(false, new List<string>() { Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly) }), expectedCode: HttpStatusCode.NotFound);
            //publish all
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(true, null));
            //publish a product already published before
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(false, new List<string>() { createdPro1.ProductCode }), expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// DiscardDrafts
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AllPending is true, should ignore productcode in the list")]
        public void ProductPublishingTests_DiscardDrafts1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);

            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(3000);
            var createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(3000);
            //AllPending is true
            PublishingScopeFactory.DiscardDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(true, new List<string>() { createdPro1.ProductCode }));
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.DeleteProduct(ApiMsgHandler, createdPro1.ProductCode, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.DeleteProduct(ApiMsgHandler, createdPro2.ProductCode, expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// DiscardDrafts
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AllPending is false")]
        public void ProductPublishingTests_DiscardDrafts2()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            var createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro2.ProductCode);
            Thread.Sleep(3000);
            //AllPending is false
            PublishingScopeFactory.DiscardDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(false, new List<string>() { createdPro1.ProductCode }));
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.OK);
        }

        /// <summary>
        /// DiscardDrafts
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AllPending is null")]
        public void ProductPublishingTests_DiscardDrafts3()
        {
            var masterCatalog = MasterCatalogFactory.GetMasterCatalog(ApiMsgHandler, masterCatalogId);
            if (masterCatalog.ProductPublishingMode.Equals("Live"))
            {
                MasterCatalogFactory.UpdateMasterCatalog(ApiMsgHandler, masterCatalog: masterCatalog, masterCatalogId: masterCatalogId, dataViewMode: DataViewMode.Pending);
            }
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);

            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            var createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro2.ProductCode);
            Thread.Sleep(5000);
            //AllPending is null
            PublishingScopeFactory.DiscardDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.OK);
            //ProductFactory.DeleteProduct(ApiMsgHandler, createdPro1.ProductCode);
            //ProductFactory.DeleteProduct(ApiMsgHandler, createdPro2.ProductCode);
        }

        /// <summary>
        /// DiscardDrafts
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductCodes: not found ProductCode")]  //bug 17977
        public void ProductPublishingTests_DiscardDrafts5()
        {
            var masterCatalog = MasterCatalogFactory.GetMasterCatalog(ApiMsgHandler, masterCatalogId);
            if (masterCatalog.ProductPublishingMode.Equals("Live"))
            {
                MasterCatalogFactory.UpdateMasterCatalog(ApiMsgHandler, masterCatalog: masterCatalog, masterCatalogId: masterCatalogId, dataViewMode: DataViewMode.Pending);
            }
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            var createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro2.ProductCode);
            Thread.Sleep(3000);
            //Nonexistent product code //bug id 21078
            var prodScope =
            Generator.GeneratePublishingScope(null, new List<string>(){Generator.RandomString(3,
                                                          Generator.RandomCharacterGroup.AlphaOnly)});
            PublishingScopeFactory.DiscardDrafts(ApiMsgHandler, prodScope, expectedCode: HttpStatusCode.NotFound);
            //discard all
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(true, null));
            //discard a product already discarded before
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(false, new List<string>() { createdPro1.ProductCode }), expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// UpdateMasterCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode, Live to Pending")]
        public void ProductPublishingTests_UpdateSiteGroup1()
        {
            var masterCatalog = MasterCatalogFactory.GetMasterCatalog(ApiMsgHandler, masterCatalogId);
            if (masterCatalog.ProductPublishingMode.Equals("Pending"))
            {
                PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(true, null));
                var mode = MasterCatalogFactory.GetMasterCatalog(ApiMsgHandler, masterCatalogId);
                if (mode.ProductPublishingMode.Equals("Pending"))
                {
                    MasterCatalogFactory.UpdateMasterCatalog(ApiMsgHandler, masterCatalog: masterCatalog, masterCatalogId: masterCatalogId, dataViewMode: DataViewMode.Live);
                }
            }
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live);
            var mode1 = MasterCatalogFactory.GetMasterCatalog(ApiMsgHandler, masterCatalogId);
            if (mode1.ProductPublishingMode.Equals("Live"))
            {
                MasterCatalogFactory.UpdateMasterCatalog(ApiMsgHandler, masterCatalog: masterCatalog, masterCatalogId: masterCatalogId, dataViewMode: DataViewMode.Pending);
            }
            var createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(3000);
            productCode1.Add(createdPro2.ProductCode);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);

        }

        /// <summary>
        /// UpdateMasterCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode, Pending to Live")]
        public void ProductPublishingTests_UpdateSiteGroup2()
        {
            var masterCatalog = MasterCatalogFactory.GetMasterCatalog(ApiMsgHandler, masterCatalogId);
            if (masterCatalog.ProductPublishingMode.Equals("Live"))
            {
                Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            }
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);

            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(5000);
            productCode1.Add(createdPro1.ProductCode);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            MasterCatalogFactory.UpdateMasterCatalog(ApiMsgHandler, masterCatalog: masterCatalog, masterCatalogId: masterCatalogId, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.Conflict);
            //PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(false, null));

        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true, Update a product, productinsite, add a site")]
        public void ProductPublishingTests_UpdateProduct5()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            //cat1 at in first site
            var catObj1 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat1 = CategoryFactory.AddCategory(ApiMsgHandler, catObj1);
            cateIds1.Add(createdCat1.Id.Value);
            //cat2 is in second site
            var msgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId, TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, siteId);
            var catObj2 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat2 = CategoryFactory.AddCategory(msgHandler, catObj2);
            cateIds1.Add(createdCat2.Id.Value);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(3000);
            productCode1.Add(createdPro1.ProductCode);
            var proInfo = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, createdCat1.Id);
            //add product to first site
            ProductFactory.AddProductInCatalog(msgHandler, proInfo, createdPro1.ProductCode);
            Thread.Sleep(3000);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            // add product to second site also
            var getPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode);
            proInfo = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, createdCat2.Id);
            getPro.ProductInCatalogs.Add(proInfo);
            ProductFactory.UpdateProduct(ApiMsgHandler, getPro, createdPro1.ProductCode);
            getPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live);
            Assert.AreEqual(1, getPro.ProductInCatalogs.Count);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            getPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live);
            Assert.AreEqual(2, getPro.ProductInCatalogs.Count);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true, Update a product's content")]
        public void ProductPublishingTests_UpdateProduct7()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(3000);
            productCode1.Add(createdPro1.ProductCode);

            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            string originalContent = createdPro1.Content.ProductName;
            createdPro1.Content = Generator.GenerateProductLocalizedContent(Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            ProductFactory.UpdateProduct(ApiMsgHandler, createdPro1, createdPro1.ProductCode);
            var getPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live);
            Assert.AreEqual(originalContent, getPro.Content.ProductName);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            getPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live);
            Assert.AreEqual(createdPro1.Content.ProductName, getPro.Content.ProductName);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true, Update a product, stock")]
        public void ProductPublishingTests_UpdateProductStock1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var product = Generator.GenerateProduct();
            //product.InventoryInfo.ManageStock = true;
            //product.InventoryInfo.OutOfStockBehavior = "AllowBackorder";
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(3000);
            productCode1.Add(createdPro1.ProductCode);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
           /* var loc = LocationFactory.GetLocations(ApiMsgHandler);
            var locCode = loc.Items[0].Code;
            var stockOnHand = Generator.RandomInt(200, 300);
            //StockAvailable - (StockOnHand minus Reserved.) Products are reserved using the ProductReservation resource
            //var stockBackOrder = Generator.RandomInt(10, 60);
            var locInv = Generator.GenerateLocationInventory(locCode, createdPro1.ProductCode,
                                                                            null, null, stockOnHand);
            //locInv.StockOnBackOrder = stockBackOrder;
            var locInvs = Generator.GenerateLocationInventoryList();
            locInvs.Add(locInv);
            LocationInventoryFactory.AddLocationInventory(ApiMsgHandler, locInvs, locCode);
            var getLocInv = LocationInventoryFactory.GetLocationInventory(ApiMsgHandler, locCode,
                                                                          createdPro1.ProductCode);
            Assert.AreEqual(stockOnHand, getLocInv.StockOnHand);
            Assert.AreEqual(stockOnHand, getLocInv.StockAvailable);
            */
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("viewmode = live")]
        public void ProductPublishingTests_GetProducts1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            //Add Category
            var catObj1 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat1 = CategoryFactory.AddCategory(ApiMsgHandler, catObj1);
            cateIds1.Add(createdCat1.Id.Value);
            var catObj2 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat2 = CategoryFactory.AddCategory(ApiMsgHandler, catObj2);
            cateIds1.Add(createdCat2.Id.Value);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            var createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro2.ProductCode);
            Thread.Sleep(3000);
            var createdPro3 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro3.ProductCode);
            Thread.Sleep(3000);
            var proInfo = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, createdCat1.Id);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, proInfo, createdPro1.ProductCode);
            Thread.Sleep(2000);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode, createdPro2.ProductCode }));

            var prodInCatalog = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode);
            var originalPrice = createdPro1.Price;
            prodInCatalog.Price = Generator.GenerateProductPrice(price: Generator.RandomDecimal(10, 50));

            ProductFactory.UpdateProduct(ApiMsgHandler, prodInCatalog, createdPro1.ProductCode);
            Thread.Sleep(3000);
            var products = ProductFactory.GetProducts(ApiMsgHandler, pageSize: 230, dataViewMode: DataViewMode.Live);
            bool found1 = false;
            foreach (var pro in products.Items)
            {
                if (createdPro1.ProductCode == pro.ProductCode)
                {
                    found1 = true;
                    Assert.AreEqual(originalPrice.Price.Value, pro.Price.Price.Value);
                    Assert.AreEqual("Draft", pro.PublishingInfo.PublishedState);
                }
            }
            Assert.IsTrue(found1);
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("viewmode = pending")]
        public void ProductPublishingTests_GetProducts2()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            //Add Category
            var catObj1 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat1 = CategoryFactory.AddCategory(ApiMsgHandler, catObj1);
            cateIds1.Add(createdCat1.Id.Value);
            var catObj2 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat2 = CategoryFactory.AddCategory(ApiMsgHandler, catObj2);
            cateIds1.Add(createdCat2.Id.Value);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            var proInfo = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, createdCat1.Id);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, proInfo, createdPro1.ProductCode);
            Thread.Sleep(3000);
            //Publish drafts
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            var prodInCatalog = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode);
            var originalPrice = createdPro1.Price;
            prodInCatalog.Price = Generator.GenerateProductPrice(price: Generator.RandomDecimal(10, 50));
            ProductFactory.UpdateProduct(ApiMsgHandler, prodInCatalog, createdPro1.ProductCode);
            var products = ProductFactory.GetProducts(ApiMsgHandler, pageSize: 200, dataViewMode: DataViewMode.Pending);
            bool found1 = false;
            foreach (var pro in products.Items)
            {
                if (createdPro1.ProductCode == pro.ProductCode)
                {
                    found1 = true;
                    Assert.AreEqual(prodInCatalog.Price.Price.Value, pro.Price.Price.Value);
                    Assert.AreEqual("Draft", pro.PublishingInfo.PublishedState);
                }
            }
            Assert.IsTrue(found1);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true")]
        public void ProductPublishingTests_AddProduct1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro1.ProductCode);
            Thread.Sleep(3000);
            var createdPro2 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            productCode1.Add(createdPro2.ProductCode);
            Thread.Sleep(3000);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.OK);
            var getPro2 = ProductFactory.GetProduct(ApiMsgHandler, createdPro2.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.OK);
            Assert.AreEqual("New", getPro2.PublishingInfo.PublishedState);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true, UpdatepProductInsite:category")]
        public void ProductPublishingTests_UpdateProductInsite1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var catObj1 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat1 = CategoryFactory.AddCategory(ApiMsgHandler, catObj1);
            cateIds1.Add(createdCat1.Id.Value);
            var catObj2 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat2 = CategoryFactory.AddCategory(ApiMsgHandler, catObj2);
            cateIds1.Add(createdCat2.Id.Value);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(3000);
            productCode1.Add(createdPro1.ProductCode);
            var proInfo = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, createdCat1.Id);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, proInfo, createdPro1.ProductCode);
            Thread.Sleep(3000);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            var readPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live);
            Assert.AreEqual(createdCat1.Id, readPro.ProductInCatalogs.First().ProductCategories.First().CategoryId);
            //change product category from 1 to 2
            proInfo = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, createdCat2.Id);
            ProductFactory.UpdateProductInCatalog(ApiMsgHandler, proInfo, createdPro1.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            readPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live);
            Assert.AreEqual(createdCat1.Id, readPro.ProductInCatalogs.First().ProductCategories.First().CategoryId);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            readPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live);
            Assert.AreEqual(createdCat2.Id, readPro.ProductInCatalogs.First().ProductCategories.First().CategoryId);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true, UpdatepProductInsite:price, content, seocontent")]
        public void ProductPublishingTests_UpdateProductInsite2()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var catObj1 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat1 = CategoryFactory.AddCategory(ApiMsgHandler, catObj1);
            cateIds1.Add(createdCat1.Id.Value);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(3000);
            productCode1.Add(createdPro1.ProductCode);
            var proInfo = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, createdCat1.Id);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, proInfo, createdPro1.ProductCode);
            Thread.Sleep(3000);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            var getPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live);
            var originalInfo = getPro.ProductInCatalogs.First();
            var info = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, originalInfo.ProductCategories, Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly), Generator.RandomDecimal(10, 100), true, true, true, true);
            ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info, createdPro1.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            var readInfo = ProductFactory.GetProductInCatalog(ApiMsgHandler, createdPro1.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, dataViewMode: DataViewMode.Live);
            Assert.AreEqual(originalInfo.Content.ProductName, readInfo.Content.ProductName);
            Assert.AreEqual(originalInfo.Price.Price.Value, readInfo.Price.Price.Value);
            readInfo = ProductFactory.GetProductInCatalog(ApiMsgHandler, createdPro1.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, dataViewMode: DataViewMode.Pending);
            Assert.AreEqual(info.Content.ProductName, readInfo.Content.ProductName);
            Assert.AreEqual(info.Price.Price.Value, readInfo.Price.Price.Value);
        }

        /// <summary>
        /// DeleteProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true, DeleteProductInsite")]
        public void ProductPublishingTests_DeleteProductInsite1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var ApiMsgHandler1 = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id,
                                                                             TestBaseTenant.MasterCatalogs.First().Id);
            var catObj1 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat1 = CategoryFactory.AddCategory(ApiMsgHandler1, catObj1);
            cateIds1.Add(createdCat1.Id.Value);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(3000);
            productCode1.Add(createdPro1.ProductCode);
            var proInfo = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, createdCat1.Id);
            ProductFactory.AddProductInCatalog(ApiMsgHandler1, proInfo, createdPro1.ProductCode);
            Thread.Sleep(3000);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            ProductFactory.DeleteProductInCatalog(ApiMsgHandler1, createdPro1.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            ProductFactory.GetProductInCatalog(ApiMsgHandler1, createdPro1.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, dataViewMode: DataViewMode.Live);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            ProductFactory.GetProductInCatalog(ApiMsgHandler1, createdPro1.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProductInCatalog(ApiMsgHandler1, createdPro1.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.NotFound);

        }

        /// <summary>
        /// DeleteProduct
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true, DeleteProduct")]
        public void ProductPublishingTests_DeleteProduct1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var ApiMsgHandler1 = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id,
                                                                             TestBaseTenant.MasterCatalogs.First().Id);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(3000);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            ProductFactory.DeleteProduct(ApiMsgHandler1, createdPro1.ProductCode);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, expectedCode: HttpStatusCode.NotFound);
            ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Pending, expectedCode: HttpStatusCode.NotFound);

        }

        /// <summary>
        /// GetProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("viewmode = pending or live, GetProductInCatalogs")]
        public void ProductPublishingTests_GetProductInCatalogs1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            // add to site 1 and publish
            var catObj1 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat1 = CategoryFactory.AddCategory(ApiMsgHandler, catObj1);
            cateIds1.Add(createdCat1.Id.Value);
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            var attributeFQN1 = new List<string>();
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var prodType = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var myPT = ProductTypeFactory.AddProductType(ApiMsgHandler, prodType);
            Thread.Sleep(3000);
            productTypeId1.Add(myPT.Id.Value);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, Generator.GenerateProduct(myPT));
            Thread.Sleep(3000);
            productCode1.Add(createdPro1.ProductCode);
            var proInfo = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, createdCat1.Id);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, proInfo, createdPro1.ProductCode);
            Thread.Sleep(3000);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));

            //add to site 2
            var ApiMsgHandler1 = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id, masterCatalogId,
                                                                              TestBaseTenant.MasterCatalogs[0].Catalogs.Last().Id);
            var catObj2 = Generator.GenerateCategory(Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly));
            var createdCat2 = CategoryFactory.AddCategory(ApiMsgHandler1, catObj2);
            cateIds1.Add(createdCat2.Id.Value);
            proInfo = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, createdCat2.Id);
            ProductFactory.AddProductInCatalog(ApiMsgHandler1, proInfo, createdPro1.ProductCode);
            Thread.Sleep(3000);
            //verify when mode=live          
            var readPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live);
            Assert.AreEqual(1, readPro.ProductInCatalogs.Count);
            //verify when mode=pending          
            readPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Pending);
            Assert.AreEqual(2, readPro.ProductInCatalogs.Count);
        }

        
        /// <summary>
        /// GetProductVariations
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true, GetProductVariations")]
        public void ProductPublishingTests_GetProductVariations1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var attrs = Generator.PrepareProductType(ApiMsgHandler);

            var shirtType = ProductTypeFactory.AddProductType(ApiMsgHandler, attrs);
            productTypeId1.Add(shirtType.Id.Value);
            Thread.Sleep(3000);
            var po = Generator.GenerateProductOptionList();
            po.Add(Generator.GenerateProductOption(shirtType.Options[0], 2));
            po.Add(Generator.GenerateProductOption(shirtType.Options[1], 2));
            po.Add(Generator.GenerateProductOption(shirtType.Options[2], 2));

            var pt = Generator.GenerateProduct(shirtType.Id, null, po, null);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, pt);
            Thread.Sleep(3000);
            productCode1.Add(createdPro1.ProductCode);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            var vars = ProductTypeVariationFactory.GenerateProductVariations(ApiMsgHandler, createdPro1.Options,
                                                      (int)createdPro1.ProductTypeId, startIndex: 0, pageSize: 20);
            var variation = vars.Items.First();
            variation.IsActive = true;
            ProductVariationFactory.UpdateProductVariation(ApiMsgHandler, variation, createdPro1.ProductCode,
                                                        variation.Variationkey);
            var variations = ProductVariationFactory.GetProductVariations(ApiMsgHandler, createdPro1.ProductCode, filter: "isactive eq true", dataViewMode: DataViewMode.Live);
            Assert.AreEqual(0, variations.TotalCount);

            variations = ProductVariationFactory.GetProductVariations(ApiMsgHandler, createdPro1.ProductCode, filter: "isactive eq true", dataViewMode: DataViewMode.Pending);
            Assert.AreEqual(1, variations.TotalCount);
            foreach (var p in po)
            {
                ProductOptionFactory.DeleteOption(ApiMsgHandler, createdPro1.ProductCode, p.AttributeFQN);
            }
            foreach (var v in variations.Items)
            {
                ProductVariationFactory.DeleteProductVariation(ApiMsgHandler, createdPro1.ProductCode, v.Variationkey);
            }

        }

        /// <summary>
        /// GetProductVariation
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true, GetProductVariation")]
        public void ProductPublishingTests_GetProductVariation1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var attrs = Generator.PrepareProductType(ApiMsgHandler);

            var shirtType = ProductTypeFactory.AddProductType(ApiMsgHandler, attrs);
            Thread.Sleep(5000);
            productTypeId1.Add(shirtType.Id.Value);
            var po = Generator.GenerateProductOptionList();;
            po.Add(Generator.GenerateProductOption(shirtType.Options[0], 2));
            po.Add(Generator.GenerateProductOption(shirtType.Options[1], 2));
            po.Add(Generator.GenerateProductOption(shirtType.Options[2], 2));
            var pt = Generator.GenerateProduct(shirtType.Id, null, po, null);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, pt);
            Thread.Sleep(3000);
            productCode1.Add(createdPro1.ProductCode);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            var vars = ProductTypeVariationFactory.GenerateProductVariations(ApiMsgHandler, createdPro1.Options,
                                                      (int)createdPro1.ProductTypeId, startIndex: 0, pageSize: 20);
            var variation = vars.Items.First();
            variation.IsActive = true;
            ProductVariationFactory.UpdateProductVariation(ApiMsgHandler, variation, createdPro1.ProductCode,
                                                        variation.Variationkey);
            var getVar = ProductVariationFactory.GetProductVariation(ApiMsgHandler, createdPro1.ProductCode, variation.Variationkey, dataViewMode: DataViewMode.Live);
            Assert.AreEqual(false, getVar.IsActive);

            getVar = ProductVariationFactory.GetProductVariation(ApiMsgHandler, createdPro1.ProductCode, variation.Variationkey, dataViewMode: DataViewMode.Pending);
            Assert.AreEqual(true, getVar.IsActive);
            foreach (var p in po)
            {
                ProductOptionFactory.DeleteOption(ApiMsgHandler, createdPro1.ProductCode, p.AttributeFQN);
            }
            ProductVariationFactory.DeleteProductVariation(ApiMsgHandler, createdPro1.ProductCode, getVar.Variationkey);
        }

        /// <summary>
        /// UpdateProductVariations
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true, UpdateProductVariations")]
        public void ProductPublishingTests_UpdateProductVariations1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var attrs = Generator.PrepareProductType(ApiMsgHandler);

            var shirtType = ProductTypeFactory.AddProductType(ApiMsgHandler, attrs);
            productTypeId1.Add(shirtType.Id.Value);
            var po = Generator.GenerateProductOptionList();;
            po.Add(Generator.GenerateProductOption(shirtType.Options[0], 2));
            po.Add(Generator.GenerateProductOption(shirtType.Options[1], 2));
            po.Add(Generator.GenerateProductOption(shirtType.Options[2], 2));
            var pt = Generator.GenerateProduct(shirtType.Id, null, po, null);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, pt);
            Thread.Sleep(3000);
            productCode1.Add(createdPro1.ProductCode);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            var vars = ProductTypeVariationFactory.GenerateProductVariations(ApiMsgHandler, createdPro1.Options,
                                                      (int)createdPro1.ProductTypeId, startIndex: 0, pageSize: 20);
            var variation1 = vars.Items.First();
            variation1.IsActive = true;
            var variation2 = vars.Items.Last();
            variation2.IsActive = true;

            var productVariationList = Generator.GenerateProductVariationList();
            productVariationList.Add(variation1);
            productVariationList.Add(variation2);
            var variationCollection = Generator.GenerateProductVariationCollection(productVariationList, 2);

            ProductVariationFactory.UpdateProductVariations(ApiMsgHandler, variationCollection, createdPro1.ProductCode);
            var getVar = ProductVariationFactory.GetProductVariations(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, filter: "isactive eq true");
            Assert.AreEqual(0, getVar.TotalCount);

            getVar = ProductVariationFactory.GetProductVariations(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Pending, filter: "isactive eq true");
            Assert.AreEqual(2, getVar.TotalCount);

            var getPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode);
            Assert.AreEqual("Draft", getPro.PublishingInfo.PublishedState);
            //publish
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            getVar = ProductVariationFactory.GetProductVariations(ApiMsgHandler, createdPro1.ProductCode, dataViewMode: DataViewMode.Live, filter: "isactive eq true");
            Assert.AreEqual(2, getVar.TotalCount);
            getPro = ProductFactory.GetProduct(ApiMsgHandler, createdPro1.ProductCode);
            Assert.AreEqual("Live", getPro.PublishingInfo.PublishedState);
            foreach (var p in po)
            {
                //bug id 21072
                ProductOptionFactory.DeleteOption(ApiMsgHandler, createdPro1.ProductCode, p.AttributeFQN);
            }
            foreach (var v in vars.Items)
            {
                if (v.IsActive.Value)
                {
                    ProductVariationFactory.DeleteProductVariation(ApiMsgHandler, createdPro1.ProductCode, v.Variationkey);
                }

            }
        }

        /// <summary>
        /// DeleteProductVariation
        /// </summary>
        [TestMethod]
        [TestCategory("ProductPublishing")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductPublishingMode is true, DeleteProductVariation")]
        public void ProductPublishingTests_DeleteProductVariation1()
        {
            var masterCatalog = Generator.SetMasterCatalogPendingMode(ApiMsgHandler, masterCatalogId);
            var attrs = Generator.PrepareProductType(ApiMsgHandler);

            var shirtType = ProductTypeFactory.AddProductType(ApiMsgHandler, attrs);
            Thread.Sleep(3000);
            productTypeId1.Add(shirtType.Id.Value);
            var po = Generator.GenerateProductOptionList();;
            po.Add(Generator.GenerateProductOption(shirtType.Options[0], 2));
            po.Add(Generator.GenerateProductOption(shirtType.Options[1], 2));
            po.Add(Generator.GenerateProductOption(shirtType.Options[2], 2));
            var pt = Generator.GenerateProduct(shirtType.Id, null, po, null);
            var createdPro1 = ProductFactory.AddProduct(ApiMsgHandler, pt);
            Thread.Sleep(3000);
            productCode1.Add(createdPro1.ProductCode);
            var vars = ProductTypeVariationFactory.GenerateProductVariations(ApiMsgHandler, createdPro1.Options,
                                                      (int)createdPro1.ProductTypeId, startIndex: 0, pageSize: 20);
            var variation = vars.Items.First();
            variation.IsActive = true;
            ProductVariationFactory.UpdateProductVariation(ApiMsgHandler, variation, createdPro1.ProductCode,
                                                        variation.Variationkey);
            PublishingScopeFactory.PublishDrafts(ApiMsgHandler, Generator.GeneratePublishingScope(null, new List<string>() { createdPro1.ProductCode }));
            ProductVariationFactory.DeleteProductVariation(ApiMsgHandler, createdPro1.ProductCode, variation.Variationkey);
            var getVar = ProductVariationFactory.GetProductVariation(ApiMsgHandler, createdPro1.ProductCode, variation.Variationkey, dataViewMode: DataViewMode.Live);
            Assert.AreEqual(false, getVar.VariationExists);
            foreach (var p in po)
            {
                ProductOptionFactory.DeleteOption(ApiMsgHandler, createdPro1.ProductCode, p.AttributeFQN);
            }
        }
    }
}
