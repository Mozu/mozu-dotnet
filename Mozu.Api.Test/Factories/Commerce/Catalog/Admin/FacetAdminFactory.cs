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

namespace Mozu.Api.Test.Factories.Commerce.Catalog.Admin
{
	/// <summary>
	/// Use the Facets resource to manage the facets shoppers use to filter product display results on a storefront. Facets can include categories, product attributes, or prices, and use either a range of values or discrete values.
	/// </summary>
	public partial class FacetAdminFactory : BaseDataFactory
	{

		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = FacetFactory.GetFacet(handler : handler,  facetId :  facetId,  validate :  validate,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Facet/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.ProductAdmin.Facet GetFacet(ServiceClientMessageHandler handler, 
 		 int facetId, bool? validate = null, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Commerce.Catalog.Admin.FacetClient.GetFacetClient(
				 facetId :  facetId,  validate :  validate,  responseFields :  responseFields		);
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
		/// var result = FacetFactory.GetFacetCategoryList(handler : handler,  categoryId :  categoryId,  includeAvailable :  includeAvailable,  validate :  validate,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<FacetSet/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.ProductAdmin.FacetSet GetFacetCategoryList(ServiceClientMessageHandler handler, 
 		 int categoryId, bool? includeAvailable = null, bool? validate = null, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Commerce.Catalog.Admin.FacetClient.GetFacetCategoryListClient(
				 categoryId :  categoryId,  includeAvailable :  includeAvailable,  validate :  validate,  responseFields :  responseFields		);
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
		/// var result = FacetFactory.AddFacet(handler : handler,  facet :  facet,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Facet/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.ProductAdmin.Facet AddFacet(ServiceClientMessageHandler handler, 
 		 Mozu.Api.Contracts.ProductAdmin.Facet facet, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.Created, HttpStatusCode successCode = HttpStatusCode.Created)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Commerce.Catalog.Admin.FacetClient.AddFacetClient(
				 facet :  facet,  responseFields :  responseFields		);
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
		/// var result = FacetFactory.UpdateFacet(handler : handler,  facet :  facet,  facetId :  facetId,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Facet/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.ProductAdmin.Facet UpdateFacet(ServiceClientMessageHandler handler, 
 		 Mozu.Api.Contracts.ProductAdmin.Facet facet, int facetId, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Commerce.Catalog.Admin.FacetClient.UpdateFacetClient(
				 facet :  facet,  facetId :  facetId,  responseFields :  responseFields		);
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
		/// var result = FacetFactory.DeleteFacetById(handler : handler,  facetId :  facetId,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<void/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static void DeleteFacetById(ServiceClientMessageHandler handler, 
 		int facetId, 
		 HttpStatusCode expectedCode = HttpStatusCode.NoContent, HttpStatusCode successCode = HttpStatusCode.NoContent)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Commerce.Catalog.Admin.FacetClient.DeleteFacetByIdClient(
				 facetId :  facetId		);
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
			}
			var noResponse = ResponseMessageFactory.CheckResponseCodes(apiClient.HttpResponse.StatusCode, expectedCode, successCode) 
					 ? (apiClient.Result()) 
					 : null;

		}
  

	}

}

