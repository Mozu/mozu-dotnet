using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Test.Helpers;
using Mozu.Api.Test.Factories;

namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class CategoryTests : MozuApiTestBase
    {

        #region NonTestCaseCode

        public CategoryTests()
        {

        }

        private static List<int> cateIds1 = new List<int>();
        private static List<int> cateIds2 = new List<int>();
        private static List<string> productCode1 = new List<string>();
        private static List<int> productTypeIds = new List<int>();

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
        /// GetCategories
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description(" Test GetCategories -> StartIndex, PageSize")]
        public void GetCategoriesTest1()
        {
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            if (cates.TotalCount < 3)
                Assert.Inconclusive("Total categories is less than 3.");
            int pageSize = (int)(cates.TotalCount / 2);
            int totalCount = 0;
            int startIndex = 0;
            int expectedTotalCount = 0;
            while (true)
            {
                cates = CategoryFactory.GetCategories(ApiMsgHandler, startIndex: startIndex, pageSize: pageSize, expectedCode: HttpStatusCode.OK);
                Assert.AreEqual(startIndex, cates.StartIndex);
                Assert.AreEqual((cates.TotalCount + cates.PageSize - 1) / cates.PageSize, cates.PageCount);
                totalCount += cates.Items.Count;
                startIndex += pageSize;
                if (cates.Items.Count < pageSize)
                {
                    expectedTotalCount = (int)cates.TotalCount;
                    break;
                }
            }
            Assert.AreEqual(expectedTotalCount, totalCount);
        }

        /// <summary>
        /// GetCategories
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description(" Test GetCategories -> SortBy")]
        public void GetCategoriesTest2()
        {
            var cates = CategoryFactory.GetCategories(ApiMsgHandler, sortBy: "id asc", expectedCode: HttpStatusCode.OK);
            Assert.IsTrue(cates.Items.First().Id < cates.Items.Last().Id);

            cates = CategoryFactory.GetCategories(ApiMsgHandler, sortBy: "id desc", expectedCode: HttpStatusCode.OK);
            Assert.IsTrue(cates.Items.First().Id > cates.Items.Last().Id);
        }

        /// <summary>
        /// GetCategories
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description(" Test GetCategories -> Filter")]
        public void GetCategoriesTest3()
        {
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            int filterId = cates.Items.Last().Id.Value;
            cates = CategoryFactory.GetCategories(ApiMsgHandler, filter: "id eq " + filterId, expectedCode: HttpStatusCode.OK);
            Assert.AreEqual(1, cates.TotalCount);
            Assert.AreEqual(filterId, cates.Items.First().Id);
        }

        /// <summary>
        /// GetCategories - categories belonging to a site should not be seen in another site
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description(" Test GetCategories - multiple sites")]
        public void GetCategoriesTest5()
        {
            if (TestBaseTenant.MasterCatalogs.First().Catalogs.Count < 2)
                Assert.Inconclusive("Sites are less than 2");
            //site1
            var cates1 = CategoryFactory.GetCategories(ApiMsgHandler);

            //another site
            var msgHandler2 = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id, TestBaseTenant.MasterCatalogs.First().Id, TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id);
            var cates2 = CategoryFactory.GetCategories(msgHandler2);
            if (cates2.TotalCount != 0)
            {
                Assert.AreNotEqual(cates1.Items.First().Id, cates2.Items.First().Id);
            }
        }

        /// <summary>
        /// GetCategory - positive test
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description(" Test GetCategory - positive")]
        public void GetCategoryTest1()
        {
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            var getCate = CategoryFactory.GetCategory(ApiMsgHandler, cates.Items.Last().Id.Value);
            Assert.AreEqual(cates.Items.Last().Id, getCate.Id);
        }

        /// <summary>
        /// GetCategory - negative test
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description(" Test GetCategory - not found")]
        public void GetCategoryTest2()
        {
            var cates = CategoryFactory.GetCategories(ApiMsgHandler, sortBy: "id desc");
            CategoryFactory.GetCategory(ApiMsgHandler, cates.Items.First().Id.Value + 1,
                                        expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// GetChildCategories - positive test
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("GetChildCategories - positive test")]
        //         cate3
        //       /   |   \
        //    c3_1 c3_2 c3_3
        //    /  \       |   
        //c3_1_1 c3_1_2  rest
        public void GetChildCategoriesTest1()
        {
            var cates = CategoryFactory.GetCategories(ApiMsgHandler, pageSize: 20);
            //get id for cate3
            int cate_id = 0;
            foreach (var cate in cates.Items)
            {
                if (cate.Content.Name == "cate3")
                {
                    cate_id = cate.Id.Value;
                    break;
                }
            }

            var childCates = CategoryFactory.GetChildCategories(ApiMsgHandler, cate_id);
            Assert.IsTrue(childCates.TotalCount >= 2);
            Assert.AreEqual("c3_1", childCates.Items[0].Content.Name);
            Assert.AreEqual("c3_2", childCates.Items[1].Content.Name);
            Assert.AreEqual("c3_3", childCates.Items[2].Content.Name);
        }

        /// <summary>
        /// GetChildCategories - no children
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("GetChildCategories - no children")]
        public void GetChildCategoriesTest2()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdCategory = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(createdCategory.Id.Value);
            var childCates = CategoryFactory.GetChildCategories(ApiMsgHandler, (int)createdCategory.Id);
            Assert.AreEqual(0, childCates.TotalCount);
        }

        /// <summary>
        /// GetChildCategories - no children
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("GetChildCategories - middle in the tree")]
        //         cate3
        //       /   |   \
        //    c3_1 c3_2 c3_3
        //    /  \       |   
        //c3_1_1 c3_1_2  rest
        public void GetChildCategoriesTest3()
        {
            var cates = CategoryFactory.GetCategories(ApiMsgHandler, pageSize: 20);

            int cate_id = 0;
            foreach (var cate in cates.Items)
            {
                if (cate.Content.Name == "c3_1")
                {
                    cate_id = cate.Id.Value;
                    break;
                }
            }


            var childCates = CategoryFactory.GetChildCategories(ApiMsgHandler, cate_id);
            Assert.IsTrue(childCates.TotalCount >= 2);
            Assert.AreEqual("c3_1_1", childCates.Items[0].Content.Name);
            Assert.AreEqual("c3_1_2", childCates.Items[1].Content.Name);
        }

        /// <summary>
        /// GetChildCategories - not found   bug 12593
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("GetChildCategories - negative test, not found")]
        public void GetChildCategoriesTest4()
        {
            var cates = CategoryFactory.GetCategories(ApiMsgHandler, sortBy: "id desc");
            var cates1 = CategoryFactory.GetChildCategories(ApiMsgHandler, cates.Items.First().Id.Value + 14, expectedCode: HttpStatusCode.NotFound);
            Assert.AreEqual(0, cates1.TotalCount);
        }

        /// <summary>
        /// CreateCategory - add to another site in same group
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("CreateCategory - add to another site in same group")]
        public void CreateCategoryTest2()
        {
            if (TestBaseTenant.MasterCatalogs.First().Catalogs.Count < 2)
                Assert.Inconclusive("The sites are less than 2");
            var cates = CategoryFactory.GetCategories(ApiMsgHandler);
            int count_site1 = (int)cates.TotalCount;

            //add a category to another site
            var msgHandler2 = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id, TestBaseTenant.MasterCatalogs.First().Id, TestBaseTenant.MasterCatalogs.First().Catalogs.Last().Id);
            cates = CategoryFactory.GetCategories(msgHandler2);
            int count_site2 = (int)cates.TotalCount;
            var cate = CategoryFactory.AddCategory(msgHandler2, Generator.GenerateCategory(Generator.RandomString(5,
                                                                                                   Generator
                                                                                                       .RandomCharacterGroup
                                                                                                       .AlphaOnly)));
            cateIds2.Add(cate.Id.Value);
            // verify the group category added to
            cates = CategoryFactory.GetCategories(msgHandler2);
            Assert.AreEqual(1 + count_site2, cates.TotalCount);

            // verify category total count for the not
            cates = CategoryFactory.GetCategories(ApiMsgHandler);
            Assert.AreEqual(count_site1, cates.TotalCount);
        }

        /// <summary>
        /// CreateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("CreateCategory - CategoryId readonly")]
        public void CreateCategoryTest3()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                                         Generator.RandomCharacterGroup.AlphaOnly));
            cateObj.Id = Generator.RandomInt(20, 50);
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);
            Assert.AreNotEqual(cateObj.Id, cate.Id);
        }

        /// <summary>
        /// CreateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("CreateCategory - ChildCount readonly")]
        public void CreateCategoryTest4()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                                         Generator.RandomCharacterGroup.AlphaOnly));
            cateObj.ChildCount = Generator.RandomInt(1, 5);
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);
            Assert.AreEqual(0, cate.ChildCount);
        }

        /// <summary>
        /// CreateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("CreateCategory - ProductCount readonly")]
        public void CreateCategoryTest5()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                                         Generator.RandomCharacterGroup.AlphaOnly));
            cateObj.ProductCount = Generator.RandomInt(1, 5);
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);
            Assert.AreEqual(0, cate.ProductCount);
        }

        /// <summary>
        /// CreateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("CreateCategory - isDisplay")]
        public void CreateCategoryTest6()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                                         Generator.RandomCharacterGroup.AlphaOnly));
            cateObj.IsDisplayed = false;
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);
            Assert.IsFalse((bool)cate.IsDisplayed);

            cateObj.IsDisplayed = true;
            cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);
            Assert.IsTrue((bool)cate.IsDisplayed);
        }

        /// <summary>
        /// CreateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("CreateCategory - sequence")]
        public void CreateCategoryTest7()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            cateObj.Sequence = Generator.RandomInt(1, 10);
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);
            Assert.AreEqual(cateObj.Sequence, cate.Sequence);
        }

        /// <summary>
        /// CreateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("CreateCategory - AuditInfo")]
        public void CreateCategoryTest8()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var audit = Generator.GenerateAuditInfoRandom();
            cateObj.AuditInfo = audit;
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);
            Assert.AreNotEqual(audit.CreateBy, cate.AuditInfo.CreateBy);
            Assert.AreNotEqual(((DateTime)audit.CreateDate).Date, ((DateTime)cate.AuditInfo.CreateDate).Date);
            Assert.AreNotEqual(audit.UpdateBy, cate.AuditInfo.UpdateBy);
            Assert.AreNotEqual(((DateTime)audit.UpdateDate).Date, ((DateTime)cate.AuditInfo.UpdateDate).Date);
        }

        /// <summary>
        /// UpdateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("UpdateCategory - id")]
        public void UpdateCategoryTest1()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);
            int original = cate.Id.Value;
            cate.Id = original + Generator.RandomInt(10, 20);
            var updateCate = CategoryFactory.UpdateCategory(ApiMsgHandler, cate, original, null);
            Assert.AreEqual(original, updateCate.Id);
        }

        /// <summary>
        /// UpdateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("UpdateCategory - ChildCount")]
        public void UpdateCategoryTest2()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                                          Generator.RandomCharacterGroup.AlphaOnly));
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);
            int original = cate.ChildCount ?? 0;
            cate.ChildCount = original + Generator.RandomInt(1, 5);
            var updateCate = CategoryFactory.UpdateCategory(ApiMsgHandler, cate, cate.Id.Value, null);
            Assert.AreEqual(original, updateCate.ChildCount);
        }

        /// <summary>
        /// UpdateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("UpdateCategory - ProductCount")]
        public void UpdateCategoryTest3()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly));
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);
            int original = cate.ProductCount ?? 0;
            cate.ProductCount = original + Generator.RandomInt(1, 5);
            var updateCate = CategoryFactory.UpdateCategory(ApiMsgHandler, cate, cate.Id.Value, null);
            Assert.AreEqual(original, updateCate.ProductCount);
        }

        /// <summary>
        /// UpdateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("UpdateCategory - CascadeVisibility:false")]
        public void UpdateCategoryTest4()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly));
            var cate1 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate1.Id.Value);

            cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly), parentCategoryId: cate1.Id);
            var cate2 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate2.Id.Value);

            cate1.IsDisplayed = false;
            CategoryFactory.UpdateCategory(ApiMsgHandler, cate1, cate1.Id.Value, cascadeVisibility: false,
                                           expectedCode: HttpStatusCode.Conflict);
        }

        /// <summary>
        /// UpdateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("UpdateCategory - CascadeVisibility:true")]
        //         cate1
        //       /  
        //    cate2
        //    /    
        //  cate3
        //   /
        //  cate4
        public void UpdateCategoryTest5()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly));
            var cate1 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate1.Id.Value);

            cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly), parentCategoryId: cate1.Id);
            var cate2 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate2.Id.Value);

            cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly), parentCategoryId: cate2.Id);
            var cate3 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate3.Id.Value);

            cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly), parentCategoryId: cate3.Id);
            var cate4 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate4.Id.Value);

            cate2.IsDisplayed = false;
            CategoryFactory.UpdateCategory(ApiMsgHandler, cate2, cate2.Id.Value, cascadeVisibility: true);

            //its parent should not change
            var getCate = CategoryFactory.GetCategory(ApiMsgHandler, cate1.Id.Value);
            Assert.IsTrue(getCate.IsDisplayed.Value);

            // verify its sons
            getCate = CategoryFactory.GetCategory(ApiMsgHandler, cate3.Id.Value);
            Assert.IsFalse(getCate.IsDisplayed.Value);

            // verify its grandsons
            getCate = CategoryFactory.GetCategory(ApiMsgHandler, cate4.Id.Value);
            Assert.IsFalse(getCate.IsDisplayed.Value);
        }

        /// <summary>
        /// UpdateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("UpdateCategory - Content")]
        public void UpdateCategoryTest6()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly));
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);

            cate.Content = Generator.GenerateCategoryLocalizedContent(Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var updateCate = CategoryFactory.UpdateCategory(ApiMsgHandler, cate, cate.Id.Value, null);
            Assert.AreEqual(cate.Content.Name, updateCate.Content.Name);
        }

        /// <summary>
        /// UpdateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("UpdateCategory - Sequence")]
        public void UpdateCategoryTest7()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                  Generator.RandomCharacterGroup.AlphaOnly));
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);
            cate.Sequence = Generator.RandomInt(20, 30);
            var updateCate = CategoryFactory.UpdateCategory(ApiMsgHandler, cate, cate.Id.Value, null);
            Assert.AreEqual(cate.Sequence, updateCate.Sequence);
        }

        /// <summary>
        /// UpdateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("UpdateCategory - AuditInfo negative")]
        public void UpdateCategoryTest9()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                      Generator.RandomCharacterGroup.AlphaOnly));
            var cate = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate.Id.Value);

            var audit = Generator.GenerateAuditInfoRandom();
            cate.AuditInfo = audit;
            var updateCate = CategoryFactory.UpdateCategory(ApiMsgHandler, cate, cate.Id.Value, null);
            Assert.AreNotEqual(audit.CreateBy, updateCate.AuditInfo.CreateBy);
            Assert.AreNotEqual(((DateTime)audit.CreateDate).Date, ((DateTime)updateCate.AuditInfo.CreateDate).Date);
            Assert.AreNotEqual(audit.UpdateBy, updateCate.AuditInfo.UpdateBy);
            Assert.AreNotEqual(((DateTime)audit.UpdateDate).Date, ((DateTime)updateCate.AuditInfo.UpdateDate).Date);
        }

        /// <summary>
        /// UpdateCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("UpdateCategory - ParentId")]
        //    cate1  cate2    =>   cate1 cate2
        //    /                            \
        //  cate3                         cate3
        public void UpdateCategoryTest10()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                  Generator.RandomCharacterGroup.AlphaOnly));
            var cate1 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate1.Id.Value);

            cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly));
            var cate2 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate2.Id.Value);

            cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly), parentCategoryId: cate1.Id);
            var cate3 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate3.Id.Value);

            cate3.ParentCategoryId = cate2.Id;
            var updateCate = CategoryFactory.UpdateCategory(ApiMsgHandler, cate3, cate3.Id.Value, null);
            Assert.AreEqual(cate2.Id, updateCate.ParentCategoryId);

            //verify its old parent
            var getCate = CategoryFactory.GetCategory(ApiMsgHandler, cate1.Id.Value);
            Assert.AreEqual(0, getCate.ChildCount.Value);

            //verify its new parent
            getCate = CategoryFactory.GetCategory(ApiMsgHandler, cate2.Id.Value);
            Assert.AreEqual(1, getCate.ChildCount.Value);
        }

        /// <summary>
        /// DeleteCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("DeleteCategory - delete a category without child or product")]
        public void DeleteCategoryTest1()
        {
            //cascadeDelete = null
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                  Generator.RandomCharacterGroup.AlphaOnly));
            var cate4 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            CategoryFactory.DeleteCategoryById(ApiMsgHandler, cate4.Id.Value, null, expectedCode: HttpStatusCode.NoContent);
            CategoryFactory.GetCategory(ApiMsgHandler, cate4.Id.Value, expectedCode: HttpStatusCode.NotFound);
            //cascadeDelete = false
            cateObj = Generator.GenerateCategory(Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var cate1 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate1.Id.Value);
            cate4 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory("cate4"));
            CategoryFactory.DeleteCategoryById(ApiMsgHandler, cate4.Id.Value, false, expectedCode: HttpStatusCode.NoContent);
            CategoryFactory.GetCategory(ApiMsgHandler, cate4.Id.Value, expectedCode: HttpStatusCode.NotFound);
            var result = CategoryFactory.GetCategory(ApiMsgHandler, cate1.Id.Value);

            //cascadeDelete = true
            cateObj = Generator.GenerateCategory(Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var cate2 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate2.Id.Value);
            cate4 = CategoryFactory.AddCategory(ApiMsgHandler, Generator.GenerateCategory("cate4"));
            CategoryFactory.DeleteCategoryById(ApiMsgHandler, cate4.Id.Value, true, expectedCode: HttpStatusCode.NoContent);
            CategoryFactory.GetCategory(ApiMsgHandler, cate4.Id.Value, expectedCode: HttpStatusCode.NotFound);
            result = CategoryFactory.GetCategory(ApiMsgHandler, cate2.Id.Value);
        }

        /// <summary>
        /// DeleteCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("DeleteCategory - delete a category with child")]
        //         cate1
        //       /  
        //    cate2
        //    /    
        //  cate3
        //   /
        //  cate4
        public void DeleteCategoryTest2()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                  Generator.RandomCharacterGroup.AlphaOnly));
            var cate1 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            cateIds1.Add(cate1.Id.Value);

            cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly), parentCategoryId: cate1.Id);
            var cate2 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            //cateIds1.Add(cate2.Id.Value);

            cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly), parentCategoryId: cate2.Id);
            var cate3 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            //cateIds1.Add(cate3.Id.Value);

            cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                              Generator.RandomCharacterGroup.AlphaOnly), parentCategoryId: cate3.Id);
            var cate4 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            //cateIds1.Add(cate4.Id.Value);

            CategoryFactory.DeleteCategoryById(ApiMsgHandler, cate2.Id.Value, false, expectedCode: HttpStatusCode.Conflict);
            CategoryFactory.DeleteCategoryById(ApiMsgHandler, cate2.Id.Value, true, expectedCode: HttpStatusCode.NoContent);

            //its parent should not change
            var getCate = CategoryFactory.GetCategory(ApiMsgHandler, cate1.Id.Value);
            Assert.AreEqual(0, getCate.ChildCount);

            // verify its sons
            CategoryFactory.GetCategory(ApiMsgHandler, cate3.Id.Value, expectedCode: HttpStatusCode.NotFound);

            // verify its grandsons
            CategoryFactory.GetCategory(ApiMsgHandler, cate4.Id.Value, expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// DeleteCategory
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Categories")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("DeleteCategory - delete a category with product")]
        public void DeleteCategoryTest3()
        {
            var cateObj = Generator.GenerateCategory(Generator.RandomString(5,
                                  Generator.RandomCharacterGroup.AlphaOnly));
            var cate4 = CategoryFactory.AddCategory(ApiMsgHandler, cateObj);
            var myPT = Generator.GenerateBasicProductType(Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            productTypeIds.Add(createdPT.Id.Value);
            var product = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, product);
            productCode1.Add(createdProduct.ProductCode);
            var proInfo = Generator.GenerateProductInCatalogInfo(TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id, cate4.Id, true);
            ProductFactory.AddProductInCatalog(ApiMsgHandler, proInfo, createdProduct.ProductCode);
            CategoryFactory.DeleteCategoryById(ApiMsgHandler, cate4.Id.Value, false, expectedCode: HttpStatusCode.Conflict);
            CategoryFactory.DeleteCategoryById(ApiMsgHandler, cate4.Id.Value, true, expectedCode: HttpStatusCode.NoContent);
            ProductFactory.GetProduct(ApiMsgHandler, product.ProductCode);
        }



    }
}
