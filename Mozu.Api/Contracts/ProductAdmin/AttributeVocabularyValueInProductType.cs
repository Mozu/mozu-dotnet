
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
		///	The actual vocabulary value of the attribute that exists as a part of the product type.
		///
		public class AttributeVocabularyValueInProductType
		{
			///
			///Defines the intended display of this attribute in the storefront. Options include Drop Down, Image Picker, and Radio Buttons.
			///
			public AttributeVocabularyValueDisplayInfo DisplayInfo { get; set; }

			public int? Order { get; set; }

			public object Value { get; set; }

			public AttributeVocabularyValue VocabularyValueDetail { get; set; }

		}

}