
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

namespace Mozu.Api.Resources.Commerce.Settings.General
{
	/// <summary>
	/// Use the Custom Routes resource to manage your custom route settings. Custom routing allows you to display SEO-friendly URLs on your site that map behind-the-scenes to conventional  resources such as a product page or a search results page. With custom routing, you gain advanced control over the URL structures on your site and can more visibly highlight the products or categories your shoppers are interested in purchasing.To learn more about custom routing, refer to the [Custom Route Settings](../../../guides/settings/custom-routes.htm) topic.
	/// </summary>
	public partial class CustomRouteSettingsResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public CustomRouteSettingsResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public CustomRouteSettingsResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new CustomRouteSettingsResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.SiteSettings.General.General.Routing.CustomRouteSettings"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customroutesettings = new CustomRouteSettings();
		///   var customRouteSettings = await customroutesettings.GetCustomRouteSettingsAsync( responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.SiteSettings.General.General.Routing.CustomRouteSettings> GetCustomRouteSettingsAsync(string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.SiteSettings.General.General.Routing.CustomRouteSettings> response;
			var client = Mozu.Api.Clients.Commerce.Settings.General.CustomRouteSettingsClient.GetCustomRouteSettingsClient( responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="settings">The details of the new custom route setting.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.SiteSettings.General.General.Routing.CustomRouteSettings"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customroutesettings = new CustomRouteSettings();
		///   var customRouteSettings = await customroutesettings.CreateCustomRouteSettingsAsync( settings,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.SiteSettings.General.General.Routing.CustomRouteSettings> CreateCustomRouteSettingsAsync(Mozu.Api.Contracts.SiteSettings.General.General.Routing.CustomRouteSettings settings, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.SiteSettings.General.General.Routing.CustomRouteSettings> response;
			var client = Mozu.Api.Clients.Commerce.Settings.General.CustomRouteSettingsClient.CreateCustomRouteSettingsClient( settings,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="settings">The updated details of the custom route settings.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.SiteSettings.General.General.Routing.CustomRouteSettings"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customroutesettings = new CustomRouteSettings();
		///   var customRouteSettings = await customroutesettings.UpdateCustomRouteSettingsAsync( settings,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.SiteSettings.General.General.Routing.CustomRouteSettings> UpdateCustomRouteSettingsAsync(Mozu.Api.Contracts.SiteSettings.General.General.Routing.CustomRouteSettings settings, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.SiteSettings.General.General.Routing.CustomRouteSettings> response;
			var client = Mozu.Api.Clients.Commerce.Settings.General.CustomRouteSettingsClient.UpdateCustomRouteSettingsClient( settings,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var customroutesettings = new CustomRouteSettings();
		///   var stream = await customroutesettings.DeleteCustomRouteSettingsAsync();
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteCustomRouteSettingsAsync(CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Commerce.Settings.General.CustomRouteSettingsClient.DeleteCustomRouteSettingsClient();
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}


