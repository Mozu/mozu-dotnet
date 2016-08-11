
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Newtonsoft.Json.Linq;

using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.CommerceRuntime.Payments
{
		///
		///	Properties of the payment action performed for an order.
		///
		public class PaymentAction
		{
			///
			///The name of the fulfillment action to perform for the purchased product. Options include "Ship" or "PickUp" (in-store pick-up).
			///
			public string ActionName { get; set; }

			///
			///The total monetary amount of the payment transaction.
			///
			public decimal? Amount { get; set; }

			///
			///The URL provided to cancel payments submitted using PayPal Express or another non-gateway payment provider.
			///
			public string CancelUrl { get; set; }

			///
			///If applicable, the check number associated with the payment action or interaction.
			///
			public string CheckNumber { get; set; }

			///
			///3-letter ISO 4217 standard global currency code. Currently, only "USD" (US Dollar) is supported.
			///
			public string CurrencyCode { get; set; }

			public JObject Data { get; set; }

			public string ExternalTransactionId { get; set; }

			///
			///Date and time of a payment interaction, including handling and processing a payment and validating and completing a payment with a payment gateway.
			///
			public DateTime? InteractionDate { get; set; }

			///
			///Properties of a manually performed interaction with the payment gateway.
			///
			public PaymentGatewayInteraction ManualGatewayInteraction { get; set; }

			///
			///The billing information associated with this payment action.
			///
			public BillingInfo NewBillingInfo { get; set; }

			///
			///Unique ID that references an original transaction in the event of a credit back.
			///
			public string ReferenceSourcePaymentId { get; set; }

			///
			///The URL provided to redirect users who submit payments using PayPal Express or another non-gateway payment provider.
			///
			public string ReturnUrl { get; set; }

		}

}