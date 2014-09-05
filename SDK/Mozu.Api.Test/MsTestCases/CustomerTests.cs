using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Contracts.Customer;
using Mozu.Api.Test.Helpers;
using Mozu.Api.Test.Factories;
using System.Net;
using System.Diagnostics;


namespace Mozu.Api.Test.MsTestCases
{
    [TestClass]
    public class CustomerTests : MozuApiTestBase
    {

        #region NonTestCaseCode

        public CustomerTests()
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
            ApiMsgHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId, masterCatalogId: masterCatalogId, catalogId: catalogId, siteId: TestBaseTenant.Sites.First().Id);
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
        #region AddAccount

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account Basic Test")]
        public void CustomerAccountAddAccountAndLogin_Validated()
        {
            //CreateAccounts
            for (int i = 0; i < 500; i++)
            {
                Debug.WriteLine("Starting Run # " + (i + 1).ToString() + " of 200");
                var cust = Generator.GenerateCustomerAccountValidatedRandom();
                var custAuth = Generator.GenerateCustomerAccountAndAuthInfo(cust);
                var customerAccount = CustomerAccountFactory.AddAccountAndLogin(ApiMsgHandler, custAuth);
                Assert.AreEqual(cust.EmailAddress, customerAccount.CustomerAccount.EmailAddress);
                Assert.AreEqual(cust.ExternalId, customerAccount.CustomerAccount.ExternalId);
                Assert.AreEqual(cust.FirstName, customerAccount.CustomerAccount.FirstName);
                Assert.AreEqual(cust.LastName, customerAccount.CustomerAccount.LastName);
                Assert.AreEqual(cust.CompanyOrOrganization, customerAccount.CustomerAccount.CompanyOrOrganization);

            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Anonymous Account Basic Test")]
        public void CustomerAnonymousAccount_Validated()
        {
            //CreateAccounts
            for (var i = 0; i < 500; i++)
            {
                var cust = Generator.GenerateCustomerAccountValidatedRandom();
                CustomerAccount customerAccount = null;
                try
                {
                    customerAccount = CustomerAccountFactory.AddAccount(ApiMsgHandler, cust);
                }
                catch 
                {
                    customerAccount = CustomerAccountFactory.GetAccounts(ApiMsgHandler,
                        filter: "firstname eq " + cust.FirstName + " and lastname eq " + cust.LastName).Items.First();
                }
                Assert.AreEqual(cust.EmailAddress, customerAccount.EmailAddress);
                Assert.AreEqual(cust.ExternalId, customerAccount.ExternalId);
                Assert.AreEqual(cust.FirstName, customerAccount.FirstName);
                Assert.AreEqual(cust.LastName, customerAccount.LastName);
                Assert.AreEqual(cust.CompanyOrOrganization, customerAccount.CompanyOrOrganization);

                var customerContact = CustomerContactFactory.AddAccountContact(ApiMsgHandler, cust.Contacts[0], customerAccount.Id);

                Assert.AreEqual(cust.Contacts[0].Email, customerContact.Email);
                Assert.AreEqual(cust.Contacts[0].FirstName, customerContact.FirstName);
                Assert.AreEqual(cust.Contacts[0].LastNameOrSurname, customerContact.LastNameOrSurname);
                Assert.AreEqual(cust.Contacts[0].CompanyOrOrganization, customerContact.CompanyOrOrganization);
                Assert.AreEqual(cust.Contacts[0].Address.Address1, customerContact.Address.Address1);
               
                
            }


        }


        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account and Login")]
        public void CustomerAccountAddLogin()
        {
            //CreateAccounts
            var cust = Generator.GenerateCustomerAccountRandom();
            var custAccount = CustomerAccountFactory.AddAccount(ApiMsgHandler, cust);
            var loginInfo = Generator.GenerateCustomerLoginInfo(custAccount.EmailAddress,
                                                                            custAccount.UserName);


            var customerAccount = CustomerAccountFactory.AddLoginToExistingCustomer(ApiMsgHandler, loginInfo, custAccount.Id, expectedCode: HttpStatusCode.BadRequest);
            var username = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaOnly);
            loginInfo.Username = username;

            customerAccount = CustomerAccountFactory.AddLoginToExistingCustomer(ApiMsgHandler, loginInfo, custAccount.Id);
            Assert.AreEqual(cust.EmailAddress, customerAccount.CustomerAccount.EmailAddress);
            Assert.AreEqual(username, customerAccount.CustomerAccount.UserName);
            Assert.AreEqual(cust.FirstName, customerAccount.CustomerAccount.FirstName);
            Assert.AreEqual(cust.LastName, customerAccount.CustomerAccount.LastName);
            Assert.AreEqual(cust.CompanyOrOrganization, customerAccount.CustomerAccount.CompanyOrOrganization);

        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account add fax number")]
        public void CustomerAddAccount_Fax()
        {

            //CreateAccounts
            var custAccount = Generator.GenerateCustomerAccountRandom();
            var customerAccount = CustomerAccountFactory.AddAccount(ApiMsgHandler, custAccount);
            var cont = Generator.GenerateCustomerContact(customerAccount.Id);
            var contact = CustomerContactFactory.AddAccountContact(ApiMsgHandler, cont, customerAccount.Id);
            Assert.AreEqual(cont.FaxNumber, contact.FaxNumber);
            var getContact = CustomerContactFactory.GetAccountContact(ApiMsgHandler, customerAccount.Id, contact.Id);
            Assert.AreEqual(contact.FaxNumber, getContact.FaxNumber);
            var faxNum = string.Format("{0}-{1}-{2}",
                                       Generator.RandomString(3, Generator.RandomCharacterGroup.NumericOnly),
                                       Generator.RandomString(3, Generator.RandomCharacterGroup.NumericOnly),
                                       Generator.RandomString(4, Generator.RandomCharacterGroup.NumericOnly));
            getContact.FaxNumber = faxNum;
            var update = CustomerContactFactory.UpdateAccountContact(ApiMsgHandler, getContact, customerAccount.Id,
                                                                     contact.Id);
            Assert.AreEqual(faxNum, update.FaxNumber);
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Add Customer as Imported")]
        public void CustomerAddAccount_IsImport()
        {

            //CreateAccounts
            var custAccount = Generator.GenerateCustomerAccountRandom();
            var authInfo = Generator.GenerateCustomerAccountAndAuthInfo(custAccount, isImport: true);
            var customerAccount = CustomerAccountFactory.AddAccountAndLogin(ApiMsgHandler, authInfo);           

        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer ExternalId")]
        public void CustomerAddAccount_ExternalId()
        {

            //CreateAccounts
            var custAccount = Generator.GenerateCustomerAccountRandom();
            var customerAccount = CustomerAccountFactory.AddAccount(ApiMsgHandler, custAccount);
            Assert.AreEqual(custAccount.ExternalId, customerAccount.ExternalId);
            //GetAccount
            var getAccount = CustomerAccountFactory.GetAccount(ApiMsgHandler, customerAccount.Id);
            Assert.AreEqual(custAccount.ExternalId, getAccount.ExternalId);
            getAccount.ExternalId = "U2P454lei33dl";
            var update = CustomerAccountFactory.UpdateAccount(ApiMsgHandler, getAccount, getAccount.Id);
            //GetAccount
            var result = CustomerAccountFactory.GetAccount(ApiMsgHandler, customerAccount.Id);
            Assert.AreEqual("U2P454lei33dl".ToUpper(), result.ExternalId.ToUpper());
        }

        #endregion

        #region GetAccounts

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account filterby contacts.firstname eq")]
        public void CustomerAccountFilterbyContactsfirstname_eq()
        {   
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 5, 12);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var contacts = CustomerContactFactory.GetAccountContacts(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(12, contacts.TotalCount);
                for (int x = 0; x < contacts.TotalCount; x++)
                {
                    var filterBy = "contacts.firstname eq " + contacts.Items[x].FirstName;
                    var result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 0, 3, null, filterBy);                  
                    Assert.AreEqual(1, result.TotalCount);
                }
            }                       
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account filterby contacts.firstname sw")]
        public void CustomerAccountFilterbyContactsfirstname_sw()
        {        
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 10, 3);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var contacts = CustomerContactFactory.GetAccountContacts(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(3, contacts.TotalCount);
                for (int x = 0; x < contacts.TotalCount; x++)
                {
                    var filterBy = "contacts.firstname sw " + contacts.Items[x].FirstName;
                    var result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 0, 3, null, filterBy);
                    Assert.AreEqual(1, result.TotalCount);
                }
            }     
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Update Customer Account Contact")]
        public void CustomerAccountUpdateContact()
        {
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 2, 6);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var contacts = CustomerContactFactory.GetAccountContacts(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(6, contacts.TotalCount);
                for (int x = 0; x < contacts.TotalCount; x++)
                {
                    var contact = CustomerContactFactory.GetAccountContact(ApiMsgHandler, customerAccounts[i].Id, contacts.Items[x].Id);
                    contact.FirstName = "newName";
                    contact.LastNameOrSurname = "latestName";
                    contact.Email = "myUpdated32Email.com";
                    CustomerContactFactory.UpdateAccountContact(ApiMsgHandler, contact, customerAccounts[i].Id,
                                                                contact.Id);
                    var result = CustomerContactFactory.GetAccountContact(ApiMsgHandler, customerAccounts[i].Id, contacts.Items[x].Id);
                    Assert.AreEqual("newName".ToLower(), result.FirstName.ToLower());
                    Assert.AreEqual("latestName".ToLower(), result.LastNameOrSurname.ToLower());
                    Assert.AreEqual("myUpdated32Email.com".ToLower(), result.Email.ToLower());
                }
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account filterby contacts.firstname cont")]
        public void CustomerAccountFilterbyContactsfirstname_cont()
        {
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 10, 3);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var contacts = CustomerContactFactory.GetAccountContacts(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(3, contacts.TotalCount);
                for (int x = 0; x < contacts.TotalCount; x++)
                {
                    var filterBy = "contacts.firstname cont " + contacts.Items[x].FirstName.Substring(1, 4);
                    var result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 0, 3, null, filterBy);
                    Assert.AreEqual(1, result.TotalCount);
                }
            }     
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account filterby contacts.lasttnameorsurname cont")]
        public void CustomerAccountFilterbyContactsLasttnameorsurname_cont()
        {           
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 2, 13);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var contacts = CustomerContactFactory.GetAccountContacts(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(13, contacts.TotalCount);
                for (int x = 0; x < contacts.TotalCount; x++)
                {
                    var filterBy = "contacts.lastnameorsurname cont " + contacts.Items[x].LastNameOrSurname.Substring(2, 7);
                    var result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 0, 3, null, filterBy);
                    Assert.AreEqual(1, result.TotalCount);
                }
            }     
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account filterby contacts.lasttnameorsurname sw")]
        public void CustomerAccountFilterbyContactsLasttnameorsurname_sw()
        {
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 3, 15);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var contacts = CustomerContactFactory.GetAccountContacts(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(15, contacts.TotalCount);
                for (int x = 0; x < contacts.TotalCount; x++)
                {
                    var filterBy = "contacts.lastnameorsurname sw " + contacts.Items[x].LastNameOrSurname.Substring(0, 3);
                    var result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 0, 3, null, filterBy);
                    Assert.AreEqual(1, result.TotalCount);
                }
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account filterby contacts.lasttnameorsurname eq")]
        public void CustomerAccountFilterbyContactsLasttnameorsurname_eq()
        {
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 4, 8);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var contacts = CustomerContactFactory.GetAccountContacts(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(8, contacts.TotalCount);
                for (int x = 0; x < contacts.TotalCount; x++)
                {
                    var filterBy = "contacts.lastnameorsurname eq " + contacts.Items[x].LastNameOrSurname;
                    var result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 0, 3, null, filterBy);
                    Assert.AreEqual(1, result.TotalCount);
                }
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account filterby contacts.email eq")]
        public void CustomerAccountFilterbyContactsEmail_eq()
        {           
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 6, 10);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var contacts = CustomerContactFactory.GetAccountContacts(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(10, contacts.TotalCount);
                for (int x = 0; x < contacts.TotalCount; x++)
                {
                    var filterBy = "contacts.email eq " + contacts.Items[x].Email;
                    var result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 0, 3, null, filterBy);
                    Assert.AreEqual(1, result.TotalCount);
                }
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account filterby contacts.email sw")]
        public void CustomerAccountFilterbyContactsEmail_sw()
        {
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 5, 5);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var contacts = CustomerContactFactory.GetAccountContacts(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(5, contacts.TotalCount);
                for (int x = 0; x < contacts.TotalCount; x++)
                {
                    var filterBy = "contacts.email sw " + contacts.Items[x].Email.Substring(0, 6);
                    var result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 0, 3, null, filterBy);
                    Assert.AreEqual(1, result.TotalCount);
                }
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account filterby contacts.email cont")]
        public void CustomerAccountFilterbyContactsEmail_cont()
        {
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 5, 5);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var contacts = CustomerContactFactory.GetAccountContacts(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(5, contacts.TotalCount);
                for (int x = 0; x < contacts.TotalCount; x++)
                {
                    var split1 = contacts.Items[x].Email.Split('.');
                    var split2 = split1[0].Split('@');
                    var filterBy = "contacts.email cont " + split2[0].Substring(1, 4);
                    var result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 0, 3, null, filterBy);
                    Assert.AreEqual(1, result.TotalCount);

                    filterBy = "contacts.email cont " + split2[1].Substring(2, 5);
                    result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 0, 3, null, filterBy);
                    Assert.AreEqual(1, result.TotalCount);

                }
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Accounts GetAccounts complex filter")]
        public void CustomerAccountsGetAccountsComplexFilter()
        {           
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 25, 1);
                var filterBy = "acceptsmarketing eq false";
                var sortBy = "createdate asc";
                var result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 0, 25, sortBy, filterBy);
                Assert.AreEqual(0, result.StartIndex);
                Assert.AreEqual(25, result.PageSize);
                Assert.AreEqual(1, result.PageCount);
                Assert.AreEqual(25, result.TotalCount);

                filterBy = "commercesummary.wishlistcount eq 0";
                sortBy = "commercesummary.totalorderamount desc";
                result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 5, 10, sortBy, filterBy);
                Assert.AreEqual(5, result.StartIndex);
                Assert.AreEqual(10, result.PageSize);
                Assert.AreEqual(3, result.PageCount);
                Assert.AreEqual(25, result.TotalCount);

                filterBy = "commercesummary.totalorderamount eq 0";
                sortBy = "commercesummary.wishlistcount asc";
                result = CustomerAccountFactory.GetAccounts(ApiMsgHandler, 12, null, sortBy, filterBy);
                Assert.AreEqual(12, result.StartIndex);
                Assert.AreEqual(20, result.PageSize);
                Assert.AreEqual(2, result.PageCount);
                Assert.AreEqual(25, result.TotalCount);
        }


        #endregion

        #region GetAccount

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account GetAccount by id")]
        public void CustomerAccountGetAccount_byId()
        {
            
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 15, 2);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                //GetAccount
                var result = CustomerAccountFactory.GetAccount(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(customerAccounts[i].Id, result.Id);
                Assert.AreEqual(2, result.Contacts.Count);

            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Account GetAccount invalid id")]
        public void CustomerAccountGetAccount_InvalidId()
        {
            //GetAccount
            var result = CustomerAccountFactory.GetAccount(ApiMsgHandler, 349, expectedCode: HttpStatusCode.NotFound);
            Assert.IsNull(result);
        }
        #endregion

        #region UpdateAccount

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("CustomerUpdateAccount")]
        public void CustomerUpdateAccount_company()
        {            
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 15, 2);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var company = Generator.RandomString(25, Generator.RandomCharacterGroup.AlphaNumericOnly);
                customerAccounts[i].CompanyOrOrganization = company;
                var result = CustomerAccountFactory.UpdateAccount(ApiMsgHandler, customerAccounts[i], customerAccounts[i].Id);
                Assert.AreEqual(company, result.CompanyOrOrganization);
                //GetAccount
                var result1 = CustomerAccountFactory.GetAccount(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(company, result1.CompanyOrOrganization);
                Assert.AreEqual(2, result1.Contacts.Count);
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Update Customer Account First Name")]
        public void CustomerUpdateAccount_firstName()
        {
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 15, 2);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var firstName = Generator.RandomString(25, Generator.RandomCharacterGroup.AlphaNumericOnly);
                customerAccounts[i].FirstName = firstName;
                var result = CustomerAccountFactory.UpdateAccount(ApiMsgHandler, customerAccounts[i], customerAccounts[i].Id);
                Assert.AreEqual(firstName, result.FirstName);
                //GetAccount
                var result1 = CustomerAccountFactory.GetAccount(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(firstName, result1.FirstName);
                Assert.AreEqual(2, result1.Contacts.Count);
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Update Customer Account Tax Exempt")]
        public void CustomerUpdateAccount_TaxExempt()
        {
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 13, 3);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                customerAccounts[i].TaxExempt = true;
                var result = CustomerAccountFactory.UpdateAccount(ApiMsgHandler, customerAccounts[i], customerAccounts[i].Id);
                Assert.AreEqual(true, result.TaxExempt);
                //GetAccount
                var result1 = CustomerAccountFactory.GetAccount(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(true, result1.TaxExempt);
                Assert.AreEqual(3, result1.Contacts.Count);
            }
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Update Customer Account TaxId")]
        public void CustomerUpdateAccount_TaxId()
         {
            //CreateAccounts
             var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 8, 0);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var taxId = Generator.RandomString(5, Generator.RandomCharacterGroup.AnyCharacter);
                customerAccounts[i].TaxExempt = true;
                customerAccounts[i].TaxId = taxId;
                var result = CustomerAccountFactory.UpdateAccount(ApiMsgHandler, customerAccounts[i], customerAccounts[i].Id);
                Assert.AreEqual(taxId, result.TaxId);
                //GetAccount
                var result1 = CustomerAccountFactory.GetAccount(ApiMsgHandler, customerAccounts[i].Id);
                Assert.AreEqual(taxId, result1.TaxId);
                Assert.AreEqual(0, result1.Contacts.Count);
            }
        }


        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Update Customer Account TaxId")]
        public void CustomerUpdateAccount_Marketing()
        {
            //CreateAccounts
            var accounts = GetAllAccounts();


            foreach (var customerAccount in accounts)
            {
                customerAccount.AcceptsMarketing = false;
                var result = CustomerAccountFactory.UpdateAccount(ApiMsgHandler, customerAccount, customerAccount.Id);
                //GetAccount
                var result1 = CustomerAccountFactory.GetAccount(ApiMsgHandler, customerAccount.Id);
                Assert.IsFalse(result1.AcceptsMarketing);
            }
        }


        #endregion


        #region DeleteAccount
        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Delete Customer Account success")]
        public void CustomerDeleteAccount_success()
        {
            var account = Generator.GenerateCustomerAccountRandom();
            var customerAccount= CustomerAccountFactory.AddAccount(ApiMsgHandler, account);
            //DeleteAccount
            CustomerAccountFactory.DeleteAccount(ApiMsgHandler, customerAccount.Id);
            //GetAccount
            var result1 = CustomerAccountFactory.GetAccount(ApiMsgHandler, customerAccount.Id, expectedCode: HttpStatusCode.NotFound);
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Delete Customer Account fail")]
        public void CustomerDeleteAccount_notfound()
        {          
            //DeleteAccount
            CustomerAccountFactory.DeleteAccount(ApiMsgHandler, 25, expectedCode: HttpStatusCode.NotFound);
            var result = CustomerAccountFactory.GetAccount(ApiMsgHandler, 25, expectedCode: HttpStatusCode.NotFound);

        }


        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Delete Customer Account fail")]
        public void CustomerDeleteAllAccounts_success()
        {
            //DeleteAccount


            var startIndex = 0;
            var contactCount = 0;

            while (true)
            {
                CustomerAccountCollection accountCollection = CustomerAccountFactory.GetAccounts(ApiMsgHandler, startIndex, pageSize: 200);
                if (accountCollection.Items.Count == 0) break;
                foreach (var customerAccount in accountCollection.Items)
                {
                    CustomerAccountFactory.DeleteAccount(ApiMsgHandler, customerAccount.Id, expectedCode: HttpStatusCode.NoContent);
                }
            }



        }

        #endregion

        #region AccountNotes

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Update Customer Account Note")]
        public void CustomerUpdateAccountNote()
        {
            //CreateAccounts
            var customerAccounts = Generator.AddAccountsRandom(ApiMsgHandler, 8, 0);
            for (int i = 0; i < customerAccounts.Count; i++)
            {
                var note = Generator.GenerateCustomerNote();
                var custNote = CustomerNoteFactory.AddAccountNote(ApiMsgHandler, note, customerAccounts[i].Id);
                //GetNote
                var result = CustomerNoteFactory.GetAccountNote(ApiMsgHandler, customerAccounts[i].Id, custNote.Id);
                Assert.AreEqual(note.Content, result.Content);
                //UpdateNote
                note.Content = Generator.RandomString(15, Generator.RandomCharacterGroup.AlphaNumericOnly);
                var updateNote = CustomerNoteFactory.UpdateAccountNote(ApiMsgHandler, note, customerAccounts[i].Id, custNote.Id);
                Assert.AreEqual(note.Content, updateNote.Content);
                //GetNote
                var result1 = CustomerNoteFactory.GetAccountNote(ApiMsgHandler, customerAccounts[i].Id, custNote.Id);
                Assert.AreEqual(note.Content, result1.Content);
            }
        }

        #endregion

        #region GetAccountContacts

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Contact AddressType Residential")]
        public void CustomerContactAddressTypeResidential()
        {           
            //Create Customer Account
            var custAcctObj = Generator.GenerateCustomerAccountVeryRandom();
            var customerAccount = CustomerAccountFactory.AddAccount(ApiMsgHandler, custAcctObj);
            //Add Account Contact
            var contactObj = Generator.GenerateCustomerContact(customerAccount.Id);
            var contact = CustomerContactFactory.AddAccountContact(ApiMsgHandler, contactObj, customerAccount.Id);
            Assert.AreEqual(contactObj.Address.AddressType, contact.Address.AddressType);
            //Get account contact
            var result = CustomerContactFactory.GetAccountContact(ApiMsgHandler, customerAccount.Id, contact.Id);
            Assert.AreEqual(contact.Address.AddressType, result.Address.AddressType);

        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Contact AddressType Commercial")]
        public void CustomerContactAddressTypeCommercial()
        {
            //Create Customer Account
            var custAcctObj = Generator.GenerateCustomerAccountRandom();
            var customerAccount = CustomerAccountFactory.AddAccount(ApiMsgHandler, custAcctObj);
            //Add Account Contact
            var address = Generator.GenerateAddressRandom(Generator.AddressType.Commercial);
            var contactObj = Generator.GenerateCustomerContact(customerAccount.Id, address);
            var contact = CustomerContactFactory.AddAccountContact(ApiMsgHandler, contactObj, customerAccount.Id);
            Assert.AreEqual(contactObj.Address.AddressType, contact.Address.AddressType);
            //Get account contact
            var result = CustomerContactFactory.GetAccountContact(ApiMsgHandler, customerAccount.Id, contact.Id);
            Assert.AreEqual(address.AddressType, result.Address.AddressType);           
        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Contact AddressType None")]
        public void CustomerContactAddressTypeNone()
        {
            //Create Customer Account
            var custAcctObj = Generator.GenerateCustomerAccountRandom();
            var customerAccount = CustomerAccountFactory.AddAccount(ApiMsgHandler, custAcctObj);
            //Add Account Contact
            var address = Generator.GenerateAddressRandom(Generator.AddressType.None);
            var contactObj = Generator.GenerateCustomerContact(customerAccount.Id, address);
            var contact = CustomerContactFactory.AddAccountContact(ApiMsgHandler, contactObj, customerAccount.Id);
            Assert.AreEqual(contactObj.Address.AddressType, contact.Address.AddressType);
            //Get account contact
            var result = CustomerContactFactory.GetAccountContact(ApiMsgHandler, customerAccount.Id, contact.Id);
            Assert.AreEqual(address.AddressType, result.Address.AddressType); 

        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Contact AddressType None")]
        public void CustomerGetContactAddress()
        {

            const int customerAccountId = 1088;
           
            //Get account contact
            var result = CustomerAccountFactory.GetAccount(ApiMsgHandler, customerAccountId);
            Assert.IsNotNull(result, "No Customer found with AccountId = " + customerAccountId);

        }
        #endregion

        #region Passwords
        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Customer Reset Password")]
        public void CustomerAccountResetPassword()
        {
            //CreateAccounts
            var cust = Generator.GenerateCustomerAccountVeryRandom();
            var authInfo = Generator.GenerateCustomerAccountAndAuthInfo(cust);
            
            var custAccount = CustomerAccountFactory.AddAccountAndLogin(ApiMsgHandler, authInfo);


            CustomerAccountFactory.ResetPassword(handler: ApiMsgHandler, resetPasswordInfo: new ResetPasswordInfo()
                {
                    UserName = custAccount.CustomerAccount.UserName, 
                    EmailAddress = custAccount.CustomerAccount.EmailAddress
                }, expectedCode: HttpStatusCode.OK, successCode: HttpStatusCode.OK);

        }

        #endregion

        #region Get Login Status

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Get Customer Last Login by Id")]
        public void CustomerAccountLoginStatusById()
        {
            //CreateAccounts
            var cust = Generator.GenerateCustomerAccountRandom();
            var authInfo = Generator.GenerateCustomerAccountAndAuthInfo(cust);
            var custAccount = CustomerAccountFactory.AddAccountAndLogin(ApiMsgHandler, authInfo);

            var loginState = CustomerAccountFactory.GetLoginState(ApiMsgHandler, custAccount.CustomerAccount.Id);

            Assert.IsTrue(loginState.LastLoginOn > (DateTime.Now.AddMinutes(-1)));

        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Get Customer Last Login by Email")]
        public void CustomerAccountLoginStatusByEmail()
        {
            //CreateAccounts
            var cust = Generator.GenerateCustomerAccountRandom();
            var authInfo = Generator.GenerateCustomerAccountAndAuthInfo(cust);
            var custAccount = CustomerAccountFactory.AddAccountAndLogin(ApiMsgHandler, authInfo);

            var loginState = CustomerAccountFactory.GetLoginStateByEmailAddress(ApiMsgHandler, custAccount.CustomerAccount.EmailAddress);

            Assert.IsTrue(loginState.LastLoginOn > (DateTime.Now.AddMinutes(-1)));

        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Get Customer Last Login by UserName")]
        public void CustomerAccountLoginStatusByUserName()
        {
            //CreateAccounts
            var cust = Generator.GenerateCustomerAccountRandom();
            var authInfo = Generator.GenerateCustomerAccountAndAuthInfo(cust);
            var custAccount = CustomerAccountFactory.AddAccountAndLogin(ApiMsgHandler, authInfo);

            var loginState = CustomerAccountFactory.GetLoginStateByUserName(ApiMsgHandler, custAccount.CustomerAccount.UserName);

            Assert.IsTrue(loginState.LastLoginOn > (DateTime.Now.AddMinutes(-1)));

        }


        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Get Customer Account Set Password Change")]
        public void CustomerAccountSetPasswordChange()
        {
            //CreateAccounts
            var customerAccountAndAuthInfo = Generator.GenerateCustomerAccountAndAuthInfo();
            var createdCustomerAccount = CustomerAccountFactory.AddAccountAndLogin(handler: ShopperMsgHandler, accountAndAuthInfo: customerAccountAndAuthInfo);

            var updateCustomerAccount = CustomerContactFactory.AddAccountContact(handler: ShopperMsgHandler,
                contact: Generator.GenerateCustomerContactReal(accountId: createdCustomerAccount.CustomerAccount.Id),
                accountId: createdCustomerAccount.CustomerAccount.Id);

            // Set the password change Required
            CustomerAccountFactory.SetPasswordChangeRequired(ApiMsgHandler, isPasswordChangeRequired: true, accountId: updateCustomerAccount.Id);

            var shopperUserAuthInfo = Generator.GenerateCustomerUserAuthInfo(userName: customerAccountAndAuthInfo.Account.UserName);

            try
            {
                var ShopperAuth =
                    Mozu.Api.Security.CustomerAuthenticator.Authenticate(customerUserAuthInfo: shopperUserAuthInfo,
                                                         tenantId: TestBaseTenant.Id,
                                                         siteId: TestBaseTenant.Sites.FirstOrDefault().Id);
                Assert.Fail("This account should have been reporting error to change password");

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }


        }

        [TestMethod]
        [TestCategory("Mozu SDK Sample")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [Description("Get Customer Account Set Locked")]
        public void CustomerAccountSetLocked()
        {
            //CreateAccounts
            var customerAccountAndAuthInfo = Generator.GenerateCustomerAccountAndAuthInfoRandom();
            var createdCustomerAccount = CustomerAccountFactory.AddAccountAndLogin(handler: ShopperMsgHandler, accountAndAuthInfo: customerAccountAndAuthInfo);

            var updateCustomerAccount = CustomerContactFactory.AddAccountContact(handler: ShopperMsgHandler,
                contact: Generator.GenerateCustomerContactReal(accountId: createdCustomerAccount.CustomerAccount.Id),
                accountId: createdCustomerAccount.CustomerAccount.Id);

            // Set the Login Locked.
            CustomerAccountFactory.SetLoginLocked(ApiMsgHandler, isLocked: true, accountId: updateCustomerAccount.Id);

            var shopperUserAuthInfo = Generator.GenerateCustomerUserAuthInfo(userName: customerAccountAndAuthInfo.Account.UserName);

            try
            {
                var ShopperAuth =
                    Mozu.Api.Security.CustomerAuthenticator.Authenticate(customerUserAuthInfo: shopperUserAuthInfo,
                                                         tenantId: TestBaseTenant.Id,
                                                         siteId: TestBaseTenant.Sites.FirstOrDefault().Id);
                Assert.Fail("This account should have been reporting error to change password");

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }


        }
        #endregion


        private List<CustomerAccount> GetAllAccounts()
        {
            var accounts = new List<CustomerAccount>();

            var startIndex = 0;
            CustomerAccountCollection accountCollection = CustomerAccountFactory.GetAccounts(ApiMsgHandler,startIndex, pageSize: 200);

            accounts.AddRange(accountCollection.Items);


            while (accounts.Count < accountCollection.TotalCount)
            {
                startIndex += 200;

                accountCollection = CustomerAccountFactory.GetAccounts(ApiMsgHandler,startIndex, pageSize: 200);

                accounts.AddRange(accountCollection.Items);

            }

            return accounts;

        }
    }
}
