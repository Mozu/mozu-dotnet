
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.CommerceRuntime.Orders
{
		///
		///	Mozu.CommerceRuntime.Contracts.Orders.OrderReturnableItem ApiType DOCUMENT_HERE 
		///
		public class OrderReturnableItem
		{
			///
			///The fulfillment status of the item, which is one of the following values:* * 
			///
			public string FulfillmentStatus { get; set; }

			///
			///Unique identifier of the order item associated with a validation message, order, or return.
			///
			public string OrderItemId { get; set; }

			///
			///The fully-qualified name of an attribute option on the item if it has an extra. For bundle items, this property is null.
			///
			public string OrderItemOptionAttributeFQN { get; set; }

			///
			///The unique identifier of the line number associated with the item.
			///
			public int OrderLineId { get; set; }

			///
			///The product code of the parent item, if applicable. For example, a product bundle is the parent of the items in the bundle, and a product is the parent of a product extra.
			///
			public string ParentProductCode { get; set; }

			///
			///The name of the parent item, if applicable. For example, a product bundle is the parent of the items in the bundle, and a product is the parent of a product extra.
			///
			public string ParentProductName { get; set; }

			///
			///The unique, user-defined product code of a product, used throughout  to reference and associate to a product.
			///
			public string ProductCode { get; set; }

			///
			///The name of the product that represents a line item in a taxable order or product bundle.
			///
			public string ProductName { get; set; }

			///
			///The quantity that has been fulfilled for the given line item. An item must be fulfilled before it is returnable. If an order contains Product X with a quantity of 3, and the quantity fulfilled is 2, then two Product X items are returnable (assuming all other return conditions are met).
			///
			public int QuantityFulfilled { get; set; }

			///
			///The total quantity of an item on the order.
			///
			public int QuantityOrdered { get; set; }

			///
			///The quantity of a given item that is eligible for return. This number may be smaller than the quantity ordered, and changes depending on the actions taken on the return. For example, if an order contains five of Product X, but only three of those items are fulfilled, then only three items show as returnable (assuming all other return conditions are met).
			///
			public int QuantityReturnable { get; set; }

			public int QuantityReturned { get; set; }

			public int? ShipmentItemId { get; set; }

			public int? ShipmentNumber { get; set; }

			///
			///The number of discrete units that make up an individual item. For example, 1 (ordered quantity) bag of screws may contain a unity quantity of 50 screws.
			///
			public int UnitQuantity { get; set; }

		}

}