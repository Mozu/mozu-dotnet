
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Codezu.     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;


namespace Mozu.Api.Contracts.PaymentService
{
		///
		///	Properties of the credential fields associated with the payment gateway.
		///
		public class GatewayCredentialFieldDefinition
		{
			///
			///The sequential display order of the gateway in Mozu Admin.
			///
			public int AdminDisplayOrder { get; set; }

			///
			///The name that displays for the payment gateway or third-party credentials field. 
			///
			public string DisplayName { get; set; }

			///
			///The display name of the source product property. For a product field it will be the display name of the field. For a product attribute it will be the Attribute Name.
			///
			public string Name { get; set; }

			///
			///The name of the Volusion store.
			///
			public string VolusionStoreName { get; set; }

		}

}