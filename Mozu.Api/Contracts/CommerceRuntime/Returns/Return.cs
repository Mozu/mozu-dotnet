
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

using Mozu.Api.Contracts.CommerceRuntime.Commerce;
using Mozu.Api.Contracts.CommerceRuntime.Fulfillment;
using Mozu.Api.Contracts.CommerceRuntime.Orders;
using Mozu.Api.Contracts.CommerceRuntime.Payments;
using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.CommerceRuntime.Returns
{
		///
		///	Properties of a return of one or more previously fulfilled items.
		///
		public class Return
		{
			public bool ActionRequired { get; set; }

			public AuditInfo AuditInfo { get; set; }

			public List<string> AvailableActions { get; set; }

			///
			///Collection (list or paged) of change messages logged for each modification made by a shopper to their carts, wishlists, orders, package, payment, pickup, and returns. Change log messages are system-supplied based on shopper actions and read only.
			///
			public List<ChangeMessage> ChangeMessages { get; set; }

			public string ChannelCode { get; set; }

			///
			///contact ApiType DOCUMENT_HERE 
			///
			public Contact Contact { get; set; }

			public string CurrencyCode { get; set; }

			public int? CustomerAccountId { get; set; }

			public string CustomerInteractionType { get; set; }

			public string Id { get; set; }

			public bool IsUnified { get; set; }

			public List<ReturnItem> Items { get; set; }

			public string LocationCode { get; set; }

			public decimal? LossTotal { get; set; }

			public List<OrderNote> Notes { get; set; }

			public string OriginalOrderId { get; set; }

			///
			///The order number of the original order where the return was created.
			///
			public int? OriginalOrderNumber { get; set; }

			public List<Package> Packages { get; set; }

			public List<Payment> Payments { get; set; }

			public decimal? ProductLossTaxTotal { get; set; }

			public decimal? ProductLossTotal { get; set; }

			///
			///The status that indicates whether you have received the return item from the shopper. The accepted values are , , or .
			///
			public string ReceiveStatus { get; set; }

			public decimal? RefundAmount { get; set; }

			///
			///The status of the refund. The accepted values are  if the shopper only wants a replacement or  if either a partial or full refund is applied to the return.
			///
			public string RefundStatus { get; set; }

			///
			///The status of the replacement order. The accepted values are  if there is no replacement order or  if a replacement order exits.
			///
			public string ReplaceStatus { get; set; }

			public int? ReturnNumber { get; set; }

			public string ReturnOrderId { get; set; }

			public string ReturnType { get; set; }

			public DateTime? RmaDeadline { get; set; }

			public decimal? ShippingLossTaxTotal { get; set; }

			public decimal? ShippingLossTotal { get; set; }

			public int? SiteId { get; set; }

			public string Status { get; set; }

			public int? TenantId { get; set; }

			public string UserId { get; set; }

			public string VisitId { get; set; }

			public string WebSessionId { get; set; }

		}

}