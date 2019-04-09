
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

namespace Mozu.Api.Urls.Commerce.Orders
{
	public partial class OrderItemUrl 
	{

		/// <summary>
        /// Get Resource Url for GetOrderItemViaLineId
        /// </summary>
        /// <param name="draft"></param>
        /// <param name="lineId"></param>
        /// <param name="orderId"></param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetOrderItemViaLineIdUrl(string orderId, int lineId, bool? draft =  null, string responseFields =  null)
		{
			var url = "/api/commerce/orders/{orderId}/items/{lineId}?draft={draft}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "draft", draft);
			mozuUrl.FormatUrl( "lineId", lineId);
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetOrderItem
        /// </summary>
        /// <param name="draft">If true, retrieve the draft version of this order item, which might include uncommitted changes to the order item, the order, or other order components.</param>
        /// <param name="orderId">Unique identifier of the order item to retrieve.</param>
        /// <param name="orderItemId">Unique identifier of the order item details to retrieve.</param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetOrderItemUrl(string orderId, string orderItemId, bool? draft =  null, string responseFields =  null)
		{
			var url = "/api/commerce/orders/{orderId}/items/{orderItemId}?draft={draft}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "draft", draft);
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "orderItemId", orderItemId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for GetOrderItems
        /// </summary>
        /// <param name="draft">If true, retrieve the draft version of the order's items, which might include uncommitted changes to one or more order items, the order itself, or other order components.</param>
        /// <param name="orderId">Unique identifier of the order items to retrieve.</param>
        /// <param name="responseFields"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl GetOrderItemsUrl(string orderId, bool? draft =  null, string responseFields =  null)
		{
			var url = "/api/commerce/orders/{orderId}/items?draft={draft}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "draft", draft);
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for CreateOrderItem
        /// </summary>
        /// <param name="orderId">Unique identifier of the order for which to add the item.</param>
        /// <param name="responseFields"></param>
        /// <param name="skipInventoryCheck">If true, do not validate the product inventory when adding this item to the order.</param>
        /// <param name="updateMode">Specifies whether to add the item by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
        /// <param name="version"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl CreateOrderItemUrl(string orderId, string updateMode =  null, string version =  null, bool? skipInventoryCheck =  null, string responseFields =  null)
		{
			var url = "/api/commerce/orders/{orderId}/items?updatemode={updateMode}&version={version}&skipInventoryCheck={skipInventoryCheck}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "skipInventoryCheck", skipInventoryCheck);
			mozuUrl.FormatUrl( "updateMode", updateMode);
			mozuUrl.FormatUrl( "version", version);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for UpdateOrderItemDiscount
        /// </summary>
        /// <param name="discountId">Unique identifier of the discount. System-supplied and read only.</param>
        /// <param name="orderId">Unique identifier of the order associated with the item discount.</param>
        /// <param name="orderItemId">Unique identifier of the item in the order.</param>
        /// <param name="responseFields"></param>
        /// <param name="updateMode">Specifies whether to change the item discount by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
        /// <param name="version"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateOrderItemDiscountUrl(string orderId, string orderItemId, int discountId, string updateMode =  null, string version =  null, string responseFields =  null)
		{
			var url = "/api/commerce/orders/{orderId}/items/{orderItemId}/discounts/{discountId}?updatemode={updateMode}&version={version}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "discountId", discountId);
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "orderItemId", orderItemId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "updateMode", updateMode);
			mozuUrl.FormatUrl( "version", version);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for UpdateItemDuty
        /// </summary>
        /// <param name="dutyAmount"></param>
        /// <param name="orderId"></param>
        /// <param name="orderItemId"></param>
        /// <param name="responseFields"></param>
        /// <param name="updateMode"></param>
        /// <param name="version"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateItemDutyUrl(string orderId, string orderItemId, decimal dutyAmount, string updateMode =  null, string version =  null, string responseFields =  null)
		{
			var url = "/api/commerce/orders/{orderId}/items/{orderItemId}/dutyAmount/{dutyAmount}?updatemode={updateMode}&version={version}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "dutyAmount", dutyAmount);
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "orderItemId", orderItemId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "updateMode", updateMode);
			mozuUrl.FormatUrl( "version", version);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for UpdateItemFulfillment
        /// </summary>
        /// <param name="orderId">Unique identifier of the order.</param>
        /// <param name="orderItemId">Unique identifier of the item in the order.</param>
        /// <param name="responseFields"></param>
        /// <param name="updateMode">Specifies whether to apply the coupon by updating the original order, updating the order in draft mode, or updating the order in draft mode and then commit the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
        /// <param name="version"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateItemFulfillmentUrl(string orderId, string orderItemId, string updateMode =  null, string version =  null, string responseFields =  null)
		{
			var url = "/api/commerce/orders/{orderId}/items/{orderItemId}/fulfillment?updatemode={updateMode}&version={version}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "orderItemId", orderItemId);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "updateMode", updateMode);
			mozuUrl.FormatUrl( "version", version);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for UpdateItemProductPrice
        /// </summary>
        /// <param name="orderId">Unique identifier of the order containing the item to price override.</param>
        /// <param name="orderItemId">Unique identifier of the item in the order to price override.</param>
        /// <param name="price">The override price to specify for this item in the specified order.</param>
        /// <param name="responseFields"></param>
        /// <param name="updateMode">Specifies whether to change the product price by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
        /// <param name="version"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateItemProductPriceUrl(string orderId, string orderItemId, decimal price, string updateMode =  null, string version =  null, string responseFields =  null)
		{
			var url = "/api/commerce/orders/{orderId}/items/{orderItemId}/price/{price}?updatemode={updateMode}&version={version}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "orderItemId", orderItemId);
			mozuUrl.FormatUrl( "price", price);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "updateMode", updateMode);
			mozuUrl.FormatUrl( "version", version);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for CancelItem
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderItemId"></param>
        /// <param name="quantity"></param>
        /// <param name="responseFields"></param>
        /// <param name="sendEmail"></param>
        /// <param name="updateFulfillment"></param>
        /// <param name="updateMode"></param>
        /// <param name="version"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl CancelItemUrl(string orderId, string orderItemId, int quantity, string updateMode =  null, string version =  null, bool? updateFulfillment =  null, bool? sendEmail =  null, string responseFields =  null)
		{
			var url = "/api/commerce/orders/{orderId}/items/{orderItemId}/quantity/{quantity}/cancel?updatemode={updateMode}&version={version}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "orderItemId", orderItemId);
			mozuUrl.FormatUrl( "quantity", quantity);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "sendEmail", sendEmail);
			mozuUrl.FormatUrl( "updateFulfillment", updateFulfillment);
			mozuUrl.FormatUrl( "updateMode", updateMode);
			mozuUrl.FormatUrl( "version", version);
			return mozuUrl;
		}

		/// <summary>
        /// Get Resource Url for UpdateItemQuantity
        /// </summary>
        /// <param name="orderId">Unique identifier of the order containing the item to update quantity.</param>
        /// <param name="orderItemId">Unique identifier of the item in the order to update quantity.</param>
        /// <param name="quantity">The quantity of the item in the order to update.</param>
        /// <param name="responseFields"></param>
        /// <param name="updateMode">Specifies whether to change the item quantity by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
        /// <param name="version"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl UpdateItemQuantityUrl(string orderId, string orderItemId, int quantity, string updateMode =  null, string version =  null, string responseFields =  null)
		{
			var url = "/api/commerce/orders/{orderId}/items/{orderItemId}/quantity/{quantity}?updatemode={updateMode}&version={version}&responseFields={responseFields}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "orderItemId", orderItemId);
			mozuUrl.FormatUrl( "quantity", quantity);
			mozuUrl.FormatUrl( "responseFields", responseFields);
			mozuUrl.FormatUrl( "updateMode", updateMode);
			mozuUrl.FormatUrl( "version", version);
			return mozuUrl;
		}

				/// <summary>
        /// Get Resource Url for DeleteOrderItem
        /// </summary>
        /// <param name="orderId">Unique identifier of the order with the item to remove.</param>
        /// <param name="orderItemId">Unique identifier of the item to remove from the order.</param>
        /// <param name="updateMode">Specifies whether to remove the item by updating the original order, updating the order in draft mode, or updating the order in draft mode and then committing the changes to the original. Draft mode enables users to make incremental order changes before committing the changes to the original order. Valid values are "ApplyToOriginal," "ApplyToDraft," or "ApplyAndCommit."</param>
        /// <param name="version"></param>
        /// <returns>
        /// String - Resource Url
        /// </returns>
        public static MozuUrl DeleteOrderItemUrl(string orderId, string orderItemId, string updateMode =  null, string version =  null)
		{
			var url = "/api/commerce/orders/{orderId}/items/{orderItemId}?updatemode={updateMode}&version={version}";
			var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false) ;
			mozuUrl.FormatUrl( "orderId", orderId);
			mozuUrl.FormatUrl( "orderItemId", orderItemId);
			mozuUrl.FormatUrl( "updateMode", updateMode);
			mozuUrl.FormatUrl( "version", version);
			return mozuUrl;
		}

		
	}
}

