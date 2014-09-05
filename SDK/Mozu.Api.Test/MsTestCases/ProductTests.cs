using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Test.Helpers;
using Mozu.Api.Test.Factories;
using System.Configuration;
using Attribute = Mozu.Api.Contracts.ProductAdmin.Attribute;
using System.Threading;


namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class ProductTests : MozuApiTestBase
    {

        #region NonTestCaseCode
        private static List<string> productCode1 = new List<string>();
        private static List<int> productTypeId1 = new List<int>();
        private static List<string> attributeFQN1 = new List<string>();

        public ProductTests()
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
            productCode1.Clear();
            productTypeId1.Clear();
            attributeFQN1.Clear();
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


        
        /// <summary>
        /// GetProducts
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("StartIndex, PageSize")]
        public void GetProductsTest1()
        {
            
            int pageSize = 5;
            int totalCount = 0;
            int startIndex = 0;
            int expectedTotalCount = 0;
            var messageHandler = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id,
                                                       TestBaseTenant.MasterCatalogs.First().Id);
            var prodList = Generator.GenerateProductsRandom(messageHandler, "grp", 18);
            foreach (var p in prodList)
            {
                productCode1.Add(p.ProductCode);
            }
            productTypeId1.Add(prodList[0].ProductTypeId.Value);
            
            while (true)
            {            
                var prods = ProductFactory.GetProducts(messageHandler, startIndex: startIndex, pageSize: pageSize);
                Assert.AreEqual(startIndex, prods.StartIndex);
                Assert.AreEqual((prods.TotalCount + prods.PageSize - 1) / prods.PageSize, prods.PageCount);
                totalCount += prods.Items.Count;
                startIndex += pageSize;
                if (prods.Items.Count < pageSize)
                {
                    expectedTotalCount = (int)prods.TotalCount;
                    break;
                }
            }
            Assert.AreEqual(expectedTotalCount, totalCount);
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("sortBy")]
        public void GetProductsTest2()
        {
            var messageHandler = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id,
                                                        TestBaseTenant.MasterCatalogs.First().Id);
            var prodList = Generator.GenerateProductsRandom(messageHandler, "site-", 13);
            foreach (var p in prodList)
            {
                productCode1.Add(p.ProductCode);
            }
            productTypeId1.Add(prodList[0].ProductTypeId.Value);
            var prods = ProductFactory.GetProducts(messageHandler, sortBy: "ProductSequence asc");
            Assert.IsTrue(prods.Items.First().ProductSequence < prods.Items.Last().ProductSequence);

            prods = ProductFactory.GetProducts(messageHandler, sortBy: "ProductSequence desc");
            Assert.IsTrue(prods.Items.First().ProductSequence > prods.Items.Last().ProductSequence);
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("filter")]
        public void GetProductsTest3()
        {
            var messageHandler = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id,
                                                        TestBaseTenant.MasterCatalogs.First().Id);
            var prodList = Generator.GenerateProductsRandom(messageHandler, "grp", 3);
            foreach (var p in prodList)
            {
                productCode1.Add(p.ProductCode);
            }
            productTypeId1.Add(prodList[0].ProductTypeId.Value);
            var prods = ProductFactory.GetProducts(messageHandler);
            var prods1 = ProductFactory.GetProducts(messageHandler, filter: "ProductSequence eq " + prods.Items.First().ProductSequence.Value);
            Assert.AreEqual(1, prods1.TotalCount);
            var getProduct = ProductFactory.GetProduct(messageHandler, prods.Items.First().ProductCode);
            Assert.AreEqual(prods.Items.First().ProductSequence, getProduct.ProductSequence);
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("q - site level : ProductCode and ProductName")]
        public void GetProductsTest5()
        {
            var messageHandler = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id,
                                                        TestBaseTenant.MasterCatalogs.First().Id,
                                                        TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            var prodList = Generator.GenerateProductsRandom(messageHandler, "grp", 8);
            foreach (var p in prodList)
            {
                productCode1.Add(p.ProductCode);
            }
            productTypeId1.Add(prodList[0].ProductTypeId.Value);
            var cates = CategoryFactory.GetCategories(messageHandler);
            if (cates.Items.Count < 2)
            {
                var cat1 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                var cat2 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
            }
            cates = CategoryFactory.GetCategories(messageHandler);
            foreach (var p in prodList)
            {
                ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                    masterCatalogId, cates.Items.First().Id, null, false, false, false), p.ProductCode);
            
            }
            var prodList1 = Generator.GenerateProductsRandom(messageHandler, "site-", 11);
            foreach (var p in prodList1)
            {
                productCode1.Add(p.ProductCode);
            }
            productTypeId1.Add(prodList1[0].ProductTypeId.Value);
            foreach (var p in prodList1)
            {
                ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                    masterCatalogId, cates.Items.Last().Id, null, false, false, false), p.ProductCode);

            }

            var products = ProductFactory.GetProducts(messageHandler, q: "grp*");
            //Assert.AreEqual(8, products.TotalCount);
            products = ProductFactory.GetProducts(messageHandler, q: "site*");
            //Assert.AreEqual(11, products.TotalCount);

        }

        /// <summary>
        /// GetProducts
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("q - sitegroup level : ProductCode and ProductName")]
        public void GetProductsTest6()
        {
            var messageHandler = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id,
                                                        TestBaseTenant.MasterCatalogs.First().Id);
            var prodColl = Generator.GenerateProductsRandom(messageHandler, "grp", 2);
            foreach (var p in prodColl)
            {
                productCode1.Add(p.ProductCode);
            }
            var prodColl1 = Generator.GenerateProductsRandom(messageHandler, "site-", 4);
            foreach (var p in prodColl1)
            {
                productCode1.Add(p.ProductCode);
            }
            var prodColl2 = Generator.GenerateProductsRandom(messageHandler, "group", 2);
            foreach (var p in prodColl2)
            {
                productCode1.Add(p.ProductCode);
            }
            Thread.Sleep(8000);
            var products = ProductFactory.GetProducts(messageHandler, q: "grp*");
            Assert.AreEqual(2, products.TotalCount);
            products = ProductFactory.GetProducts(messageHandler, q: "site*");
            //Assert.AreEqual(4, products.TotalCount);

            var products1 = ProductFactory.GetProducts(messageHandler, q: prodColl2[1].ProductCode);
            Assert.AreEqual(1, products1.TotalCount);
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("q - multiple words")]
        public void GetProductsTest7()
        {
            var messageHandler = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id,
                                                        TestBaseTenant.MasterCatalogs.First().Id);
            var prodColl = Generator.GenerateProductsRandom(messageHandler, "b1KL7 ", 2);
            foreach (var p in prodColl)
            {
                productCode1.Add(p.ProductCode);
            }
            var prodColl1 = Generator.GenerateProductsRandom(messageHandler, "site pro", 9);
            foreach (var p in prodColl1)
            {
                productCode1.Add(p.ProductCode);
            }
            var products = ProductFactory.GetProducts(messageHandler, q: "b1KL7 ");
            //Assert.AreEqual(2, products.TotalCount);

            products = ProductFactory.GetProducts(messageHandler, q: "site*pro*");
            //Assert.AreEqual(9, products.TotalCount);
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("q - word with *")]
        public void GetProductsTest8()
        {
            var messageHandler = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id,
                                                        TestBaseTenant.MasterCatalogs.First().Id);
            var prodColl = Generator.GenerateProductsRandom(messageHandler, "site", 5);
            foreach (var p in prodColl)
            {
                productCode1.Add(p.ProductCode);
            }
            var prodColl1 = Generator.GenerateProductsRandom(messageHandler, "grp", 4);
            foreach (var p in prodColl1)
            {
                productCode1.Add(p.ProductCode);
            }

            var products = ProductFactory.GetProducts(messageHandler, q: "grp* site*");
            Assert.AreEqual(0, products.TotalCount);

            products = ProductFactory.GetProducts(messageHandler, q: "site* ");
            //Assert.AreEqual(5, products.TotalCount);

            products = ProductFactory.GetProducts(messageHandler, q: "sit*");
            //Assert.AreEqual(5, products.TotalCount);

            products = ProductFactory.GetProducts(messageHandler, q: "grp*");
            //Assert.AreEqual(4, products.TotalCount);        
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("qlimit")]
        public void GetProductsTest10()
        {
            var messageHandler = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id,
                                                        TestBaseTenant.MasterCatalogs.First().Id);
            var prodColl = Generator.GenerateProductsRandom(messageHandler, "site", 10);
            foreach (var p in prodColl)
            {
                productCode1.Add(p.ProductCode);
            }
            Thread.Sleep(8000);
            var products = ProductFactory.GetProducts(messageHandler, q: prodColl[7].Content.ProductName, qLimit: 0);
            Assert.AreEqual(0, products.TotalCount);

            products = ProductFactory.GetProducts(messageHandler, q: prodColl[7].Content.ProductName, qLimit: 1);
            Assert.AreEqual(1, products.TotalCount);

            products = ProductFactory.GetProducts(messageHandler, q: "site*", qLimit: 3);
            Assert.AreEqual(3, products.TotalCount);

            products = ProductFactory.GetProducts(messageHandler, q: "site*", qLimit: 5, pageSize: 3);
            Assert.AreEqual(5, products.TotalCount);
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description(".")]
        public void GetProductsTest11()
        {
            var messageHandler = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id,
                                                        TestBaseTenant.MasterCatalogs.First().Id);
            var prodColl = Generator.GenerateProductsRandom(messageHandler, "abc.xyz", 2);
            foreach (var p in prodColl)
            {
                productCode1.Add(p.ProductCode);
            }
            Thread.Sleep(8000);
            var products = ProductFactory.GetProducts(messageHandler, q: "abc.xyz*");
            Assert.AreEqual(2, products.TotalCount);
        }

        /// <summary>
        /// GetProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("positive")]
        public void GetProductTest1()
        {
            var messageHandler = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id,
                                                        TestBaseTenant.MasterCatalogs.First().Id);
            var prodColl = Generator.GenerateProductsRandom(messageHandler, "spyd", 5);
            foreach (var p in prodColl)
            {
                productCode1.Add(p.ProductCode);
            }
            Thread.Sleep(5000);
            var prods = ProductFactory.GetProducts(messageHandler);
            var result = ProductFactory.GetProduct(messageHandler, prods.Items.Last().ProductCode);
            Assert.AreEqual(prods.Items.Last().ProductCode, result.ProductCode);
        }

        /// <summary>
        /// GetProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("not found")]
        public void GetProductTest2()
        {
            ProductFactory.GetProduct(ApiMsgHandler, Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly), expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductTypeId, not found")]
        public void AddProductTest1()
        {
            var pts = ProductTypeFactory.GetProductTypes(ApiMsgHandler, sortBy: "Id desc");
            var pro = Generator.GenerateProduct(pts.Items.First().Id.Value + 1);
            ProductFactory.AddProduct(ApiMsgHandler, pro, expectedCode: HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductTypeId, not found")]
        public void AddProductTest2()
        {
            var pts = ProductTypeFactory.GetProductTypes(ApiMsgHandler, sortBy: "Id desc");
            var pro = Generator.GenerateProduct(pts.Items.First().Id.Value + 1);
            ProductFactory.AddProduct(ApiMsgHandler, pro, expectedCode: HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("IsRequiredByAdmin is false, IsValidForProductType is true")]
        public void AddProductTest3()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            myPT.Properties.First().IsRequiredByAdmin = false;
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.IsTrue(createdProduct.IsValidForProductType.Value);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("IsRequiredByAdmin is true, IsValidForProductType is false")]
        public void AddProductTest4()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            myPT.Properties.First().IsRequiredByAdmin = true;
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            myProduct.Properties.Clear();
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.IsFalse(createdProduct.IsValidForProductType.Value);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("HasConfigurableOptions is false")]
        public void AddProductTest5()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.IsFalse(createdProduct.HasConfigurableOptions);

        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("HasConfigurableOptions is true,  HasStandAloneOptions is false")]
        public void AddProductTest6()
        {
            var attrObj = Generator.GenerateAttribute(isOption: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.IsTrue(createdProduct.HasConfigurableOptions);
            Assert.IsFalse(createdProduct.HasStandAloneOptions);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("HasStandAloneOptions is true")]
        public void AddProductTest7()
        {
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr, Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.IsTrue(createdProduct.HasStandAloneOptions);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Options, not existent value")]
        public void AddProductTest8()
        {
            var attrObj = Generator.GenerateAttribute(attributeCode: Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                                                              adminName: Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                                                                              isOption: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            productTypeId1.Add(createdPT.Id.Value);
            var myProduct = Generator.GenerateProduct(createdPT);
            myProduct.Options.First().Values.First().Value = Generator.RandomString(5,
                                                                                    Generator.RandomCharacterGroup
                                                                                             .AlphaOnly);
            ProductFactory.AddProduct(ApiMsgHandler, myProduct, expectedCode: HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Extras: IsRequired, IsMultiSelect")]
        public void AddProductTest9()
        {
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            productTypeId1.Add(createdPT.Id.Value);
            var myProduct = Generator.GenerateProduct(createdPT);
            myProduct.Extras.First().IsMultiSelect = true;
            myProduct.Extras.First().IsRequired = true;
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            Assert.IsTrue(createdProduct.Extras.First().IsMultiSelect.Value);
            Assert.IsTrue(createdProduct.Extras.First().IsRequired.Value);
            myProduct.ProductCode = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly);
            myProduct.Extras.First().IsMultiSelect = false;
            myProduct.Extras.First().IsRequired = false;
            createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            Assert.IsFalse(createdProduct.Extras.First().IsMultiSelect.Value);
            Assert.IsFalse(createdProduct.Extras.First().IsRequired.Value);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductCode, UPC")]
        public void AddProductTest10()
        {
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            myProduct.ProductCode = Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly);
            myProduct.Upc = Generator.RandomUPC();
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.AreEqual(myProduct.ProductCode, createdProduct.ProductCode);
            Assert.AreEqual(myProduct.Upc, createdProduct.Upc);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Set true: IsBackOrderAllowed, IsHiddenWhenOutOfStock, IsRecurring, IsTaxable, ManageStock")]
        public void AddProductTest11()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
//            myProduct.IsBackOrderAllowed = true;
//            myProduct.IsHiddenWhenOutOfStock = true;
            myProduct.IsRecurring = true;
            myProduct.IsTaxable = true;
            myProduct.InventoryInfo = Generator.GenerateProductInventoryInfo(true, 
                "DisplayMessage");

            myProduct.IsVariation = true;
            myProduct.HasConfigurableOptions = true;
            myProduct.HasStandAloneOptions = true;
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.AreEqual("DisplayMessage", createdProduct.InventoryInfo.OutOfStockBehavior);
            Assert.AreEqual(true, createdProduct.InventoryInfo.ManageStock);
            Assert.IsFalse(createdProduct.HasConfigurableOptions);
            Assert.IsFalse(createdProduct.HasStandAloneOptions);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Set false: IsBackOrderAllowed, IsHiddenWhenOutOfStock, IsRecurring, IsTaxable, ManageStock")]
        //TODO Eileen
        public void AddProductTest12()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
//            myProduct.IsBackOrderAllowed = false;
//            myProduct.IsHiddenWhenOutOfStock = false;
            myProduct.IsRecurring = false;
            myProduct.IsTaxable = false;
//            myProduct.ManageStock = false;
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct, expectedCode: HttpStatusCode.Created);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
//            Assert.IsFalse(createdProduct.IsBackOrderAllowed.Value || createdProduct.IsHiddenWhenOutOfStock.Value ||
//                createdProduct.IsRecurring.Value || createdProduct.IsTaxable.Value || createdProduct.ManageStock.Value);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("StockOnHand")]
        //TODO Eileen
        public void AddProductTest13()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
//            myProduct.StockOnHand = Generator.RandomInt(100, 1000);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
//            Assert.AreEqual(createdProduct.StockOnHand, myProduct.StockOnHand);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductInCatalogs: IsContentOverridden, IsPriceOverridden, IsSeoContentOverridden  --false")]
        public void AddProductTest14()  
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.TotalCount < 1)
                Assert.Inconclusive("no categories at first site");
            myProduct.ProductInCatalogs = Generator.GenerateProductInCatalogInfoList();

            myProduct.ProductInCatalogs = Generator.GenerateProductInCatalogInfoList();
            myProduct.ProductInCatalogs.Add(Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id.Value, null, false, false, false));
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.AreEqual(createdProduct.Content.ProductName, createdProduct.ProductInCatalogs.First().Content.ProductName);
            Assert.AreEqual(createdProduct.Price.Price, createdProduct.ProductInCatalogs.First().Price.Price);
            Assert.AreEqual(createdProduct.SeoContent.TitleTagTitle, createdProduct.ProductInCatalogs.First().SeoContent.TitleTagTitle);
            var messageHandler1 = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, TestBaseTenant.MasterCatalogs.First().Id);
            var info = ProductFactory.GetProductInCatalog(messageHandler1, createdProduct.ProductCode,
                                         TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(cates.Items.First().Id, info.ProductCategories[0].CategoryId);
            Assert.AreEqual(createdProduct.Content.ProductName, info.Content.ProductName);
            Assert.AreEqual(createdProduct.Price.Price, info.Price.Price);
            Assert.AreEqual(createdProduct.SeoContent.TitleTagTitle, info.SeoContent.TitleTagTitle);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Content")]
        public void AddProductTest15()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var imageList = Generator.GenerateProductLocalizedImageList();
            imageList.Add(Generator.GenerateProductLocalizedImage(Generator.RandomURL(), Generator.RandomURL()));

            myProduct.Content =
                Generator.GenerateProductLocalizedContent(
                    Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly), imageList);


            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.AreEqual(myProduct.Content.ProductName, createdProduct.Content.ProductName);
            Assert.AreEqual(myProduct.Content.ProductFullDescription, createdProduct.Content.ProductFullDescription);
            Assert.AreEqual(myProduct.Content.ProductShortDescription, createdProduct.Content.ProductShortDescription);
            Assert.AreEqual(myProduct.Content.ProductImages.First().AltText, createdProduct.Content.ProductImages.First().AltText);
            Assert.AreEqual(myProduct.Content.ProductImages.First().ImageLabel, createdProduct.Content.ProductImages.First().ImageLabel);
            //Assert.AreEqual(myProduct.Content.ProductImages.First().ImagePath, createdProduct.Content.ProductImages.First().ImagePath);
            Assert.AreEqual(myProduct.Content.ProductImages.First().ImageUrl, createdProduct.Content.ProductImages.First().ImageUrl);
            Assert.AreEqual(myProduct.Content.ProductImages.First().VideoUrl, createdProduct.Content.ProductImages.First().VideoUrl);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Price")]
        public void AddProductTest16()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            myProduct.Price.Price = Generator.RandomDecimal(80, 100);
            myProduct.Price.SalePrice = Generator.RandomDecimal(60, 80);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.AreEqual(myProduct.Price.Price, createdProduct.Price.Price);
            Assert.AreEqual(myProduct.Price.SalePrice, createdProduct.Price.SalePrice);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("SeoContent")]
        public void AddProductTest17()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            myProduct.SeoContent = Generator.GenerateProductLocalizedSEOContent();
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.AreEqual(myProduct.SeoContent.MetaTagDescription, createdProduct.SeoContent.MetaTagDescription);
            Assert.AreEqual(myProduct.SeoContent.MetaTagKeywords, createdProduct.SeoContent.MetaTagKeywords);
            Assert.AreEqual(myProduct.SeoContent.MetaTagTitle, createdProduct.SeoContent.MetaTagTitle);
            Assert.AreEqual(myProduct.SeoContent.SeoFriendlyUrl, createdProduct.SeoContent.SeoFriendlyUrl);
            Assert.AreEqual(myProduct.SeoContent.TitleTagTitle, createdProduct.SeoContent.TitleTagTitle);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Measurement")]
        public void AddProductTest18()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            myProduct.PackageHeight = Generator.GenerateMeasurement("in", Generator.RandomDecimal(10, 100));
            myProduct.PackageLength = Generator.GenerateMeasurement("in", Generator.RandomDecimal(10, 100));
            myProduct.PackageWidth = Generator.GenerateMeasurement("in", Generator.RandomDecimal(10, 100));
            myProduct.PackageWeight = Generator.GenerateMeasurement("lbs", Generator.RandomDecimal(10, 100));
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.AreEqual(myProduct.PackageHeight.Value, createdProduct.PackageHeight.Value);
            Assert.AreEqual(myProduct.PackageLength.Value, createdProduct.PackageLength.Value);
            Assert.AreEqual(myProduct.PackageWeight.Value, createdProduct.PackageWeight.Value);
            Assert.AreEqual(myProduct.PackageWidth.Value, createdProduct.PackageWidth.Value);
            Assert.AreEqual(myProduct.PackageHeight.Unit, createdProduct.PackageHeight.Unit);
            Assert.AreEqual(myProduct.PackageLength.Unit, createdProduct.PackageLength.Unit);
            Assert.AreEqual(myProduct.PackageWeight.Unit, createdProduct.PackageWeight.Unit);
            Assert.AreEqual(myProduct.PackageWidth.Unit, createdProduct.PackageWidth.Unit);
        }
        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Measurement 0")]
        public void AddProductTest_null_measurements()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            myProduct.PackageHeight = Generator.GenerateMeasurement("in", 0);
            myProduct.PackageLength = Generator.GenerateMeasurement("in", 0);
            myProduct.PackageWidth = Generator.GenerateMeasurement("in", 0);
            myProduct.PackageWeight = Generator.GenerateMeasurement("lbs", Generator.RandomDecimal(10, 100));
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            productCode1.Add(createdProduct.ProductCode);
            Assert.AreEqual(null, createdProduct.PackageHeight);
            Assert.AreEqual(null, createdProduct.PackageLength);
            Assert.AreEqual(null, createdProduct.PackageWidth);
            Assert.AreEqual(myProduct.PackageWeight.Value, createdProduct.PackageWeight.Value);
            Assert.AreEqual(myProduct.PackageWeight.Unit, createdProduct.PackageWeight.Unit);

            var myProduct2 = Generator.GenerateProduct(createdPT);
            myProduct2.PackageHeight = Generator.GenerateMeasurement("in", 0);
            myProduct2.PackageLength = Generator.GenerateMeasurement("in", 0);
            myProduct2.PackageWidth = Generator.GenerateMeasurement("in", 0);
            myProduct2.PackageWeight = Generator.GenerateMeasurement("lbs", 0);
            //PackageWeight Invalid PackageWeight: PackageWeight must be present with a valid unit, and a value greater than or equal to 0
            var createdProduct2 = ProductFactory.AddProduct(ApiMsgHandler, myProduct2, expectedCode: HttpStatusCode.BadRequest);          
        }
        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("StandAlonePackageType, IsPackagedStandAlone")]
        public void AddProductTest19()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            
            var myProduct = Generator.GenerateProduct(createdPT);
            myProduct.IsPackagedStandAlone = true;

            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            
            Assert.IsTrue(createdProduct.IsPackagedStandAlone.Value);
            Assert.AreEqual(myProduct.StandAlonePackageType, createdProduct.StandAlonePackageType);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AuditInfo")]
        public void AddProductTest20()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            
            var myProduct = Generator.GenerateProduct(createdPT);
            myProduct.AuditInfo = Generator.GenerateAuditInfoRandom();
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct, expectedCode: HttpStatusCode.Created);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.AreNotEqual(myProduct.AuditInfo.CreateBy, createdProduct.AuditInfo.CreateBy);
            Assert.AreNotEqual(((DateTime)myProduct.AuditInfo.CreateDate).Date, ((DateTime)createdProduct.AuditInfo.CreateDate).Date);
            Assert.AreNotEqual(myProduct.AuditInfo.UpdateBy, createdProduct.AuditInfo.UpdateBy);
            Assert.AreNotEqual(((DateTime)myProduct.AuditInfo.UpdateDate).Date, ((DateTime)createdProduct.AuditInfo.UpdateDate).Date);
        }

        /// <summary>
        /// AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductInCatalogs: IsContentOverridden, IsPriceOverridden, IsSeoContentOverridden  --true")]
        public void AddProductTest21()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.TotalCount < 1)
                Assert.Inconclusive("no categories at first site");
            myProduct.ProductInCatalogs =Generator.GenerateProductInCatalogInfoList();
            myProduct.ProductInCatalogs.Add(Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id.Value, null, true, true, true));
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.AreNotEqual(createdProduct.Content.ProductName, createdProduct.ProductInCatalogs.First().Content.ProductName);
            Assert.AreNotEqual(createdProduct.Price.Price, createdProduct.ProductInCatalogs.First().Price.Price);
            Assert.AreNotEqual(createdProduct.SeoContent.TitleTagTitle, createdProduct.ProductInCatalogs.First().SeoContent.TitleTagTitle);
            var messageHandler1 = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, TestBaseTenant.MasterCatalogs.First().Id);
            var info = ProductFactory.GetProductInCatalog(messageHandler1, createdProduct.ProductCode,
                                         TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(cates.Items.First().Id, info.ProductCategories[0].CategoryId);
            Assert.AreNotEqual(createdProduct.Content.ProductName, info.Content.ProductName);
            Assert.AreNotEqual(createdProduct.Price.Price, info.Price.Price);
            Assert.AreNotEqual(createdProduct.SeoContent.TitleTagTitle, info.SeoContent.TitleTagTitle);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("readonly: SiteGroupId, ProductSequence, ProductCode")]
        public void UpdateProductTest1()
        {
            var myPT =
                Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup
                                                                                            .AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            //var prods = ProductFactory.GetProducts(ApiMsgHandler, sortBy: "ProductSequence desc");
            //if (prods.TotalCount == 0 || TestBaseTenant.MasterCatalogs.Count < 2)
            //    Assert.Inconclusive("no products");
            int originalSiteGroupId = createdProduct.MasterCatalogId.Value;
            int originalProductSequence = createdProduct.ProductSequence.Value;
            string originalProductCode = createdProduct.ProductCode;
            createdProduct.MasterCatalogId = TestBaseTenant.MasterCatalogs.Last().Id;
            createdProduct.ProductSequence = originalProductSequence + 1;
            createdProduct.ProductCode = Generator.RandomString(7, Generator.RandomCharacterGroup.AlphaOnly);
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, originalProductCode);
            Assert.AreEqual(originalSiteGroupId, updateProd.MasterCatalogId);
            Assert.AreEqual(originalProductSequence, updateProd.ProductSequence);
            Assert.AreEqual(originalProductCode, updateProd.ProductCode);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductInCatalog : remove ")]
        public void UpdateProductTest2()
        {
            var myPT =
               Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup
                                                                                           .AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.TotalCount < 1)
                Assert.Inconclusive("no categories at first site");
            myProduct.ProductInCatalogs =Generator.GenerateProductInCatalogInfoList();
            myProduct.ProductInCatalogs.Add(Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id.Value));
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode);
            var messageHandler1 = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, TestBaseTenant.MasterCatalogs.First().Id);
            ProductFactory.GetProductInCatalog(messageHandler1, createdProduct.ProductCode,
                                            TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductInCatalog : add ")]
        public void UpdateProductTest3()
        {
            var myPT =
               Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup
                                                                                           .AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            
            Assert.AreEqual(0, createdProduct.ProductInCatalogs.Count);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.TotalCount < 1)
                Assert.Inconclusive("no categories at first site");
            createdProduct.ProductInCatalogs = Generator.GenerateProductInCatalogInfoList();
            createdProduct.ProductInCatalogs.Add(Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id.Value));
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode);
            Assert.AreEqual(1, updateProd.ProductInCatalogs.Count);
            Assert.AreEqual(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, updateProd.ProductInCatalogs[0].CatalogId);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("content")]
        public void UpdateProductTest4()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);

            var imageList = Generator.GenerateProductLocalizedImageList();
            imageList.Add(Generator.GenerateProductLocalizedImage(Generator.RandomURL(), Generator.RandomURL()));
            createdProduct.Content = Generator.GenerateProductLocalizedContent(
                    Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly), imageList);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode);
            Assert.AreEqual(updateProd.Content.ProductName, createdProduct.Content.ProductName);
            Assert.AreEqual(updateProd.Content.ProductFullDescription, createdProduct.Content.ProductFullDescription);
            Assert.AreEqual(updateProd.Content.ProductShortDescription, createdProduct.Content.ProductShortDescription);
            Assert.AreEqual(updateProd.Content.ProductImages.First().AltText, createdProduct.Content.ProductImages.First().AltText);
            Assert.AreEqual(updateProd.Content.ProductImages.First().ImageLabel, createdProduct.Content.ProductImages.First().ImageLabel);
            //Assert.AreEqual(updateProd.Content.ProductImages.First().ImagePath, createdProduct.Content.ProductImages.First().ImagePath);
            Assert.AreEqual(updateProd.Content.ProductImages.First().ImageUrl, createdProduct.Content.ProductImages.First().ImageUrl);
            Assert.AreEqual(updateProd.Content.ProductImages.First().VideoUrl, createdProduct.Content.ProductImages.First().VideoUrl);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("price")]
        public void UpdateProductTest5()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            createdProduct.Price.Price = Generator.RandomDecimal(80, 100);
            createdProduct.Price.SalePrice = Generator.RandomDecimal(60, 80);
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode);
            Assert.AreEqual(updateProd.Price.Price, createdProduct.Price.Price);
            Assert.AreEqual(updateProd.Price.SalePrice, createdProduct.Price.SalePrice);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("SeoContent")]
        public void UpdateProductTest6()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            createdProduct.SeoContent = Generator.GenerateProductLocalizedSEOContent();
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode);
            Assert.AreEqual(createdProduct.SeoContent.MetaTagDescription, createdProduct.SeoContent.MetaTagDescription);
            Assert.AreEqual(createdProduct.SeoContent.MetaTagKeywords, createdProduct.SeoContent.MetaTagKeywords);
            Assert.AreEqual(createdProduct.SeoContent.MetaTagTitle, createdProduct.SeoContent.MetaTagTitle);
            Assert.AreEqual(createdProduct.SeoContent.SeoFriendlyUrl, createdProduct.SeoContent.SeoFriendlyUrl);
            Assert.AreEqual(createdProduct.SeoContent.TitleTagTitle, createdProduct.SeoContent.TitleTagTitle);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("productTypeId, can not be updated")]
        public void UpdateProductTest7()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var firstPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var secondPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT1 = ProductTypeFactory.AddProductType(ApiMsgHandler, firstPT);
            
            var createdPT2 = ProductTypeFactory.AddProductType(ApiMsgHandler, secondPT);
            productTypeId1.Add(createdPT2.Id.Value);
            var myProduct = Generator.GenerateProduct(createdPT1);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            createdProduct.ProductTypeId = createdPT2.Id;
            //ProductTypeId cannot be changed
            ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode, expectedCode: HttpStatusCode.Conflict);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("IsValidForProductType, HasConfigurableOptions, HasStandAloneOptions   ----readonly")]
        public void UpdateProductTest8()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            bool original_IsValidForProductType = createdProduct.IsValidForProductType.Value;
            createdProduct.IsValidForProductType = !original_IsValidForProductType;
            bool original_HasConfigurableOptions = createdProduct.HasConfigurableOptions;
            createdProduct.HasConfigurableOptions = !original_HasConfigurableOptions;
            bool original_HasStandAloneOptions = createdProduct.HasStandAloneOptions;
            createdProduct.HasStandAloneOptions = !original_HasStandAloneOptions;
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode);
            Assert.AreEqual(original_HasConfigurableOptions, updateProd.HasConfigurableOptions);
            Assert.AreEqual(original_HasStandAloneOptions, updateProd.HasStandAloneOptions);
            Assert.AreEqual(original_IsValidForProductType, updateProd.IsValidForProductType);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Options, IsValidForProductType false -> true")]
        public void UpdateProductTest9()
        {
            var attrObj = Generator.GenerateAttribute(attributeCode: Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                adminName: Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly), isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            myPT.Properties.First().IsRequiredByAdmin = true;
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);

            myProduct.Properties.Clear();
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.IsFalse(createdProduct.IsValidForProductType.Value);

            if (createdProduct.Properties == null)
                createdProduct.Properties =  new List<ProductProperty>();//ProductFactory.ProductPropertyList;

            createdProduct.Properties = Generator.GenerateProduct(createdPT).Properties;
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode, expectedCode: HttpStatusCode.OK);
            Assert.IsTrue(updateProd.IsValidForProductType.Value);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Properties, values")]
        public void UpdateProductTest10()
        {
            var attrObj = Generator.GenerateAttribute(attributeCode: Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                adminName: Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly), isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            myPT.Properties.First().IsRequiredByAdmin = true;
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            if (myProduct.Properties.Last().Values.Count != 2)
                Assert.Inconclusive("The values count for the last property is not 2.");
            myProduct.Properties.Last().Values.Remove(myProduct.Properties.Last().Values.Last());
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.AreEqual(createdPT.Properties.Last().VocabularyValues.First().Value, createdProduct.Properties.First().Values.First().Value);
            createdProduct.Properties.First().Values.First().Value =
                createdPT.Properties.Last().VocabularyValues.Last().Value;
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode);
            Assert.AreEqual(createdPT.Properties.Last().VocabularyValues.Last().Value, createdProduct.Properties.First().Values.First().Value);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("isTaxable, ManageStock, IsRecurring, IsBackOrderAllowed, IsHiddenWhenOutOfStock")]
        //TODO Eileen
        public void UpdateProductTest11()
        {
            var myPT =
                Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup
                                                                                            .AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            createdProduct.IsTaxable = Generator.RandomBool();
//            createdProduct.ManageStock = Generator.RandomBool();
            createdProduct.IsRecurring = Generator.RandomBool();
//            createdProduct.IsBackOrderAllowed = Generator.RandomBool();
//            createdProduct.IsHiddenWhenOutOfStock = Generator.RandomBool();
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode);
            Assert.AreEqual(updateProd.IsTaxable, createdProduct.IsTaxable);
