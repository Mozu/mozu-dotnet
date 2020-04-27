
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Mozu.Api.Urls.Content
{
	public partial class DocumentDraftSummaryUrl 
	{

		/// <summary>
        /// Get Resource Url for ListDocumentDraftSummaries
        /// </summary>
        /// <param name="documentLists">List of document lists that contain documents to delete.</param>
        /// <param name="pageSize">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with this parameter set to 25, to get the 51st through the 75th items, set startIndex to 50.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <param name="startIndex">When creating paged results from a query, this value indicates the zero-based offset in the complete result set where the returned entities begin. For example, with pageSize set to 25, to get the 51st through the 75th items, set this parameter to 50.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl ListDocumentDraftSummariesUrl(int? pageSize =  null, int? startIndex =  null, string documentLists =  null, string responseFields =  null)
		{
			var url = "/api/content/documentpublishing/draft?pageSize={pageSize}&startIndex={startIndex}&documentLists={documentLists}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "documentLists", documentLists);
			mozuUrl.FormatUrl( "pageSize", pageSize);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "startIndex", startIndex);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteDocumentDrafts
        /// </summary>
        /// <param name="documentLists">List of document lists that contain documents to delete.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteDocumentDraftsUrl(string documentLists =  null)
		{
			var url = "/api/content/documentpublishing/draft?documentLists={documentLists}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "documentLists", documentLists);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for PublishDocuments
        /// </summary>
        /// <param name="documentLists">List of document lists that contain documents to delete.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl PublishDocumentsUrl(string documentLists =  null)
		{
			var url = "/api/content/documentpublishing/active?documentLists={documentLists}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "documentLists", documentLists);
			return mozuUrl;
		}

				
	}
}

