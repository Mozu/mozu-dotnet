
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

using Mozu.Api.Contracts.CommerceRuntime.Fulfillment;

namespace Mozu.Api.Contracts.CommerceRuntime.Checkouts
{
		///
		///	Mozu.CommerceRuntime.Contracts.Checkouts.CheckoutGroupShippingMethod ApiType DOCUMENT_HERE 
		///
		public class CheckoutGroupShippingMethod
		{
			///
			///The grouping ID that the shipping method applies to.
			///
			public string GroupingId { get; set; }

			///
			///The shipping rate applied to the grouping.
			///
			public ShippingRate ShippingRate { get; set; }

		}

}