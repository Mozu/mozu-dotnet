
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Mozu.Api.Security;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mozu.Api.Clients.Content.Documentlists
{
	/// <summary>
	/// Use the document tree subresource to retrieve documents and manage content within the document hierarchy.
	/// </summary>
	public partial class DocumentTreeClient 	{
		
		/// <summary>
		/// Retrieve the content associated with the document, such as a product image or PDF specifications file.
		/// </summary>
		/// <param name="documentListName">Name of content documentListName to delete</param>
		/// <param name="documentName">The name of the document in the site.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetTreeDocumentContent(dataViewMode,  documentListName,  documentName);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> GetTreeDocumentContentClient(DataViewMode dataViewMode, string documentListName, string documentName)
		{
			var url = Mozu.Api.Urls.Content.Documentlists.DocumentTreeUrl.GetTreeDocumentContentUrl(documentListName, documentName);
			const string verb = "GET";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="crop"></param>
		/// <param name="documentListName"></param>
		/// <param name="documentName"></param>
		/// <param name="height"></param>
		/// <param name="max"></param>
		/// <param name="maxHeight"></param>
		/// <param name="maxWidth"></param>
		/// <param name="quality"></param>
		/// <param name="width"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=TransformTreeDocumentContent( documentListName,  documentName,  width,  height,  max,  maxWidth,  maxHeight,  crop,  quality);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> TransformTreeDocumentContentClient(string documentListName, string documentName, int? width =  null, int? height =  null, int? max =  null, int? maxWidth =  null, int? maxHeight =  null, string crop =  null, int? quality =  null)
		{
			var url = Mozu.Api.Urls.Content.Documentlists.DocumentTreeUrl.TransformTreeDocumentContentUrl(documentListName, documentName, width, height, max, maxWidth, maxHeight, crop, quality);
			const string verb = "GET";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// Retrieves a document based on its document list and folder path in the document hierarchy.
		/// </summary>
		/// <param name="documentListName">Name of content documentListName to delete</param>
		/// <param name="documentName">The name of the document in the site.</param>
		/// <param name="includeInactive"></param>
		/// <param name="responseFields">Use this field to include those fields which are not included by default.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Content.Document"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetTreeDocument(dataViewMode,  documentListName,  documentName,  includeInactive,  responseFields);
		///   var documentClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Content.Document> GetTreeDocumentClient(DataViewMode dataViewMode, string documentListName, string documentName, bool? includeInactive =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Content.Documentlists.DocumentTreeUrl.GetTreeDocumentUrl(documentListName, documentName, includeInactive, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Content.Document>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// Updates the content associated with a document, such as a product image or PDF specifications file, based on the document's position in the document hierarchy.
		/// </summary>
		/// <param name="documentListName">Name of content documentListName to delete</param>
		/// <param name="documentName">The name of the document in the site.</param>
		/// <param name="stream">Data stream that delivers information. Used to input and output data.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateTreeDocumentContent( stream,  documentListName,  documentName,  contentType);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient UpdateTreeDocumentContentClient(System.IO.Stream stream, string documentListName, string documentName, String  contentType= null)
		{
			var url = Mozu.Api.Urls.Content.Documentlists.DocumentTreeUrl.UpdateTreeDocumentContentUrl(documentListName, documentName);
			const string verb = "PUT";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody(stream)									.WithHeader(Headers.CONTENT_TYPE ,contentType)
;
			return mozuClient;

		}

		/// <summary>
		/// Deletes the content associated with a document, such as a product image or PDF specifications file.
		/// </summary>
		/// <param name="documentListName">Name of content documentListName to delete</param>
		/// <param name="documentName">The name of the document in the site.</param>
		/// <param name="stream">Data stream that delivers information. Used to input and output data.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteTreeDocumentContent( stream,  documentListName,  documentName,  contentType);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient DeleteTreeDocumentContentClient(System.IO.Stream stream, string documentListName, string documentName, String  contentType= null)
		{
			var url = Mozu.Api.Urls.Content.Documentlists.DocumentTreeUrl.DeleteTreeDocumentContentUrl(documentListName, documentName);
			const string verb = "DELETE";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody(stream)									.WithHeader(Headers.CONTENT_TYPE ,contentType)
;
			return mozuClient;

		}


	}

}


