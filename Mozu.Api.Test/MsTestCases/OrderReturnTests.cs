// ***********************************************************************
// <copyright file="OrderReturnTests.cs" company="Volusion">
//     Copyright (c) Volusion 2013. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Test.Helpers;
using Mozu.Api.Contracts.CommerceRuntime.Returns;
using Mozu.Api.Test.Factories;
using System.Configuration;

namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class OrderReturnTests : MozuApiTestBase
    {
        private static Dictionary<string, int> products;
        private static List<ReturnItem> returnItems;
        private static Dictionary<string, int> reasons;
        private static Dictionary<string, object> siteSettings = new Dictionary<string, object>();

        #region NonTestCaseCode

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReturnTests"/> class.
        /// </summary>
        public OrderReturnTests()
        {

        }

        #region Initializers

        /// <summary>
        /// This will run once before each test.
        /// </summary>
        [TestInitialize]
        public void TestMethodInit()
        {

            tenantId = Convert.ToInt32(ConfigurationManager.AppSettings["TenantId"]);
            TestBaseTenant = TenantFactory.GetTenant(ApiMsgHandler, tenantId);
             

            masterCatalogId = TestBaseTenant.MasterCatalogs.First().Id;
            catalogId = TestBaseTenant.MasterCatalogs.First().Catalogs.First().Id;
            ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId, catalogId, siteId);
            var createdUser = UserFactory.CreateUser(ApiMsgHandler, Users.GenerateUser());
            var loginResult = UserFactory.Login(ApiMsgHandler,
                UserAuthInfo.GenerateUserAuthInfo(createdUser.EmailAddress, Constant.Password));
            AnonShopperMsgHandler = ServiceClientMessageFactory.GetTestShopperMessage(tenantId, siteId, masterCatalogId, catalogId, true);
            ShopperMsgHandler = ServiceClientMessageFactory.GetServiceClientMessageFactory(ApiContextFactory.GetApiContext(tenantId, masterCatalogId, catalogId, siteId,
                Constant.LocaleCode, Constant.Currency, loginResult.AuthTicket));
            products = new Dictionary<string, int>();
            returnItems = new List<ReturnItem>();
            reasons = new Dictionary<string, int>();
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
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return when order is in Complete state.")]
        public void OrderReturnTests_Test1()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(ShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder); 
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler, 
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            Assert.AreEqual(createdReturn.Status, "Created");
            Assert.AreEqual(createdReturn.ReturnType, "Refund");
            Assert.AreEqual(createdReturn.Items.Count, 1);
            Assert.AreEqual(createdReturn.OriginalOrderId, orderId);
            Assert.AreEqual(createdReturn.Items[0].OrderItemId, order.Items[0].Id);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, 1);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Reason, "Damaged");           
            Assert.AreEqual(createdReturn.AvailableActions.Count, 2);
            Assert.IsTrue(createdReturn.AvailableActions[0].Contains("Authorize") || createdReturn.AvailableActions[0].Contains("Cancel"));
            Assert.IsTrue(createdReturn.AvailableActions[1].Contains("Authorize") || createdReturn.AvailableActions[1].Contains("Cancel"));
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return when order state is Processing and shipment state is Shipped.")]
        public void OrderReturnTests_Test2()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 1}, {"metropolitan-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderShipped(ApiMsgHandler, getOrder); 
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler, 
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            Assert.AreEqual(createdReturn.Items.Count, 1);
            Assert.AreEqual(createdReturn.OriginalOrderId, orderId);
            Assert.AreEqual(createdReturn.Items[0].OrderItemId, order.Items[1].Id);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, 1);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Reason, "Damaged"); 
            Assert.AreEqual(createdReturn.AvailableActions.Count, 2);
            Assert.IsTrue(createdReturn.AvailableActions[0].Equals("Authorize") || createdReturn.AvailableActions[0].Equals("Cancel"));
            Assert.IsTrue(createdReturn.AvailableActions[1].Equals("Authorize") || createdReturn.AvailableActions[1].Equals("Cancel"));
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return when order state is Processing and shipment state is PartiallyShipped.")]
        public void OrderReturnTests_Test3()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 1}, {"metropolitan-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderPartialShipped(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            Assert.AreEqual(createdReturn.Items.Count, 1);
            Assert.AreEqual(createdReturn.OriginalOrderId, orderId);
            Assert.AreEqual(createdReturn.Items[0].OrderItemId, order.Items[0].Id);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, 1);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Reason, "Damaged");            
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return to refund (check) to shopper when the parent order is in complete state.")]
        public void OrderReturnTests_Test4() 
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);  
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var createdPaymentAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "12345", 6630, order.Payments[0].Id));  //---------------------------------> bug 17541
            var availablePaymentActions = ReturnFactory.GetAvailablePaymentActionsForReturn(ApiMsgHandler, createdReturn.Id,
                createdPaymentAction.Payments[0].Id);
            Assert.AreEqual(createdPaymentAction.Payments.Count, 1);
            Assert.AreEqual(createdPaymentAction.Payments[0].Status, "Credited");
            Assert.AreEqual(createdPaymentAction.Payments[0].PaymentType.ToString(), PaymentType.Check.ToString());
            Assert.AreEqual(createdPaymentAction.Payments[0].Interactions.Count, 1);
            Assert.AreEqual(createdPaymentAction.Payments[0].Interactions[0].CheckNumber, "12345");
            Assert.AreEqual(createdPaymentAction.Payments[0].Interactions[0].InteractionType, PaymentInteractionType.Credit.ToString());
            var returnActions = ReturnFactory.GetAvailableReturnActions(ApiMsgHandler, createdReturn.Id);
            Assert.AreEqual(returnActions.Count, 3);
            Assert.IsTrue(returnActions[0].Contains("Refund") || returnActions[0].Contains("Cancel") || returnActions[0].Contains("Await"));
            Assert.IsTrue(returnActions[1].Contains("Refund") || returnActions[1].Contains("Cancel") || returnActions[1].Contains("Await"));
            Assert.IsTrue(returnActions[2].Contains("Refund") || returnActions[2].Contains("Cancel") || returnActions[2].Contains("Await"));
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return to replace items for shopper when the parent order is in complete state (ship without re-stocking).")]
        public void OrderReturnTests_Test5()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 2);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            Assert.AreEqual(createdReturn.ReturnType, "Replace");
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler, 
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            awaitReturn.Items[0].Items[0].QuantityReceived = 2;
            var updatedReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, awaitReturn.Items[0].Id,
               awaitReturn.Items[0]);
            var receiveReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Receive", returnIds));
            var shipReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Ship", returnIds));
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturn.Id);
            Assert.AreEqual(getReturn.Items.Count, 1);
            Assert.AreEqual(getReturn.Status, "Shipped");
            Assert.AreEqual(getReturn.Items[0].QuantityReceived, awaitReturn.Items[0].Items[0].QuantityReceived);
            Assert.IsNotNull(getReturn.ReturnOrderId);
            var returnActions = ReturnFactory.GetAvailableReturnActions(ApiMsgHandler, createdReturn.Id); 
            Assert.AreEqual(returnActions.Count, 1);
            Assert.IsTrue(returnActions[0].Contains("Close"));
            shipReturn.Items[0].Items[0].QuantityRestockable = 1;
            var updateReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, shipReturn.Items[0].Id,
               shipReturn.Items[0]);
            returnActions = ReturnFactory.GetAvailableReturnActions(ApiMsgHandler, createdReturn.Id);
            Assert.AreEqual(returnActions.Count, 2);
            Assert.IsTrue(returnActions[0].Contains("Close") || returnActions[0].Contains("Restock"));
            Assert.IsTrue(returnActions[1].Contains("Close") || returnActions[1].Contains("Restock"));
            var childOrder = OrderFactory.GetOrder(ApiMsgHandler, getReturn.ReturnOrderId);
            Assert.AreEqual(childOrder.Status, "Submitted");
            Assert.AreEqual(childOrder.Items.Count, 1);
            Assert.AreEqual(childOrder.Items[0].Product.ProductCode, "bantam-sofa");
            Assert.AreEqual(childOrder.Items[0].Quantity, 2);
            Assert.AreEqual(childOrder.Items[0].Product.Price.Price, getOrder.Items[0].Product.Price.Price);
            Assert.AreEqual(childOrder.PaymentStatus, "Pending");
            Assert.AreEqual(childOrder.FulfillmentStatus, "NotShipped");
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return for the entire order item in one order when the parent is in partially shipped state.")]
        public void OrderReturnTests_Test6()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"metropolitan-chair", 1}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderPartialShipped(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 2);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            Assert.AreEqual(createdReturn.Items.Count, 1);
            Assert.AreEqual(createdReturn.OriginalOrderId, orderId);
            Assert.AreEqual(createdReturn.Items[0].OrderItemId, order.Items[0].Id);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, order.Items[0].Quantity);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return for units from different order items in one order when the parent order has been completed.")]
        public void OrderReturnTests_Test7()
        {
            var products = new Dictionary<string, int>();
            products.Add("bantam-sofa", 2);
            products.Add("eames-dining-chair", 2);
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("DifferentExpectations", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[0].Id, reasons));
            reasons = new Dictionary<string, int> {{"Damaged", 1}};
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[1].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            Assert.AreEqual(createdReturn.Items.Count, 2);
            Assert.AreEqual(createdReturn.OriginalOrderId, orderId);
            Assert.AreEqual(createdReturn.Items[0].OrderItemId, order.Items[0].Id);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, 1);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Reason, "DifferentExpectations");
            Assert.AreEqual(createdReturn.Items[1].OrderItemId, order.Items[1].Id);
            Assert.AreEqual(createdReturn.Items[1].Reasons[0].Quantity, 1);
            Assert.AreEqual(createdReturn.Items[1].Reasons[0].Reason, "Damaged");
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return for the entire order (cancel order).")]
        public void OrderReturnTests_Test8()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 2);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[0].Id, reasons));
            reasons = new Dictionary<string, int> {{"NoLongerWanted", 2}};
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[1].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            Assert.AreEqual(createdReturn.Items.Count, 2);
            Assert.AreEqual(createdReturn.OriginalOrderId, orderId);
            Assert.AreEqual(createdReturn.Items[0].OrderItemId, order.Items[0].Id);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, order.Items[0].Quantity);
            Assert.AreEqual(createdReturn.Items[1].OrderItemId, order.Items[1].Id);
            Assert.AreEqual(createdReturn.Items[1].Reasons[0].Quantity, order.Items[1].Quantity);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Refund return by check.")]
        public void OrderReturnTests_Test9()
        {
            var products = new Dictionary<string, int>();
            products.Add("bantam-sofa", 2);
            products.Add("eames-dining-chair", 2);
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler, 
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            Assert.AreEqual(createdReturn.ReturnType, "Refund");
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            Assert.AreEqual(authReturn.Items[0].Status, "Authorized");
            var createdPaymentAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "12345", 6630, order.Payments[0].Id));  
            Assert.AreEqual(createdPaymentAction.Payments.Count, 1);
            Assert.AreEqual(createdPaymentAction.Payments[0].AmountCredited, 6630);
            Assert.AreEqual(createdPaymentAction.Payments[0].Status, "Credited");
            Assert.AreEqual(createdPaymentAction.Payments[0].PaymentType, PaymentType.Check.ToString());  //----------------------------> bug 17541
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Refund return by credit card.")]
        public void OrderReturnTests_Test10()
        {
            var products = new Dictionary<string, int>();
            products.Add("bantam-sofa", 2);
            products.Add("eames-dining-chair", 2);
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var createdPaymentAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "", 6630, order.Payments[0].Id));
            Assert.AreEqual(createdPaymentAction.Payments.Count, 1);
            Assert.AreEqual(createdPaymentAction.Payments[0].Interactions.Count, 3);
            Assert.AreEqual(createdPaymentAction.Payments[0].Interactions[2].InteractionType, PaymentInteractionType.Credit.ToString());
            Assert.IsFalse(createdPaymentAction.Payments[0].Interactions[2].IsManual);
            Assert.AreEqual(createdPaymentAction.Payments[0].AmountCredited, 6630);
            Assert.AreEqual(createdPaymentAction.Payments[0].Status, "Credited");
            Assert.AreEqual(createdPaymentAction.Payments[0].PaymentType, PaymentType.CreditCard.ToString());
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Refund return partially by check and partially by credit card.")]
        public void OrderReturnTests_Test11()
        {
            var products = new Dictionary<string, int>();
            products.Add("bantam-sofa", 1);
            products.Add("metropolitan-chair", 2);
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderShipped(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[1].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var payByCreditAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "", 4000, order.Payments[0].Id));
            var payByCheckAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "12345", 2000));
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturn.Id);   
            Assert.AreEqual(getReturn.Payments.Count, 2);
            Assert.AreEqual(getReturn.Payments[0].AmountCredited, 4000);
            Assert.AreEqual(getReturn.Payments[1].AmountCredited, 2000);
            Assert.AreEqual(getReturn.Payments[0].Interactions.Count, 3);
            Assert.AreEqual(getReturn.Payments[0].PaymentType, PaymentType.CreditCard.ToString());
            Assert.AreEqual(getReturn.Payments[1].PaymentType, PaymentType.Check.ToString());
            Assert.AreEqual(getReturn.Payments[0].Interactions[2].Status, "Credited"); 
            Assert.AreEqual(getReturn.Payments[1].Interactions[0].Status, "Credited");
            Assert.AreEqual(getReturn.Payments[0].Status, "Credited");
            Assert.AreEqual(getReturn.Payments[1].Status, "Credited");
            var refundReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Refund", returnIds));
            Assert.AreEqual(refundReturn.Items[0].Status, "Refunded");
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Refund return using two different credit cards.")]
        public void OrderReturnTests_Test12()
        {

        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Set RMA deadline.")]
        public void OrderReturnTests_Test13()
        {
            var products = new Dictionary<string, int>();
            products.Add("bantam-sofa", 2);
            products.Add("eames-dining-chair", 2);
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            createdReturn.RMADeadline = ((DateTime) createdReturn.AuditInfo.CreateDate).AddDays(10);
            var updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturn.Id, createdReturn);
            DateTime createdDate = (DateTime) updateReturn.AuditInfo.CreateDate;
            //Assert.IsTrue(updateReturn.RMADeadline.Subtract(createdDate).Days == 10);
        }
         

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Close return when refund process completes (refund before receive).")]
        public void OrderReturnTests_Test14()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);       
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var createdPaymentAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "", 6630, order.Payments[0].Id));
            var refundReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Refund", returnIds));
            Assert.AreEqual(refundReturn.Items[0].Status, "Refunded");
            var returnActions = ReturnFactory.GetAvailableReturnActions(ApiMsgHandler, createdReturn.Id);
            Assert.AreEqual(returnActions.Count, 1);
            Assert.IsTrue(returnActions[0].Contains("Close"));             
            refundReturn.Items[0].Items[0].QuantityReceived = 1;
            var updatedReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, refundReturn.Items[0].Id,
               refundReturn.Items[0]);
            returnActions = ReturnFactory.GetAvailableReturnActions(ApiMsgHandler, createdReturn.Id);
            Assert.AreEqual(returnActions.Count, 1);                                                                 
            Assert.IsTrue(returnActions[0].Contains("Close"));
            var closeReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Close", returnIds));
            Assert.AreEqual(closeReturn.Items[0].Status, "Closed");
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Close return when child order hasn't completed its whole process.")]  
        public void OrderReturnTests_Test15()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            awaitReturn.Items[0].Items[0].QuantityReceived = 1;
            createdReturn.Items[0].QuantityReceived = 1;
            var updatedReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, awaitReturn.Items[0].Id, awaitReturn.Items[0]);
            var receiveReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Receive", returnIds));
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturn.Id);
            Assert.IsNotNull(getReturn);
            var getProd = ProductFactory.GetProduct(ApiMsgHandler, "bantam-sofa");
            getReturn.Items[0].QuantityRestockable = 1;
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturn.Id, getReturn);
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            var getProd1 = ProductFactory.GetProduct(ApiMsgHandler, "bantam-sofa");
    /*        Assert.AreEqual(getProd1.StockAvailable, getProd.StockAvailable + getReturn.Items[0].QuantityRestockable);
            Assert.AreEqual(getProd1.StockOnHand, getProd.StockOnHand + getReturn.Items[0].QuantityRestockable);        */
            var shipReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Ship", returnIds));
            var closeReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Close", returnIds), (int) HttpStatusCode.Conflict); 
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return with invalid reason or without a reason.")]
        public void OrderReturnTests_Test16()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("I don't like it", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId), (int) HttpStatusCode.Conflict); 
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return with reason - Defective.")]
        public void OrderReturnTests_Test17()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 1}, {"metropolitan-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderPartialShipped(ApiMsgHandler, getOrder);
            reasons.Add("Defective", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            Assert.AreEqual(createdReturn.Items[0].Reasons.Count, 1);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Reason, "Defective");
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, 1);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return with reason - MissingParts.")]
        public void OrderReturnTests_Test18()
        {
            var products = new Dictionary<string, int> {{"eames-dining-chair", 2}, {"lancaster_barstool", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("MissingParts", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            Assert.AreEqual(createdReturn.Items[0].Reasons.Count, 1);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Reason, "MissingParts");
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, 1);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return with reason - DifferentExpections.")]
        public void OrderReturnTests_Test19()
        {
            var products = new Dictionary<string, int> {{"eames-dining-chair", 3}, {"lancaster_barstool", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("DifferentExpectations", 2);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));          
            Assert.AreEqual(createdReturn.Items[0].Reasons.Count, 1);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Reason, "DifferentExpectations");
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, 2);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return with reason - Late.")]
        public void OrderReturnTests_Test20()
        {
            var products = new Dictionary<string, int> {{"eames-dining-chair", 3}, {"lancaster_barstool", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Late", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            Assert.AreEqual(createdReturn.Items[0].Reasons.Count, 1);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Reason, "Late");
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, 1);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return with reasons - NoLongerWanted and Damaged.")]
        public void OrderReturnTests_Test21()
        {
            var products = new Dictionary<string, int> {{"eames-dining-chair", 2}, {"lancaster_barstool", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));            
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            Assert.AreEqual(createdReturn.Items[0].Reasons.Count, 2);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Reason, "NoLongerWanted");
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, 1);
            Assert.AreEqual(createdReturn.Items[0].Reasons[1].Reason, "Damaged");
            Assert.AreEqual(createdReturn.Items[0].Reasons[1].Quantity, 1);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return with reason - Other.")]
        public void OrderReturnTests_Test22()
        {
            var products = new Dictionary<string, int> {{"lancaster_barstool", 2}, {"eames-dining-chair", 1}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Other", 1);
            var notes = OrderNoteFactory.OrderNoteList;
            notes.Add(OrderNoteFactory.GenerateOrderNote("Customer has something against the material used on this product."));
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons, notes));            
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId)); 
            Assert.AreEqual(createdReturn.Items[0].Reasons.Count, 1);
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Reason, "Other");
            Assert.AreEqual(createdReturn.Items[0].Reasons[0].Quantity, 1);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create two returns, one for refund and one for replacement, for one parent order.")] 
        public void OrderReturnTests_Test23()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdRefundReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var reasons1 = new Dictionary<string, int> {{"MissingParts", 1}};
            var returnItems1 = ReturnFactory.ReturnItemList;
            returnItems1.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons1));
            var createdReplaceReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems1,  orderId));
            var getReturns = ReturnFactory.GetReturns(ApiMsgHandler, 0, 5, null, "originalorderid eq " + orderId);
            Assert.AreEqual(getReturns.Items.Count, 2);                         
            Assert.AreEqual(getReturns.Items[0].Items.Count, 1);
            Assert.AreEqual(getReturns.Items[0].OriginalOrderId, orderId);
            Assert.AreEqual(getReturns.Items[0].ReturnType, "Refund");
            Assert.AreEqual(getReturns.Items[1].Items.Count, 1);
            Assert.AreEqual(getReturns.Items[1].OriginalOrderId, orderId);
            Assert.AreEqual(getReturns.Items[1].ReturnType, "Replace");
            Assert.AreEqual(getReturns.Items[0].Items[0].Reasons.Count, 1);
            Assert.AreEqual(getReturns.Items[1].Items[0].Reasons.Count, 1);
            Assert.AreEqual(getReturns.Items[0].Items[0].Reasons[0].Quantity, 1);
            Assert.AreEqual(getReturns.Items[0].Items[0].Reasons[0].Reason, "Damaged");
            Assert.AreEqual(getReturns.Items[1].Items[0].Reasons[0].Quantity, 1);
            Assert.AreEqual(getReturns.Items[1].Items[0].Reasons[0].Reason, "MissingParts");
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Cancel return when refund has already been issued.")]
        public void OrderReturnTests_Test24()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            awaitReturn.Items[0].Items[0].QuantityReceived = 1;
            var updatedReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, awaitReturn.Items[0].Id,
               awaitReturn.Items[0]);
            var receiveReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Receive", returnIds));
            var createdPaymentAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CredItPayment", "", 6630, order.Payments[0].Id));
            var refundReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Refund", returnIds));
            var cancelReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Cancel", returnIds), (int) HttpStatusCode.NotFound);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Cancel return when the replacement has already been shipped out.")]
        public void OrderReturnTests_Test25()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            awaitReturn.Items[0].Items[0].QuantityReceived = 1;
            var updatedReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, awaitReturn.Items[0].Id, awaitReturn.Items[0]);
            var receiveReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Receive", returnIds));
            var shipReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Ship", returnIds));
            var cancelReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Cancel", returnIds), (int) HttpStatusCode.NotFound);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return given order item id which is not from the parent order.")]
        public void OrderReturnTests_Test26()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 1}, {"metropolitan-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderShipped(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem("InvalidOrderItemId", reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId), (int) HttpStatusCode.NotFound);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return the return quantity of the item is greater than the quantity of the corresponding parent order item.")]
        public void OrderReturnTests_Test27()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 1}, {"metropolitan-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderShipped(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 5);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[1].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId), (int)HttpStatusCode.Conflict);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return with the return quantity less than zero.")]
        public void OrderReturnTests_Test28()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 1}, {"metropolitan-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderShipped(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", -2);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId), (int)HttpStatusCode.Conflict); 
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Deleting an existing return after the return state changes to cancel.")]
        public void OrderReturnTests_Test29()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var cancelReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Cancel", returnIds));
            Assert.AreEqual(cancelReturn.Items[0].Status, "Cancelled");
            ReturnFactory.DeleteReturn(ApiMsgHandler, createdReturn.Id);
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturn.Id, (int) HttpStatusCode.NotFound);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return when none of packages from parent order have been shipped out.")]
        public void OrderReturnTests_Test30()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 1}, {"metropolitan-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var captureOrderPayment = PaymentFactory.PerformPaymentAction(ApiMsgHandler, orderId,
                getOrder.Payments[0].Id, Payments.GeneratePaymentAction("CapturePayment",
                "", Convert.ToDecimal(getOrder.Total), getOrder.Payments[0].Id));
            var items = PackageFactory.PackageItemList;
            items.Add(PackageFactory.GeneratePackageItem(getOrder.Items[1].Id, getOrder.Items[1].Quantity));
            var pkg = PackageFactory.GeneratePackage("fedex_FEDEX_2_DAY", "FEDEX_2_DAY", items);
            var createdPkg = PackageFactory.CreatePackage(ApiMsgHandler, orderId, pkg);
            var pkgIds = new List<string> {createdPkg.Id};
            var createPkgShipment = PackageFactory.CreatePackageShipments(ApiMsgHandler, orderId, pkgIds);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId), (int)HttpStatusCode.Conflict);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Delete an existing return when the return has not been cancelled.")]
        public void OrderReturnTests_Test31()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            ReturnFactory.DeleteReturn(ApiMsgHandler, createdReturn.Id, (int) HttpStatusCode.Conflict); 
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturn.Id);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Tracking Return status/actions for return work flow - refund + restock.")]
        public void OrderReturnTests_Test32()
        {
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> {{"profile-dining-chair", 3}, {"lancaster_barstool", 4}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            reasons = new Dictionary<string, int> {{"MissingParts", 1}};
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(1, 1);
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            Assert.AreEqual(createdReturn.ReturnType, "Refund");
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            Assert.AreEqual(authReturn.Items[0].ReturnType, "Refund");
            Assert.AreEqual(authReturn.Items[0].AvailableActions.Count, 3);
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            Assert.AreEqual(awaitReturn.Items[0].ReturnType, "Refund");
            Assert.AreEqual(awaitReturn.Items[0].AvailableActions.Count, 2);
            foreach (var r in receiveItems)
            {
                awaitReturn.Items[0].Items[r.Key].QuantityReceived = r.Value;
            }
            var updatedReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, awaitReturn.Items[0].Id, awaitReturn.Items[0]);
            var receiveReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Receive", returnIds));
            Assert.AreEqual(receiveReturn.Items[0].ReturnType, "Refund");
            Assert.AreEqual(receiveReturn.Items[0].AvailableActions.Count, 2);
            Assert.IsTrue(receiveReturn.Items[0].AvailableActions[0].Contains("Refund") || receiveReturn.Items[0].AvailableActions[0].Contains("Ship"));  
            Assert.IsTrue(receiveReturn.Items[0].AvailableActions[1].Contains("Refund") || receiveReturn.Items[0].AvailableActions[1].Contains("Ship"));
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturn.Id);
            getReturn.Items[0].QuantityRestockable = 1;
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturn.Id, getReturn);
            Assert.IsTrue(updatedReturn1.AvailableActions[0].Contains("Refund") || updatedReturn1.AvailableActions[0].Contains("Ship") || updatedReturn1.AvailableActions[0].Contains("Restock"));
            Assert.IsTrue(updatedReturn1.AvailableActions[1].Contains("Refund") || updatedReturn1.AvailableActions[1].Contains("Ship") || updatedReturn1.AvailableActions[1].Contains("Restock"));
            Assert.IsTrue(updatedReturn1.AvailableActions[2].Contains("Refund") || updatedReturn1.AvailableActions[2].Contains("Ship") || updatedReturn1.AvailableActions[2].Contains("Restock"));
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            Assert.AreEqual(restockReturn.Items[0].ReturnType, "Refund");
            Assert.AreEqual(restockReturn.Items[0].AvailableActions.Count, 2);
            Assert.IsTrue(restockReturn.Items[0].AvailableActions[0].Contains("Refund") || restockReturn.Items[0].AvailableActions[0].Contains("Ship"));
            Assert.IsTrue(restockReturn.Items[0].AvailableActions[1].Contains("Refund") || restockReturn.Items[0].AvailableActions[1].Contains("Ship"));
            var createdPaymentAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "", 6630, order.Payments[0].Id));
            var refundReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Refund", returnIds));
            Assert.AreEqual(refundReturn.Items[0].Status, "Refunded");
            var closeReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Close", returnIds));
            Assert.AreEqual(closeReturn.Items[0].Status, "Closed");
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Close return when refund process completes (receive before refund).")]
        public void OrderReturnTests_Test33()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            Assert.AreEqual(awaitReturn.Items[0].Status, "Pending");
            awaitReturn.Items[0].Items[0].QuantityReceived = 1;
            var updatedReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, awaitReturn.Items[0].Id,
               awaitReturn.Items[0]);
            var receiveReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Receive", returnIds));
            Assert.AreEqual(receiveReturn.Items[0].Status, "Received");
            var returnActions = ReturnFactory.GetAvailableReturnActions(ApiMsgHandler, createdReturn.Id);
            Assert.AreEqual(returnActions.Count, 2);
            Assert.IsTrue(returnActions[0].Contains("Refund") || returnActions[0].Contains("Ship"));
            Assert.IsTrue(returnActions[1].Contains("Refund") || returnActions[1].Contains("Ship"));
            var createdPaymentAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "", 6630, order.Payments[0].Id));
            var refundReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Refund", returnIds));
            Assert.AreEqual(refundReturn.Items[0].Status, "Refunded");
            var closeReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Close", returnIds));
            Assert.AreEqual(closeReturn.Items[0].Status, "Closed");
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return to replace items for shopper when the parent order is in complete state (re-stocking and then ship).")]
        public void OrderReturnTests_Test34()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            Assert.AreEqual(createdReturn.ReturnType, "Replace");
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            awaitReturn.Items[0].Items[0].QuantityReceived = 1;
            var updatedReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, awaitReturn.Items[0].Id, awaitReturn.Items[0]);
            var receiveReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Receive", returnIds));
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturn.Id);
            getReturn.Items[0].QuantityRestockable = 1;
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturn.Id, getReturn);
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            Assert.AreEqual(restockReturn.Items[0].Status, "Restocked");
            var shipReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Ship", returnIds));
            Assert.AreEqual(shipReturn.Items[0].Status, "Shipped");
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return for the package which hasn't been shipped out of parent order.")]
        public void OrderReturnTests_Test35()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 1}, {"metropolitan-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderPartialShipped(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[1].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId), (int) HttpStatusCode.Conflict);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Refund failed due to gateway issue and try to refund the 2nd time.")]
        public void OrderReturnTests_Test36()
        {

        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Get all return payments.")]
        public void OrderReturnTests_Test37()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 1}, {"metropolitan-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderShipped(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[1].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var payByCreditAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "", 4000, order.Payments[0].Id));
            var payByCheckAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "12345", 2000, order.Payments[0].Id));
            var getReturnPayments = ReturnFactory.GetReturnPayments(ApiMsgHandler, createdReturn.Id);
            Assert.AreEqual(getReturnPayments.Count, 2);
            Assert.AreEqual(getReturnPayments[0].PaymentType, PaymentType.CreditCard.ToString());
            Assert.AreEqual(getReturnPayments[1].PaymentType, PaymentType.Check.ToString());   //------------------------------> bug 17541
            Assert.AreEqual(getReturnPayments[0].AmountCredited, 4000);
            Assert.AreEqual(getReturnPayments[1].AmountCredited, 2000);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Get a specific return payment.")]
        public void OrderReturnTests_Test38()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 1}, {"metropolitan-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderShipped(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[1].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var payByCreditAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "", 4000, order.Payments[0].Id));
            var payByCheckAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturn.Id,
                Payments.GeneratePaymentAction("CreditPayment", "12345", 2000, "78210"));   //-------------------------------> bug 17541
            var getReturnPayment = ReturnFactory.GetReturnPayment(ApiMsgHandler, createdReturn.Id,
                payByCreditAction.Payments[0].Id);
            Assert.AreEqual(getReturnPayment.AmountCredited, 4000);
            Assert.AreEqual(getReturnPayment.Interactions.Count, 3);
            Assert.AreEqual(getReturnPayment.Interactions[2].Amount, 4000);
            Assert.AreEqual(getReturnPayment.Interactions[2].InteractionType, PaymentInteractionType.Credit.ToString());
            Assert.AreEqual(getReturnPayment.Interactions[2].Status, "Credited");
            Assert.AreEqual(getReturnPayment.PaymentType, PaymentType.CreditCard.ToString());
            Assert.AreEqual(getReturnPayment.Status, "Credited");
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Perform receive return action without entering QuantityReceived for return item first.")]
        public void OrderReturnTests_Test39()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            var receiveReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Receive", returnIds), (int) HttpStatusCode.Conflict);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Restock return without entering QuantityRestockable for return item first.")]
        public void OrderReturnTests_Test40()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1); 
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            awaitReturn.Items[0].Items[0].QuantityReceived = 1;
            var updatedReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, awaitReturn.Items[0].Id, awaitReturn.Items[0]);
            var receiveReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Receive", returnIds));
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds), (int) HttpStatusCode.NotFound);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Tracking Return status/actions for return work flow - replace + restock.")]
        public void OrderReturnTests_Test41()
        {

        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Set RMA deadline prior to return CreateDate.")]
        public void OrderReturnTests_Test42()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            createdReturn.RMADeadline = ((DateTime)createdReturn.AuditInfo.CreateDate).AddDays(-10);
            var updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturn.Id, createdReturn, (int) HttpStatusCode.Conflict); 
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Cancel return and then create return again.")]
        public void OrderReturnTests_Test43()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(ShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var cancelReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Cancel", returnIds));
            Assert.AreEqual(cancelReturn.Items[0].Status, "Cancelled");
            createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Move return to Shipped state and make sure child order is created.")]
        public void OrderReturnTests_Test44()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Replace, returnItems, orderId));
            Assert.AreEqual(createdReturn.ReturnType, "Replace");
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            awaitReturn.Items[0].Items[0].QuantityReceived = 1;
            var updatedReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, awaitReturn.Items[0].Id, awaitReturn.Items[0]);
            var receiveReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Receive", returnIds));
            var shipReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Ship", returnIds));
            Assert.IsNotNull(shipReturn.Items[0].ReturnOrderId);
            Assert.AreEqual(shipReturn.Items[0].LossTotal, 6630);
            var getChildOrder = OrderFactory.GetOrder(ApiMsgHandler, shipReturn.Items[0].ReturnOrderId);
            Assert.AreEqual(getChildOrder.Items.Count, 1);
            Assert.AreEqual(getChildOrder.Items[0].Quantity, 1);
            Assert.AreEqual(getChildOrder.Items[0].Product.ProductCode, "bantam-sofa");
            Assert.AreEqual(getChildOrder.ParentReturnId, createdReturn.Id);
            Assert.AreEqual(getChildOrder.Status, "Submitted");
            Assert.AreEqual(getChildOrder.PaymentStatus, "Pending");
            Assert.AreEqual(getChildOrder.FulfillmentStatus, "NotShipped");
            Assert.AreEqual(getChildOrder.Payments.Count, 1);
            Assert.AreEqual(getChildOrder.Payments[0].Status, "Authorized");
            Assert.AreEqual(getChildOrder.Payments[0].Interactions.Count, 1);
            Assert.AreEqual(getChildOrder.Payments[0].Interactions[0].Status, "Authorized");
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Create return when item quantity is greater than the parent order.")]
        public void OrderReturnTests_Test45()
        {
            var products = new Dictionary<string, int> { { "bantam-sofa", 1 }, { "metropolitan-chair", 2 } };
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderPartialShipped(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 3);
            returnItems.Add(ReturnFactory.GenerateReturnItem(getOrder.Items[1].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId), (int) HttpStatusCode.Conflict);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Merchant overrides return losses at item level - flat rate per item.")]
        public void OrderReturnTests_Test46()
        {
            TaxableTerritoryFactory.SetDefaultTaxSettings(ApiMsgHandler);
            CarrierConfigurationFactory.UpdateCustomShippingMethod(ApiMsgHandler, true, false, "35");
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> { { "profile-dining-chair", 3 }, { "lancaster_barstool", 4 } };
            var orderId = OrderFactory.CreateCartToSubmitOrder1(AnonShopperMsgHandler, ApiMsgHandler,
                products, "CA", "95814", "custom_FLAT_RATE_PER_ITEM_EXACT_AMOUNT", "Flat Rate Per Item");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            reasons = new Dictionary<string, int> { { "MissingParts", 3 } };
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(1, 3);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].ProductLossAmount = 390 * getReturn.Items[0].QuantityReceived;  //---->399
            //tax rate is 0.08
            getReturn.Items[0].ShippingLossAmount = (decimal)45 * getReturn.Items[0].QuantityReceived;
            getReturn.Items[1].ProductLossAmount = 655 * getReturn.Items[1].QuantityReceived;  //----> 650
            getReturn.Items[1].ShippingLossAmount = (decimal)25 * getReturn.Items[1].QuantityReceived;
            var updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            Assert.AreEqual(updateReturn.Items[0].ProductLossAmount, getReturn.Items[0].ProductLossAmount);  //----------------------------------------------> bug 17943
            Assert.AreEqual(updateReturn.Items[0].ProductLossTaxAmount, getReturn.Items[0].ProductLossAmount * (decimal)0.08);  //------------> no this field
            Assert.AreEqual(updateReturn.Items[0].ShippingLossAmount, getReturn.Items[0].ShippingLossAmount);
            Assert.AreEqual(updateReturn.Items[0].ShippingLossTaxAmount, getReturn.Items[0].ShippingLossAmount * (decimal)0.08);  //--------------> no this field
            Assert.AreEqual(updateReturn.Items[1].ProductLossAmount, getReturn.Items[0].ProductLossAmount);
            Assert.AreEqual(updateReturn.Items[1].ProductLossTaxAmount, getReturn.Items[0].ProductLossAmount * (decimal)0.08);  //--------------> no this field
            Assert.AreEqual(updateReturn.Items[1].ShippingLossAmount, getReturn.Items[1].ShippingLossAmount);
            Assert.AreEqual(updateReturn.Items[1].ShippingLossTaxAmount, getReturn.Items[1].ShippingLossAmount * (decimal)0.08);  //-----------------> no this field
            Assert.AreEqual(updateReturn.ProductLossTotal, updateReturn.Items[0].ProductLossAmount+updateReturn.Items[1].ProductLossAmount);
            Assert.AreEqual(updateReturn.ProductLossTaxTotal, updateReturn.Items[0].ProductLossTaxAmount+updateReturn.Items[1].ProductLossTaxAmount);  //----------------> no this field
            Assert.AreEqual(updateReturn.ShippingLossTotal, getReturn.Items[0].ShippingLossAmount + getReturn.Items[1].ShippingLossAmount);
            Assert.AreEqual(updateReturn.ShippingLossTaxTotal, getReturn.Items[0].ShippingLossTaxAmount + getReturn.Items[1].ShippingLossTaxAmount);
            Assert.AreEqual(updateReturn.LossTotal, updateReturn.ProductLossTotal + updateReturn.ShippingLossTotal);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Merchant overrides return losses at shipping level - flat rate per order.")]
        public void OrderReturnTests_Test47()
        {
            TaxableTerritoryFactory.SetDefaultTaxSettings(ApiMsgHandler);
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> { { "profile-dining-chair", 3 }, { "lancaster_barstool", 4 } };
            var orderId = OrderFactory.CreateCartToSubmitOrder1(AnonShopperMsgHandler, ApiMsgHandler,
                products, "CA", "95814");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            reasons = new Dictionary<string, int> { { "MissingParts", 3 } };
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(1, 3);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].ProductLossAmount = 500 * getReturn.Items[0].QuantityReceived;
            getReturn.Items[1].ProductLossAmount = 480 * getReturn.Items[1].QuantityReceived;
            getReturn.Items[0].ShippingLossAmount = 10;
            getReturn.Items[1].ShippingLossAmount = 20;
            var updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            Assert.AreEqual(updateReturn.Items[0].ProductLossAmount, getReturn.Items[0].ProductLossAmount);  //-----------------------------------> bug 17945, 17943
            //Assert.AreEqual(updateReturn.Items[0].ProductLossTaxAmount, updateReturn.Items[0].ProductLossAmount * (decimal)0.08);
            Assert.AreEqual(updateReturn.Items[0].ShippingLossAmount, getReturn.Items[0].ShippingLossAmount);
            //Assert.AreEqual(updateReturn.Items[0].ShippingLossTaxAmount, updateReturn.Items[0].ShippingLossAmount * (decimal)0.08);
            Assert.AreEqual(updateReturn.Items[1].ProductLossAmount, getReturn.Items[1].ProductLossAmount);
            //Assert.AreEqual(updateReturn.Items[1].ProductLossTaxAmount, updateReturn.Items[1].ProductLossAmount * (decimal)0.08);
            Assert.AreEqual(updateReturn.Items[1].ShippingLossAmount, getReturn.Items[1].ShippingLossAmount);
            //Assert.AreEqual(updateReturn.Items[1].ShippingLossTaxAmount, updateReturn.Items[1].ShippingLossAmount * (decimal)0.08);
            Assert.AreEqual(updateReturn.ProductLossTotal, updateReturn.Items[0].ProductLossAmount + updateReturn.Items[1].ProductLossAmount);
            //Assert.AreEqual(updateReturn.ProductLossTaxTotal, updateReturn.Items[0].ProductLossTaxAmount + updateReturn.Items[1].ProductLossTaxAmount);
            Assert.AreEqual(updateReturn.ShippingLossTotal, updateReturn.Items[0].ShippingLossAmount + updateReturn.Items[1].ShippingLossAmount);
            //Assert.AreEqual(updateReturn.ShippingLossTaxTotal, getReturn.ShippingLossTaxTotal);
            Assert.AreEqual(updateReturn.LossTotal, updateReturn.ProductLossTotal + updateReturn.ShippingLossTotal);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Merchant overrides losses as negative figures.")]
        public void OrderReturnTests_Test48()
        {
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> { { "profile-dining-chair", 3 }, { "lancaster_barstool", 4 } };
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].ProductLossAmount = -395*2;            
            var updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn, (int) HttpStatusCode.Conflict);   //------------------------> bug 17947
            getReturn.ShippingLossTotal = -30;
            updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn, (int)HttpStatusCode.Conflict);
            getReturn.Items[0].ShippingLossAmount = -5;
            updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn, (int)HttpStatusCode.Conflict);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Merchant overrides losses greater than the total of return items minus the total of re-stocking.")]
        public void OrderReturnTests_Test49()
        {

        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Merchants overrides losses when return has been closed.")]
        public void OrderReturnTests_Test50()
        {
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> { { "profile-dining-chair", 3 }, { "lancaster_barstool", 4 } };
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            reasons = new Dictionary<string, int> { { "MissingParts", 1 } };
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(1, 1);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var returnIds = new List<string>();
            returnIds.Add(createdReturnId);
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].QuantityRestockable = 1;
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            var createdPaymentAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturnId,
                Payments.GeneratePaymentAction("CreditPayment", "", 6630, order.Payments[0].Id));
            var refundReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Refund", returnIds));
            var closeReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Close", returnIds));
            getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].ProductLossAmount = 395;
            var updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn, (int) HttpStatusCode.Conflict);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Merchants overrides losses when return has been cancelled.")]
        public void OrderReturnTests_Test51()
        {
            var products = new Dictionary<string, int> { { "bantam-sofa", 2 }, { "eames-dining-chair", 2 } };
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete1(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> { createdReturn.Id };
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            var cancelReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Cancel", returnIds));
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturn.Id);
            getReturn.Items[0].ProductLossAmount = 6800;
            var updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturn.Id, getReturn, (int)HttpStatusCode.Conflict);   //-------------------> bug 17949
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Merchants overrides losses when return is in Created, Authorized, or Pending state.")]
        public void OrderReturnTests_Test52()
        {
            var products = new Dictionary<string, int> { { "bantam-sofa", 2 }, { "eames-dining-chair", 2 } };
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Damaged", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            createdReturn.Items[0].ProductLossAmount = 6630;
            var updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturn.Id, createdReturn);
            var returnIds = new List<string> { createdReturn.Id };
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturn.Id);
            getReturn.Items[0].ProductLossAmount = 6800;
            updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturn.Id, createdReturn);
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturn.Id, createdReturn);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description(".")]
        public void OrderReturnTests_Test53()
        {
                        
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("System default the return losses - flat rate per order.")]
        public void OrderReturnTests_Test54()
        {
            TaxableTerritoryFactory.SetDefaultTaxSettings(ApiMsgHandler);
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> { { "profile-dining-chair", 3 }, { "lancaster_barstool", 4 } };
            var orderId = OrderFactory.CreateCartToSubmitOrder1(AnonShopperMsgHandler, ApiMsgHandler,
                products, "CA", "95814");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            reasons = new Dictionary<string, int> { { "MissingParts", 3 } };
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(1, 3);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            Assert.AreEqual(getReturn.Items[0].ProductLossAmount, 399);
            //Assert.AreEqual(getReturn.Items[0].ProductLossTaxAmount, getReturn.Items[0].ProductLossAmount * (decimal)0.08);   //----------------------------------------------> bug 17943
            Assert.AreEqual(getReturn.Items[1].ProductLossAmount, (decimal)650 * getReturn.Items[1].QuantityReceived);
            //Assert.AreEqual(getReturn.Items[1].ProductLossTaxAmount, getReturn.Items[1].ProductLossAmount * (decimal)0.08);
            Assert.AreEqual(getReturn.ProductLossTotal, getReturn.Items[0].ProductLossAmount + getReturn.Items[1].ProductLossAmount);
            //Assert.AreEqual(getReturn.ProductLossTaxTotal, getReturn.ProductLossTotal * (decimal)0.08);
            Assert.AreEqual(getReturn.LossTotal, getReturn.ProductLossTotal+getReturn.ShippingLossTotal);
            getReturn.Items[0].ShippingLossAmount = 5;
            getReturn.Items[1].ShippingLossAmount = 10;
            var updateReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            Assert.AreEqual(updateReturn.Items[0].ShippingLossAmount, getReturn.Items[0].ShippingLossAmount);
            Assert.AreEqual(updateReturn.Items[0].ShippingLossTaxAmount, updateReturn.Items[0].ShippingLossAmount * (decimal)0.08);
            Assert.AreEqual(updateReturn.Items[1].ShippingLossAmount, getReturn.Items[1].ShippingLossAmount);
            Assert.AreEqual(updateReturn.Items[1].ShippingLossTaxAmount, updateReturn.Items[1].ShippingLossAmount * (decimal)0.08);
            Assert.AreEqual(updateReturn.ShippingLossTotal, updateReturn.Items[0].ShippingLossAmount + updateReturn.Items[1].ShippingLossAmount);
            Assert.AreEqual(updateReturn.ShippingLossTaxTotal, updateReturn.Items[0].ShippingLossTaxAmount + updateReturn.Items[1].ShippingLossTaxAmount);
            Assert.AreEqual(updateReturn.LossTotal, updateReturn.ProductLossTotal+updateReturn.ShippingLossTotal);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("System default the return losses - flat rate per item.")]
        public void OrderReturnTests_Test55()
        {
            TaxableTerritoryFactory.SetDefaultTaxSettings(ApiMsgHandler);
            CarrierConfigurationFactory.UpdateCustomShippingMethod(ApiMsgHandler, true, false, "35");
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> { { "profile-dining-chair", 3 }, { "lancaster_barstool", 4 } };
            var orderId = OrderFactory.CreateCartToSubmitOrder1(AnonShopperMsgHandler, ApiMsgHandler,
                products, "CA", "95814", "custom_FLAT_RATE_PER_ITEM_EXACT_AMOUNT", "Flat Rate Per Item");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            reasons = new Dictionary<string, int> { { "MissingParts", 3 } };
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(1, 3);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            Assert.AreEqual(getReturn.Items[0].ProductLossAmount, (decimal)399);      //--------------------------------------------------> bug 18031
            //Assert.AreEqual(getReturn.Items[0].ProductLossTaxAmount, getReturn.Items[0].ProductLossAmount * (decimal)0.08);
            Assert.AreEqual(getReturn.Items[0].ShippingLossAmount, (decimal)35);
            //Assert.AreEqual(getReturn.Items[0].ShippingLossTaxAmount, getReturn.Items[0].ShippingLossAmount * getReturn.Items[0].QuantityReceived);
            Assert.AreEqual(getReturn.Items[1].ProductLossAmount, (decimal)650*(decimal)getReturn.Items[0].QuantityReceived);
            //Assert.AreEqual(getReturn.Items[1].ProductLossTaxAmount, getReturn.Items[1].ProductLossAmount * (decimal)0.08);
            Assert.AreEqual(getReturn.Items[1].ShippingLossAmount, (decimal)35 * getReturn.Items[1].QuantityReceived);
            //Assert.AreEqual(getReturn.Items[1].ShippingLossTaxAmount, getReturn.Items[1].ShippingLossAmount * (decimal)0.08);
            Assert.AreEqual(getReturn.ProductLossTotal, getReturn.Items[0].ProductLossAmount+getReturn.Items[1].ProductLossAmount);
            //Assert.AreEqual(getReturn.ProductLossTaxTotal, getReturn.ProductLossTotal*(decimal)0.08);
            Assert.AreEqual(getReturn.ShippingLossTotal, getReturn.Items[0].ShippingLossAmount+getReturn.Items[1].ShippingLossAmount);
            //Assert.AreEqual(getReturn.ShippingLossTaxTotal, getReturn.ShippingLossTotal*(decimal)0.08);
            Assert.AreEqual(getReturn.LossTotal, getReturn.ProductLossTotal + getReturn.ShippingLossTotal);
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description(".")]
        public void OrderReturnTests_Test()
        {

        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Return one unit of a single order item and it is good for re-stocking.")]
        public void OrderReturnRestockTests_Test1()
        {

            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> {{"profile-dining-chair", 3}, {"lancaster_barstool", 4}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var returnIds = new List<string> {createdReturnId};
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].QuantityRestockable = 1;
            var getProduct = ProductFactory.GetProduct(ApiMsgHandler, "profile-dining-chair");
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            var getProductAfterRestock = ProductFactory.GetProduct(ApiMsgHandler, "profile-dining-chair");
     /*       Assert.AreEqual(getProductAfterRestock.StockAvailable - getProduct.StockAvailable, 1);   */
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Return multiple units of one order item and some are good for re-stocking.")]
        public void OrderReturnRestockTests_Test2()
        {
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> {{"profile-dining-chair", 3}, {"lancaster_barstool", 4}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 3);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(0, 3);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var returnIds = new List<string> {createdReturnId};
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].QuantityRestockable = 2;
            var getProduct = ProductFactory.GetProduct(ApiMsgHandler, "lancaster_barstool");
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            var getProductAfterRestock = ProductFactory.GetProduct(ApiMsgHandler, "lancaster_barstool");
     /*       Assert.AreEqual(getProductAfterRestock.StockAvailable - getProduct.StockAvailable, 2);       */
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Return the entire order item and all units are good for re-stocking.")]
        public void OrderReturnRestockTests_Test3()
        {
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> {{"profile-dining-chair", 3}, {"lancaster_barstool", 4}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 3);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 3);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var returnIds = new List<string> {createdReturnId};
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].QuantityRestockable = 3;
            var getProduct = ProductFactory.GetProduct(ApiMsgHandler, "profile-dining-chair");
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            var getProductAfterRestock = ProductFactory.GetProduct(ApiMsgHandler, "profile-dining-chair");
    /*        Assert.AreEqual(getProductAfterRestock.StockAvailable - getProduct.StockAvailable, 3);            */
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Return one unit of item1, one unit of item2, and item1 is good for re-stocking.")]
        public void OrderReturnRestockTests_Test4()
        {
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> {{"profile-dining-chair", 3}, {"lancaster_barstool", 4}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            reasons = new Dictionary<string, int> {{"MissingParts", 1}};
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(1, 1);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var returnIds = new List<string> {createdReturnId};
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].QuantityRestockable = 1;
            var getProduct = ProductFactory.GetProduct(ApiMsgHandler, "profile-dining-chair");
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            var getProductAfterRestock = ProductFactory.GetProduct(ApiMsgHandler, "profile-dining-chair");
 /*           Assert.AreEqual(getProductAfterRestock.StockAvailable - getProduct.StockAvailable, 1);      */
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Return two units item1, two units of item2, and one for item1, one for item2 are good for re-stocking.")]
        public void OrderReturnRestockTests_Test5()
        {
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> {{"profile-dining-chair", 3}, {"lancaster_barstool", 4}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 2);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 2);
            reasons = new Dictionary<string, int> {{"NoLongerWanted", 2}};
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(1, 2);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var returnIds = new List<string> {createdReturnId};
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].QuantityRestockable = 1;
            getReturn.Items[1].QuantityRestockable = 1;
            var getProduct = ProductFactory.GetProduct(ApiMsgHandler, "profile-dining-chair");
            var getProduct1 = ProductFactory.GetProduct(ApiMsgHandler, "lancaster_barstool");
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            var getProductAfterRestock = ProductFactory.GetProduct(ApiMsgHandler, "profile-dining-chair");
            var getProductAfterRestock1 = ProductFactory.GetProduct(ApiMsgHandler, "lancaster_barstool");
 /*           Assert.AreEqual(getProductAfterRestock.StockAvailable - getProduct.StockAvailable, 1);
            Assert.AreEqual(getProductAfterRestock1.StockAvailable - getProduct1.StockAvailable, 1);          */
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Return one unit for item1, the entire item2, and all units for item2 are good for -re-stocking.")]
        public void OrderReturnRestockTests_Test6()
        {
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> {{"profile-dining-chair", 3}, {"lancaster_barstool", 4}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("Defective", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            reasons = new Dictionary<string, int> {{"NoLongerWanted", 4}};
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(1, 4);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var returnIds = new List<string> {createdReturnId};
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[1].QuantityRestockable = 4;
            var getProduct = ProductFactory.GetProduct(ApiMsgHandler, "lancaster_barstool");
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            var getProductAfterRestock = ProductFactory.GetProduct(ApiMsgHandler, "lancaster_barstool");
 /*           Assert.AreEqual(getProductAfterRestock.StockAvailable - getProduct.StockAvailable, 4);          */
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Update return item restock quantity - QuantityRestockable is greater than QuantityReceived.")]
        public void OrderReturnRestockTests_Test7()
        {
            var products = new Dictionary<string, int> {{"bantam-sofa", 2}, {"eames-dining-chair", 2}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 2);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            var createdReturn = ReturnFactory.CreateReturn(ApiMsgHandler,
                ReturnFactory.GenerateReturn(ReturnFactory.ReturnType.Refund, returnItems, orderId));
            var returnIds = new List<string> {createdReturn.Id};
            var authReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Authorize", returnIds));
            var awaitReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Await", returnIds));
            Assert.AreEqual(awaitReturn.Items[0].ReturnType, "Refund");  
            awaitReturn.Items[0].Items[0].QuantityReceived = 2;
            var updatedReturn = ReturnFactory.UpdateReturn(ApiMsgHandler, awaitReturn.Items[0].Id, awaitReturn.Items[0]);
            var receiveReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Receive", returnIds));
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturn.Id);
            getReturn.Items[0].QuantityRestockable = 4;
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturn.Id, getReturn, (int) HttpStatusCode.BadRequest); //----> ask Srini for future story
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Complete restock, refund, and then close the return.")]
        public void OrderReturnRestockTests_Test8()
        {
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> {{"profile-dining-chair", 3}, {"lancaster_barstool", 4}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            reasons = new Dictionary<string, int> {{"MissingParts", 1}};
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(1, 1);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var returnIds = new List<string>();
            returnIds.Add(createdReturnId);
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].QuantityRestockable = 1;
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            var createdPaymentAction = ReturnFactory.CreatePaymentActionForReturn(ApiMsgHandler, createdReturnId,
                Payments.GeneratePaymentAction("CreditPayment", "", 6630, order.Payments[0].Id));
            var refundReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Refund", returnIds));   
            Assert.AreEqual(refundReturn.Items[0].Status, "Refunded");
            var closeReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Close", returnIds));
            Assert.AreEqual(closeReturn.Items[0].Status, "Closed");
        }


        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        [Owner("CORP\\esther_shieh")]
        [TestCategory("Api")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Calculate the lost amount because the damaged items cannot be restock.")]
        public void OrderReturnRestockTests_Test9()
        {
            var receiveItems = new Dictionary<int, int>();
            var products = new Dictionary<string, int> {{"profile-dining-chair", 3}, {"lancaster_barstool", 4}};
            var orderId = OrderFactory.CreateCartToSubmitOrder(AnonShopperMsgHandler, ApiMsgHandler,
                products, null, "custom_FLAT_RATE_PER_ORDER_EXACT_AMOUNT", "Flat Rate Per Order");
            var getOrder = OrderFactory.GetOrder(ApiMsgHandler, orderId);
            var order = OrderFactory.CapturePaymentToOrderComplete(ApiMsgHandler, getOrder);
            reasons.Add("NoLongerWanted", 1);
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[0].Id, reasons));
            receiveItems.Add(0, 1);
            reasons = new Dictionary<string, int> {{"MissingParts", 1}};
            returnItems.Add(ReturnFactory.GenerateReturnItem(order.Items[1].Id, reasons));
            receiveItems.Add(1, 1);
            var createdReturnId = ReturnFactory.CreateReturnToReceiveItems(ApiMsgHandler, orderId, returnItems, receiveItems);
            var returnIds = new List<string> {createdReturnId};
            var getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            getReturn.Items[0].QuantityRestockable = 1;
            var updatedReturn1 = ReturnFactory.UpdateReturn(ApiMsgHandler, createdReturnId, getReturn);
            var restockReturn = ReturnFactory.PerformReturnAction(ApiMsgHandler,
                ReturnFactory.GenerateReturnAction("Restock", returnIds));
            getReturn = ReturnFactory.GetReturn(ApiMsgHandler, createdReturnId);
            //Verify the lossAmount
            Assert.AreEqual(getReturn.Items[0].ProductLossAmount, 399);
            Assert.AreEqual(getReturn.Items[1].ProductLossAmount, 650);
            Assert.AreEqual(getReturn.ProductLossTotal, getReturn.Items[0].ProductLossAmount + getReturn.Items[1].ProductLossAmount);
        }
    }  
}
