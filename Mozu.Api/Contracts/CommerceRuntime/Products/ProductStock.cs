
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.CommerceRuntime.Products
{
		///
		///	The number of products accounted for in inventory that are available for purchase.
		///
		public class ProductStock
		{
			public DateTime? AvailableDate { get; set; }

			public bool IsOnBackOrder { get; set; }

			public bool ManageStock { get; set; }

			public int? StockAvailable { get; set; }

		}

}