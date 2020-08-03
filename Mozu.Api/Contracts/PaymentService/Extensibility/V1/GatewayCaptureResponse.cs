
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
		///	Contains a capture response
		///
		public class GatewayCaptureResponse
		{
			///
			///Contains the auth code from the gateway.
			///
			public string AuthCode { get; set; }

			///
			///Contains the avs codes from the gateway.
			///
			public string AvsCodes { get; set; }

			///
			///capturedAmount ApiType DOCUMENT_HERE 
			///
			public decimal CapturedAmount { get; set; }

			///
			///Contains the cvv codes from the gateway.
			///
			public string CvV2Codes { get; set; }

			///
			///Set this to true if the transaction is declined or fails for any reason.
			///
			public bool IsDeclined { get; set; }

			///
			///Contains information about the interaction with the gateway.
			///
			public ConnectionStatuses RemoteConnectionStatus { get; set; }

			///
			///Contains the response code from the gateway.
			///
			public string ResponseCode { get; set; }

			///
			///Contains information not in the object allowing flexibility.
			///
			public List<KeyValueTuple> ResponseData { get; set; }

			///
			///Contains the text for the response, eg, 'Insufficient funds'.
			///
			public string ResponseText { get; set; }

			///
			///Contains the id for the transaction provided by the gateway.
			///
			public string TransactionId { get; set; }

		}

}