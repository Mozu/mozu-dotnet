
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


namespace Mozu.Api.Contracts.ProductRuntime
{
		///
		///	Properties of the facet used to retrieve documents.
		///
		public class Facet
		{
			public string FacetType { get; set; }

			public string Field { get; set; }

			public string Label { get; set; }

			public List<FacetValue> Values { get; set; }

		}

}