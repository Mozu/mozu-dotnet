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

namespace Mozu.Api.Test.Factories.Commerce.Customer
{
	/// <summary>
	/// Use the Customer Sets resource to manage your customer sets. You can use customer sets to control the specific sites your customers can access using the same login credentials, as well as what customer My Account information is shared between sites.Refer to [Customer Sets](../../../guides/settings/customer-sets.htm) in the Guides section for more information.
	/// </summary>
	public partial class CustomerSetFactory : BaseDataFactory
	{

		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = CustomerSetFactory.GetCustomerSets(handler : handler,  startIndex :  startIndex,  pageSize :  pageSize,  sortBy :  sortBy,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<CustomerSetCollection/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.Customer.CustomerSetCollection GetCustomerSets(ServiceClientMessageHandler handler, 
 		 int? startIndex = null, int? pageSize = null, string sortBy = null, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Commerce.Customer.CustomerSetClient.GetCustomerSetsClient(
				 startIndex :  startIndex,  pageSize :  pageSize,  sortBy :  sortBy,  responseFields :  responseFields		);
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
		/// var result = CustomerSetFactory.GetCustomerSet(handler : handler,  code :  code,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<CustomerSet/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.Customer.CustomerSet GetCustomerSet(ServiceClientMessageHandler handler, 
 		 string code, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Commerce.Customer.CustomerSetClient.GetCustomerSetClient(
				 code :  code,  responseFields :  responseFields		);
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


