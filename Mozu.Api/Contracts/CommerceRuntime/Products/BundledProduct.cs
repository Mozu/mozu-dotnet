
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

using Mozu.Api.Contracts.CommerceRuntime.Commerce;

namespace Mozu.Api.Contracts.CommerceRuntime.Products
{
		///
		///	Properties of a component product in a product bundle. A product bundle can represent either a collection of multiple products sold as a single entity, or a collection of the same product sold as a package. For example, a 10-pack of socks or multiple parts and devices in a technology bundle for a computer.
		///
		public class BundledProduct
		{
			///
			///Allocation ID associated with this product on this order.
			///
			public DateTime? AllocationExpiration { get; set; }

			///
			///Allocation ID associated with this product on this order.
			///
			public int? AllocationId { get; set; }

			///
			///The credit value of the product or bundled product. When the `goodsType `is `DigitalCredit`, this value is populated to indicate the value of the credit. This is used to create store credit in the fulfillment of gift cards.
			///
			public decimal? CreditValue { get; set; }

			///
			///If the product is in relative pricing mode, this is the difference between associated prices for a product, variation option, or extra. The difference is calculated by subtracting the base price from the associated price with this product, option, and/or extra. For example, if a product with a defined monogram extra costs an additional $10, the `deltaPrice `value is "10". Between options, a price for a medium may be $10 and a large $12 giving a `deltaPrice `value of "2".Refer to [Product Variant Pricing and Weight](../../../guides/catalog/products.htm#product_variant_pricing_and_weight) in the Products guides topic for more information.
			///
			public decimal? DeltaPrice { get; set; }

			///
			///The localized description in text for the object, displayed per the locale code. For example, descriptions are used for product descriptions, attributes, and pre-authorization transaction types.
			///
			public string Description { get; set; }

			///
			///Fulfillment status of the product.
			///
			public string FulfillmentStatus { get; set; }

			///
			///The type of goods in a bundled product. A bundled product is composed of products associated to sell together. Possible values include â€œPhysicalâ€ and â€œDigitalCreditâ€. This comes from the `productType `of the product. Products are defaulted to a Physical `goodsType`. Gift cards have a `goodsType `of DigitalCredit.
			///
			public string GoodsType { get; set; }

			///
			///Indicates if the product must be shipped alone in a container. This is used for products and products within a bundle. If true, this product cannot be shipped in a package with other items and must ship in a package by itself.
			///
			public bool IsPackagedStandAlone { get; set; }

			///
			///Dimensions of the packaged product.
			///
			public PackageMeasurements Measurements { get; set; }

			///
			///The user supplied name that appears in . You can use this field for identification purposes.
			///
			public string Name { get; set; }

			///
			///The fully qualified name of the attribute, which is a user defined attribute identifier.
			///
			public string OptionAttributeFQN { get; set; }

			///
			///The value of the option attribute. These values are associated and used by product bundles and options.
			///
			public object OptionValue { get; set; }

			///
			///Merchant-created code that uniquely identifies the product such as a SKU or item number. Once created, the product code is read-only.
			///
			public string ProductCode { get; set; }

			///
			///Unique identifier of the product reservation associated with the component product in a product bundle or item in a cart/order. System-supplied and read only.
			///
			public int? ProductReservationId { get; set; }

			///
			///The specified quantity of objects and items. This property is used for numerous object types including products, options, components within a product bundle, cart and order items, returned items, shipping line items, items in a digital product. and items associated with types and reservations.
			///
			public int Quantity { get; set; }

			public ProductStock Stock { get; set; }

		}

}