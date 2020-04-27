
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


namespace Mozu.Api.Contracts.ShippingRuntime
{
		///
		///	Properties of the calculated shipping rate based on the information supplied in the request.
		///
		public class RatesResponse
		{
			///
			///Unique identifier of the source property, such as a catalog, discount, order, or email template.For a product field it will be the name of the field.For a category ID, must be a positive integer not greater than 2000000. By default,  auto-generates a category ID when categories are created. If you want to specify an ID during creation (which preserves category link relationships when migrating tenant data from one sandbox to another), you must also include the  query string in the endpoint. For example, . Then, use the  property to specify the desired category ID.For a product attribute it will be the Attribute FQN.For a document, the ID must be specified as a 32 character, case-insensitive, alphanumeric string. You can specify the ID as 32 sequential characters or as groups separated by dashes in the format 8-4-4-4-12. For example, or.For email templates, the ID must be one of the following values:///
			///
			public string Id { get; set; }

			public List<CarrierRatesResponse> Rates { get; set; }

			///
			///Resolved Shipping Zone Code. This value can be null if the tenant/site does not have shipping zones defined or there are no matching shipping zones for the request (e.g. the only zone defined is "UNITED-STATES" and the destination address of the rate request is in Canada)
			///
			public string ResolvedShippingZoneCode { get; set; }

			///
			///A code denoting a zone for shipping rates. Zip and postal codes are associated to these zones, determining set rates and costs for shipping origin and destination points.
			///
			public List<string> ShippingZoneCodes { get; set; }

		}

}