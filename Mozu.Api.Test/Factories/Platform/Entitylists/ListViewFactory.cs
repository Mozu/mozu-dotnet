//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#region Usings Setup

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Mozu.Api;
using Mozu.Api.Security;
using Mozu.Api.Test.Helpers;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Threading;

#endregion

namespace Mozu.Api.Test.Factories.Platform.Entitylists
{
	/// <summary>
	/// Provides settings and options for displaying associated content within a context level of site, tenant, catalog, or master catalog. ListViews can be associated with entity lists and entities.
	/// </summary>
	public partial class ListViewFactory : BaseDataFactory
	{

		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = ListViewFactory.GetViewEntity(handler : handler,  entityListFullName :  entityListFullName,  viewName :  viewName,  entityId :  entityId,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<JObject/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static JObject GetViewEntity(ServiceClientMessageHandler handler, 
 		 string entityListFullName, string viewName, string entityId, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetViewEntityClient(
				 entityListFullName :  entityListFullName,  viewName :  viewName,  entityId :  entityId,  responseFields :  responseFields		);
			try
			{
				apiClient.WithContext(handler.ApiContext).ExecuteAsync(default(CancellationToken)).Wait();
			}
			catch (ApiException ex)
			{
				// Custom error handling for test cases can be placed here
				Exception customException = TestFailException.GetCustomTestException(ex, currentClassName, currentMethodName, expectedCode);
				if (customException != null)
					throw customException;
				return null;
			}
			return ResponseMessageFactory.CheckResponseCodes(apiClient.HttpResponse.StatusCode, expectedCode, successCode) 
					 ? (apiClient.Result()) 
					 : null;

		}
  
		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = ListViewFactory.GetViewEntities(handler : handler,  entityListFullName :  entityListFullName,  viewName :  viewName,  pageSize :  pageSize,  startIndex :  startIndex,  filter :  filter,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<EntityCollection/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.MZDB.EntityCollection GetViewEntities(ServiceClientMessageHandler handler, 
 		 string entityListFullName, string viewName, int? pageSize = null, int? startIndex = null, string filter = null, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetViewEntitiesClient(
				 entityListFullName :  entityListFullName,  viewName :  viewName,  pageSize :  pageSize,  startIndex :  startIndex,  filter :  filter,  responseFields :  responseFields		);
			try
			{
				apiClient.WithContext(handler.ApiContext).ExecuteAsync(default(CancellationToken)).Wait();
			}
			catch (ApiException ex)
			{
				// Custom error handling for test cases can be placed here
				Exception customException = TestFailException.GetCustomTestException(ex, currentClassName, currentMethodName, expectedCode);
				if (customException != null)
					throw customException;
				return null;
			}
			return ResponseMessageFactory.CheckResponseCodes(apiClient.HttpResponse.StatusCode, expectedCode, successCode) 
					 ? (apiClient.Result()) 
					 : null;

		}
  
		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = ListViewFactory.GetViewEntityContainer(handler : handler,  entityListFullName :  entityListFullName,  viewName :  viewName,  entityId :  entityId,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<EntityContainer/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.MZDB.EntityContainer GetViewEntityContainer(ServiceClientMessageHandler handler, 
 		 string entityListFullName, string viewName, string entityId, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetViewEntityContainerClient(
				 entityListFullName :  entityListFullName,  viewName :  viewName,  entityId :  entityId,  responseFields :  responseFields		);
			try
			{
				apiClient.WithContext(handler.ApiContext).ExecuteAsync(default(CancellationToken)).Wait();
			}
			catch (ApiException ex)
			{
				// Custom error handling for test cases can be placed here
				Exception customException = TestFailException.GetCustomTestException(ex, currentClassName, currentMethodName, expectedCode);
				if (customException != null)
					throw customException;
				return null;
			}
			return ResponseMessageFactory.CheckResponseCodes(apiClient.HttpResponse.StatusCode, expectedCode, successCode) 
					 ? (apiClient.Result()) 
					 : null;

		}
  
		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = ListViewFactory.GetViewEntityContainers(handler : handler,  entityListFullName :  entityListFullName,  viewName :  viewName,  pageSize :  pageSize,  startIndex :  startIndex,  filter :  filter,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<EntityContainerCollection/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.MZDB.EntityContainerCollection GetViewEntityContainers(ServiceClientMessageHandler handler, 
 		 string entityListFullName, string viewName, int? pageSize = null, int? startIndex = null, string filter = null, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetViewEntityContainersClient(
				 entityListFullName :  entityListFullName,  viewName :  viewName,  pageSize :  pageSize,  startIndex :  startIndex,  filter :  filter,  responseFields :  responseFields		);
			try
			{
				apiClient.WithContext(handler.ApiContext).ExecuteAsync(default(CancellationToken)).Wait();
			}
			catch (ApiException ex)
			{
				// Custom error handling for test cases can be placed here
				Exception customException = TestFailException.GetCustomTestException(ex, currentClassName, currentMethodName, expectedCode);
				if (customException != null)
					throw customException;
				return null;
			}
			return ResponseMessageFactory.CheckResponseCodes(apiClient.HttpResponse.StatusCode, expectedCode, successCode) 
					 ? (apiClient.Result()) 
					 : null;

		}
  
		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = ListViewFactory.GetEntityListView(handler : handler,  entityListFullName :  entityListFullName,  viewName :  viewName,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<ListView/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.MZDB.ListView GetEntityListView(ServiceClientMessageHandler handler, 
 		 string entityListFullName, string viewName, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetEntityListViewClient(
				 entityListFullName :  entityListFullName,  viewName :  viewName,  responseFields :  responseFields		);
			try
			{
				apiClient.WithContext(handler.ApiContext).ExecuteAsync(default(CancellationToken)).Wait();
			}
			catch (ApiException ex)
			{
				// Custom error handling for test cases can be placed here
				Exception customException = TestFailException.GetCustomTestException(ex, currentClassName, currentMethodName, expectedCode);
				if (customException != null)
					throw customException;
				return null;
			}
			return ResponseMessageFactory.CheckResponseCodes(apiClient.HttpResponse.StatusCode, expectedCode, successCode) 
					 ? (apiClient.Result()) 
					 : null;

		}
  
		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = ListViewFactory.GetEntityListViews(handler : handler,  entityListFullName :  entityListFullName,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<ListViewCollection/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.MZDB.ListViewCollection GetEntityListViews(ServiceClientMessageHandler handler, 
 		 string entityListFullName, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.GetEntityListViewsClient(
				 entityListFullName :  entityListFullName,  responseFields :  responseFields		);
			try
			{
				apiClient.WithContext(handler.ApiContext).ExecuteAsync(default(CancellationToken)).Wait();
			}
			catch (ApiException ex)
			{
				// Custom error handling for test cases can be placed here
				Exception customException = TestFailException.GetCustomTestException(ex, currentClassName, currentMethodName, expectedCode);
				if (customException != null)
					throw customException;
				return null;
			}
			return ResponseMessageFactory.CheckResponseCodes(apiClient.HttpResponse.StatusCode, expectedCode, successCode) 
					 ? (apiClient.Result()) 
					 : null;

		}
  
		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = ListViewFactory.CreateEntityListView(handler : handler,  listView :  listView,  entityListFullName :  entityListFullName,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<ListView/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.MZDB.ListView CreateEntityListView(ServiceClientMessageHandler handler, 
 		 Mozu.Api.Contracts.MZDB.ListView listView, string entityListFullName, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.Created, HttpStatusCode successCode = HttpStatusCode.Created)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.CreateEntityListViewClient(
				 listView :  listView,  entityListFullName :  entityListFullName,  responseFields :  responseFields		);
			try
			{
				apiClient.WithContext(handler.ApiContext).ExecuteAsync(default(CancellationToken)).Wait();
			}
			catch (ApiException ex)
			{
				// Custom error handling for test cases can be placed here
				Exception customException = TestFailException.GetCustomTestException(ex, currentClassName, currentMethodName, expectedCode);
				if (customException != null)
					throw customException;
				return null;
			}
			return ResponseMessageFactory.CheckResponseCodes(apiClient.HttpResponse.StatusCode, expectedCode, successCode) 
					 ? (apiClient.Result()) 
					 : null;

		}
  
		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = ListViewFactory.UpdateEntityListView(handler : handler,  listView :  listView,  entityListFullName :  entityListFullName,  viewName :  viewName,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<ListView/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.MZDB.ListView UpdateEntityListView(ServiceClientMessageHandler handler, 
 		 Mozu.Api.Contracts.MZDB.ListView listView, string entityListFullName, string viewName, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.UpdateEntityListViewClient(
				 listView :  listView,  entityListFullName :  entityListFullName,  viewName :  viewName,  responseFields :  responseFields		);
			try
			{
				apiClient.WithContext(handler.ApiContext).ExecuteAsync(default(CancellationToken)).Wait();
			}
			catch (ApiException ex)
			{
				// Custom error handling for test cases can be placed here
				Exception customException = TestFailException.GetCustomTestException(ex, currentClassName, currentMethodName, expectedCode);
				if (customException != null)
					throw customException;
				return null;
			}
			return ResponseMessageFactory.CheckResponseCodes(apiClient.HttpResponse.StatusCode, expectedCode, successCode) 
					 ? (apiClient.Result()) 
					 : null;

		}
  
		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = ListViewFactory.DeleteEntityListView(handler : handler,  entityListFullName :  entityListFullName,  viewName :  viewName,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Stream/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static System.IO.Stream DeleteEntityListView(ServiceClientMessageHandler handler, 
 		 string entityListFullName, string viewName, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Platform.Entitylists.ListViewClient.DeleteEntityListViewClient(
				 entityListFullName :  entityListFullName,  viewName :  viewName		);
			try
			{
				apiClient.WithContext(handler.ApiContext).ExecuteAsync(default(CancellationToken)).Wait();
			}
			catch (ApiException ex)
			{
				// Custom error handling for test cases can be placed here
				Exception customException = TestFailException.GetCustomTestException(ex, currentClassName, currentMethodName, expectedCode);
				if (customException != null)
					throw customException;
				return null;
			}
			return ResponseMessageFactory.CheckResponseCodes(apiClient.HttpResponse.StatusCode, expectedCode, successCode) 
					 ? (apiClient.Result()) 
					 : null;

		}
  

	}

}


