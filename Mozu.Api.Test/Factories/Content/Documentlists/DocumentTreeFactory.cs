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

namespace Mozu.Api.Test.Factories.Content.Documentlists
{
	/// <summary>
	/// Use the document tree subresource to retrieve documents and manage content within the document hierarchy.
	/// </summary>
	public partial class DocumentTreeFactory : BaseDataFactory
	{

		/// <summary> 
		/// 
		/// <example> 
		///  <code> 
		/// var result = DocumentTreeFactory.GetTreeDocumentContent(handler : handler,  documentListName :  documentListName,  documentName :  documentName,  dataViewMode: dataViewMode,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Stream/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static System.IO.Stream GetTreeDocumentContent(ServiceClientMessageHandler handler, 
 		 string documentListName, string documentName,  DataViewMode dataViewMode= DataViewMode.Live, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Content.Documentlists.DocumentTreeClient.GetTreeDocumentContentClient(
				 documentListName :  documentListName,  documentName :  documentName, dataViewMode: dataViewMode		);
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
		/// var result = DocumentTreeFactory.TransformTreeDocumentContent(handler : handler,  documentListName :  documentListName,  documentName :  documentName,  width :  width,  height :  height,  max :  max,  maxWidth :  maxWidth,  maxHeight :  maxHeight,  crop :  crop,  quality :  quality,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Stream/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static System.IO.Stream TransformTreeDocumentContent(ServiceClientMessageHandler handler, 
 		 string documentListName, string documentName, int? width = null, int? height = null, int? max = null, int? maxWidth = null, int? maxHeight = null, string crop = null, int? quality = null, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Content.Documentlists.DocumentTreeClient.TransformTreeDocumentContentClient(
				 documentListName :  documentListName,  documentName :  documentName,  width :  width,  height :  height,  max :  max,  maxWidth :  maxWidth,  maxHeight :  maxHeight,  crop :  crop,  quality :  quality		);
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
		/// var result = DocumentTreeFactory.GetTreeDocument(handler : handler,  documentListName :  documentListName,  documentName :  documentName,  includeInactive :  includeInactive,  responseFields :  responseFields,  dataViewMode: dataViewMode,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Document/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static Mozu.Api.Contracts.Content.Document GetTreeDocument(ServiceClientMessageHandler handler, 
 		 string documentListName, string documentName, bool? includeInactive = null, string responseFields = null,  DataViewMode dataViewMode= DataViewMode.Live, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Content.Documentlists.DocumentTreeClient.GetTreeDocumentClient(
				 documentListName :  documentListName,  documentName :  documentName,  includeInactive :  includeInactive,  responseFields :  responseFields, dataViewMode: dataViewMode		);
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
		/// var result = DocumentTreeFactory.UpdateTreeDocumentContent(handler : handler,  stream :  stream,  documentListName :  documentListName,  documentName :  documentName,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Stream/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static System.IO.Stream UpdateTreeDocumentContent(ServiceClientMessageHandler handler, 
 		 System.IO.Stream stream, string documentListName, string documentName, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Content.Documentlists.DocumentTreeClient.UpdateTreeDocumentContentClient(
				 stream :  stream,  documentListName :  documentListName,  documentName :  documentName		);
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
		/// var result = DocumentTreeFactory.DeleteTreeDocumentContent(handler : handler,  stream :  stream,  documentListName :  documentListName,  documentName :  documentName,  expectedCode: expectedCode, successCode: successCode); 
		/// var optionalCasting = ConvertClass<Stream/>(result); 
		/// return optionalCasting;
		///  </code> 
		/// </example> 
		/// </summary>
		public static System.IO.Stream DeleteTreeDocumentContent(ServiceClientMessageHandler handler, 
 		 System.IO.Stream stream, string documentListName, string documentName, 
		 HttpStatusCode expectedCode = HttpStatusCode.OK, HttpStatusCode successCode = HttpStatusCode.OK)
		{
			SetSdKparameters();
			var currentClassName = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name;
			var currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			Debug.WriteLine(currentMethodName  + '.' + currentMethodName );
			var apiClient = Mozu.Api.Clients.Content.Documentlists.DocumentTreeClient.DeleteTreeDocumentContentClient(
				 stream :  stream,  documentListName :  documentListName,  documentName :  documentName		);
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


