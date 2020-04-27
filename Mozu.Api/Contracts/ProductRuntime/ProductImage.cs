
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.ProductRuntime
{
		///
		///	Properties of an image defined for a product.
		///
		public class ProductImage
		{
			public string AltText { get; set; }

			///
			///The identifier of the image in the  CMS. Supply a value for either the CMS ID or Image URL parameter.
			///
			public string CmsId { get; set; }

			public string ImageLabel { get; set; }

			public string ImageUrl { get; set; }

			public string MediaType { get; set; }

			///
			///A unique identifier for the product image group.
			///
			public string ProductImageGroupId { get; set; }

			public int? Sequence { get; set; }

			public string VideoUrl { get; set; }

		}

}