//            Assert.AreEqual(updateProd.ManageStock, createdProduct.ManageStock);
            Assert.AreEqual(updateProd.IsRecurring, createdProduct.IsRecurring);
//            Assert.AreEqual(updateProd.IsBackOrderAllowed, createdProduct.IsBackOrderAllowed);
//            Assert.AreEqual(updateProd.IsHiddenWhenOutOfStock, createdProduct.IsHiddenWhenOutOfStock);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("StockOnHand, StockAvailable, StockOnBackOrder")]
        public void UpdateProductTest12()
        { 
            var myPT =
                Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup
                                                                                            .AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Assert.AreEqual(false, createdProduct.InventoryInfo.ManageStock);
            createdProduct.InventoryInfo.ManageStock = true;
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode);
            Assert.AreEqual(true, createdProduct.InventoryInfo.ManageStock);

        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("StandAlonePackageType, isPackedStandAlone")]
        public void UpdateProductTest13()
        {
            var myPT =
                Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup
                                                                                            .AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
//            var prods = ProductFactory.GetProducts(ApiMsgHandler);
            createdProduct.IsPackagedStandAlone = true;
//            createdProduct.StandAlonePackageType = ShippingAdmin.GenerateStandAlonePackageTypeConst();   //TODO Esther
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode, expectedCode: HttpStatusCode.Conflict);
            createdProduct.StandAlonePackageType = Constant.CARRIER_BOX_MEDIUM;
            updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode);
            Assert.IsTrue((bool)updateProd.IsPackagedStandAlone);
            Assert.AreEqual(createdProduct.StandAlonePackageType, updateProd.StandAlonePackageType);
            updateProd.IsPackagedStandAlone = false;
            var updateProd1 = ProductFactory.UpdateProduct(ApiMsgHandler, updateProd, createdProduct.ProductCode);
            Assert.IsFalse((bool)updateProd.IsPackagedStandAlone);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Measurement")]
        public void UpdateProductTest14()
        {
            var myPT =
               Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup
                                                                                           .AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
//            var prods = ProductFactory.GetProducts(ApiMsgHandler);
            createdProduct.PackageHeight = Generator.GenerateMeasurement("in", Generator.RandomDecimal(10, 100));
            createdProduct.PackageLength = Generator.GenerateMeasurement("in", Generator.RandomDecimal(10, 100));
            createdProduct.PackageWidth = Generator.GenerateMeasurement("in", Generator.RandomDecimal(10, 100));
            createdProduct.PackageWeight = Generator.GenerateMeasurement("lbs", Generator.RandomDecimal(10, 100));
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct,
                                                              createdProduct.ProductCode);
            Assert.AreEqual(createdProduct.PackageWidth.Value, updateProd.PackageWidth.Value);
            Assert.AreEqual(createdProduct.PackageLength.Value, updateProd.PackageLength.Value);
            Assert.AreEqual(createdProduct.PackageHeight.Value, updateProd.PackageHeight.Value);
            Assert.AreEqual(createdProduct.PackageWeight.Value, updateProd.PackageWeight.Value);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AuditInfo")]
        public void UpdateProductTest15()
        {
            var myPT =
               Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup
                                                                                           .AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
//            var prods = ProductFactory.GetProducts(ApiMsgHandler);
            createdProduct.AuditInfo = Generator.GenerateAuditInfoRandom();
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct,
                                                           createdProduct.ProductCode);
            Assert.AreNotEqual(createdProduct.AuditInfo.CreateBy, updateProd.AuditInfo.CreateBy);
            Assert.AreNotEqual(createdProduct.AuditInfo.CreateDate, updateProd.AuditInfo.CreateDate);
            Assert.AreNotEqual(createdProduct.AuditInfo.UpdateBy, updateProd.AuditInfo.UpdateBy);
            Assert.AreNotEqual(createdProduct.AuditInfo.UpdateDate, updateProd.AuditInfo.UpdateDate);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductInCatalog, change siteId")]
        public void UpdateProductTest16()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            myProduct.ProductInCatalogs =Generator.GenerateProductInCatalogInfoList();
            myProduct.ProductInCatalogs.Add(Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null));
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            createdProduct.ProductInCatalogs.First().CatalogId = TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id;
            var updateProd = ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode);
            Assert.AreEqual(1, updateProd.ProductInCatalogs.Count);
            Assert.AreEqual(TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, updateProd.ProductInCatalogs.First().CatalogId);
            ProductFactory.GetProductInCatalog(ApiMsgHandler, createdProduct.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id);
            ProductFactory.GetProductInCatalog(ApiMsgHandler, createdProduct.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductInCatalog, change siteId, but not category")]
        public void UpdateProductTest17()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.Items.Count < 2)
            {
                var cat1 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                var cat2 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                cates = CategoryFactory.GetCategories(ApiMsgHandler);
            }
            myProduct.ProductInCatalogs =Generator.GenerateProductInCatalogInfoList();
            myProduct.ProductInCatalogs.Add(Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id));
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            createdProduct.ProductInCatalogs.First().CatalogId = TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id;
            ProductFactory.UpdateProduct(ApiMsgHandler, createdProduct, createdProduct.ProductCode, expectedCode: HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// DeleteProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("positive")]
        public void DeleteProductTest1()
        {
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            ProductFactory.DeleteProduct(ApiMsgHandler, createdProduct.ProductCode);
            ProductFactory.GetProduct(ApiMsgHandler, createdProduct.ProductCode, expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// DeleteProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductInCatalogs not empty")]
        public void DeleteProductTest2()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.Items.Count < 2)
            {
                var cat1 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                var cat2 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                cates = CategoryFactory.GetCategories(ApiMsgHandler);
            }
            myProduct.ProductInCatalogs =Generator.GenerateProductInCatalogInfoList();
            myProduct.ProductInCatalogs.Add(Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id));
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            ProductFactory.DeleteProduct(ApiMsgHandler, createdProduct.ProductCode);
            ProductFactory.GetProduct(ApiMsgHandler, createdProduct.ProductCode, expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// DeleteProduct
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("delete and then add one with same product code")]
        public void DeleteProductTest3()
        {
            var myPT =
                Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            ProductFactory.DeleteProduct(ApiMsgHandler, createdProduct.ProductCode);
            var result = ProductFactory.GetProduct(ApiMsgHandler, createdProduct.ProductCode, expectedCode: HttpStatusCode.NotFound);
            var newProduct = ProductFactory.AddProduct(ApiMsgHandler, createdProduct);
            productCode1.Add(newProduct.ProductCode);
            result = ProductFactory.GetProduct(ApiMsgHandler, createdProduct.ProductCode);
        }

        /// <summary>
        /// AddProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("product already added")]
        public void AddProductInCatalogTest1()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.Items.Count < 2)
            {
                var cat1 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                var cat2 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                cates = CategoryFactory.GetCategories(ApiMsgHandler);
            }
            myProduct.ProductInCatalogs = Generator.GenerateProductInCatalogInfoList();
            var info = Generator.GenerateProductInCatalogInfo(catalogId, cates.Items.First().Id);
            myProduct.ProductInCatalogs.Add(info);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            Thread.Sleep(8000);
            // Item already exists: ProductInCatalog catalog entry already exists for this product
            ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(catalogId, cates.Items.First().Id), 
                                        createdProduct.ProductCode, expectedCode: HttpStatusCode.Conflict);
        }

        /// <summary>
        /// AddProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("IsContentOverridden, IsPriceOverridden, IsSeoContentOverridden  --false")]
        public void AddProductInCatalogTest2()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.Items.Count < 2)
            {
                var cat1 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                var cat2 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                cates = CategoryFactory.GetCategories(ApiMsgHandler);
            }
            ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id, null, false, false, false), createdProduct.ProductCode);
            var getProduct = ProductFactory.GetProduct(ApiMsgHandler, createdProduct.ProductCode);
            Assert.AreEqual(getProduct.Content.ProductName, getProduct.ProductInCatalogs.First().Content.ProductName);
            Assert.AreEqual(getProduct.Content.ProductFullDescription, getProduct.ProductInCatalogs.First().Content.ProductFullDescription);
            Assert.AreEqual(getProduct.Content.ProductImages, getProduct.ProductInCatalogs.First().Content.ProductImages);
            Assert.AreEqual(getProduct.Content.ProductShortDescription, getProduct.ProductInCatalogs.First().Content.ProductShortDescription);

            Assert.AreEqual(getProduct.Price.Price, getProduct.ProductInCatalogs.First().Price.Price);
            Assert.AreEqual(getProduct.Price.SalePrice, getProduct.ProductInCatalogs.First().Price.SalePrice);

            Assert.AreEqual(getProduct.SeoContent.MetaTagDescription, getProduct.ProductInCatalogs.First().SeoContent.MetaTagDescription);
            Assert.AreEqual(getProduct.SeoContent.MetaTagKeywords, getProduct.ProductInCatalogs.First().SeoContent.MetaTagKeywords);
            Assert.AreEqual(getProduct.SeoContent.MetaTagTitle, getProduct.ProductInCatalogs.First().SeoContent.MetaTagTitle);
            Assert.AreEqual(getProduct.SeoContent.SeoFriendlyUrl, getProduct.ProductInCatalogs.First().SeoContent.SeoFriendlyUrl);
            Assert.AreEqual(getProduct.SeoContent.TitleTagTitle, getProduct.ProductInCatalogs.First().SeoContent.TitleTagTitle);
        }

        /// <summary>
        /// AddProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("IsContentOverridden, IsPriceOverridden, IsSeoContentOverridden  --true")]
        public void AddProductInCatalogTest3()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            ProductFactory.AddProductInCatalog(ApiMsgHandler,
                                            Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id, null, true, true, true), createdProduct.ProductCode);
            var getProduct = ProductFactory.GetProduct(ApiMsgHandler, createdProduct.ProductCode);
            Assert.AreNotEqual(getProduct.Content.ProductName, getProduct.ProductInCatalogs.First().Content.ProductName);
            Assert.AreNotEqual(getProduct.Content.ProductFullDescription, getProduct.ProductInCatalogs.First().Content.ProductFullDescription);
            Assert.AreNotEqual(getProduct.Content.ProductShortDescription, getProduct.ProductInCatalogs.First().Content.ProductShortDescription);

            Assert.AreNotEqual(getProduct.Price.Price, getProduct.ProductInCatalogs.First().Price.Price);

            Assert.AreNotEqual(getProduct.SeoContent.MetaTagDescription, getProduct.ProductInCatalogs.First().SeoContent.MetaTagDescription);
            Assert.AreNotEqual(getProduct.SeoContent.MetaTagKeywords, getProduct.ProductInCatalogs.First().SeoContent.MetaTagKeywords);
            Assert.AreNotEqual(getProduct.SeoContent.MetaTagTitle, getProduct.ProductInCatalogs.First().SeoContent.MetaTagTitle);
            Assert.AreNotEqual(getProduct.SeoContent.SeoFriendlyUrl, getProduct.ProductInCatalogs.First().SeoContent.SeoFriendlyUrl);
            Assert.AreNotEqual(getProduct.SeoContent.TitleTagTitle, getProduct.ProductInCatalogs.First().SeoContent.TitleTagTitle);
        }

        /// <summary>
        /// AddProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("two categories")]
        public void AddProductInCatalogTest4()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr, Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var messageHandler = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id,
                                                                          TestBaseTenant.MasterCatalogs.First()
                                                                                  .Catalogs.First()
                                                                                  .Id,
                                                                      TestBaseTenant.MasterCatalogs.First().Id);
            var cates = CategoryFactory.GetCategories(messageHandler);
            if (cates.TotalCount < 2)
            {
                Assert.Inconclusive("Less than 2 categories.");
            }
            var catIdList = new List<int>() {cates.Items.First().Id.Value, cates.Items.Last().Id.Value};
            var pcs = Generator.GenerateProductCategoryList(catIdList);
      
            ProductFactory.AddProductInCatalog(messageHandler, Generator.GenerateProductInCatalogInfo(
                                            TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, pcs.ToList(),
                                            Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                                            Generator.RandomDecimal(10, 100), null, null, null, null), createdProduct.ProductCode);
            var getProduct = ProductFactory.GetProduct(ApiMsgHandler, createdProduct.ProductCode);
            Assert.AreEqual(2, getProduct.ProductInCatalogs.First().ProductCategories.Count());
            Assert.AreEqual(cates.Items.First().Id, getProduct.ProductInCatalogs.First().ProductCategories.First().CategoryId);
            Assert.AreEqual(cates.Items.Last().Id, getProduct.ProductInCatalogs.First().ProductCategories.Last().CategoryId);
        }

        /// <summary>
        /// GetProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("positive")]
        public void GetProductInCatalogTest1()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.Items.Count < 2)
            {
                var cat1 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                var cat2 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                cates = CategoryFactory.GetCategories(ApiMsgHandler);
            }
            var info = Generator.GenerateProductInCatalogInfo(
                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id, true);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, info, createdProduct.ProductCode);
            var getInfo = ProductFactory.GetProductInCatalog(ApiMsgHandler, createdProduct.ProductCode,
                                                                      TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(info.IsActive, getInfo.IsActive);
            Assert.AreEqual(info.Price.Price, getInfo.Price.Price);
            Assert.AreEqual(info.ProductCategories.First().CategoryId, getInfo.ProductCategories.First().CategoryId);
        }

        /// <summary>
        /// GetProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("not found product code")]
        public void GetProductInCatalogTest2()
        {
            var getInfo = ProductFactory.GetProductInCatalog(ApiMsgHandler, Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                                                                      TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// GetProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("not found in the site")]
        public void GetProductInCatalogTest3()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.Items.Count < 2)
            {
                var cat1 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                var cat2 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                cates = CategoryFactory.GetCategories(ApiMsgHandler);
            }
            var info = Generator.GenerateProductInCatalogInfo(
                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id, true);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, info, createdProduct.ProductCode);
            if (TestBaseTenant.MasterCatalogs.First().Catalogs.Count < 2)
                Assert.Inconclusive("Less than two sites in first site group.");
            var getInfo = ProductFactory.GetProductInCatalog(ApiMsgHandler, createdProduct.ProductCode,
                                                                      TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// GetProductInCatalogs
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("not found product code")]
        public void GetProductInCatalogsTest1()
        {
            ProductFactory.GetProductInCatalogs(ApiMsgHandler, Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly), expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// GetProductInCatalogs
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("positive")]
        public void GetProductInCatalogsTest2()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.Items.Count < 2)
            {
                var cat1 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                var cat2 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                cates = CategoryFactory.GetCategories(ApiMsgHandler);
            }
            ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id), createdProduct.ProductCode);
            var getInfo = ProductFactory.GetProductInCatalogs(ApiMsgHandler, createdProduct.ProductCode, expectedCode: HttpStatusCode.OK);
            Assert.AreEqual(1, getInfo.Count);
            Assert.AreEqual(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, getInfo.First().CatalogId);
        }

        /// <summary>
        /// GetProductInCatalogs
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("two sites")]
        public void GetProductInCatalogsTest3()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, true, true, true, true), createdProduct.ProductCode);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                 TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, null, false, false, false, false), createdProduct.ProductCode);
            var getInfo = ProductFactory.GetProductInCatalogs(ApiMsgHandler, createdProduct.ProductCode);
            Assert.AreEqual(2, getInfo.Count);
            Assert.AreNotEqual(getInfo.First().CatalogId, getInfo.Last().CatalogId);
            Assert.AreNotEqual(getInfo.First().Price.Price, getInfo.Last().Price.Price);
            Assert.AreNotEqual(getInfo.First().IsActive, getInfo.Last().IsActive);
            Assert.AreNotEqual(getInfo.First().Content.ProductName, getInfo.Last().Content.ProductName);
            Assert.AreNotEqual(getInfo.First().SeoContent.TitleTagTitle, getInfo.Last().SeoContent.TitleTagTitle);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Auditinfo")]
        public void UpdateProductInCatalogTest1()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var info = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, true, true, true, true), createdProduct.ProductCode);
            info.AuditInfo = Generator.GenerateAuditInfoRandom();
            var updateInfo = ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info,
                                                                              createdProduct.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreNotEqual(info.AuditInfo.CreateBy, updateInfo.AuditInfo.CreateBy);
            Assert.AreNotEqual(((DateTime)info.AuditInfo.CreateDate).Date, ((DateTime)updateInfo.AuditInfo.CreateDate).Date);
            Assert.AreNotEqual(info.AuditInfo.UpdateBy, updateInfo.AuditInfo.UpdateBy);
            Assert.AreNotEqual(((DateTime)info.AuditInfo.UpdateDate).Date, ((DateTime)updateInfo.AuditInfo.UpdateDate).Date);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Content, IsContentOverridden = true")]
        public void UpdateProductInCatalogTest2()
        {
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var info = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            info.Content = Generator.GenerateProductLocalizedContent(Generator.RandomString(5, Generator.RandomCharacterGroup
                                                                                            .AlphaOnly));
            info.IsContentOverridden = true;
            var updateInfo = ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info,
                                                                              createdProduct.ProductCode,
                                                                              TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(updateInfo.Content.ProductName, info.Content.ProductName);
            Assert.AreEqual(updateInfo.Content.ProductFullDescription, info.Content.ProductFullDescription);
            Assert.AreEqual(updateInfo.Content.ProductShortDescription, info.Content.ProductShortDescription);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Content, IsContentOverridden = false")]
        public void UpdateProductInCatalogTest3()
        {
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var info = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            info.Content = Generator.GenerateProductLocalizedContent(Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            info.IsContentOverridden = false;
            var updateInfo = ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info, createdProduct.ProductCode,
                                                                              TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(updateInfo.Content.ProductName, createdProduct.Content.ProductName);
            Assert.AreEqual(updateInfo.Content.ProductFullDescription, createdProduct.Content.ProductFullDescription);
            Assert.AreEqual(updateInfo.Content.ProductShortDescription, createdProduct.Content.ProductShortDescription);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Price, IsPriceOverridden = true")]
        public void UpdateProductInCatalogTest4()
        {
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var info = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            info.Price.Price = Generator.RandomDecimal(50, 70);
            info.Price.SalePrice = Generator.RandomDecimal(30, 50);
            info.IsPriceOverridden = true;
            var updateInfo = ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info,
                                                                              createdProduct.ProductCode,
                                                                              TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(updateInfo.Price.Price, info.Price.Price);
            Assert.AreEqual(updateInfo.Price.SalePrice, info.Price.SalePrice);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Price, IsPriceOverridden = false")]
        public void UpdateProductInCatalogTest5()
        {
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup
                                                                                            .AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var info = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            info.Price.Price = Generator.RandomDecimal(50, 70);
            info.Price.SalePrice = Generator.RandomDecimal(30, 50);
            info.IsPriceOverridden = false;
            var updateInfo = ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info, createdProduct.ProductCode,
                                                                              TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(updateInfo.Price.Price, createdProduct.Price.Price);
            Assert.AreEqual(updateInfo.Price.SalePrice, createdProduct.Price.SalePrice);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("SeoContent, IsSeoContentOverridden = true")]
        public void UpdateProductInCatalogTest6()
        {
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var info = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            info.SeoContent = Generator.GenerateProductLocalizedSEOContent();
            info.IsseoContentOverridden = true;
            var updateInfo = ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info, createdProduct.ProductCode,
                                                                              TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(updateInfo.SeoContent.MetaTagDescription, info.SeoContent.MetaTagDescription);
            Assert.AreEqual(updateInfo.SeoContent.MetaTagKeywords, info.SeoContent.MetaTagKeywords);
            Assert.AreEqual(updateInfo.SeoContent.MetaTagTitle, info.SeoContent.MetaTagTitle);
            Assert.AreEqual(updateInfo.SeoContent.SeoFriendlyUrl, info.SeoContent.SeoFriendlyUrl);
            Assert.AreEqual(updateInfo.SeoContent.TitleTagTitle, info.SeoContent.TitleTagTitle);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("SeoContent, IsSeoContentOverridden = false")]
        public void UpdateProductInCatalogTest7()
        {
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var info = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            info.SeoContent = Generator.GenerateProductLocalizedSEOContent();
            info.IsseoContentOverridden = false;
            var updateInfo = ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info, createdProduct.ProductCode,
                                                                              TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(updateInfo.SeoContent.MetaTagDescription, createdProduct.SeoContent.MetaTagDescription);
            Assert.AreEqual(updateInfo.SeoContent.MetaTagKeywords, createdProduct.SeoContent.MetaTagKeywords);
            Assert.AreEqual(updateInfo.SeoContent.MetaTagTitle, createdProduct.SeoContent.MetaTagTitle);
            Assert.AreEqual(updateInfo.SeoContent.SeoFriendlyUrl, createdProduct.SeoContent.SeoFriendlyUrl);
            Assert.AreEqual(updateInfo.SeoContent.TitleTagTitle, createdProduct.SeoContent.TitleTagTitle);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("isActive")]
        public void UpdateProductInCatalogTest8()
        {
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            
            var info = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            info.IsActive = Generator.RandomBool();
            var updateInfo = ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info,
                                                                              createdProduct.ProductCode,
                                                                              TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, expectedCode: HttpStatusCode.OK);
            Assert.AreEqual(updateInfo.IsActive, info.IsActive);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductCategories, add a category")]
        public void UpdateProductInCatalogTest10()
        {
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.Items.Count < 2)
            {
                var cat1 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                var cat2 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                cates = CategoryFactory.GetCategories(ApiMsgHandler);
            }
            var info = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id, null, null, null, null), createdProduct.ProductCode);
            var catIds = new List<int>() { cates.Items.First().Id.Value, cates.Items.Last().Id.Value };
            info.ProductCategories = Generator.GenerateProductCategoryList(catIds).ToList();
                
            //info.ProductCategories = Product.GenerateProductCategory(2);// new ProductCategory[2];
            info.ProductCategories[0] = Generator.GenerateProductCategory(cates.Items.First().Id.Value);
            info.ProductCategories[1] = Generator.GenerateProductCategory(cates.Items.Last().Id.Value);
            var updateInfo = ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info, createdProduct.ProductCode,
                                                                              TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(2, updateInfo.ProductCategories.Count());
            Assert.AreEqual(cates.Items.First().Id.Value, updateInfo.ProductCategories.First().CategoryId);
            Assert.AreEqual(cates.Items.Last().Id.Value, updateInfo.ProductCategories.Last().CategoryId);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("ProductCategories, change to another category")]
        public void UpdateProductInCatalogTest11()
        {
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.Items.Count < 2)
            {
                var cat1 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                var cat2 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory());
                cates = CategoryFactory.GetCategories(ApiMsgHandler);
            }
            var info = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cates.Items.First().Id, null, null, null, null), createdProduct.ProductCode);
            info.ProductCategories[0] = Generator.GenerateProductCategory(cates.Items.Last().Id.Value);
            var updateInfo = ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info, createdProduct.ProductCode,
                                                                              TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(1, updateInfo.ProductCategories.Count());
            Assert.AreEqual(cates.Items.Last().Id.Value, updateInfo.ProductCategories.Last().CategoryId);
        }

        /// <summary>
        /// UpdateProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("SiteId -- readonly")]
        public void UpdateProductInCatalogTest12()
        {
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var info = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            info.CatalogId = TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id;
            var updateInfo = ProductFactory.UpdateProductInCatalog(ApiMsgHandler, info, createdProduct.ProductCode,
                                                                              TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id);
            Assert.AreEqual(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, updateInfo.CatalogId);
        }

        /// <summary>
        /// UpdateProductInCatalogs
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("two sites -> one site")]
        public void UpdateProductInCatalogsTest1()
        {
            
            if (TestBaseTenant.MasterCatalogs.First().Catalogs.Count < 2)
            {
                Assert.Inconclusive("Less than 2 sites in first sitegroup");
            }
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var info1 = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            var info2 = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, null, null, null, null, null), createdProduct.ProductCode);
            var infos =Generator.GenerateProductInCatalogInfoList();
            infos.Add(info1);
            var getInfos = ProductFactory.UpdateProductInCatalogs(ApiMsgHandler, infos, createdProduct.ProductCode);
            Assert.AreEqual(1, getInfos.Count);
            var getProduct = ProductFactory.GetProduct(ApiMsgHandler, createdProduct.ProductCode);
            Assert.AreEqual(1, getProduct.ProductInCatalogs.Count);
            Assert.AreEqual(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, getProduct.ProductInCatalogs.First().CatalogId);
        }

        /// <summary>
        /// UpdateProductInCatalogs
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("one site -> two sites")]
        public void UpdateProductInCatalogsTest2()
        {
            if (TestBaseTenant.MasterCatalogs.First().Catalogs.Count < 2)
            {
                Assert.Inconclusive("Less than 2 sites in first sitegroup");
            }
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            var info1 = ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            var info2 = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, null, null, null, null, null);
            var infos =Generator.GenerateProductInCatalogInfoList();
            infos.Add(info1);
            infos.Add(info2);
            var getInfos = ProductFactory.UpdateProductInCatalogs(ApiMsgHandler, infos, createdProduct.ProductCode);
            Assert.AreEqual(2, getInfos.Count);
            var getProduct = ProductFactory.GetProduct(ApiMsgHandler, createdProduct.ProductCode);
            Assert.AreEqual(2, getProduct.ProductInCatalogs.Count);
            Assert.AreEqual(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, getProduct.ProductInCatalogs.First().CatalogId);
            Assert.AreEqual(TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, getProduct.ProductInCatalogs.Last().CatalogId);
        }

        /// <summary>
        /// DeleteProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("SiteId is wrong")]
        public void DeleteProductInCatalog1()
        {
            if (TestBaseTenant.MasterCatalogs.First().Catalogs.Count < 2)
            {
                Assert.Inconclusive("Less than 2 sites in first sitegroup");
            }
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr, Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
           
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            ProductFactory.DeleteProductInCatalog(ApiMsgHandler, createdProduct.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// DeleteProductInCatalog
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("two sites -> one -> none")]
        public void DeleteProductInCatalog2()
        {
            if (TestBaseTenant.MasterCatalogs.First().Catalogs.Count < 2)
            {
                Assert.Inconclusive("Less than 2 sites in first sitegroup");
            }
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            productTypeId1.Add(createdProduct.ProductTypeId.Value);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, null, null, null, null, null), createdProduct.ProductCode);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, Generator.GenerateProductInCatalogInfo(
                                                TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, null, null, null, null, null), createdProduct.ProductCode);
            ProductFactory.DeleteProductInCatalog(ApiMsgHandler, createdProduct.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, expectedCode: HttpStatusCode.NoContent);
            var pt = ProductFactory.GetProduct(ApiMsgHandler, createdProduct.ProductCode);
            Assert.AreEqual(1, pt.ProductInCatalogs.Count);
            Assert.AreEqual(TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, pt.ProductInCatalogs.First().CatalogId);
            ProductFactory.DeleteProductInCatalog(ApiMsgHandler, createdProduct.ProductCode, TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id, expectedCode: HttpStatusCode.NoContent);
            pt = ProductFactory.GetProduct(ApiMsgHandler, createdProduct.ProductCode);
            Assert.AreEqual(0, pt.ProductInCatalogs.Count);
        }

        /// <summary>
        /// AddOption
        /// </summary>
        [TestMethod]
        [TestCategory("SDK")]
        [TestCategory("Product")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Add two vocabulary values")]
        public void AddOptionTest1()
        {
            var colorAttr = Generator.CreateOptionAttribute(ApiMsgHandler, "Color", new List<string>() { "Red", "Blue", "Green" });

            attributeFQN1.Add(colorAttr.AttributeFQN);
            var sizeAttr = Generator.CreateOptionAttribute(ApiMsgHandler, "Size", new List<string>() { "Small", "Medium", "Large" });
            attributeFQN1.Add(sizeAttr.AttributeFQN); 
            var attList = new List<Attribute>();
            attList.Add(colorAttr);
            attList.Add(sizeAttr);
            var shirtTypeObj = Generator.GenerateProductType(attList, "Shirt");
            var shirtType = ProductTypeFactory.AddProductType(ApiMsgHandler, shirtTypeObj);
            var pro = Generator.GenerateProduct(shirtType.Id);
            var createdPro = ProductFactory.AddProduct(ApiMsgHandler, pro);
            productCode1.Add(createdPro.ProductCode);
            productTypeId1.Add(createdPro.ProductTypeId.Value);
            var option = Generator.GenerateProductOption(shirtType.Options.First(), 2);
            ProductOptionFactory.AddOption(handler: ApiMsgHandler,productCode: pro.ProductCode,productOption: option );
        }       
    
    }
}
