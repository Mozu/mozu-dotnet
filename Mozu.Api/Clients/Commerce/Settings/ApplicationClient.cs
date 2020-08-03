
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

namespace Mozu.Api.Clients.Commerce.Settings
{
	/// <summary>
	/// Use the Applications resource to update site-specific settings for installed applications.
	/// </summary>
	public partial class ApplicationClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.SiteSettings.Application.Application"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=ThirdPartyGetApplication( responseFields);
		///   var applicationClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.SiteSettings.Application.Application> ThirdPartyGetApplicationClient(string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Settings.ApplicationUrl.ThirdPartyGetApplicationUrl(responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.SiteSettings.Application.Application>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="application">Properties of an application installed in a tenant.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.SiteSettings.Application.Application"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=ThirdPartyUpdateApplication( application,  responseFields);
		///   var applicationClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.SiteSettings.Application.Application> ThirdPartyUpdateApplicationClient(Mozu.Api.Contracts.SiteSettings.Application.Application application, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Commerce.Settings.ApplicationUrl.ThirdPartyUpdateApplicationUrl(responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.SiteSettings.Application.Application>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.SiteSettings.Application.Application>(application);
			return mozuClient;

		}


	}

}


