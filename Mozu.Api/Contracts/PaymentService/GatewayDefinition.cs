
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
using Newtonsoft.Json.Linq;

using Mozu.Api.Contracts.Core;

namespace Mozu.Api.Contracts.PaymentService
{
		///
		///	Properties of the payment gateway.
		///
		public class GatewayDefinition
		{
			public JObject AdministationUi { get; set; }

			public string CountryCode { get; set; }

			public List<GatewayCredentialFieldDefinition> CredentialDefinitions { get; set; }

			public string Id { get; set; }

			public string IntegrationImplTypeName { get; set; }

			public string Name { get; set; }

			public PreAuthorizeDefinition PreAuthorizeDefinition { get; set; }

			public string ProdServiceURL { get; set; }

			public List<SupportedCard> SupportedCards { get; set; }

			public string TestServiceURL { get; set; }

		}

}