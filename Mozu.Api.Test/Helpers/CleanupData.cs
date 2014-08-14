// ***********************************************************************
// <copyright file="CleanUpData.cs" company="Volusion, Inc.">
//     Copyright (c) Volusion. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Mozu.Api.Test.Factories;
using System.Net;

namespace Mozu.Api.Test.Helpers
{
    public class CleanUpData
    {
        private static string SinceWhen()
        {
            var date = Since();
            return date.Date.Year + "-" + date.Date.Month + "-" + date.Date.Day;
        }

        private static string SinceWhen(DateTime date)
        {
            return date.Date.Year + "-" + date.Date.Month + "-" + date.Date.Day;
        }

        private static DateTime Since()
        {
            return DateTime.Now.AddDays(-100);
        }

        /// <summary>
        /// clean up products, attributes, productypes and categories since provisioning the tenant
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="masterCatalogId"></param>
        /// <param name="siteId"></param>
        public static void CleanUpProducts(int tenantId, int masterCatalogId, int? catalogId = null, int? siteId = null)
        {
            var tenant = TenantFactory.GetTenant(ServiceClientMessageFactory.GetTestClientMessage(), tenantId);
            var ApiMessageHandler = ServiceClientMessageFactory.GetTestClientMessage(tenantId: tenantId, masterCatalogId: masterCatalogId, catalogId: catalogId, siteId: siteId);
            var products = ProductFactory.GetProducts(ApiMessageHandler,noCount:null,pageSize:null,q:null,qLimit:null,sortBy:null,startIndex:null, filter: "createdate gt " + SinceWhen(DateTime.Now.AddDays(-1)));
            foreach (var pro in products.Items)
            {
                ProductFactory.DeleteProduct(ApiMessageHandler, pro.ProductCode);
            }
            var productTypes = ProductTypeFactory.GetProductTypes(handler: ApiMessageHandler, dataViewMode: DataViewMode.Live, successCode:HttpStatusCode.OK, expectedCode: HttpStatusCode.OK);
            foreach (var pt in productTypes.Items)
            {
                if (pt.AuditInfo.CreateDate.Value > DateTime.Now.AddDays(-1))
                {
                    try
                    {
                        ProductTypeFactory.DeleteProductType(ApiMessageHandler, pt.Id.Value);
                    }
                    catch (TestFailException e)   //getaround base product type
                    {
                        // ToDo: e.ActualReturnCode
                    }
                }
            }
            var attributes = AttributeFactory.GetAttributes(handler: ApiMessageHandler, dataViewMode: DataViewMode.Live, successCode: HttpStatusCode.OK, expectedCode: HttpStatusCode.OK);
            if (attributes.TotalCount != 0)
            {
                foreach (var attr in attributes.Items)
                {
                    if (attr.AuditInfo.CreateDate.Value > DateTime.Now.AddDays(-1))
                    {
                        //bug 18745, should return NoContent
                        try
                        {
                            AttributeFactory.DeleteAttribute(ApiMessageHandler, attr.AttributeFQN);
                        }
                        catch (TestFailException e)  //get around the bug
                        {
                            // ToDo: e.ActualReturnCode
                        }
                    }
                }
            }
            var cates = CategoryFactory.GetCategories(ApiMessageHandler, pageSize: null, sortBy: null, startIndex: null, filter: "createdate gt " + SinceWhen(DateTime.Now.AddDays(-1)));
            foreach (var cate in cates.Items)
            {
                var messageHandler1 = ServiceClientMessageFactory.GetTestClientMessage(tenantId: tenantId, masterCatalogId: masterCatalogId, catalogId:catalogId, siteId: siteId);
                try
                {
                    CategoryFactory.DeleteCategoryById(handler: messageHandler1, categoryId: (int)cate.Id, cascadeDelete: true);
                }
                catch (TestFailException e)   //work around notfound
                {
                    // ToDo: e.ActualReturnCode
                }
            }
        }

        public static void CleanUpAttributes(ServiceClientMessageHandler handler, List<string> attributeFQNs)
        {
            foreach (var attributeFQN in attributeFQNs)
            {
                //should return NoContent, bypass for now
                try
                {
                   AttributeFactory.DeleteAttribute(handler, attributeFQN);
                }
                catch (TestFailException e)  //work around the bug
                {
                    // ToDo: e.ActualReturnCode
                }
            }
        }

        public static void CleanUpProductTypes(ServiceClientMessageHandler handler, List<int> productTypeIds)
        {
            foreach (var id in productTypeIds)
            {
                ProductTypeFactory.DeleteProductType(handler, id);
            }
        }

        public static void CleanUpProducts(ServiceClientMessageHandler handler, List<string> productCodes)
        {
            foreach (var code in productCodes)
            {
                //should return NoContent, bypass for now
                try
                {
                    ProductFactory.DeleteProduct(handler, code);
                }
                catch (TestFailException e)
                {
                    // ToDo: e.ActualReturnCode
                }
            }
        }

        public static void CleanUpCategories(ServiceClientMessageHandler handler, List<int> CategoryIds)
        {
            foreach (var id in CategoryIds)
            {
                //should return NoContent, bypass for now
                try
                {
                    CategoryFactory.DeleteCategoryById(handler: handler,categoryId: id,cascadeDelete: true);
                }
                catch (TestFailException e)  //work around cascade, not found
                {
                    // ToDo: e.ActualReturnCode
                }
            }
        }

        public static void RestoreToLive(ServiceClientMessageHandler handler, int siteGrpId)
        {
           // MasterCatalogFactory.UpdateMasterCatalog(handler, Generator.GenerateMasterCatalog(siteGrpId, "Live"), siteGrpId); 
        }

    

    }
}
