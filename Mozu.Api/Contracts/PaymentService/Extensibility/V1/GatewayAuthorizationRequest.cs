
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.PaymentService.Extensibility.V1
{
		///
		///	Mozu.PaymentService.Extensibility.Contracts.V1.GatewayAuthorizationRequest ApiType DOCUMENT_HERE 
		///
		public class GatewayAuthorizationRequest
		{
			///
			///additionalData ApiType DOCUMENT_HERE 
			///
			public object AdditionalData { get; set; }

			///
			///amount ApiType DOCUMENT_HERE 
			///
			public decimal Amount { get; set; }

			///
			///apiVersion ApiType DOCUMENT_HERE 
			///
			public string ApiVersion { get; set; }

			///
			///card ApiType DOCUMENT_HERE 
			///
			public CardInformation Card { get; set; }

			///
			///context ApiType DOCUMENT_HERE 
			///
			public AdapterContext Context { get; set; }

			///
			///methodName ApiType DOCUMENT_HERE 
			///
			public string MethodName { get; set; }

			///
			///preAuth ApiType DOCUMENT_HERE 
			///
			public bool PreAuth { get; set; }

			///
			///recurringType ApiType DOCUMENT_HERE 
			///
			public string RecurringType { get; set; }

			///
			///shopper ApiType DOCUMENT_HERE 
			///
			public CustomerInformation Shopper { get; set; }

		}

}