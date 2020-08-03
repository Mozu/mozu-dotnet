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

namespace Mozu.Api.Test.Factories.Platform
{
	/// <summary>
	/// Use the Applications resource to update and retrieve details about the applications installed for your tenant.
	/// </summary>
	public partial class InstalledApplicationsFactory : BaseDataFactory
	{

		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = InstalledApplicationsFactory.GetApplication(handler : handler,  appId :  appId,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Application/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.InstalledApplications.Application GetApplication(ServiceClientMessageHandler handler, 
 		 string appId, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Platform.InstalledApplicationsClient.GetApplicationClient(
				 appId :  appId,  responseFields :  responseFields		);
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
		/// var result = InstalledApplicationsFactory.UpdateApplication(handler : handler,  application :  application,  appId :  appId,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Application/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.InstalledApplications.Application UpdateApplication(ServiceClientMessageHandler handler, 
 		 Mozu.Api.Contracts.InstalledApplications.Application application, string appId, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Platform.InstalledApplicationsClient.UpdateApplicationClient(
				 application :  application,  appId :  appId,  responseFields :  responseFields		);
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


