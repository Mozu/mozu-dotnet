
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
		///	The localized content of the threshold message.
		///
		public class ThresholdMessageLocalizedContent
		{
			///
			///Basic audit info about the object, including date, time, and user account. This data may be captured when creating, updating, and removing data.
			///
			public AuditInfo AuditInfo { get; set; }

			///
			///The two character locale code, per the country code provided. This code determines the localized content to use and display.
			///
			public string LocaleCode { get; set; }

			///
			///Locale-based contents of the Threshold Message that will be displayed.
			///
			public string MessageTemplate { get; set; }

		}

}