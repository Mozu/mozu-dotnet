
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.CommerceRuntime.Payments
{
		///
		///	The token used to authorize the payment request.
		///
		public class PaymentToken
		{
			///
			///The identifier of the payment service token.
			///
			public string PaymentServiceTokenId { get; set; }

			///
			///The type of token being provided for the payment.
			///
			public string Type { get; set; }

		}

}