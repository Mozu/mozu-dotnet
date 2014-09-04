using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Contracts.CommerceRuntime.Fulfillment;
using Mozu.Api.Contracts.CommerceRuntime.Orders;
using Mozu.Api.Contracts.CommerceRuntime.Payments;
using Mozu.Api.Contracts.CommerceRuntime.Returns;
using Mozu.Api.Contracts.Customer;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.Security;
using Mozu.Api.Test.Helpers;
using Mozu.Api.Contracts.CommerceRuntime.Carts;
using Mozu.Api.Test.Factories;
using Mozu.Api.Contracts.Core;
using Product = Mozu.Api.Contracts.CommerceRuntime.Products.Product;
using System.Threading;
using System.Diagnostics;
using System.Collections;


namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class ProductAttributeTests : MozuApiTestBase
    {

        #region NonTestCaseCode

        public ProductAttributeTests()
        {

        }
        private static List<string> attributeFQN1 = new List<string>();
        private static List<string> attributeFQN2 = new List<string>();
        private static List<int> productTypeId1 = new List<int>();
        private static List<string> productCode1 = new List<string>();

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
            ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId: masterCatalogId, catalogId: catalogId);
            ShopperMsgHandler = ServiceClientMessageFactory.GetTestShopperMessage(tenantId, siteId: TestBaseTenant.Sites.First().Id);
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
        /// GetAttributes
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("startIndex, page size")]
        public void GetAttributesTest1()
        {
            int pageSize = 5;
            int totalCount = 0;
            int startIndex = 0;
            int expectedTotalCount = 0;
            while (true)
            {
                //  Mozu.ProductAdmin.Contracts.Attribute it = AttributeFactory.Attibute;

                var attrs = AttributeFactory.GetAttributes(
                    ApiMsgHandler,
                    startIndex: startIndex, pageSize: pageSize, expectedCode: HttpStatusCode.OK);
                Assert.AreEqual(startIndex, attrs.StartIndex);
                Assert.AreEqual((attrs.TotalCount + attrs.PageSize - 1) / attrs.PageSize, attrs.PageCount);
                if (attrs.TotalCount <= 5)
                    Assert.Inconclusive("Not enough attributes for testing.");
                totalCount += attrs.Items.Count;
                startIndex += pageSize;
                if (attrs.Items.Count < pageSize)
                {
                    expectedTotalCount = (int)attrs.TotalCount;
                    break;
                }
            }
            Assert.AreEqual(expectedTotalCount, totalCount);


        }

        /// <summary>
        /// GetAttributes
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("sortby")]
        public void GetAttributesTest2()
        {

            var attrs = AttributeFactory.GetAttributes(ApiMsgHandler, sortBy: "AttributeCode asc", expectedCode: HttpStatusCode.OK);

            Assert.IsTrue(string.Compare(attrs.Items.First().AttributeCode, attrs.Items.Last().AttributeCode) < 0);

            attrs = AttributeFactory.GetAttributes(ApiMsgHandler, sortBy: "AttributeCode desc", expectedCode: HttpStatusCode.OK);
            Assert.IsTrue(string.Compare(attrs.Items.First().AttributeCode, attrs.Items.Last().AttributeCode) > 0);
        }

        /// <summary>
        /// GetAttributes
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("filter")]
        public void GetAttributesTest3()
        {
            var attrs = AttributeFactory.GetAttributes(ApiMsgHandler);
            var attrs_filter = AttributeFactory.GetAttributes(ApiMsgHandler, filter: "AttributeSequence eq " + attrs.Items.First().AttributeSequence, expectedCode: HttpStatusCode.OK);
            Assert.AreEqual(1, attrs_filter.TotalCount);
            Assert.AreEqual(attrs.Items.First().AttributeFQN, attrs_filter.Items.First().AttributeFQN);
        }

        /// <summary>
        /// GetAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("positive")]
        public void GetAttributeTest1()
        {
            var attrs = AttributeFactory.GetAttributes(ApiMsgHandler);
            var getAttr = AttributeFactory.GetAttribute(ApiMsgHandler, attrs.Items.Last().AttributeFQN, expectedCode: HttpStatusCode.OK);
            Assert.AreEqual(attrs.Items.Last().AttributeFQN, getAttr.AttributeFQN);
        }

        /// <summary>
        /// GetAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Not Found")]
        public void GetAttributeTest2()
        {
            var getAttr = AttributeFactory.GetAttribute(ApiMsgHandler, Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly), expectedCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Positive")]
        public void AddAttributeTest1()
        {
            var attr1 = Generator.GenerateAttribute(isProperty: true, isExtra: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attr1);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var getAttr = AttributeFactory.GetAttribute(ApiMsgHandler, createdAttr.AttributeFQN);
            Assert.AreEqual(attr1.AttributeCode, getAttr.AttributeCode);
            Assert.AreEqual(createdAttr.AttributeFQN, getAttr.AttributeFQN);
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AttributeCode, namespace, AttributeFQN")]
        public void AddAttributeTest2()
        {
            var attr1 = Generator.GenerateAttribute(isProperty: true, isExtra: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attr1);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            // Add a same one
            AttributeFactory.AddAttribute(ApiMsgHandler, attr1, expectedCode: HttpStatusCode.Conflict);

            // random namespace
            string originalNamespace = attr1.Namespace;
            attr1.Namespace = Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly);
            AttributeFactory.AddAttribute(ApiMsgHandler, attr1, expectedCode: HttpStatusCode.BadRequest);
            attr1.Namespace = originalNamespace;

            // Assign a new AttributeFQN, not change AttributeCode
            attr1.AttributeFQN = Generator.RandomString(10, Generator.RandomCharacterGroup.AlphaOnly);
            AttributeFactory.AddAttribute(ApiMsgHandler, attr1, expectedCode: HttpStatusCode.Conflict);
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("SiteGroupId")]
        public void AddAttributeTest3()
        {

            if (TestBaseTenant.MasterCatalogs.Count < 2)
            {
                Assert.Inconclusive("only one site group");
            }
            else
            {
                var msgHandler2 = ServiceClientMessageFactory.GetTestClientMessage(TestBaseTenant.Id, TestBaseTenant.MasterCatalogs.Last().Id);
                var attr1 = Generator.GenerateAttribute(isProperty: true, isExtra: true);
                attr1.MasterCatalogId = TestBaseTenant.MasterCatalogs.Last().Id;
                var createdAttr = AttributeFactory.AddAttribute(msgHandler2, attr1);
                attributeFQN2.Add(createdAttr.AttributeFQN);
                // should not be in the first site group
                AttributeFactory.GetAttribute(ApiMsgHandler, createdAttr.AttributeFQN, expectedCode: HttpStatusCode.NotFound);
                // should be in the last site group
                AttributeFactory.GetAttribute(msgHandler2, createdAttr.AttributeFQN);
            }
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AttributeTypeRules")]
        public void AddAttributeTest4()
        {
            var rules = AttributeTypeRuleFactory.GetAttributeTypeRules(ApiMsgHandler);
            //Attribute attrObj;
            foreach (var rule in rules.Items)
            {
                var attrObj = Generator.GenerateAttribute(rule);
                var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj, expectedCode: HttpStatusCode.Created);
                attributeFQN1.Add(createdAttr.AttributeFQN);
                var getAttr = AttributeFactory.GetAttribute(ApiMsgHandler, createdAttr.AttributeFQN);
                Assert.AreEqual(rule.AttributeDataType, getAttr.DataType);
                Assert.AreEqual(rule.AttributeInputType, getAttr.InputType);
                Assert.AreEqual(rule.AttributeValueType, getAttr.ValueType);
                switch (rule.AttributeUsageType)
                {
                    case "Property":
                        Assert.IsTrue((bool)getAttr.IsProperty);
                        Assert.IsFalse((bool)getAttr.IsExtra);
                        Assert.IsFalse((bool)getAttr.IsOption);
                        break;
                    case "Extra":
                        Assert.IsFalse((bool)getAttr.IsProperty);
                        Assert.IsTrue((bool)getAttr.IsExtra);
                        Assert.IsFalse((bool)getAttr.IsOption);
                        break;
                    case "Option":
                        Assert.IsFalse((bool)getAttr.IsProperty);
                        Assert.IsFalse((bool)getAttr.IsExtra);
                        Assert.IsTrue((bool)getAttr.IsOption);
                        break;
                }
            }
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AttributeTypeRules negative")]
        public void AddAttributeTest5()
        {
            var str = Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly);
            // invalid DataType
            var attrObj = Generator.GenerateAttribute();
            attrObj.DataType = str;
            AttributeFactory.AddAttribute(ApiMsgHandler, attrObj, expectedCode: HttpStatusCode.Conflict);

            // invalid InputType
            attrObj = Generator.GenerateAttribute();
            attrObj.InputType = str;
            AttributeFactory.AddAttribute(ApiMsgHandler, attrObj, expectedCode: HttpStatusCode.Conflict);

            // invalid ValueType
            attrObj = Generator.GenerateAttribute();
            attrObj.InputType = str;
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj, expectedCode: HttpStatusCode.Conflict);
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Validation")]
        public void AddAttributeTest6()
        {
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            attrObj.Validation = Generator.GenerateAttributeValidation(DateTime.Now.Date.AddDays(10),
                                                                         DateTime.Now.Date,
                                                                         Generator.RandomInt(8, 20),
                                                                         Generator.RandomInt(1, 7),
                                                                         Generator.RandomInt(10, 20),
                                                                         Generator.RandomInt(1, 10),
                                                                         Generator.RandomString(5,
                                                                                                Generator
                                                                                                    .RandomCharacterGroup
                                                                                                    .AlphaOnly));
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var getAttr = AttributeFactory.GetAttribute(ApiMsgHandler, createdAttr.AttributeFQN);
            Assert.AreEqual(attrObj.Validation.RegularExpression, getAttr.Validation.RegularExpression);
            Assert.AreEqual(attrObj.Validation.MaxDateValue, getAttr.Validation.MaxDateValue);
            Assert.AreEqual(attrObj.Validation.MinDateValue, getAttr.Validation.MinDateValue);
            Assert.AreEqual(attrObj.Validation.MaxNumericValue, getAttr.Validation.MaxNumericValue);
            Assert.AreEqual(attrObj.Validation.MinNumericValue, getAttr.Validation.MinNumericValue);
            Assert.AreEqual(attrObj.Validation.MaxStringLength, getAttr.Validation.MaxStringLength);
            Assert.AreEqual(attrObj.Validation.MinStringLength, getAttr.Validation.MinStringLength);
        }

        /// <summary>
        /// AddAttribute bug 9631
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("VocabularyValues: lower case for InputType, ValueType, DataType")]
        public void AddAttributeTest7()
        {
            var attrObj = Generator.GenerateAttribute(Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                inputType: "list", valueType: "predefined", dataType: "string", isExtra: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj, expectedCode: HttpStatusCode.Created);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var getAttr = AttributeFactory.GetAttribute(ApiMsgHandler, createdAttr.AttributeFQN);
            Assert.AreEqual(attrObj.VocabularyValues.First().Value, getAttr.VocabularyValues.First().Value);
            Assert.AreEqual(attrObj.VocabularyValues.First().Content.LocaleCode, getAttr.VocabularyValues.First().Content.LocaleCode);
            Assert.AreEqual(attrObj.VocabularyValues.First().Content.StringValue, getAttr.VocabularyValues.First().Content.StringValue);
            Assert.AreEqual(attrObj.VocabularyValues.Last().Value, getAttr.VocabularyValues.Last().Value);
            Assert.AreEqual(attrObj.VocabularyValues.Last().Content.LocaleCode, getAttr.VocabularyValues.Last().Content.LocaleCode);
            Assert.AreEqual(attrObj.VocabularyValues.Last().Content.StringValue, getAttr.VocabularyValues.Last().Content.StringValue);
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AttributeMetadata")]
        public void AddAttributeTest8()
        {
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            attrObj.AttributeMetadata = Generator.GenerateAttributeMetadataItemList();
            attrObj.AttributeMetadata.Clear();
            var meta1 = Generator.GenerateAttributeMetadataItem();
            var meta2 = Generator.GenerateAttributeMetadataItem();
            attrObj.AttributeMetadata.Add(meta1);
            attrObj.AttributeMetadata.Add(meta2);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var getAttr = AttributeFactory.GetAttribute(ApiMsgHandler, createdAttr.AttributeFQN);
            Assert.AreEqual(meta1.Key, getAttr.AttributeMetadata.Last().Key);
            Assert.AreEqual(meta1.Value, getAttr.AttributeMetadata.Last().Value);
            Assert.AreEqual(meta2.Key, getAttr.AttributeMetadata.First().Key);
            Assert.AreEqual(meta2.Value, getAttr.AttributeMetadata.First().Value);
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Content")]
        public void AddAttributeTest9()
        {
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            attrObj.Content = Generator.GenerateAttributeLocalizedContent();
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var getAttr = AttributeFactory.GetAttribute(ApiMsgHandler, createdAttr.AttributeFQN);
            Assert.AreEqual(attrObj.Content.Description, getAttr.Content.Description);
            Assert.AreEqual(attrObj.Content.Name, getAttr.Content.Name);
            Assert.AreEqual(attrObj.Content.LocaleCode, getAttr.Content.LocaleCode);
        }

        /// <summary>
        /// AddAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AuditInfo")]
        public void AddAttributeTest10()
        {
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            var audit = Generator.GenerateAuditInfoRandom();
            attrObj.AuditInfo = audit;
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var getAttr = AttributeFactory.GetAttribute(ApiMsgHandler, createdAttr.AttributeFQN);
            Assert.AreNotEqual(audit.CreateBy, getAttr.AuditInfo.CreateBy);
            Assert.AreNotEqual(((DateTime)audit.CreateDate).Date, ((DateTime)getAttr.AuditInfo.CreateDate).Date);
            Assert.AreNotEqual(audit.UpdateBy, getAttr.AuditInfo.UpdateBy);
            Assert.AreNotEqual(((DateTime)audit.UpdateDate).Date, ((DateTime)getAttr.AuditInfo.UpdateDate).Date);
        }

        /// <summary>
        /// UpdateAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AttributeCode: once created, can not be changed")]
        public void UpdateAttributeTest1()
        {
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            attrObj.AttributeCode = Generator.RandomString(8, Generator.RandomCharacterGroup.AlphaOnly);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            Assert.AreEqual(attrObj.AttributeCode, createdAttr.AttributeCode);
            createdAttr.AttributeCode = Generator.RandomString(6, Generator.RandomCharacterGroup.AlphaOnly);
            var updateAttr = AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN);
            Assert.AreEqual(attrObj.AttributeCode, updateAttr.AttributeCode);
        }

        /// <summary>
        /// UpdateAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("readonly items : AttributeFQN, AttributeSequence, SiteGroupId")]
        public void UpdateAttributeTest2()
        {
            var attrObj = Generator.GenerateAttribute(isExtra: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var originalFQN = createdAttr.AttributeFQN;
            var originalSeq = createdAttr.AttributeSequence.Value;
            createdAttr.AttributeFQN = Generator.RandomString(8, Generator.RandomCharacterGroup.AlphaOnly);
            createdAttr.MasterCatalogId = TestBaseTenant.MasterCatalogs.Last().Id;
            createdAttr.AttributeSequence = createdAttr.AttributeSequence + 100;
            var updateAttr = AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, originalFQN);
            Assert.AreEqual(originalFQN, updateAttr.AttributeFQN);
            Assert.AreEqual(originalSeq, updateAttr.AttributeSequence);
            Assert.AreEqual(1, updateAttr.MasterCatalogId);
        }

        /// <summary>
        /// UpdateAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("DataType, InputType, ValueType   ----set once or locked")]
        public void UpdateAttributeTest3()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var rules = AttributeTypeRuleFactory.GetAttributeTypeRules(ApiMsgHandler);
            bool found = false;
            foreach (var rule in rules.Items)
            {
                if (rule.AttributeUsageType.ToLower().Equals("property") &&
                    rule.AttributeDataType.ToLower().Equals(createdAttr.DataType.ToLower()) &&
                    rule.AttributeInputType.ToLower().Equals(createdAttr.InputType.ToLower()) &&
                    rule.AttributeValueType.ToLower().Equals(createdAttr.ValueType.ToLower()))
                    continue;
                found = true;
                createdAttr.DataType = rule.AttributeDataType;
                createdAttr.InputType = rule.AttributeInputType;
                createdAttr.ValueType = rule.AttributeValueType;
                break;
            }
            if (!found) Assert.Inconclusive("could find another rule");
            var updateAttr = AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN, expectedCode: HttpStatusCode.Conflict);
        }

        /// <summary>
        /// UpdateAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AttributeMetadata")]
        public void UpdateAttributeTest4()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var meta1 = Generator.GenerateAttributeMetadataItem();
            var meta2 = Generator.GenerateAttributeMetadataItem();
            attrObj.AttributeMetadata = Generator.GenerateAttributeMetadataItemList();
            attrObj.AttributeMetadata.Add(meta1);
            attrObj.AttributeMetadata.Add(meta2);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var meta3 = Generator.GenerateAttributeMetadataItem();
            createdAttr.AttributeMetadata.Clear();
            createdAttr.AttributeMetadata.Add(meta3);
            var updateAttr = AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN);
            Assert.AreEqual(1, updateAttr.AttributeMetadata.Count);
            Assert.AreEqual(meta3.Key, updateAttr.AttributeMetadata.First().Key);
            Assert.AreEqual(meta3.Value, updateAttr.AttributeMetadata.First().Value);
        }

        /// <summary>
        /// UpdateAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Content")]
        public void UpdateAttributeTest5()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var content = Generator.GenerateAttributeLocalizedContent();
            attrObj.Content = content;
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var content2 = Generator.GenerateAttributeLocalizedContent();
            createdAttr.Content = content2;
            var updateAttr = AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN);
            Assert.AreEqual(content2.Description, updateAttr.Content.Description);
            Assert.AreEqual(content2.Name, updateAttr.Content.Name);
        }

        /// <summary>
        /// UpdateAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Validation")]
        public void UpdateAttributeTest6()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            attrObj.Validation = Generator.GenerateAttributeValidation(DateTime.Now.Date.AddDays(10),
                                                                          DateTime.Now.Date,
                                                                          Generator.RandomInt(8, 20),
                                                                          Generator.RandomInt(1, 7),
                                                                          Generator.RandomInt(10, 20),
                                                                          Generator.RandomInt(1, 10),
                                                                          Generator.RandomString(5,
                                                                                                 Generator
                                                                                                     .RandomCharacterGroup
                                                                                                     .AlphaOnly));
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            createdAttr.Validation.RegularExpression = Generator.RandomString(4, Generator.RandomCharacterGroup.AlphaOnly);
            createdAttr.Validation.MaxDateValue = DateTime.Now.Date.AddDays(15);
            createdAttr.Validation.MinDateValue = DateTime.Now.Date.AddDays(1);
            createdAttr.Validation.MaxNumericValue = Generator.RandomInt(30, 40);
            createdAttr.Validation.MinNumericValue = Generator.RandomInt(10, 20);
            createdAttr.Validation.MinStringLength = Generator.RandomInt(10, 20);
            createdAttr.Validation.MaxStringLength = Generator.RandomInt(21, 30);
            var updateAttr = AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN);
            Assert.AreEqual(createdAttr.Validation.RegularExpression, updateAttr.Validation.RegularExpression);
            Assert.AreEqual(createdAttr.Validation.MaxDateValue, updateAttr.Validation.MaxDateValue);
            Assert.AreEqual(createdAttr.Validation.MinDateValue, updateAttr.Validation.MinDateValue);
            Assert.AreEqual(createdAttr.Validation.MaxNumericValue, updateAttr.Validation.MaxNumericValue);
            Assert.AreEqual(createdAttr.Validation.MinNumericValue, updateAttr.Validation.MinNumericValue);
            Assert.AreEqual(createdAttr.Validation.MaxStringLength, updateAttr.Validation.MaxStringLength);
            Assert.AreEqual(createdAttr.Validation.MinStringLength, updateAttr.Validation.MinStringLength);
        }

        /// <summary>
        /// UpdateAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Validation")]
        public void UpdateAttributeTest7()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var value1 = Generator.GenerateAttributeVocabularyValueRandom();
            var value2 = Generator.GenerateAttributeVocabularyValueRandom();
            attrObj.VocabularyValues = Generator.GenerateAttributeVocabularyValueList();
            attrObj.VocabularyValues.Clear();
            attrObj.VocabularyValues.Add(value1);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            createdAttr.VocabularyValues.Add(value2);
            var updateAttr = AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN);
            Assert.IsNotNull(updateAttr.VocabularyValues.First().ValueSequence);
            Assert.IsNotNull(updateAttr.VocabularyValues.Last().ValueSequence);
            Assert.AreEqual(value1.Content.StringValue, updateAttr.VocabularyValues.First().Content.StringValue);
            Assert.AreEqual(value2.Content.StringValue, updateAttr.VocabularyValues.Last().Content.StringValue);
        }

        /// <summary>
        /// UpdateAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("AuditInfo")]
        public void UpdateAttributeTest8()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var audit = Generator.GenerateAuditInfoRandom();
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            createdAttr.AuditInfo = audit;
            var updateAttr = AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN);
            Assert.AreNotEqual(audit.CreateBy, updateAttr.AuditInfo.CreateBy);
            Assert.AreNotEqual(((DateTime)audit.CreateDate).Date, ((DateTime)updateAttr.AuditInfo.CreateDate).Date);
            Assert.AreNotEqual(audit.UpdateBy, updateAttr.AuditInfo.UpdateBy);
            Assert.AreNotEqual(((DateTime)audit.UpdateDate).Date, ((DateTime)updateAttr.AuditInfo.UpdateDate).Date);
        }

        /// <summary>
        /// UpdateAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("if referenced by a producttype, AttributeUsage could be updated from off to on, but from off to on ")]
        public void UpdateAttributeTest9()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr, Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            productTypeId1.Add(createdPT.Id.Value);
            createdAttr.IsExtra = true;
            var updateAttr = AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN, expectedCode: HttpStatusCode.OK);
            Assert.IsTrue((bool)updateAttr.IsExtra);
            createdAttr.IsProperty = false;
            AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN, expectedCode: HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// UpdateAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("if referenced by a producttype, content, validation and metadata should be able to be updated")]
        public void UpdateAttributeTest10()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr, Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            productTypeId1.Add(createdPT.Id.Value);
            createdAttr.Content = Generator.GenerateAttributeLocalizedContent();
            createdAttr.Validation = Generator.GenerateAttributeValidation(null, null, null, null,
                                                                             Generator.RandomInt(5, 10),
                                                                             Generator.RandomInt(1, 4));
            createdAttr.AttributeMetadata = Generator.GenerateAttributeMetadataItemList();
            createdAttr.AttributeMetadata.Clear();
            createdAttr.AttributeMetadata.Add(Generator.GenerateAttributeMetadataItem());
            var updateAttr = AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN);
            Assert.AreEqual(createdAttr.Content.Description, updateAttr.Content.Description);
            Assert.AreEqual(createdAttr.Content.Name, updateAttr.Content.Name);
            Assert.AreEqual(createdAttr.Validation.MaxStringLength, updateAttr.Validation.MaxStringLength);
            Assert.AreEqual(createdAttr.Validation.MinStringLength, updateAttr.Validation.MinStringLength);
            Assert.AreEqual(createdAttr.AttributeMetadata.Count, updateAttr.AttributeMetadata.Count);
            Assert.AreEqual(createdAttr.AttributeMetadata.Last().Key, updateAttr.AttributeMetadata.First().Key);
            Assert.AreEqual(createdAttr.AttributeMetadata.Last().Value, updateAttr.AttributeMetadata.First().Value);
        }

        /// <summary>
        /// UpdateAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("an attribute is referenced by a product type, but its vocabularyvalue is not referenced, you can update vocabularytype")]
        public void UpdateAttributeTest11()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var vv1 = Generator.GenerateAttributeVocabularyValueRandom();
            var vv2 = Generator.GenerateAttributeVocabularyValueRandom();
            attrObj.VocabularyValues = Generator.GenerateAttributeVocabularyValueList();
            attrObj.VocabularyValues.Clear();
            attrObj.VocabularyValues.Add(vv1);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr, Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly));
            myPT.Properties.Last().VocabularyValues.Clear();
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            productTypeId1.Add(createdPT.Id.Value);
            createdAttr.VocabularyValues.First().Content.StringValue = vv2.Content.StringValue;
            createdAttr.VocabularyValues.First().Value = vv2.Value;
            var updateAttr = AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN);
            Assert.AreEqual(vv2.Content.StringValue, updateAttr.VocabularyValues.First().Content.StringValue);
            Assert.AreEqual(vv2.Value, updateAttr.VocabularyValues.First().Value);

            // if vocabularyvalue is referenced by producttype, you can not update it
            myPT.Properties.First().VocabularyValues = Generator.GenerateAttributeVocabularyValueInProductTypeList();
            myPT.Properties.First().VocabularyValues.Add(Generator.GenerateAttributeVocabularyValueInProductType(vv2.Value));
            createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            productTypeId1.Add(createdPT.Id.Value);
            createdAttr.VocabularyValues.First().Content.StringValue = vv1.Content.StringValue;
            createdAttr.VocabularyValues.First().Value = vv1.Value;
            AttributeFactory.UpdateAttribute(ApiMsgHandler, createdAttr, createdAttr.AttributeFQN, expectedCode: HttpStatusCode.Conflict);
        }

        /// <summary>
        /// DeleteAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("delete attribute which was referenced by a product")]
        public void DeleteAttributeTest1()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler, attrObj);
            attributeFQN1.Add(createdAttr.AttributeFQN);
            var myPT = Generator.GenerateProductType(createdAttr,
                                                       Generator.RandomString(5,
                                                                              Generator.RandomCharacterGroup.AlphaOnly));
            var createdPT = ProductTypeFactory.AddProductType(ApiMsgHandler, myPT);
            productTypeId1.Add(createdPT.Id.Value);
            var myProduct = Generator.GenerateProduct(createdPT);
            var createdProduct = ProductFactory.AddProduct(ApiMsgHandler, myProduct);
            productCode1.Add(createdProduct.ProductCode);
            AttributeFactory.DeleteAttribute(ApiMsgHandler, createdAttr.AttributeFQN, expectedCode: HttpStatusCode.Conflict);
        }

        /// <summary>
        /// DeleteAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("positive")]
        public void DeleteAttributeTest2()
        {
            var attrObj = Generator.GenerateAttribute(isProperty: true);
            var createdAttr = AttributeFactory.AddAttribute(ApiMsgHandler,
                attrObj);
            AttributeFactory.DeleteAttribute(ApiMsgHandler,
                createdAttr.AttributeFQN,
                expectedCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// DeleteAttribute
        /// </summary>
        [TestMethod]
        [TestCategory("Product")]
        [TestCategory("Attributes")]
        [TestCategory("SDK")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("NotFound")]
        public void DeleteAttributeTest3()
        {
            AttributeFactory.DeleteAttribute(ApiMsgHandler,
                Generator.RandomString(5, Generator.RandomCharacterGroup.AlphaOnly),
                expectedCode: HttpStatusCode.NotFound);
        }


    }
}
