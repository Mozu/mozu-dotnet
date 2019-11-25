
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
using Mozu.Api.Security;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Mozu.Api.Clients.Commerce.Customer
{
	/// <summary>
	/// Use the Address Validation resource to validate addresses associated with a customer account contact.
	/// </summary>
	public partial class AddressValidationRequestClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="addressValidationRequest">Properties of the address used for validation of the account's full address. This content may include multiple lines of an address, city, state/province, zip/postal code, and country.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.Customer.AddressValidationResponse"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=ValidateAddress( addressValidationRequest,  responseFields);
		///   var addressValidationResponseClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.Customer.AddressValidationResponse> ValidateAddressClient(Mozu.Api.Contracts.Customer.AddressValidationRequest addressValidationRequest, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Customer.AddressValidationRequestUrl.ValidateAddressUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Customer.AddressValidationResponse>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Customer.AddressValidationRequest>(addressValidationRequest);
			return mozuClient;

		}


	}

}


