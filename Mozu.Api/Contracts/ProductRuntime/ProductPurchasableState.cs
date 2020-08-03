
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
		///	The current state of the product purchase determines whether or not the product is eligible for purchase. Products with options are only purchasable if the shopper has selected all required options. If the product is not ready for purchase, a message lists missing options that are required.
		///
		public class ProductPurchasableState
		{
			public bool IsPurchasable { get; set; }

			public List<ValidationMessage> Messages { get; set; }

		}

}