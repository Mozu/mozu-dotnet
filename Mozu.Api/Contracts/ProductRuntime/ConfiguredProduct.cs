
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


namespace Mozu.Api.Contracts.ProductRuntime
{
		///
		///	Properties of a product configuration with shopper-selected options.
		///
		public class ConfiguredProduct
		{
			public List<Discount> AvailableShippingDiscounts { get; set; }

			///
			///List of supported types of fulfillment for the product or variation. The types include direct ship, in-store pickup, or both.
			///
			public List<string> FulfillmentTypesSupported { get; set; }

			public ProductInventoryInfo InventoryInfo { get; set; }

			public PackageMeasurements Measurements { get; set; }

			///
			///The manufacturer's part number for the product.
			///
			public string MfgPartNumber { get; set; }

			public List<ProductOption> Options { get; set; }

			public ProductPrice Price { get; set; }

			///
			///The price list entry type.
			///
			public ProductProperty PriceListEntryTypeProperty { get; set; }

			public ProductPriceRange PriceRange { get; set; }

			public string ProductCode { get; set; }

			///
			///List of image files associated with a product. This content may include the image file URL, name, and other information as available.
			///
			public List<ProductImage> ProductImages { get; set; }

			public ProductPurchasableState PurchasableState { get; set; }

			///
			///The location where the order item(s) was purchased.
			///
			public string PurchaseLocation { get; set; }

			///
			///The universal product code (UPC) is the barcode defined for the product. The UPC is unique across all sales channels. 
			///
			public string Upc { get; set; }

			public string VariationProductCode { get; set; }

			///
			///The details of any volume price bands associated with the product.Refer to [Volume Pricing](https://www.mozu.com/docs/guides/catalog/price-lists.htm#volume_pricing) for more information.
			///
			public List<ProductVolumePrice> VolumePriceBands { get; set; }

			///
			///The details of the volume price range associated with the product. Volume price ranges consist of a lower price and an upper price, and either lower or upper prices can be affected by discounts.You can display the volume price range on product listing pages, such as category and search result pages, and product detail pages.Refer to [Volume Pricing Storefront Behavior](https://www.mozu.com/docs/guides/catalog/price-lists.htm#volume_pricing_storefront_behavior) for more information.
			///
			public ProductPriceRange VolumePriceRange { get; set; }

		}

}