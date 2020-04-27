
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.Customer
{
		///
		///	The site identifier assigned to the customer set.
		///
		public class CustomerSetSite
		{
			///
			///The unique code of the customer set.
			///
			public string CustomerSetCode { get; set; }

			///
			///The user supplied name that appears in . You can use this field for identification purposes.
			///
			public string Name { get; set; }

			///
			///Unique identifier for the site. This IDÂ is used at all levels of a store, catalog, and tenant to associate objects to a site.
			///
			public int SiteId { get; set; }

		}

}