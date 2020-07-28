
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

namespace Mozu.Api.Clients.Platform.Applications
{
	/// <summary>
	/// Use the Authetickets for applications resource to manage authentication tickets for your apps.
	/// </summary>
	public partial class AuthTicketClient 	{
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="appAuthInfo">The information required to authenticate third party applications against the  API.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.AppDev.AuthTicket"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=AuthenticateApp( appAuthInfo,  responseFields);
		///   var authTicketClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.AppDev.AuthTicket> AuthenticateAppClient(Mozu.Api.Contracts.AppDev.AppAuthInfo appAuthInfo, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Platform.Applications.AuthTicketUrl.AuthenticateAppUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.AppDev.AuthTicket>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.AppDev.AppAuthInfo>(appAuthInfo);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="appAuthInfo"></param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.AppDev.OAuthAccessTokenResponse"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=OauthAuthenticateApp( appAuthInfo,  responseFields);
		///   var oAuthAccessTokenResponseClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.AppDev.OAuthAccessTokenResponse> OauthAuthenticateAppClient(Mozu.Api.Contracts.AppDev.OauthAuthRequest appAuthInfo, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Platform.Applications.AuthTicketUrl.OauthAuthenticateAppUrl(responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.AppDev.OAuthAccessTokenResponse>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.AppDev.OauthAuthRequest>(appAuthInfo);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="authTicketRequest">Properties of the authentication ticket refresh requests, which includes the refresh token string.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.AppDev.AuthTicket"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=RefreshAppAuthTicket( authTicketRequest,  responseFields);
		///   var authTicketClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.AppDev.AuthTicket> RefreshAppAuthTicketClient(Mozu.Api.Contracts.AppDev.AuthTicketRequest authTicketRequest, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Platform.Applications.AuthTicketUrl.RefreshAppAuthTicketUrl(responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.AppDev.AuthTicket>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.AppDev.AuthTicketRequest>(authTicketRequest);
			return mozuClient;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="refreshToken">Alphanumeric string used for access tokens. This token refreshes access for accounts by generating a new developer or application account authentication ticket after an access token expires.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="System.IO.Stream"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteAppAuthTicket( refreshToken);
		///   var streamClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<System.IO.Stream> DeleteAppAuthTicketClient(string refreshToken)
		{
			var url = Mozu.Api.Urls.Platform.Applications.AuthTicketUrl.DeleteAppAuthTicketUrl(refreshToken);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<System.IO.Stream>()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}


