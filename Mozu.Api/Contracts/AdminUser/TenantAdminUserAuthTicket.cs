
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

using Mozu.Api.Contracts.Core;
using Mozu.Api.Contracts.Tenant;

namespace Mozu.Api.Contracts.AdminUser
{
		///
		///	Properties of the authentication ticket to be used in user claims with the  API.
		///
		public class TenantAdminUserAuthTicket
		{
			public string AccessToken { get; set; }

			public DateTime AccessTokenExpiration { get; set; }

			public List<Tenant.Tenant> AvailableTenants { get; set; }

			public DateTime CreatedOn { get; set; }

			public List<int> GrantedBehaviors { get; set; }

			public string JwtAccessToken { get; set; }

			public string Redirect { get; set; }

			public string RefreshToken { get; set; }

			public DateTime RefreshTokenExpiration { get; set; }

			public Tenant.Tenant Tenant { get; set; }

			public UserProfile User { get; set; }

		}

}