
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


namespace Mozu.Api.Contracts.PaymentService.Extensibility.V1
{
		///
		///	Mozu.PaymentService.Extensibility.Contracts.V1.GatewayCreditResponse ApiType DOCUMENT_HERE 
		///
		public class GatewayCreditResponse
		{
			///
			///isDeclined ApiType DOCUMENT_HERE 
			///
			public bool IsDeclined { get; set; }

			///
			///remoteConnectionStatus ApiType DOCUMENT_HERE 
			///
			public ConnectionStatuses RemoteConnectionStatus { get; set; }

			///
			///responseCode ApiType DOCUMENT_HERE 
			///
			public string ResponseCode { get; set; }

			///
			///responseData ApiType DOCUMENT_HERE 
			///
			public List<KeyValueTuple> ResponseData { get; set; }

			///
			///responseText ApiType DOCUMENT_HERE 
			///
			public string ResponseText { get; set; }

			///
			///transactionId ApiType DOCUMENT_HERE 
			///
			public string TransactionId { get; set; }

		}

}