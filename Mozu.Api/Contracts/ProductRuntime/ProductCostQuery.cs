
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
		///	Mozu.ProductRuntime.Contracts.ProductCostQuery ApiType DOCUMENT_HERE 
		///
		public class ProductCostQuery
		{
			///
			///A list of product codes of associated products. When this field is in the Product Publishing resource, you can use this field  to publish or delete individual pending product changes, or assign individual pending product changes to a publish set.
			///
			public List<string> ProductCodes { get; set; }

		}

}