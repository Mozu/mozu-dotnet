
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.ProductAdmin
{
		///
		///	Describes whether a facet is currently valid and the reason. A facet may become invalid if the source data is changed in some ways (for example if the category tree structure is changed).
		///
		public class FacetValidity
		{
			public bool IsValid { get; set; }

			public string ReasonCode { get; set; }

		}

}