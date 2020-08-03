
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.PaymentService
{
		///
		///	Mozu.PaymentService.Contracts.CustomData ApiType DOCUMENT_HERE 
		///
		public class CustomData
		{
			///
			///Key used for metadata defined for objects, including extensible attributes, custom attributes associated with a shipping provider, and search synonyms definitions. This content may be user-defined depending on the object and usage.For search synonym definitions, refer to [Synonym Expansion Types](https://www.mozu.com/docs/Developer/api-guides/search-settings.htm#synonym_expansion_types) for more information about the key usage.
			///
			public string Key { get; set; }

			///
			///The value of a property, used by numerous objects within  including facets, attributes, products, localized content, metadata, capabilities ( and third-party), location inventory adjustment, and more. The value may be a string, integer, or double. Validation may be run against the entered and saved values depending on the object type.
			///
			public string Value { get; set; }

		}

}