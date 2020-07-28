
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
		///	Properties of the product option to create such as attribute detail, fully qualified name, and list of product option values.
		///
		public class ProductOption
		{
			public AttributeDetail AttributeDetail { get; set; }

			public string AttributeFqn { get; set; }

			public bool? IsMultiValue { get; set; }

			///
			///Indicates that the product option is used as a grouping mechanism for product images.  Only one ProductOption is allowed to have a true value for this property at a given time.  The ProductOption with a true value will be the selected option on the Images section on the product page in the Admin app when Assign Images to Options is checked.
			///
			public bool IsProductImageGroupSelector { get; set; }

			public bool? IsRequired { get; set; }

			public List<ProductOptionValue> Values { get; set; }

		}

}