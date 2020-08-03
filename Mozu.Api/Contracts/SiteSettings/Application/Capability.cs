
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

using Mozu.Api.Contracts.Core.ThirdParty;

namespace Mozu.Api.Contracts.SiteSettings.Application
{
		///
		///	Properties of a capability application installed in a tenant.
		///
		public class Capability
		{
			///
			///Array list of credit types active for the capability.
			///
			public List<string> ActiveCreditTypes { get; set; }

			///
			///Array list of the countries (by country code) to which this capability can actively ship. The entered shipping country is validated against a list of supported shipping countries. Messages return if the country code is not supported or duplicated. Supported carriers are also checked per country code.
			///
			public List<ActiveShippingCountry> ActiveShippingCountries { get; set; }

			///
			///Array list of the countries (by country code) for which this capability can actively shop. All active shopping countries must be in the supported shopping country list. Validation rules determine the supported validity of the entered country against the list.
			///
			public List<string> ActiveShoppingCountries { get; set; }

			///
			///The enablement mode of the capability, typically read only.
			///
			public string CapabilityMode { get; set; }

			///
			///The capability type installed in the tenant.
			///
			public string CapabilityType { get; set; }

			///
			///Indicates if a capability, function tied to an Arc.js action, application, or price list is enabled for the tenant/site. If true, the capability/application/function/price list is enabled for the tenant. System-supplied and read-only with the exception of functions tied to an Arc.js action and price lists.
			///
			public bool? Enabled { get; set; }

			///
			///Unique identifier of the source property, such as a catalog, discount, order, or email template.For a product field it will be the name of the field.For a category ID, must be a positive integer not greater than 2000000. By default,  auto-generates a category ID when categories are created. If you want to specify an ID during creation (which preserves category link relationships when migrating tenant data from one sandbox to another), you must also include the  query string in the endpoint. For example, . Then, use the  property to specify the desired category ID.For a product attribute it will be the Attribute FQN.For a document, the ID must be specified as a 32 character, case-insensitive, alphanumeric string. You can specify the ID as 32 sequential characters or as groups separated by dashes in the format 8-4-4-4-12. For example, or.For email templates, the ID must be one of the following values:///
			///
			public string Id { get; set; }

			///
			///Indicates if an app is initialized and capable of being enabled in the tenant and site. Apps will need to be installed and configured to become initialized, such as validating credentials and/or API keys with a third-party service. If true, the app is initialized and can be enabled for usage.
			///
			public bool? Initialized { get; set; }

			///
			///Array list of URL endpoints for the operations associated with this capability.
			///
			public List<OperationUrl> OperationUrls { get; set; }

			///
			///The unique identifier of the scope. For example, if your scope type is site, then this value would be the site id.
			///
			public int? ScopeId { get; set; }

			///
			///The type of scope associated with the documentList. For example, if the documentList is pageTemplateContent, the scopeType is Site.Valid values are: "Tenant", "MasterCatalog", and "Site".
			///
			public string ScopeType { get; set; }

			///
			///List of credit types this capability supports.
			///
			public List<InitializablePropertyValue> SupportedCreditTypes { get; set; }

			///
			///Array list of countries this capability supports for shipping.
			///
			public List<InitializableShippingCountryPropertyValue> SupportedShippingCountries { get; set; }

			///
			///List of countries this capability supports for shopping.
			///
			public List<InitializablePropertyValue> SupportedShoppingCountries { get; set; }

		}

}