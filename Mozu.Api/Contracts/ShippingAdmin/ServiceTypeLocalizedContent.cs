
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.ShippingAdmin
{
		///
		///	Complex type that contains content for a language specified by LocaleCode.
		///
		public class ServiceTypeLocalizedContent
		{
			///
			///Language used for the entity. Currently, only "en-US" is supported.
			///
			public string LocaleCode { get; set; }

			///
			///The display name of the source product property. For a product field it will be the display name of the field. For a product attribute it will be the Attribute Name.
			///
			public string Name { get; set; }

		}

}