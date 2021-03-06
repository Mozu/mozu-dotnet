
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.CommerceRuntime.Commerce
{
		///
		///	Information on where, when and what content to display in a threshold message to customers.
		///
		public class ThresholdMessage
		{
			///
			///The unique identifier of the discount.
			///
			public int DiscountId { get; set; }

			///
			///The text of the change message, such as "This product is no longer available." System-supplied and read-only.
			///
			public string Message { get; set; }

			///
			///Boolean field indicating whether or not threshold message requires the customer entering a coupon code to display.
			///
			public bool RequiresCouponCode { get; set; }

			///
			///Boolean field indicating whether or not the threshold message should be displayed on the Cart page.
			///
			public bool ShowInCart { get; set; }

			///
			///Boolean field indicating whether or not the threshold message should display on the Checkout page
			///
			public bool ShowOnCheckout { get; set; }

			///
			///Numerical value representing the Cart minimum total to be satisfied in order to display the threshold message.
			///
			public decimal ThresholdValue { get; set; }

		}

}