
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


namespace Mozu.Api.Contracts.Kibo.Fulfillment.Model
{
		public class ResourceOfShipment
		{
			public DateTime? AcceptedDate { get; set; }

			public Dictionary<String,Object> Attributes { get; set; }

			public AuditInfo AuditInfo { get; set; }

			public List<CanceledItem> CanceledItems { get; set; }

			public List<ChangeMessage> ChangeMessages { get; set; }

			public List<int> ChildShipmentNumbers { get; set; }

			public string CurrencyCode { get; set; }

			public int? CustomerAccountId { get; set; }

			public int? CustomerAddressId { get; set; }

			public string CustomerTaxId { get; set; }

			public object Data { get; set; }

			public Destination Destination { get; set; }

			public decimal? DutyAdjustment { get; set; }

			public decimal? DutyTotal { get; set; }

			public string Email { get; set; }

			public string ExternalShipmentId { get; set; }

			public DateTime? FulfillmentDate { get; set; }

			public string FulfillmentLocationCode { get; set; }

			public string FulfillmentStatus { get; set; }

			public decimal? HandlingAdjustment { get; set; }

			public decimal? HandlingSubtotal { get; set; }

			public decimal? HandlingTaxAdjustment { get; set; }

			public decimal? HandlingTaxTotal { get; set; }

			public decimal? HandlingTotal { get; set; }

			public bool? HasLabel { get; set; }

			public List<Item> Items { get; set; }

			public decimal? LineItemSubtotal { get; set; }

			public decimal? LineItemTaxAdjustment { get; set; }

			public decimal? LineItemTaxTotal { get; set; }

			public decimal? LineItemTotal { get; set; }

			public Dictionary<String,Link> Links { get; set; }

			public string OrderId { get; set; }

			public int? OrderNumber { get; set; }

			public DateTime? OrderSubmitDate { get; set; }

			public string OriginalOrderId { get; set; }

			public int? OriginalShipmentNumber { get; set; }

			public List<Package> Packages { get; set; }

			public int? ParentShipmentNumber { get; set; }

			public string PickStatus { get; set; }

			public string PickType { get; set; }

			public bool? ReadyForPickup { get; set; }

			public DateTime? ReadyForPickupDate { get; set; }

			public List<ReassignItem> ReassignedItems { get; set; }

			public decimal? ShipmentAdjustment { get; set; }

			public int? ShipmentNumber { get; set; }

			public string ShipmentStatus { get; set; }

			public ShipmentStatusReason ShipmentStatusReason { get; set; }

			public string ShipmentType { get; set; }

			public decimal? ShippingAdjustment { get; set; }

			public string ShippingMethodCode { get; set; }

			public string ShippingMethodName { get; set; }

			public decimal? ShippingSubtotal { get; set; }

			public decimal? ShippingTaxAdjustment { get; set; }

			public decimal? ShippingTaxTotal { get; set; }

			public decimal? ShippingTotal { get; set; }

			public bool? SignatureRequired { get; set; }

			public int? SiteId { get; set; }

			public object TaxData { get; set; }

			public int? TenantId { get; set; }

			public decimal? Total { get; set; }

			public List<string> TrackingNumbers { get; set; }

			public WorkflowState WorkflowState { get; set; }

		}

}