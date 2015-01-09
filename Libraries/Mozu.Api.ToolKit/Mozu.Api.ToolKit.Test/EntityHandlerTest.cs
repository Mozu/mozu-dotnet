using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozu.Api.Contracts.MZDB;
using Mozu.Api.Resources.Platform;
using Mozu.Api.ToolKit.Config;
using Mozu.Api.ToolKit.Handlers;

namespace Mozu.Api.ToolKit.Test
{
    [TestClass]
    public class EntityHandlerTest : BaseTest
    {
        private IEntityHandler _entityHandler;
        private IEntitySchemaHandler _entitySchemaHandler;
        private IAppSetting _appSetting;
        private String listName = "contacts";

        [TestInitialize]
        public void Initialize()
        {
            _entityHandler = Container.Resolve<IEntityHandler>();
            _entitySchemaHandler = Container.Resolve<IEntitySchemaHandler>();
            _appSetting = Container.Resolve<IAppSetting>();
            InstallSchema();
        }

        [TestCleanup]
        public void Cleanup()
        {
            
        }

        [TestMethod]
        public void GetEntitiesTest()
        {
            var entities =_entityHandler.GetEntitiesAsync<Contact>(new ApiContext(TenantId), listName).Result;
        }


        [TestMethod]
        public void AddContactTest()
        {
            var contact = new Contact { Id = 10, FirstName = "Foo", LastName = "Bar" };
            var result = _entityHandler.AddEntityAsync(new ApiContext(TenantId), listName, contact).Result;
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void UpdateContactTest()
        {
            var contact = new Contact { Id = 10000, FirstName = "Foo", LastName = "Bar" };
            var result = _entityHandler.UpdateEntityAsync(new ApiContext(TenantId),contact.Id, listName, contact).Result;
        }

        [TestMethod]
        public void UpsertContactTest()
        {
            var contact = new Contact {Id = 1, FirstName = "Foo", LastName = "Bar"};
            var result = _entityHandler.UpsertEntityAsync(new ApiContext(TenantId), contact.Id.ToString(), listName, contact).Result;
        }

        [TestMethod]
        public void GetContactTest()
        {
            var contact = _entityHandler.GetEntityAsync<Contact>(new ApiContext(TenantId), "1", listName).Result;
            Assert.IsNotNull(contact);
            Assert.AreEqual(contact.Id, 1);
            Assert.AreEqual(contact.FirstName, "Foo");
            Assert.AreEqual(contact.LastName, "Bar");
        }

        private void InstallSchema()
        {
            var contactEntityList = new EntityList
            {
                IsSandboxDataCloningSupported = false,
                IsShopperSpecific = false,
                IsVisibleInStorefront = true,
                Name = listName
            };

            var indexProperties = new List<IndexedProperty>()
            {
                _entitySchemaHandler.GetIndexedProperty("firstName", EntityDataType.String),
                _entitySchemaHandler.GetIndexedProperty("lastName", EntityDataType.String)
            };
            var idProperty = _entitySchemaHandler.GetIndexedProperty("id", EntityDataType.Integer);

            _entitySchemaHandler.InstallSchemaAsync(new ApiContext(TenantId), contactEntityList, EntityScope.Tenant,idProperty, indexProperties).Wait();
        }
    }

    public class Contact
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public string LastName { get; set; }
    }
}
