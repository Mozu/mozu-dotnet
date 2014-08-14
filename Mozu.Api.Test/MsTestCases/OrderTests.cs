using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Contracts.CommerceRuntime.Fulfillment;
using Mozu.Api.Contracts.CommerceRuntime.Orders;
using Mozu.Api.Contracts.CommerceRuntime.Payments;
using Mozu.Api.Contracts.CommerceRuntime.Returns;
using Mozu.Api.Test.Helpers;
using Mozu.Api.Contracts.CommerceRuntime.Carts;
using Mozu.Api.Test.Factories;
using Product = Mozu.Api.Contracts.CommerceRuntime.Products.Product;
using System.Threading;
using System.Diagnostics;
using System.Collections;


namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class OrderTests : MozuApiTestBase
    {

        #region NonTestCaseCode

        public OrderTests()
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
            //Framework.DataFactory.Platform.SiteSettingsFactory.SetDefaultSiteSettings(ServiceClientMessageFactory.GetTestClientMessage(tenantId, siteId, siteGroupId), true, true, true, true, "LoginRequired", "AuthorizeAndCaptureOnOrderPlacement", cards);
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
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Create order from existing cart.")]
        // NOTE:  This create an empty, first stage order.  It will not show up in MozuAdmin Orders UI until after the customer fulfillment and billing info is added and processed.
        public void OrderTests_CreateCart()
        {
            var customerAccountAndAuthInfo = Generator.GenerateCustomerAccountAndAuthInfo(taxExempt: true, taxId: "98-02565-0000");
            var createdCustomerAccount = CustomerAccountFactory.AddAccountAndLogin(handler: ShopperMsgHandler,
                                                                                   accountAndAuthInfo:
                                                                                       customerAccountAndAuthInfo);

            var updateCustomerAccount = CustomerContactFactory.AddAccountContact(handler: ShopperMsgHandler,
                                                                                 contact:
                                                                                     Generator
                                                                                     .GenerateCustomerContactReal(
                                                                                         accountId:
                                                                                             createdCustomerAccount
                                                                                             .CustomerAccount.Id,
                                                                                             firstname: customerAccountAndAuthInfo.Account.FirstName,
                                                                                             lastname: customerAccountAndAuthInfo.Account.LastName,
                                                                                             username: customerAccountAndAuthInfo.Account.UserName),
                                                                                 accountId:
                                                                                     createdCustomerAccount
                                                                                     .CustomerAccount.Id);

            var shopperUserAuthInfo = Generator.GenerateCustomerUserAuthInfo(userName: customerAccountAndAuthInfo.Account.UserName);

            var ShopperAuth = Mozu.Api.Security.CustomerAuthenticator.Authenticate(customerUserAuthInfo: shopperUserAuthInfo,
                tenantId: TestBaseTenant.Id, siteId: TestBaseTenant.Sites.FirstOrDefault().Id);

            ShopperMsgHandler.ApiContext.UserAuthTicket = ShopperAuth.AuthTicket;
            var createdCart = CartFactory.GetOrCreateCart(ShopperMsgHandler);
            const int index = 0;
            var product = StorefrontProductFactory.GetProducts(handler: ShopperMsgHandler, startIndex: index, pageSize: 13).Items.First();
            const int itemQty = 1;
            var item = CartItemFactory.AddItemToCart(ShopperMsgHandler,
                                                     new CartItem()
                                                     {
                                                         Product =
                                                             new Product
                                                             {
                                                                 ProductCode = product.ProductCode
                                                             },
                                                         Quantity = itemQty
                                                     });
            var getUserCart = CartFactory.GetUserCart(handler: ShopperMsgHandler, userId: createdCart.UserId);
            var order = OrderFactory.CreateOrderFromCart(ShopperMsgHandler, getUserCart.Id);
            Assert.AreEqual(order.Items.Count, itemQty, "The number of order items is not correct.");
            Assert.AreEqual(order.Items[0].Product.ProductCode, product.ProductCode, "The order item is not the same the shopper entered in the cart.");
            Assert.AreEqual(order.Status, "Created", "The order status is not correct.");
            Assert.IsTrue(order.PaymentStatus.Equals("Unpaid"));
            Assert.IsTrue(order.FulfillmentStatus.Equals("NotFulfilled"));
        }


        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Add payment info (pay by check) and shipping info (using customrates provider) to the order.")]
        public void OrderTests_CreateOrderDoNotSubmit()
        {
            var orderId = CreateOrdersForTest(submitOrder: false);
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Submit the order, pay by check, fulfill and rma checks")]
        public void OrderTests_CompleteOrderStartToFinish()
        {
            for (int i = 0; i < 200; i++)
            {
                Debug.WriteLine("Starting Run # " + (i + 1).ToString() + " of 200");
                var orderId = CreateOrdersForTest(submitOrder: true, fullfillOrder: true, returnOrder: true, anonymous: false);
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Submit the order, pay by check, fulfill and rma checks")]
        public void OrderTests_CompleteOrderStartToFinish_DirectshipOnly()
        {
            for (int i = 0; i < 200; i++)
            {
                Debug.WriteLine("Starting Run # " + (i + 1).ToString() + " of 200");
                var orderId = CreateOrdersForTest(submitOrder: true, fullfillOrder: true, returnOrder: true, anonymous: false, pickupMethod: false, directShipMethod: true);
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Submit the order, pay by check, fulfill and rma checks")]
        public void OrderTests_CompleteAnonymousOrderStartToFinish()
        {
            var orderId = CreateOrdersForTest(submitOrder: true, fullfillOrder: true, returnOrder: true, anonymous: true);
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Submit the order, pay by check.")]
        public void OrderTests_CreateOrderDoNotFullfill()
        {
            for (int i = 0; i < 200; i++)
            {
                Debug.WriteLine("Starting Run # " + (i + 1).ToString() + " of 200");
                var orderId = CreateOrdersForTest(submitOrder: true, fullfillOrder: false, returnOrder: false);
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Submit the order, pay by check, fulfill and rma checks")]
        public void OrderTests_CreateOrderDoNotFullfill_DirectshipOnly()
        {
            for (int i = 0; i < 200; i++)
            {
                Debug.WriteLine("Starting Run # " + (i + 1).ToString() + " of 200");
                var orderId = CreateOrdersForTest(submitOrder: true, fullfillOrder: false, returnOrder: false, anonymous: false, pickupMethod: false, directShipMethod: true);
            }
        }
        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [Description("Submit the order, pay by credit card.")]
        public void OrderTests_CreateOrderPayByCreditCard()
        {
            var customerAccountAndAuthInfo = Generator.GenerateCustomerAccountAndAuthInfo(taxExempt: true, taxId: "98-02565-0000");
            var createdCustomerAccount = CustomerAccountFactory.AddAccountAndLogin(handler: ShopperMsgHandler,
                                                                                   accountAndAuthInfo:
                                                                                       customerAccountAndAuthInfo);

            var updateCustomerAccount = CustomerContactFactory.AddAccountContact(handler: ShopperMsgHandler,
                                                                                 contact:
                                                                                     Generator
                                                                                     .GenerateCustomerContactReal(
                                                                                         accountId:
                                                                                             createdCustomerAccount
                                                                                             .CustomerAccount.Id,
                                                                                             firstname: customerAccountAndAuthInfo.Account.FirstName,
                                                                                             lastname: customerAccountAndAuthInfo.Account.LastName,
                                                                                             username: customerAccountAndAuthInfo.Account.UserName),
                                                                                 accountId:
                                                                                     createdCustomerAccount
                                                                                     .CustomerAccount.Id);

            var shopperUserAuthInfo =
                Generator.GenerateCustomerUserAuthInfo(userName: customerAccountAndAuthInfo.Account.UserName);

            var ShopperAuth =
                Mozu.Api.Security.CustomerAuthenticator.Authenticate(customerUserAuthInfo: shopperUserAuthInfo,
                                                                     tenantId: TestBaseTenant.Id,
                                                                     siteId: TestBaseTenant.Sites.FirstOrDefault().Id);

            ShopperMsgHandler.ApiContext.UserAuthTicket = ShopperAuth.AuthTicket;
            var createdCart = CartFactory.GetOrCreateCart(ShopperMsgHandler);
            const int index = 0;

            var productCollection = StorefrontProductFactory.GetProducts(handler: ShopperMsgHandler, startIndex: index,
                                                                         pageSize: 13, filter: "productcode eq AC-1");
            if (productCollection.TotalCount == 0)
            {
                productCollection = StorefrontProductFactory.GetProducts(handler: ShopperMsgHandler, startIndex: index,
                                                                         pageSize: 13, filter: null);
            }
            var product = productCollection.Items.First();

            var fulfillmentLocationTypeCodes = LocationTypeFactory.GetLocationTypes(handler: ShopperMsgHandler);
            var fulfillmentLocationTypeCode = fulfillmentLocationTypeCodes.First().Code;
            var DirectShipLocationCode = LocationFactory.GetDirectShipLocation(handler: ShopperMsgHandler).Code;
            var PickupLocationCodes = LocationFactory.GetInStorePickupLocations(handler: ShopperMsgHandler);
            var PickupLocationCode = PickupLocationCodes.Items.First().Code;

            const int itemQty = 3;
            var item = CartItemFactory.AddItemToCart(ShopperMsgHandler,
                                                     new CartItem()
                                                         {
                                                             Product = new Product
                                                                 {
                                                                     ProductCode = product.ProductCode
                                                                 },
                                                             Quantity = itemQty
                                                             ,
                                                             FulfillmentLocationCode = PickupLocationCode, // or "HomeBase",
                                                             FulfillmentMethod = "PickUp"
                                                         });
            item = CartItemFactory.AddItemToCart(ShopperMsgHandler,
                                      new CartItem()
                                      {
                                          Product = new Product
                                          {
                                              ProductCode = product.ProductCode
                                          },
                                          Quantity = itemQty
                                          ,
                                          FulfillmentLocationCode = DirectShipLocationCode, // or "HomeBase",
                                          FulfillmentMethod = "Ship"
                                      });

            var getUserCart = CartFactory.GetUserCart(handler: ShopperMsgHandler, userId: createdCart.UserId);

            var order = OrderFactory.CreateOrderFromCart(handler: ShopperMsgHandler, cartId: getUserCart.Id);
            var shippingContact = Generator.GenerateContactRealAddress(isValidated: true,
                                                                firstname:
                                                                     customerAccountAndAuthInfo
                                                                     .Account.FirstName,
                                                                 lastname:
                                                                     customerAccountAndAuthInfo
                                                                     .Account.LastName,
                                                                 email:
                                                                     customerAccountAndAuthInfo
                                                                     .Account.EmailAddress);


            var shippingAddressInfo = FulfillmentInfoFactory.SetFulFillmentInfo(handler: ShopperMsgHandler,
                                                                                orderId: order.Id,
                                                                                fulfillmentInfo: new FulfillmentInfo()
                                                                                    {

                                                                                        IsDestinationCommercial = false,
                                                                                        FulfillmentContact =
                                                                                            shippingContact,
                                                                                    });

            var billingContact = Generator.GenerateContactRealAddress();
            var discover = new AuthorizeDotNetCreditCard(Constant.DISCOVER);
            var card = Generator.GenerateDefaultCard(sendPart: discover.SendPart, 
                                                     paymentServiceCardId: Generator.RandomInt32().ToString(),     
                                                     type: Constant.DISCOVER);

            var billingAddress = BillingInfoFactory.SetBillingInfo(handler: ShopperMsgHandler, orderId: order.Id,
                                                                   billingInfo: new BillingInfo()
                                                                       {
                                                                           PaymentType = "CreditCard",
                                                                           BillingContact = billingContact,
                                                                           IsSameBillingShippingAddress = true,
                                                                           Card = card
                                                                       });

            System.Threading.Thread.Sleep(200);
            var availableShippingMethods = StorefrontShipmentFactory.GetAvailableShipmentMethods(handler: ShopperMsgHandler,
                                                                                       orderId: order.Id);
            var shipping = FulfillmentInfoFactory.SetFulFillmentInfo(handler: ShopperMsgHandler, orderId: order.Id,
                                                                     fulfillmentInfo: new FulfillmentInfo()
                                                                         {

                                                                             IsDestinationCommercial = false,
                                                                             FulfillmentContact = shippingContact,
                                                                             ShippingMethodCode =
                                                                                 availableShippingMethods.First()
                                                                                                         .ShippingMethodCode,
                                                                             ShippingMethodName =
                                                                                 availableShippingMethods.First()
                                                                                                         .ShippingMethodName
                                                                         });

            var getOrder = OrderFactory.GetOrder(handler: ShopperMsgHandler,
                                                 orderId: order.Id,
                                                 draft: false);

            var getOrderActions = OrderFactory.GetAvailableActions(handler: ShopperMsgHandler, orderId: getOrder.Id);
            Assert.AreEqual(getOrderActions.Count, 1);
            Assert.IsTrue(getOrderActions[0].Equals("SubmitOrder"));

            var status = OrderFactory.PerformOrderAction(handler: ShopperMsgHandler, orderId: getOrder.Id, action:
                                                                                                               new OrderAction
                                                                                                               ()
                                                                                                               {
                                                                                                                   ActionName
                                                                                                                       =
                                                                                                                       "SubmitOrder"
                                                                                                               });

            getOrder = OrderFactory.GetOrder(handler: ShopperMsgHandler,
                                             orderId: order.Id,
                                             draft: false);

            Assert.AreEqual(getOrder.Payments[0].AvailableActions.Count, 1);
            Assert.IsTrue(getOrder.Payments[0].AvailableActions[0].Contains("CreditPayment") || getOrder.Payments[0].AvailableActions[1].Contains("CreditPayment") || getOrder.Payments[0].AvailableActions[2].Contains("CreditPayment"));
            var creditPayment = PaymentFactory.PerformPaymentAction(handler: ShopperMsgHandler,
                                                                    orderId: getOrder.Id,
                                                                    paymentId: getOrder.Payments[0].Id,
                                                                    action: Generator.GeneratePaymentAction("CreditPayment",
                                                                      "", Convert.ToDecimal(getOrder.Total), getOrder.Payments[0].Id));

            Assert.AreEqual(creditPayment.Payments[0].AmountCredited, creditPayment.Total);

            //var createdCard = CardFactory.Create(ApiMsgHandler, card);

            var paymentAction = Generator.GeneratePaymentAction(action: "AuthorizePayment",
                amt: Convert.ToDecimal(order.Total),
                state: "TX",
                zip: "78717",
                card: card, 
                savePart: discover.SavePart, 
                manualInteraction: Generator.GeneratePaymentGatewayInteraction());

            var createdPaymentAction = PaymentFactory.CreatePaymentAction(handler: ShopperMsgHandler,
                                                                          orderId: order.Id,
                                                                          action: paymentAction,
                                                                          expectedCode: HttpStatusCode.OK,
                                                                          successCode: HttpStatusCode.OK);
            Assert.AreEqual(createdPaymentAction.Payments.Count, 2);
            Assert.AreEqual(createdPaymentAction.Payments[1].Status, "Authorized");
            Assert.AreEqual(createdPaymentAction.Payments[1].AmountCollected, 0);
            Assert.AreEqual(createdPaymentAction.Payments[1].Interactions.Count, 1);
            Assert.AreEqual(createdPaymentAction.Payments[1].Interactions[0].Status, "Authorized");
            Assert.IsTrue(createdPaymentAction.Payments[1].Interactions[0].IsManual);
            Assert.AreEqual(createdPaymentAction.PaymentStatus, "Pending");
            Assert.AreEqual(createdPaymentAction.Status, "Processing");
            paymentAction = Generator.GeneratePaymentAction(action: "CapturePayment", 
                amt: Convert.ToDecimal(order.Total), 
                state: "TX", 
                zip: "78717", 
                card: card, 
                savePart: discover.SavePart, 
                manualInteraction: Generator.GeneratePaymentGatewayInteraction());
            var capturePayment = PaymentFactory.PerformPaymentAction(handler: ShopperMsgHandler,
                orderId: getOrder.Id, paymentId: createdPaymentAction.Payments[1].Id, action: paymentAction);
            Assert.AreEqual(capturePayment.Payments[1].Status, "Collected");
            Assert.AreEqual(capturePayment.Payments[1].AmountCollected, capturePayment.Total);
            Assert.AreEqual(capturePayment.Payments[1].Interactions.Count, 2);
            Assert.AreEqual(capturePayment.Payments[1].Interactions[1].Status, "Captured");
            Assert.IsTrue(capturePayment.Payments[1].Interactions[1].IsManual);
            Assert.AreEqual(capturePayment.PaymentStatus, "Paid");
        }

        #region Code For Orders
        public string CreateOrdersForTest(bool submitOrder= false, bool fullfillOrder = false,
            bool returnOrder = false, bool anonymous = false, bool pickupMethod = true, bool directShipMethod = true)
        {
            var random = new Random();
            var productsUsed = new ArrayList();
                //var productToUse = productList[random.Next(productList.Length)];
                
            var customerAccountAndAuthInfo = Generator.GenerateCustomerAccountAndAuthInfo();
            var shopperUserAuthInfo = Generator.GenerateCustomerUserAuthInfo();
            var isCommercial = true;// Generator.RandomBool();
            var addressType = isCommercial ? "Commercial" : "Residential";

            if (anonymous)
            {
                var customer = Generator.GenerateCustomerAccountValidatedRandom();
                var customerAccount = CustomerAccountFactory.AddAccount(ApiMsgHandler, customer);
                Assert.AreEqual(customer.EmailAddress, customerAccount.EmailAddress);
                Assert.AreEqual(customer.ExternalId, customerAccount.ExternalId);
                Assert.AreEqual(customer.FirstName, customerAccount.FirstName);
                Assert.AreEqual(customer.LastName, customerAccount.LastName);
                Assert.AreEqual(customer.CompanyOrOrganization, customerAccount.CompanyOrOrganization);

                var customerContact = CustomerContactFactory.AddAccountContact(ApiMsgHandler, customer.Contacts[0], customerAccount.Id);

                Assert.AreEqual(customer.Contacts[0].Email, customerContact.Email);
                Assert.AreEqual(customer.Contacts[0].FirstName, customerContact.FirstName);
                Assert.AreEqual(customer.Contacts[0].LastNameOrSurname, customerContact.LastNameOrSurname);
                Assert.AreEqual(customer.Contacts[0].CompanyOrOrganization, customerContact.CompanyOrOrganization);
                Assert.AreEqual(customer.Contacts[0].Address.Address1, customerContact.Address.Address1);
                customerAccountAndAuthInfo = Generator.GenerateCustomerAccountAndAuthInfo(customer);
                customerAccountAndAuthInfo.Account.UserName = null;
                customerAccountAndAuthInfo.Password = null;
                shopperUserAuthInfo = Generator.GenerateCustomerUserAuthInfo();

            }
            else
            {
                customerAccountAndAuthInfo = Generator.GenerateCustomerAccountAndAuthInfo(taxExempt: true,
                    taxId: "98-02565-0000");
                var checkCustomerIdentDuplication = CustomerAccountFactory.GetAccounts(handler: ShopperMsgHandler,
                    startIndex: 100,
                    filter:
                        "firstname eq '" + customerAccountAndAuthInfo.Account.FirstName +
                        "' and lastname eq '" + customerAccountAndAuthInfo.Account.LastName + "'");

                if (checkCustomerIdentDuplication.TotalCount == 0)
                {
                    var createdCustomerAccount = CustomerAccountFactory.AddAccountAndLogin(handler: ShopperMsgHandler,
                        accountAndAuthInfo: customerAccountAndAuthInfo);
                    var updateCustomerAccount = CustomerContactFactory.AddAccountContact(handler: ShopperMsgHandler,
                        contact:
                            Generator.GenerateCustomerContactReal(
                                    accountId: createdCustomerAccount.CustomerAccount.Id,
                                    firstname: customerAccountAndAuthInfo.Account.FirstName,
                                    lastname:  customerAccountAndAuthInfo.Account.LastName,
                                    username:  customerAccountAndAuthInfo.Account.UserName,
                                    email: customerAccountAndAuthInfo.Account.EmailAddress,
                                    addressType: addressType),
                        accountId:
                            createdCustomerAccount.CustomerAccount.Id);
                }
                shopperUserAuthInfo = Generator.GenerateCustomerUserAuthInfo(userName: customerAccountAndAuthInfo.Account.UserName);


            }



            // User Auth Ticket is required for further work.
                var ShopperAuth = new Mozu.Api.Security.CustomerAuthenticationProfile();
                try
                {
                    ShopperAuth =
                        Mozu.Api.Security.CustomerAuthenticator.Authenticate(customerUserAuthInfo: shopperUserAuthInfo,
                            tenantId: TestBaseTenant.Id,
                            siteId: TestBaseTenant.Sites.FirstOrDefault().Id);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Shopper could not Authenticate.");
                    Assert.Fail("Shopper could not Authenticate.");
                }

                Assert.IsNotNull(ShopperAuth,"Shopper could not Authenticate");
                ShopperMsgHandler.ApiContext.UserAuthTicket = ShopperAuth.AuthTicket;
                var createdCart = CartFactory.GetOrCreateCart(ShopperMsgHandler);
                const int index = 0;

                ShopperMsgHandler.ApiContext.UserAuthTicket = null;
                var fulfillmentLocationTypeCodes = LocationTypeFactory.GetLocationTypes(handler: ShopperMsgHandler);
                var fulfillmentLocationTypeCode = fulfillmentLocationTypeCodes.First().Code;

                var AdminApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId,
                                                                          masterCatalogId:
                                                                              masterCatalogId,
                                                                          catalogId: catalogId,
                                                                          siteId:
                                                                              ShopperMsgHandler
                                                                              .ApiContext.SiteId);

                var productUsageCollection = ProductFactory.GetProducts(handler: AdminApiMsgHandler,
                                                                        startIndex: index, pageSize: 4000,
                                                                        filter: "productusage eq Standard");

                Assert.AreNotEqual(productUsageCollection.TotalCount, 0, "No products able to be used in this store.");

                var DirectShipLocationCode = "";
                var PickupLocationCode = "";
                var PickupLocationCodes = LocationFactory.GetInStorePickupLocations(handler: ShopperMsgHandler);
                DirectShipLocationCode = LocationFactory.GetDirectShipLocation(handler: ShopperMsgHandler).Code;
                long loopQty = 0;
                const int maxProductItems = 2; // max product items 5
                loopQty = productUsageCollection.TotalCount < maxProductItems ? productUsageCollection.TotalCount : maxProductItems;
                Debug.WriteLine("Loop for " + loopQty + " qty of products");

                for (var itemsLoop = 0; itemsLoop <= loopQty; itemsLoop++)
                {
                    var randomProductRank = productUsageCollection.TotalCount > productUsageCollection.PageSize
                                                ? productUsageCollection.PageSize
                                                : productUsageCollection.TotalCount;
                    var conv = Convert.ToInt32(randomProductRank);
                    var ran = random.Next(conv);
                    var productToUse = productUsageCollection.Items[ran].ProductCode;
                   
                    if (productsUsed.Count > 0)
                    {
                        while (productsUsed.Contains(productToUse))
                        {
                            productToUse = productUsageCollection.Items[random.Next(conv)].ProductCode;
                        }
                    }

                    productsUsed.Add(productToUse);
                    

                    // find product , if that product isn't there fail over to first product that is available.
                    var product = GetStoreFrontProduct(handler: ShopperMsgHandler, productCode: productToUse);

                    while (product == null || product.IsActive == false)
                    {
                        Debug.WriteLine("Product: " + productToUse + " is visable in ProductAdmin and not Storefront. Finding new product");
                        productToUse = productUsageCollection.Items[random.Next(conv)].ProductCode;
                        while (productsUsed.Contains(productToUse))
                        {
                            productToUse = productUsageCollection.Items[random.Next(conv)].ProductCode;
                        }
                        product = GetStoreFrontProduct(handler: ShopperMsgHandler, productCode: productToUse);
                        if (product != null)
                            productsUsed.Add(productToUse);
                        
                    }
                    Debug.WriteLine("Product Being used: " + product.ProductCode);

                    // check for IsActive or Usage Types.
                    Assert.AreNotEqual(product.IsActive, 0,
                                       "Product: " + productToUse + " is visable in ProductAdmin and not Storefront.");

                    Assert.AreEqual(product.ProductUsage, "Standard", "Product is not of Usage Type Standard.");

                    // change the random number of products per line item.
                    int itemQty = Generator.RandomInt(1, 3);  
                    Debug.WriteLine("Qty per product " + itemQty);

                    if (PickupLocationCodes.TotalCount != 0 && pickupMethod)
                    {
                        PickupLocationCode = PickupLocationCodes.Items.First().Code;
                        if (product.InventoryInfo.ManageStock.Value == true)
                        {
                            var currInventory = LocationInventoryFactory.GetLocationInventory(
                                handler: ShopperMsgHandler,
                                locationCode: PickupLocationCode,
                                productCode: product.ProductCode);

                            if (currInventory == null)
                            {
                                // add inventory.
                                Debug.WriteLine("Current Inventory Location/Qty key was null/empty " +
                                                PickupLocationCode + " " + product.ProductCode);
                                var inv = LocationInventoryFactory.AddLocationInventory(handler: ShopperMsgHandler,
                                    locationCode: PickupLocationCode,
                                    locationInventoryList:
                                        Generator.GenerateListOfLocationInventory(
                                            locationCode: PickupLocationCode,
                                            productCode: product.ProductCode,
                                            stockAvailable: (itemQty*2),
                                            stockOnHand: (itemQty*2)));
                                Thread.Sleep(3000);
                            }
                            else if (currInventory.StockAvailable == 0 || currInventory.StockAvailable <= itemQty)
                            {
                                Debug.WriteLine("Current Inventory Location/Qty key showed out of stock " +
                                                PickupLocationCode + " " + product.ProductCode + " stock available: " +
                                                currInventory.StockAvailable);
                                var inventory =
                                    LocationInventoryFactory.UpdateLocationInventory(handler: ShopperMsgHandler,
                                        locationInventoryAdjustments:
                                            Generator.GenerateListOfLocationInventoryAdjustments(
                                                locationCode: PickupLocationCode,
                                                productCode: product.ProductCode,
                                                valueChange: (itemQty*2),
                                                stockAdjustmentType: "Delta"),
                                        locationCode: PickupLocationCode);

                                Thread.Sleep(3000);
                            }
                        }
                        // first line item
                        ShopperMsgHandler.ApiContext.UserAuthTicket = ShopperAuth.AuthTicket;
                        var item = CartItemFactory.AddItemToCart(ShopperMsgHandler,
                                                                 new CartItem()
                                                                 {
                                                                     Product = new Product
                                                                     {
                                                                         ProductCode = product.ProductCode
                                                                     },
                                                                     Quantity = itemQty,
                                                                     FulfillmentLocationCode = PickupLocationCode,
                                                                     FulfillmentMethod = "PickUp"
                                                                 });
                        ShopperMsgHandler.ApiContext.UserAuthTicket = null;
                    }
                    ran = random.Next(conv);
                    var product2 = productUsageCollection.Items[ran];

                    if (DirectShipLocationCode != null 
                        && product2 != null 
                        && directShipMethod)
                    {
                        productToUse = product2.ProductCode;
                        productsUsed.Add(productToUse);
                        var productDirectShip = GetStoreFrontProduct(handler: ShopperMsgHandler, productCode: productToUse);
                        while (productDirectShip == null || productDirectShip.IsActive == false)
                        {
                            Debug.WriteLine("Product: " + productToUse + " is visable in ProductAdmin and not Storefront. Finding new product");
                            productToUse = productUsageCollection.Items[random.Next(conv)].ProductCode;
                            while (productsUsed.Contains(productToUse))
                            {
                                productToUse = productUsageCollection.Items[random.Next(conv)].ProductCode;
                            }
                            productDirectShip = GetStoreFrontProduct(handler: ShopperMsgHandler, productCode: productToUse);
                            if (productDirectShip !=null)
                                productsUsed.Add(productDirectShip.ProductCode);
                            
                        }
                        Debug.WriteLine("Product Being used: " + productDirectShip.ProductCode);

                        Assert.AreNotEqual(productDirectShip.IsActive, 0,
                                           "Product: " + productToUse + " is visable in ProductAdmin and not Storefront.");
                        if (productDirectShip.InventoryInfo.ManageStock.Value == true)
                        {
                            var currInventory = LocationInventoryFactory.GetLocationInventory(
                                handler: ShopperMsgHandler,
                                locationCode: DirectShipLocationCode,
                                productCode: productDirectShip.ProductCode);

                            // second line item
                            if (currInventory == null && productDirectShip.InventoryInfo.ManageStock.Value == true)
                            {
                                // add inventory.
                                Debug.WriteLine("Current Inventory Location/Qty key was null/empty " +
                                                DirectShipLocationCode + " " + productDirectShip.ProductCode);
                                var inv2 = LocationInventoryFactory.AddLocationInventory(handler: ShopperMsgHandler,
                                    locationCode: DirectShipLocationCode,
                                    locationInventoryList: Generator.GenerateListOfLocationInventory(
                                        locationCode: DirectShipLocationCode,
                                        productCode: productDirectShip.ProductCode,
                                        stockAvailable: (itemQty*2),
                                        stockOnHand: (itemQty*2)));
                                Thread.Sleep(3000);
                            }
                            else if (currInventory.StockAvailable == 0 || currInventory.StockAvailable <= itemQty)
                            {
                                Debug.WriteLine("Current Inventory Location/Qty key showed out of stock " +
                                                DirectShipLocationCode + " " + productDirectShip.ProductCode +
                                                " stock available: " + currInventory.StockAvailable);
                                var inventoryItem2 =
                                    LocationInventoryFactory.UpdateLocationInventory(handler: ShopperMsgHandler,
                                        locationInventoryAdjustments:
                                            Generator.GenerateListOfLocationInventoryAdjustments(
                                                locationCode: DirectShipLocationCode,
                                                productCode: productDirectShip.ProductCode,
                                                valueChange: (itemQty*2),
                                                stockAdjustmentType: "Delta"),
                                        locationCode: DirectShipLocationCode);
                                Thread.Sleep(3000);
                            }
                        }
                        ShopperMsgHandler.ApiContext.UserAuthTicket = ShopperAuth.AuthTicket;
                        var item = CartItemFactory.AddItemToCart(ShopperMsgHandler,
                                                                 new CartItem()
                                                                 {
                                                                     Product = new Product { ProductCode = productDirectShip.ProductCode },
                                                                     Quantity = itemQty,
                                                                     FulfillmentLocationCode = DirectShipLocationCode,
                                                                     FulfillmentMethod = "Ship"
                                                                 });
                        ShopperMsgHandler.ApiContext.UserAuthTicket = null;
                    }

                }

                ShopperMsgHandler.ApiContext.UserAuthTicket = null;
                var getUserCart = CartFactory.GetUserCart(handler: ShopperMsgHandler, userId: createdCart.UserId);
                var order = OrderFactory.CreateOrderFromCart(handler: ShopperMsgHandler, cartId: getUserCart.Id);

                order.IpAddress = Generator.RandomIPAddress();

                order = OrderFactory.UpdateOrder(handler: ShopperMsgHandler, order: order, orderId: order.Id);

                

                Debug.WriteLine("Order # made: " + order.OrderNumber);
                var shippingContact = Generator.GenerateContactRealAddress(isValidated: true,
                                                                           firstname:
                                                                               customerAccountAndAuthInfo
                                                                               .Account.FirstName,
                                                                           lastname:
                                                                               customerAccountAndAuthInfo
                                                                               .Account.LastName,
                                                                           email:
                                                                               customerAccountAndAuthInfo
                                                                               .Account.EmailAddress
                                                                           );



                var shippingAddressInfo = FulfillmentInfoFactory.SetFulFillmentInfo(handler: ShopperMsgHandler,
                                                                                    orderId: order.Id,
                                                                                    fulfillmentInfo:
                                                                                        new FulfillmentInfo()
                                                                                        { IsDestinationCommercial = isCommercial,
                                                                                          FulfillmentContact = shippingContact,
                                                                                        });

                var billingContact = Generator.GenerateContactRealAddress(isValidated: true,
                                                                          firstname:
                                                                              customerAccountAndAuthInfo
                                                                              .Account.FirstName,
                                                                          lastname:
                                                                              customerAccountAndAuthInfo
                                                                              .Account.LastName,
                                                                          email:
                                                                              customerAccountAndAuthInfo
                                                                              .Account.EmailAddress,
                                                                          addressType: addressType);

                var billingAddress = BillingInfoFactory.SetBillingInfo(handler: ShopperMsgHandler, orderId: order.Id,
                                                                       billingInfo: new BillingInfo()
                                                                       {
                                                                           PaymentType = "Check",
                                                                           BillingContact = billingContact,
                                                                           IsSameBillingShippingAddress = true,
                                                                       });

                System.Threading.Thread.Sleep(200);
                var availableShippingMethods = StorefrontShipmentFactory.GetAvailableShipmentMethods(handler: ShopperMsgHandler,
                                                                                           orderId: order.Id);
                var shipping = FulfillmentInfoFactory.SetFulFillmentInfo(handler: ShopperMsgHandler, orderId: order.Id,
                                                                         fulfillmentInfo: new FulfillmentInfo()
                                                                         {

                                                                             IsDestinationCommercial = isCommercial,
                                                                             FulfillmentContact = shippingContact,
                                                                             ShippingMethodCode =
                                                                                 availableShippingMethods.First()
                                                                                                         .ShippingMethodCode,
                                                                             ShippingMethodName =
                                                                                 availableShippingMethods.First()
                                                                                                         .ShippingMethodName
                                                                         });

                var paymentAction = Generator.GeneratePaymentAction(action: "CreatePayment",
                                                                    amt: Convert.ToDecimal(order.Total),
                                                                    billingInfo: billingAddress,
                                                                    checkNumber:
                                                                        Generator.RandomString(4,
                                                                                               Generator
                                                                                                   .RandomCharacterGroup
                                                                                                   .NumericOnly));

                var createdPaymentAction = PaymentFactory.CreatePaymentAction(handler: ShopperMsgHandler,
                                                                              orderId: order.Id,
                                                                              action: paymentAction,
                                                                              expectedCode: HttpStatusCode.OK,
                                                                              successCode: HttpStatusCode.OK);

                var getOrder = OrderFactory.GetOrder(handler: ShopperMsgHandler,
                                                     orderId: order.Id,
                                                     draft: false);

                var getOrderActions = OrderFactory.GetAvailableActions(handler: ShopperMsgHandler, orderId: getOrder.Id);
                Assert.AreEqual(getOrderActions.Count, 1);
                Assert.IsTrue(getOrderActions[0].Equals("SubmitOrder"));

                if (submitOrder)
                {
                    ShopperMsgHandler.ApiContext.UserAuthTicket = ShopperAuth.AuthTicket;

                    var status = OrderFactory.PerformOrderAction(handler: ShopperMsgHandler, orderId: getOrder.Id, 
                                                                action: new OrderAction(){ ActionName = "SubmitOrder" });
                    ShopperMsgHandler.ApiContext.UserAuthTicket = null;

                    getOrder = OrderFactory.GetOrder(handler: ShopperMsgHandler,
                                                 orderId: order.Id,
                                                 draft: false);

                    Assert.AreEqual(getOrder.Status, "Accepted");
                    Assert.AreEqual(getOrder.PaymentStatus, "Pending");
                    Assert.AreEqual(getOrder.FulfillmentStatus, "NotFulfilled");
                    Assert.AreEqual(getOrder.ReturnStatus, "None");
                    Assert.AreEqual(getOrder.SubmittedDate.Value.Date, DateTime.UtcNow.Date);
                    Assert.AreEqual(getOrder.TotalCollected, 0);
                    Assert.AreEqual(getOrder.Payments.Count, 1);
                    Assert.AreEqual(getOrder.Payments[0].PaymentType, "Check");
                    Assert.AreEqual(getOrder.Payments[0].Status, "Pending");
                    Assert.AreEqual(getOrder.Payments[0].Interactions.Count, 1);
                    Assert.AreEqual(getOrder.Payments[0].Interactions[0].InteractionType, "RequestCheck");
                    Assert.IsTrue(getOrder.Payments[0].Interactions[0].Status.Equals("CheckRequested"));

                    var getPaymentActions = PaymentFactory.GetAvailablePaymentActions(ApiMsgHandler, order.Id,
                                                                                  getOrder.Payments[0].Id);
                    Assert.AreEqual(getPaymentActions.Count, 3);
                    Assert.IsTrue(getPaymentActions[0].Equals("CapturePayment") ||
                              getPaymentActions[0].Equals("VoidPayment") ||
                              getPaymentActions[0].Equals("DeclinePayment"));
                    Assert.IsTrue(getPaymentActions[1].Equals("CapturePayment") ||
                              getPaymentActions[1].Equals("VoidPayment") ||
                              getPaymentActions[1].Equals("DeclinePayment"));
                    Assert.IsTrue(getPaymentActions[2].Equals("CapturePayment") ||
                              getPaymentActions[2].Equals("VoidPayment") ||
                              getPaymentActions[2].Equals("DeclinePayment"));
                    var newPaymentAction = new PaymentAction()
                    {
                        ActionName = "CapturePayment",
                        CheckNumber = Generator.RandomString(4, Generator.RandomCharacterGroup.NumericOnly),
                        Amount = Convert.ToDecimal(getOrder.Total)
                    };
                    var orderPayment1 = PaymentFactory.PerformPaymentAction(handler: ApiMsgHandler, orderId: order.Id,
                                                                        paymentId: getOrder.Payments[0].Id,
                                                                        action: newPaymentAction);
                    Assert.AreEqual(orderPayment1.PaymentStatus, "Paid");
                    Assert.AreEqual(orderPayment1.Payments[0].Status, "Collected");
                    Assert.AreEqual(orderPayment1.Payments[0].AmountCollected, getOrder.Total);
                    Assert.AreEqual(orderPayment1.Payments[0].Interactions.Count, 2);
                    Assert.IsTrue(orderPayment1.Payments[0].Interactions[1].Status.Equals("Captured"));
                    Assert.IsTrue(orderPayment1.Payments[0].Interactions[1].InteractionType.Equals("Capture"));
                    Assert.IsTrue(orderPayment1.Payments[0].Interactions[1].CheckNumber.Equals(newPaymentAction.CheckNumber));
                    Assert.AreEqual(orderPayment1.Payments[0].Interactions[1].Amount, getOrder.Total);

                    if (fullfillOrder)
                    {
                        if (PickupLocationCode.Length != 0 && pickupMethod)
                        {
                            var unFulfilledPickupOrders = OrderFactory.GetOrders(handler: AdminApiMsgHandler, startIndex: 0,
                                                                             pageSize: 400,
                                                                             filter:
                                                                                 "(status eq 'accepted' or status eq 'processing') and (items.fulfillmentmethodandlocationcode eq 'Pickup," +
                                                                                 PickupLocationCode +
                                                                                 "' )");

                            Assert.IsNotNull(unFulfilledPickupOrders.Items.Find(x => x.OrderNumber.Equals(getOrder.OrderNumber)));
                            var unFulfilledPickupOrder = unFulfilledPickupOrders.Items.Find(x => x.OrderNumber.Equals(getOrder.OrderNumber));

                            var pickupLines = unFulfilledPickupOrder.Items.FindAll(x => x.FulfillmentMethod.Equals("Pickup") && x.FulfillmentLocationCode.Equals(PickupLocationCode));

                            var pickupItemList = Generator.GeneratePickupItemList();
                            pickupItemList.AddRange(pickupLines.Select(item => Generator.GeneratePickupItem(productCode: item.Product.ProductCode, quantity: item.Quantity)));

                            var pickup = Generator.GeneratePickup(pickupItemList, PickupLocationCode);

                            var createdPickup = PickupFactory.CreatePickup(handler: AdminApiMsgHandler,
                                                                       pickup: pickup,
                                                                       orderId: unFulfilledPickupOrder.Id);
                            // perform pickup
                            var performFulfillmentAction =
                            FulfillmentActionFactory.PerformFulfillmentAction(handler: AdminApiMsgHandler,
                                                                              orderId: order.Id,
                                                                              action:
                                                                                  Generator.GenerateFulfillmentAction(
                                                                                      "Pickup",
                                                                                      null,
                                                                                      new List<string>
                                                                                          {
                                                                                              createdPickup.Id
                                                                                          }));

                            Assert.AreEqual(performFulfillmentAction.FulfillmentStatus, "PartiallyFulfilled");
                        }
                        if (directShipMethod)
                        { 
                            var unFulfilledShipOrders = OrderFactory.GetOrders(handler: AdminApiMsgHandler, startIndex: 0,
                                                                           pageSize: 400,
                                                                                 filter:
                                                                                     "(status eq 'accepted' or status eq 'processing') and (items.fulfillmentmethodandlocationcode eq 'Ship," +
                                                                                     DirectShipLocationCode +
                                                                                     "' )");

                            Assert.IsNotNull(unFulfilledShipOrders.Items.Find(x => x.OrderNumber.Equals(getOrder.OrderNumber)));
                            var unFulfilledShipOrder = unFulfilledShipOrders.Items.Find(x => x.OrderNumber.Equals(getOrder.OrderNumber));

                            var shipmentLines = unFulfilledShipOrder.Items.FindAll(x => x.FulfillmentMethod.Equals("Ship") && x.FulfillmentLocationCode.Equals(DirectShipLocationCode));

                            var pkgShippingItems = Generator.GeneratePackageItemList();
                            pkgShippingItems.AddRange(shipmentLines.Select(item => Generator.GeneratePackageItem(productCode: item.Product.ProductCode, quantity: item.Quantity)));

                            // perform ship
                            availableShippingMethods = StorefrontShipmentFactory.GetAvailableShipmentMethods(handler: AdminApiMsgHandler,
                                                                                               orderId: order.Id);

                            var pkg = Generator.GeneratePackage(
                                shippingMethodCode: availableShippingMethods.First().ShippingMethodCode,
                                shippingMethodName: availableShippingMethods.First().ShippingMethodName,
                                items: pkgShippingItems);


                            var createdPkg = StorefrontPackageFactory.CreatePackage(handler: AdminApiMsgHandler, orderId: order.Id,
                                                                      pkg: pkg);

                            var pkgIds = new List<string>() { createdPkg.Id };

                            var createPkgShipment = StorefrontShipmentFactory.CreatePackageShipments(handler: AdminApiMsgHandler,
                                                                                       orderId: order.Id, packageIds: pkgIds);
                            //   var getLabel = PackageFactory.GetPackageLabel(handler: AdminApiMsgHandler, orderId: order.Id,
                            //                                                 packageId: createdPkg.Id);
                            //Assert.IsNotNull(getLabel);

                            var orderShipment = FulfillmentActionFactory.PerformFulfillmentAction(handler: AdminApiMsgHandler,
                                                                                              orderId: order.Id,
                                                                                              action: Generator.GenerateFulfillmentAction("Ship", pkgIds));
                            Assert.AreEqual(orderShipment.FulfillmentStatus, "Fulfilled");
                        }
                        

                        if (returnOrder)
                        {
                            var reasons = new Dictionary<string, int>();
                            var returnItems = new List<ReturnItem>();
                            reasons.Add("Damaged", 1);
                            returnItems.Add(Generator.GenerateReturnItem(order.Items[0].Id, reasons));

                            var createdReturn = ReturnFactory.CreateReturn(handler: AdminApiMsgHandler,
                                                                       ret: Generator.GenerateReturn(Generator.ReturnType.Refund, returnItems, order.Id));
                            var returnIds = new List<string> { createdReturn.Id };
                            var authReturn = ReturnFactory.PerformReturnActions(handler: AdminApiMsgHandler, 
                                                                        action: Generator.GenerateReturnAction("Authorize", returnIds));
                            getOrder = OrderFactory.GetOrder(handler: ShopperMsgHandler,
                                                         orderId: order.Id,
                                                         draft: false);

                            var createdReturnPaymentAction = ReturnFactory.CreatePaymentActionForReturn(
                                handler: AdminApiMsgHandler, returnId: createdReturn.Id,
                                action: Generator.GeneratePaymentAction(action: "CreditPayment", checkNumber: "", amt: 5,
                                                                    paymentSourceId: getOrder.Payments[0].Id),
                            expectedCode: HttpStatusCode.OK, successCode: HttpStatusCode.OK);

                            var refundReturn = ReturnFactory.PerformReturnActions(handler: AdminApiMsgHandler,
                                                                              action: Generator.GenerateReturnAction("Refund", returnIds));
                            Assert.AreEqual(refundReturn.Items[0].Status, "Refunded");
                            var returnActions = ReturnFactory.GetAvailableReturnActions(handler: AdminApiMsgHandler,
                                                                                    returnId: createdReturn.Id);
                            Assert.AreEqual(returnActions.Count, 1);
                            Assert.IsTrue(returnActions[0].Contains("Close"));
                            refundReturn.Items[0].Items[0].QuantityReceived = 1;

                            var updatedReturn = ReturnFactory.UpdateReturn(handler: AdminApiMsgHandler,
                                                                       returnId: refundReturn.Items[0].Id,
                                                                       ret: refundReturn.Items[0]);
                            returnActions = ReturnFactory.GetAvailableReturnActions(handler: AdminApiMsgHandler,
                                                                                returnId: createdReturn.Id);
                            Assert.AreEqual(returnActions.Count, 1);
                            Assert.IsTrue(returnActions[0].Contains("Close"));
                            var closeReturn = ReturnFactory.PerformReturnActions(handler: AdminApiMsgHandler,
                                                                             action: Generator.GenerateReturnAction("Close", returnIds));
                            Assert.AreEqual(closeReturn.Items[0].Status, "Closed");
                        }
                    }
                }
            return getOrder.Id;
        }

        public Mozu.Api.Contracts.ProductRuntime.Product GetStoreFrontProduct(ServiceClientMessageHandler handler, string productCode)
        {
            try
            {
                var product = StorefrontProductFactory.GetProduct(handler: handler, productCode: productCode);
                if (product == null)
                    return null;
                return product.IsActive == false ? null : product;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error getting Product: " + ex.Message);
                return null;
            }
        }
        #endregion
    }
}
