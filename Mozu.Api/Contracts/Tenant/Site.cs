
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


namespace Mozu.Api.Contracts.Tenant
{
		///
		///	Properties of a site associated with a tenant.
		///
		public class Site
		{
			public List<TenantAttribute> Attributes { get; set; }

			public int CatalogId { get; set; }

			public string CountryCode { get; set; }

			public string CurrencyCode { get; set; }

			public string Domain { get; set; }

			public int Id { get; set; }

			public string LocaleCode { get; set; }

			public string Name { get; set; }

			public string PrimaryCustomDomain { get; set; }

			public int TenantId { get; set; }

		}

}