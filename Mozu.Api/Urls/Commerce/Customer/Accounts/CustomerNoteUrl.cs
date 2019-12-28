
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

namespace Mozu.Api.Urls.Commerce.Customer.Accounts
{
	public partial class CustomerNoteUrl 
	{

		/// <summary>
        /// Get Resource Url for GetAccountNote
        /// </summary>
        /// <param name="accountId">Unique identifier of the customer account that contains the note being retrieved.</param>
        /// <param name="noteId">Unique identifier of a particular note to retrieve.</param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetAccountNoteUrl(int accountId, int noteId, string responseFields =  null)
		{
			var url = "/api/commerce/customer/accounts/{accountId}/notes/{noteId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "accountId", accountId);
			mozuUrl.FormatUrl( "noteId", noteId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetAccountNotes
        /// </summary>
        /// <param name="accountId">Unique identifier of the customer account.</param>
        /// <param name="filter"></param>
        /// <param name="pageSize"></param>
        /// <param name="responseFields"></param>
        /// <param name="sortBy"></param>
        /// <param name="startIndex"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetAccountNotesUrl(int accountId, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string responseFields =  null)
		{
			var url = "/api/commerce/customer/accounts/{accountId}/notes?startIndex={startIndex}&pageSize={pageSize}&sortBy={sortBy}&filter={filter}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "accountId", accountId);
			mozuUrl.FormatUrl( "filter", filter);
			mozuUrl.FormatUrl( "pageSize", pageSize);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "sortBy", sortBy);
			mozuUrl.FormatUrl( "startIndex", startIndex);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for AddAccountNote
        /// </summary>
        /// <param name="accountId">Unique identifier of the customer account for which to create the note.</param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl AddAccountNoteUrl(int accountId, string responseFields =  null)
		{
			var url = "/api/commerce/customer/accounts/{accountId}/notes?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "accountId", accountId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdateAccountNote
        /// </summary>
        /// <param name="accountId">Unique identifier of the customer account note to modify.</param>
        /// <param name="noteId">Unique identifier of the note to update.</param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateAccountNoteUrl(int accountId, int noteId, string responseFields =  null)
		{
			var url = "/api/commerce/customer/accounts/{accountId}/notes/{noteId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "accountId", accountId);
			mozuUrl.FormatUrl( "noteId", noteId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteAccountNote
        /// </summary>
        /// <param name="accountId">Unique identifier of the customer account that contains the note being deleted.</param>
        /// <param name="noteId">Unique identifier of the customer account note being deleted.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteAccountNoteUrl(int accountId, int noteId)
		{
			var url = "/api/commerce/customer/accounts/{accountId}/notes/{noteId}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "accountId", accountId);
			mozuUrl.FormatUrl( "noteId", noteId);
			return mozuUrl;
		}

		
	}
}

