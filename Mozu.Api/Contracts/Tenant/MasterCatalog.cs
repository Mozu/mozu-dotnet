
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
		///	Properties of a master catalog defined for a tenant. All catalogs associated with a master catalog share product definitions.
		///
		public class MasterCatalog
		{
			public List<Catalog> Catalogs { get; set; }

			public string DefaultCurrencyCode { get; set; }

			public string DefaultLocaleCode { get; set; }

			public int Id { get; set; }

			public string Name { get; set; }

			public int TenantId { get; set; }

		}

}