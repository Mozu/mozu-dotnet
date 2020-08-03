
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
		///	Contains information about the payment gateway adapter configuration
		///
		public class AdapterContext
		{
			///
			///A list of KeyValueTuples containing the configuration from the application setup.
			///
			public List<KeyValueTuple> Configuration { get; set; }

			///
			///The previous transactions performed from this adapter.
			///
			public List<Transaction> PreviousTransactions { get; set; }

			///
			///A list of KeyValueTuples containing the configuration from the settings for the application in the Tenant.
			///
			public List<KeyValueTuple> Settings { get; set; }

			///
			///Contains information on the transaction, including previous interactions with the gateway.
			///
			public Transaction Transaction { get; set; }

		}

}