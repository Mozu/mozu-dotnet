
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

namespace Mozu.Api.Contracts.ShippingAdmin
{
		///
		///	Properties of a carrier configured in the shipping admin.
		///
		public class CarrierConfiguration
		{
			public bool AreCredentialsSet { get; set; }

			public AuditInfo AuditInfo { get; set; }

			public List<CustomTableRate> CustomTableRates { get; set; }

			public bool Enabled { get; set; }

			public bool EnabledForReturns { get; set; }

			public string Id { get; set; }

			public List<Setting> Settings { get; set; }

		}

}