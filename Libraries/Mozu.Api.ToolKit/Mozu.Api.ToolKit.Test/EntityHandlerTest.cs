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
        private IAppSetting _appSetting;
        private String listName = "contacts";

        [TestInitialize]
        public void Initialize()
        {
            _entityHandler = Container.Resolve<IEntityHandler>();
            _appSetting = Container.Resolve<IAppSetting>();
            InstallSchema();
        }

        [TestCleanup]
        public void Cleanup()
        {
            DeleteSchema();
        }

        [TestMethod]
        public void GetEntitiesTest()
        {
            var entities =_entityHandler.GetEntitiesAsync<Person>(new ApiContext(TenantId), listName).Result;
        }


        [TestMethod]
        public void AddContactTest()
        {
            var contact = new Person {Id = 1, FirstName = "Foo", LastName = "Bar"};
            var result = _entityHandler.UpsertEntityAsync(new ApiContext(TenantId), contact.Id.ToString(), listName, contact).Result;
        }

        [TestMethod]
        public void GetContactTest()
        {
            var contact = _entityHandler.GetEntityAsync<Person>(new ApiContext(TenantId), "1", listName).Result;
            Assert.AreEqual(contact.Id, 1);
            Assert.AreEqual(contact.FirstName, "Foo");
            Assert.AreEqual(contact.LastName, "Bar");
        }

        private void InstallSchema()
        {
            var entityListResource = new EntityListResource(new ApiContext(TenantId));
            var personEntityList = new EntityList
            {
                ContextLevel = "tenant",
                IdProperty = new IndexedProperty { PropertyName = "Id", DataType = "string" },
                IndexA = new IndexedProperty { PropertyName = "FirstName", DataType = "string" },
                IndexB = new IndexedProperty { PropertyName = "LastName", DataType = "string" },
                IsSandboxDataCloningSupported = false,
                IsShopperSpecific = false,
                IsVisibleInStorefront = true,
                Name = listName,
                NameSpace = _appSetting.Namespace,
                TenantId = TenantId
            };

            EntityList existing = null;
            try
            {
                existing = entityListResource.GetEntityListAsync(ListFQN).Result;
            }
            catch (AggregateException ae)
            {
                if ( ae.InnerException.GetType() ==  typeof(ApiException))
                {
                    var aex = (ApiException) ae.InnerException;
                    if (!string.Equals(aex.ErrorCode, "ITEM_NOT_FOUND", StringComparison.OrdinalIgnoreCase))
                        Assert.Fail(aex.Message);
                    
                }
                else
                {
                    Assert.Fail(ae.Message);
                }
            }

            try
            {
                existing = existing != null
                    ? entityListResource.UpdateEntityListAsync(personEntityList, ListFQN).Result
                    : entityListResource.CreateEntityListAsync(personEntityList).Result;
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException.GetType() == typeof(ApiException))
                {
                    var aex = (ApiException)ae.InnerException;
                    Assert.Fail(aex.Message);
                }
                else
                {
                    Assert.Fail(ae.Message);
                }
                
            }

        }

        private string ListFQN
        {
            get { return String.Format("{0}@{1}", listName, _appSetting.Namespace); }
        }

        private void DeleteSchema()
        {
            
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public string LastName { get; set; }
    }
}
