
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

namespace Mozu.Api.Clients.Platform.Adminuser
{
	/// <summary>
	/// Use the Admin User authentication tickets resource to generate and refresh authentication tickets that enable Mozu administrator or developer account users to access development or production tenants.
	/// </summary>
	public partial class TenantAdminUserAuthTicketClient 	{
		
		/// <summary>
		/// Creates an authentication ticket for the supplied user to specify in API requests associated with the supplied tenant.
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="tenantId">Unique identifier of the development or production tenant for which to generate the user authentication ticket.</param>
		/// <param name="userAuthInfo">The user authentication information required to generate the user authentication ticket, which consists of a user name and password.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.AdminUser.TenantAdminUserAuthTicket"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=CreateUserAuthTicket( userAuthInfo,  tenantId,  responseFields);
		///   var tenantAdminUserAuthTicketClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.AdminUser.TenantAdminUserAuthTicket> CreateUserAuthTicketClient(Mozu.Api.Contracts.Core.UserAuthInfo userAuthInfo, int? tenantId =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Platform.Adminuser.TenantAdminUserAuthTicketUrl.CreateUserAuthTicketUrl(tenantId, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.AdminUser.TenantAdminUserAuthTicket>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Core.UserAuthInfo>(userAuthInfo);
			return mozuClient;

		}

		/// <summary>
		/// Generates a new user authentication ticket for the specified tenant by supplying the user's existing refresh token information.
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="tenantId"></param>
		/// <param name="existingAuthTicket">Properties of the authentication ticket to refresh. The refresh token is required to complete this request.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />{<see cref="Mozu.Api.Contracts.AdminUser.TenantAdminUserAuthTicket"/>}
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=RefreshAuthTicket( existingAuthTicket,  tenantId,  responseFields);
		///   var tenantAdminUserAuthTicketClient = mozuClient.WithBaseAddress(url).Execute().Result();
		/// </code>
		/// </example>
		public static MozuClient<Mozu.Api.Contracts.AdminUser.TenantAdminUserAuthTicket> RefreshAuthTicketClient(Mozu.Api.Contracts.AdminUser.TenantAdminUserAuthTicket existingAuthTicket, int? tenantId =  null, string responseFields =  null)
		{
			var url = Mozu.Api.Urls.Platform.Adminuser.TenantAdminUserAuthTicketUrl.RefreshAuthTicketUrl(tenantId, responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.AdminUser.TenantAdminUserAuthTicket>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.AdminUser.TenantAdminUserAuthTicket>(existingAuthTicket);
			return mozuClient;

		}

		/// <summary>
		/// Deletes the authentication ticket for the user by supplying the refresh token.
		/// </summary>
		/// <param name="refreshToken">Refresh token string associated with the user authentication ticket.</param>
		/// <returns>
		///  <see cref="Mozu.Api.MozuClient" />
		/// </returns>
		/// <example>
		/// <code>
		///   var mozuClient=DeleteUserAuthTicket( refreshToken);
		///mozuClient.WithBaseAddress(url).Execute();
		/// </code>
		/// </example>
		public static MozuClient DeleteUserAuthTicketClient(string refreshToken)
		{
			var url = Mozu.Api.Urls.Platform.Adminuser.TenantAdminUserAuthTicketUrl.DeleteUserAuthTicketUrl(refreshToken);
			const string verb = "DELETE";
			var mozuClient = new MozuClient()
									.WithVerb(verb).WithResourceUrl(url)
;
			return mozuClient;

		}


	}

}


