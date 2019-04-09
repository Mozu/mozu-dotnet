
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

namespace Mozu.Api.Urls.Commerce
{
	public partial class ReturnUrl 
	{

		/// <summary>
        /// Get Resource Url for GetReturns
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageSize"></param>
        /// <param name="q"></param>
        /// <param name="responseFields"></param>
        /// <param name="sortBy"></param>
        /// <param name="startIndex"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetReturnsUrl(int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, string q =  null, string responseFields =  null)
		{
			var url = "/api/commerce/returns/?startIndex={startIndex}&pageSize={pageSize}&sortBy={sortBy}&filter={filter}&q={q}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "filter", filter);
			mozuUrl.FormatUrl( "pageSize", pageSize);
			mozuUrl.FormatUrl( "q", q);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "sortBy", sortBy);
			mozuUrl.FormatUrl( "startIndex", startIndex);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetAvailableReturnActions
        /// </summary>
        /// <param name="returnId">Unique identifier of the return for which to retrieve available actions.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetAvailableReturnActionsUrl(string returnId)
		{
			var url = "/api/commerce/returns/{returnId}/actions";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetReturnItem
        /// </summary>
        /// <param name="responseFields"></param>
        /// <param name="returnId"></param>
        /// <param name="returnItemId"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetReturnItemUrl(string returnId, string returnItemId, string responseFields =  null)
		{
			var url = "/api/commerce/returns/{returnId}/items/{returnItemId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "returnId", returnId);
			mozuUrl.FormatUrl( "returnItemId", returnItemId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetReturnItems
        /// </summary>
        /// <param name="responseFields"></param>
        /// <param name="returnId"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetReturnItemsUrl(string returnId, string responseFields =  null)
		{
			var url = "/api/commerce/returns/{returnId}/items?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetAvailablePaymentActionsForReturn
        /// </summary>
        /// <param name="paymentId">Unique identifier of the payment for which to perform the action.</param>
        /// <param name="returnId">Unique identifier of the return associated with the payment.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetAvailablePaymentActionsForReturnUrl(string returnId, string paymentId)
		{
			var url = "/api/commerce/returns/{returnId}/payments/{paymentId}/actions";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "paymentId", paymentId);
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetPayment
        /// </summary>
        /// <param name="paymentId">Unique identifier of the return payment to retrieve.</param>
        /// <param name="responseFields"></param>
        /// <param name="returnId">Unique identifier of the return associated with the payment.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetPaymentUrl(string returnId, string paymentId, string responseFields =  null)
		{
			var url = "/api/commerce/returns/{returnId}/payments/{paymentId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "paymentId", paymentId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetPayments
        /// </summary>
        /// <param name="responseFields"></param>
        /// <param name="returnId">Returns the details of the refund payment associated with the return specified in the request.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetPaymentsUrl(string returnId, string responseFields =  null)
		{
			var url = "/api/commerce/returns/{returnId}/payments?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetReturn
        /// </summary>
        /// <param name="responseFields"></param>
        /// <param name="returnId">Returns the properties of the return specified in the request as well as system-supplied information.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetReturnUrl(string returnId, string responseFields =  null)
		{
			var url = "/api/commerce/returns/{returnId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetReasons
        /// </summary>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetReasonsUrl(string responseFields =  null)
		{
			var url = "/api/commerce/returns/reasons?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for CreateReturn
        /// </summary>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl CreateReturnUrl(string responseFields =  null)
		{
			var url = "/api/commerce/returns/?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for CreateReturnItem
        /// </summary>
        /// <param name="responseFields"></param>
        /// <param name="returnId"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl CreateReturnItemUrl(string returnId, string responseFields =  null)
		{
			var url = "/api/commerce/returns/{returnId}/items?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for PerformPaymentActionForReturn
        /// </summary>
        /// <param name="paymentId">Unique identifier of the return payment to update.</param>
        /// <param name="responseFields"></param>
        /// <param name="returnId">Unique identifier of the return associated with the refund payment.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl PerformPaymentActionForReturnUrl(string returnId, string paymentId, string responseFields =  null)
		{
			var url = "/api/commerce/returns/{returnId}/payments/{paymentId}/actions?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "paymentId", paymentId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for CreatePaymentActionForReturn
        /// </summary>
        /// <param name="responseFields"></param>
        /// <param name="returnId">Unique identifier of the return associated with the payment action.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl CreatePaymentActionForReturnUrl(string returnId, string responseFields =  null)
		{
			var url = "/api/commerce/returns/{returnId}/payments/actions?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for CreateReturnShippingOrder
        /// </summary>
        /// <param name="responseFields"></param>
        /// <param name="returnId"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl CreateReturnShippingOrderUrl(string returnId, string responseFields =  null)
		{
			var url = "/api/commerce/returns/{returnId}/ship?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for PerformReturnActions
        /// </summary>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl PerformReturnActionsUrl(string responseFields =  null)
		{
			var url = "/api/commerce/returns/actions?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdateReturn
        /// </summary>
        /// <param name="responseFields"></param>
        /// <param name="returnId">Unique identifier of the return.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateReturnUrl(string returnId, string responseFields =  null)
		{
			var url = "/api/commerce/returns/{returnId}?responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for ResendReturnEmail
        /// </summary>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl ResendReturnEmailUrl()
		{
			var url = "/api/commerce/returns/email/resend";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteOrderItem
        /// </summary>
        /// <param name="returnId"></param>
        /// <param name="returnItemId"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteOrderItemUrl(string returnId, string returnItemId)
		{
			var url = "/api/commerce/returns/{orderId}/items/{orderItemId}?updatemode={updateMode}&version={version}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "returnId", returnId);
			mozuUrl.FormatUrl( "returnItemId", returnItemId);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for DeleteReturn
        /// </summary>
        /// <param name="returnId">Unique identifier of the return to delete.</param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteReturnUrl(string returnId)
		{
			var url = "/api/commerce/returns/{returnId}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "returnId", returnId);
			return mozuUrl;
		}

		
	}
}

