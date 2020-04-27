
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
using System.Threading;

namespace Mozu.Api.Clients.Content
{
	/// <summary>
	/// Use the Document List Types resource to manage the types of document lists in your site's document hierarchy. The type denotes a content type for that list of folders, sub-folders, and documents such as `web_pages`.
	/// </summary>
	public partial class DocumentListTypeClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Content.DocumentListTypeCollection"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetDocumentListTypes(dataViewMode,  pageSize,  startIndex,  responseFields);
		///   var documentListTypeCollectionClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Content.DocumentListTypeCollection> GetDocumentListTypesClient(DataViewMode dataViewMode, int? pageSize =  null, int? startIndex =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Content.DocumentListTypeUrl.GetDocumentListTypesUrl(pageSize, startIndex, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Content.DocumentListTypeCollection>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="documentListTypeFQN"></param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Content.DocumentListType"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=GetDocumentListType(dataViewMode,  documentListTypeFQN,  responseFields);
		///   var documentListTypeClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Content.DocumentListType> GetDocumentListTypeClient(DataViewMode dataViewMode, string documentListTypeFQN, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Content.DocumentListTypeUrl.GetDocumentListTypeUrl(documentListTypeFQN, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Content.DocumentListType>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="list">Properties for the document list type. Document lists contain documents with an associated document type, such as web pages.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Content.DocumentListType"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=CreateDocumentListType(dataViewMode,  list,  responseFields);
		///   var documentListTypeClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Content.DocumentListType> CreateDocumentListTypeClient(DataViewMode dataViewMode, Mozu.Api.Contracts.Content.DocumentListType list, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Content.DocumentListTypeUrl.CreateDocumentListTypeUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Content.DocumentListType>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Content.DocumentListType>(list)									.WithHeader(Headers.X_VOL_DATAVIEW_MODE ,dataViewMode.ToString())
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="documentListTypeFQN"></param>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="list">Properties for the document list type. Document lists contain documents with an associated document type, such as web pages.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Content.DocumentListType"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=UpdateDocumentListType( list,  documentListTypeFQN,  responseFields);
		///   var documentListTypeClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Content.DocumentListType> UpdateDocumentListTypeClient(Mozu.Api.Contracts.Content.DocumentListType list, string documentListTypeFQN, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Content.DocumentListTypeUrl.UpdateDocumentListTypeUrl(documentListTypeFQN, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Content.DocumentListType>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Content.DocumentListType>(list);
			return mozuClient;

		}


	}

}


