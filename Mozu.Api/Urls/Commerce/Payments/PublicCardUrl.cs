
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

namespace Mozu.Api.Urls.Commerce.Payments
{
	public partial class PublicCardUrl 
	{

				/// <summary>
        /// Get Resource Url for Create
        /// </summary>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl CreateUrl(string responseFields =  null)
		{
			var url = "/payments/commerce/payments/cards/?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.PCI_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetGiftCardBalance
        /// </summary>
        /// <param name="cardId">Unique identifier of the card associated with the customer account billing contact.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetGiftCardBalanceUrl(string cardId, string responseFields =  null)
		{
			var url = "/payments/commerce/payments/cards/{cardId}/balance?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.PCI_POD, false) ;
			mozuUrl.FormatUrl( "cardId", cardId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetUnregisteredGiftCardBalance
        /// </summary>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetUnregisteredGiftCardBalanceUrl(string responseFields =  null)
		{
			var url = "/payments/commerce/payments/cards/balance?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.PCI_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for Update
        /// </summary>
        /// <param name="cardId">Unique identifier of the card associated with the customer account billing contact.</param>
        /// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateUrl(string cardId, string responseFields =  null)
		{
			var url = "/payments/commerce/payments/cards/{cardId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.PCI_POD, false) ;
			mozuUrl.FormatUrl( "cardId", cardId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for Delete
        /// </summary>
        /// <param name="cardId">Unique identifier of the card associated with the customer account billing contact.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteUrl(string cardId)
		{
			var url = "/payments/commerce/payments/cards/{cardId}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.PCI_POD, false) ;
			mozuUrl.FormatUrl( "cardId", cardId);
			return mozuUrl;
		}

		
	}
}

