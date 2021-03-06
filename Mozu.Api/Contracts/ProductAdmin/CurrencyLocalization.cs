
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
		///	Currency localization formatting rules, such as decimal places and rounding strategies.
		///
		public class CurrencyLocalization
		{
			///
			///Basic audit info about the object, including date, time, and user account. This data may be captured when creating, updating, and removing data.
			///
			public AuditInfo AuditInfo { get; set; }

			///
			///The localized currency code for the monetary amount.
			///
			public string CurrencyCode { get; set; }

			///
			///The allowed decimal places used in the localized currency format
			///
			public int? DecimalPlaces { get; set; }

			///
			///The rounding strategy used in the localized currency format.
			///
			public int? RoundingStrategy { get; set; }

		}

}