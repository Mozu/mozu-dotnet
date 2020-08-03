
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

using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.CommerceRuntime.Payments
{
		///
		///	Properties of a resulting payment interaction that occurs when a payment action is performed.
		///
		public class PaymentInteraction
		{
			public decimal? Amount { get; set; }

			public AuditInfo AuditInfo { get; set; }

			public string CheckNumber { get; set; }

			public string CurrencyCode { get; set; }

			public string GatewayAuthCode { get; set; }

			public string GatewayAVSCodes { get; set; }

			public string GatewayCVV2Codes { get; set; }

			public int? GatewayInteractionId { get; set; }

			public string GatewayResponseCode { get; set; }

			///
			///Additional response data from the gateway that's unique to each gateway.This is a list of key value pairs.Refer to [Gateway Response Data](https://www.mozu.com/docs/developer/api-guides/payment-gateways.htm#gateway_response_data) in the API Guides for more information.
			///
			public List<PaymentGatewayResponseData> GatewayResponseData { get; set; }

			///
			///Textual message returned by the payment gateway for the associated .Refer to [Gateway Response Code and Text](https://www.mozu.com/docs/developer/api-guides/payment-gateways.htm#gateway_response_code_and_text) in the API Guides for more information.
			///
			public string GatewayResponseText { get; set; }

			public string GatewayTransactionId { get; set; }

			public string Id { get; set; }

			public DateTime? InteractionDate { get; set; }

			public string InteractionType { get; set; }

			public bool IsManual { get; set; }

			public bool? IsRecurring { get; set; }

			public string Note { get; set; }

			public string OrderId { get; set; }

			public string PaymentEntryStatus { get; set; }

			public string PaymentId { get; set; }

			public int? PaymentTransactionInteractionIdReference { get; set; }

			///
			///The unique identifier of the refund for a given interaction.
			///
			public string RefundId { get; set; }

			///
			///The unique identifier of the return associated with a given interaction.
			///
			public string ReturnId { get; set; }

			public string Status { get; set; }

			///
			///Targets represent the object, such as an item to apply discounts to(products or orders) or a view field for content. Targets are the dot notations that link to the source document property. For example, firstitem for the direct level or firstitem.seconditem.thirditem for a deeper property.
			///
			public PaymentActionTarget Target { get; set; }

		}

}