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

namespace Mozu.Api.Test.Factories.Commerce.Returns
{
	/// <summary>
	/// Use the Return Shipments subresource to manage shipments for a return replacement.
	/// </summary>
	public partial class ReturnsShipmentFactory : BaseDataFactory
	{

		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = ShipmentFactory.GetShipment(handler : handler,  returnId :  returnId,  shipmentId :  shipmentId,  responseFields :  responseFields,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Shipment/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Shipment GetShipment(ServiceClientMessageHandler handler, 
 		 string returnId, string shipmentId, string responseFields = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Commerce.Returns.ShipmentClient.GetShipmentClient(
				 returnId :  returnId,  shipmentId :  shipmentId,  responseFields :  responseFields		);
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
		/// var result = ShipmentFactory.CreatePackageShipments(handler : handler,  packageIds :  packageIds,  returnId :  returnId,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<List<Package>/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static List<Mozu.Api.Contracts.CommerceRuntime.Fulfillment.Package> CreatePackageShipments(ServiceClientMessageHandler handler, 
 		 List<string> packageIds, string returnId, 
		 HttpStatusCode expectedCode = HttpStatusCode.Created, HttpStatusCode successCode = HttpStatusCode.Created)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Commerce.Returns.ShipmentClient.CreatePackageShipmentsClient(
				 packageIds :  packageIds,  returnId :  returnId		);
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
		/// var result = ShipmentFactory.DeleteShipment(handler : handler,  returnId :  returnId,  shipmentId :  shipmentId,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Stream/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static System.IO.Stream DeleteShipment(ServiceClientMessageHandler handler, 
 		 string returnId, string shipmentId, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Commerce.Returns.ShipmentClient.DeleteShipmentClient(
				 returnId :  returnId,  shipmentId :  shipmentId		);
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


