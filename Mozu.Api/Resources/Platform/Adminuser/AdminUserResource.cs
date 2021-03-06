
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

namespace Mozu.Api.Resources.Platform.Adminuser
{
	/// <summary>
	/// The Accounts resource displays the user accounts and account details associated with a developer or  tenant administrator. Email addresses uniquely identify admin user accounts.
	/// </summary>
	public partial class AdminUserResource  	{
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		
		public AdminUserResource() 
		{
			_apiContext = null;
		}
		 public AdminUserResource(IApiContext apiContext) 
		{
			_apiContext = apiContext;
		}

		public AdminUserResource CloneWithApiContext(Action<IApiContext> contextModification) 
		{
			return new AdminUserResource(_apiContext.CloneWith(contextModification));
		}

				

		/// <summary>
		/// 
		/// </summary>
		/// <param name="emailAddress"></param>
		/// <param name="filter"></param>
		/// <param name="pageSize"></param>
		/// <param name="sortBy"></param>
		/// <param name="startIndex"></param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var stream = await adminuser.GetUsersAsync( emailAddress,  startIndex,  pageSize,  sortBy,  filter);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> GetUsersAsync(string emailAddress =  null, int? startIndex =  null, int? pageSize =  null, string sortBy =  null, string filter =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.GetUsersClient( emailAddress,  startIndex,  pageSize,  sortBy,  filter);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="userId"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.AdminUser.UserRoleCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var userRoleCollection = await adminuser.GetUserRolesAsync( userId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.AdminUser.UserRoleCollection> GetUserRolesAsync(string userId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.AdminUser.UserRoleCollection> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.GetUserRolesClient( userId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="userId">Unique identifier of the user whose tenant scopes you want to retrieve.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Tenant.TenantCollection"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var tenantCollection = await adminuser.GetTenantScopesForUserAsync( userId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Tenant.TenantCollection> GetTenantScopesForUserAsync(string userId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Tenant.TenantCollection> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.GetTenantScopesForUserClient( userId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="userId"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Core.User"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var user = await adminuser.GetUserByIdAsync( userId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Core.User> GetUserByIdAsync(string userId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Core.User> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.GetUserByIdClient( userId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields">Filtering syntax appended to an API call to increase or decrease the amount of data returned inside a JSON object. This parameter should only be used to retrieve data. Attempting to update data using this parameter may cause data loss.</param>
		/// <param name="userId">Unique identifier of the user whose tenant scopes you want to retrieve.</param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Core.User"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var user = await adminuser.GetUserAsync( userId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Core.User> GetUserAsync(string userId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Core.User> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.GetUserClient( userId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="user"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Core.User"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var user = await adminuser.CreateUserAsync( user,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Core.User> CreateUserAsync(Mozu.Api.Contracts.Core.User user, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Core.User> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.CreateUserClient( user,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="passwordInfo"></param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var stream = await adminuser.ChangePasswordAsync( passwordInfo,  userId);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> ChangePasswordAsync(Mozu.Api.Contracts.AdminUser.PasswordInfo passwordInfo, string userId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.ChangePasswordClient( passwordInfo,  userId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="changeUserPasswordInfo"></param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var stream = await adminuser.ChangeUserPasswordAsync( changeUserPasswordInfo,  userId);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> ChangeUserPasswordAsync(Mozu.Api.Contracts.AdminUser.ChangeUserPasswordInfo changeUserPasswordInfo, string userId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.ChangeUserPasswordClient( changeUserPasswordInfo,  userId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="roleId"></param>
		/// <param name="userId"></param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var stream = await adminuser.AddUserRoleAsync( userId,  roleId);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> AddUserRoleAsync(string userId, int roleId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.AddUserRoleClient( userId,  roleId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="resetPasswordInfo"></param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var stream = await adminuser.ResetPasswordAsync( resetPasswordInfo);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> ResetPasswordAsync(Mozu.Api.Contracts.AdminUser.ResetPasswordInfo resetPasswordInfo, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.ResetPasswordClient( resetPasswordInfo);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="userId"></param>
		/// <param name="user"></param>
		/// <returns>
		/// <see cref="Mozu.Api.Contracts.Core.User"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var user = await adminuser.UpdateUserAsync( user,  userId,  responseFields);
		/// </code>
		/// </example>
		public virtual async Task<Mozu.Api.Contracts.Core.User> UpdateUserAsync(Mozu.Api.Contracts.Core.User user, string userId, string responseFields =  null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Core.User> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.UpdateUserClient( user,  userId,  responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="userId"></param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var stream = await adminuser.DeleteUserAsync( userId);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> DeleteUserAsync(string userId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.DeleteUserClient( userId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="roleId"></param>
		/// <param name="userId"></param>
		/// <returns>
		/// <see cref="System.IO.Stream"/>
		/// </returns>
		/// <example>
		/// <code>
		///   var adminuser = new AdminUser();
		///   var stream = await adminuser.RemoveUserRoleAsync( userId,  roleId);
		/// </code>
		/// </example>
		public virtual async Task<System.IO.Stream> RemoveUserRoleAsync(string userId, int roleId, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<System.IO.Stream> response;
			var client = Mozu.Api.Clients.Platform.Adminuser.AdminUserClient.RemoveUserRoleClient( userId,  roleId);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();

		}


	}

}


