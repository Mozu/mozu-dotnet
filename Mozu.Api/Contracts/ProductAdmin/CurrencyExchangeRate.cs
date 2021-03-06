
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.ProductAdmin
{
		///
		///	Mozu.ProductAdmin.Contracts.CurrencyExchangeRate ApiType DOCUMENT_HERE 
		///
		public class CurrencyExchangeRate
		{
			///
			///Basic audit info about the object, including date, time, and user account. This data may be captured when creating, updating, and removing data.
			///
			public AuditInfo AuditInfo { get; set; }

			///
			///The code of the original currency that the new currency equivalent is being calculated from.
			///
			public string FromCurrencyCode { get; set; }

			///
			///The multiplier that is used to calculate the equivalent between two currencies.
			///
			public decimal? Multiplier { get; set; }

			///
			///The exact rate of the given currency exchange.
			///
			public decimal? Rate { get; set; }

			///
			///Any reference information for the exchange calculation.
			///
			public string ReferenceData { get; set; }

			///
			///The code of the new currency that the original currency's equivalent is being calculated to.
			///
			public string ToCurrencyCode { get; set; }

		}

}