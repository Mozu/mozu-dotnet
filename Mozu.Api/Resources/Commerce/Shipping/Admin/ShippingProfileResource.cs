
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

namespace Mozu.Api.Resources.Commerce.Shipping.Admin
{
	/// <summary>
	/// Use the Profiles resource to manage your shipping profiles.
	/// </summary>
	public partial class ShippingProfileResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public ShippingProfileResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public ShippingProfileResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new ShippingProfileResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="dataViewMode">{<see cref="Mozu.Api.DataViewMode"/>}</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.ShippingAdmin.Profile.ShippingProfileCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var shippingprofile = new ShippingProfile();
		///   var shippingProfileCollection = await shippingprofile.GetProfilesAsync( responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.ShippingAdmin.Profile.ShippingProfileCollection> GetProfilesAsync(string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.ShippingAdmin.Profile.ShippingProfileCollection> response;
			var client = Mozu.Api.Clients.Commerce.Shipping.Admin.ShippingProfileClient.GetProfilesClient( responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}


