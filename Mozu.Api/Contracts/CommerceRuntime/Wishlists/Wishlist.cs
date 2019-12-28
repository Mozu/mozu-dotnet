
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
using Newtonsoft.Json.Linq;

using Mozu.Api.Contracts.CommerceRuntime.Commerce;
using Mozu.Api.Contracts.CommerceRuntime.Discounts;
using Mozu.Api.Contracts.CommerceRuntime.Fulfillment;
using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.CommerceRuntime.Wishlists
{
		///
		///	Properties of a shopper wish list defined for a site, associated with a customer account.
		///
		public class Wishlist
		{
			public AuditInfo AuditInfo { get; set; }

			public List<ChangeMessage> ChangeMessages { get; set; }

			public string ChannelCode { get; set; }

			public string CurrencyCode { get; set; }

			public int? CustomerAccountId { get; set; }

			public string CustomerInteractionType { get; set; }

			public JObject Data { get; set; }

			public decimal? DiscountedSubtotal { get; set; }

			public decimal? DiscountedTotal { get; set; }

			public decimal? DiscountTotal { get; set; }

			public DateTime? ExpirationDate { get; set; }

			public List<ExtendedProperty> ExtendedProperties { get; set; }

			///
			///The identifier an external program uses to identify the Mozu wish list.
			///
			public string ExternalId { get; set; }

			public decimal? FeeTotal { get; set; }

			public FulfillmentInfo FulfillmentInfo { get; set; }

			public decimal? HandlingTaxTotal { get; set; }

			public string Id { get; set; }

			///
			///If this wish list was imported from an external program, the date and time the wish list was imported.
			///
			public DateTime? ImportDate { get; set; }

			///
			///If true, this wish list was imported from an external program.
			///
			public bool? IsImport { get; set; }

			public List<WishlistItem> Items { get; set; }

			public decimal? ItemTaxTotal { get; set; }

			public DateTime? LastValidationDate { get; set; }

			public decimal? LineItemSubtotalWithOrderAdjustments { get; set; }

			public string Name { get; set; }

			public List<AppliedDiscount> OrderDiscounts { get; set; }

			public string PrivacyType { get; set; }

			public decimal? ShippingAmountBeforeDiscountsAndAdjustments { get; set; }

			public decimal? ShippingSubTotal { get; set; }

			public decimal? ShippingTaxTotal { get; set; }

			public decimal? ShippingTotal { get; set; }

			public int? SiteId { get; set; }

			public int? SortOrder { get; set; }

			public decimal? Subtotal { get; set; }

			public List<SuggestedDiscount> SuggestedDiscounts { get; set; }

			public JObject TaxData { get; set; }

			public decimal? TaxTotal { get; set; }

			public int? TenantId { get; set; }

			public decimal? Total { get; set; }

			public string TypeTag { get; set; }

			public string Version { get; set; }

			public string VisitId { get; set; }

			public string WebSessionId { get; set; }

		}

}