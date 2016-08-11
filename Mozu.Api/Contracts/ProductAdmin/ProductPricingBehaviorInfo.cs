
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.ProductAdmin
{
		///
		///	Properties that describe the behavior the system uses when determining the price of the product.
		///
		public class ProductPricingBehaviorInfo
		{
			///
			///Indicates if the discount is restricted. If true, the system cannot apply any discounts to this product. Discount restrictions are defined at the master catalog level. Client administrators cannot override discount restrictions at the catalog level, but they can limit the restriction to a defined time interval.
			///
			public bool? DiscountsRestricted { get; set; }

			///
			///The date and time on which the discount restriction period ends.
			///
			public DateTime? DiscountsRestrictedEndDate { get; set; }

			///
			///The date and time on which the discount restriction period starts.
			///
			public DateTime? DiscountsRestrictedStartDate { get; set; }

			public string VariationPricingMethod { get; set; }

		}

}