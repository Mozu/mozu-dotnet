
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


namespace Mozu.Api.Contracts.ShippingAdmin
{
		///
		///	Mozu.ShippingAdmin.Contracts.TargetRuleCollection ApiType DOCUMENT_HERE 
		///
		public class TargetRuleCollection
		{
			///
			///A list of requested items. All returned data is provided in an items array.For a failed request, the returned response may be success with an empty item array.
			///
			public List<TargetRule> Items { get; set; }

			///
			///The total number of items in the list.
			///
			public int TotalCount { get; set; }

		}

}