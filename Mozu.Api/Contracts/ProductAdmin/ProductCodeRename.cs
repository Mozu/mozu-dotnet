
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
		///	Properties for a product code current and changed content.
		///
		public class ProductCodeRename
		{
			///
			///The existing product code to be changed.
			///
			public string ExistingProductCode { get; set; }

			///
			///The new product code for the product. This code must be unique across all catalogs.
			///
			public string NewProductCode { get; set; }

		}

}