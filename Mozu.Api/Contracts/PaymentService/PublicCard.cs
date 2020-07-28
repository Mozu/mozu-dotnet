
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.PaymentService
{
		public class PublicCard
		{
			///
			///The card holder full name.
			///
			public string CardHolderName { get; set; }

			///
			///The month the credit card was issued; used by some cards.
			///
			public int CardIssueMonth { get; set; }

			///
			///For Amex Cards, this is an additional field for verification that is used in conjunction with a CVV
			///
			public string CardIssueNumber { get; set; }

			///
			///The issue year; used by some cards.
			///
			public int CardIssueYear { get; set; }

			///
			///This is the full number of the card.
			///
			public string CardNumber { get; set; }

			///
			///The type of credit card, such as Visa or Amex.
			///
			public string CardType { get; set; }

			///
			///The CVV code for the credit card.
			///
			public string Cvv { get; set; }

			///
			///The two-digit month a credit card expires for a payment method.
			///
			public int ExpireMonth { get; set; }

			///
			///The four-digit year the credit card expires for a payment method.
			///
			public int ExpireYear { get; set; }

			public bool IsTokenized { get; set; }

		}

}