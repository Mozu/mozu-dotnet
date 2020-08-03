
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

namespace Mozu.Api.Resources.Commerce.Settings
{
	/// <summary>
	/// Use the Checkout Settings resource to specify the site-wide settings that define checkout and order processing behavior. This resource includes subresources for payment settings, customer checkout settings, and order processing settings.
	/// </summary>
	public partial class CheckoutSettingsResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public CheckoutSettingsResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public CheckoutSettingsResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new CheckoutSettingsResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.SiteSettings.Order.CheckoutSettings"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var checkoutsettings = new CheckoutSettings();
		///   var checkoutSettings = await checkoutsettings.GetCheckoutSettingsAsync( responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.SiteSettings.Order.CheckoutSettings> GetCheckoutSettingsAsync(string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.SiteSettings.Order.CheckoutSettings> response;
			var client = Mozu.Api.Clients.Commerce.Settings.CheckoutSettingsClient.GetCheckoutSettingsClient( responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}


