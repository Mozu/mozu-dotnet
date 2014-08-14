using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Mozu.Api.Contracts.AdminUser;
using Mozu.Api.Contracts.Core;
using Mozu.Api.Contracts.Customer;
using Mozu.Api.Urls.Commerce.Customer;
using Mozu.Api.Urls.Platform.Adminuser;
using Mozu.Api.Urls.Platform.Developer;
using Mozu.Api.Utilities;
using Newtonsoft.Json;

namespace Mozu.Api.Security
{

    public class AuthenticationProfile
    {
        public AuthTicket AuthTicket { get; set; }
        public List<Scope> AuthorizedScopes { get; set; }
        public Scope ActiveScope { get; set; }
        public UserProfile UserProfile { get; set; }
        public CustomerAccount ShopperAccount { get; set; }
    }

   


    public class UserAuthenticator
    {

        public static AuthenticationProfile SetActiveScope(AuthTicket authTicket, Scope scope)
        {
            return RefreshUserAuthTicket(authTicket, scope.Id);
        }

        public static AuthTicket EnsureAuthTicket(AuthTicket authTicket)
        {
            if (DateTime.UtcNow >= authTicket.AccessTokenExpiration.AddSeconds(-180))
               return RefreshUserAuthTicket(authTicket).AuthTicket;

            return null;
        }

        public static AuthenticationProfile RefreshUserAuthTicket(AuthTicket authTicket, int? id = null)
        {

            var resourceUrl = GetResourceRefreshUrl(authTicket, id);

            var client = new HttpClient { BaseAddress = new Uri(AppAuthenticator.Instance.BaseUrl) };
            AppAuthenticator.AddHeader(client);
            
            if (authTicket.SiteId.HasValue)
                client.DefaultRequestHeaders.Add(Headers.X_VOL_SITE, authTicket.SiteId.Value.ToString());

            var stringContent = JsonConvert.SerializeObject(authTicket);
            var response = client.PutAsync(resourceUrl, new StringContent(stringContent, Encoding.UTF8, "application/json")).Result;
            ResponseHelper.EnsureSuccess(response);

           var userInfo = SetUserAuth(response.Content.ReadAsStringAsync().Result, authTicket.AuthenticationScope);

            return userInfo;
        }

        public static AuthenticationProfile Authenticate(UserAuthInfo authInfo, AuthenticationScope scope, int? id = null)
        {
            var resourceUrl = GetResourceUrl(scope, id); 

            var client = new HttpClient { BaseAddress = new Uri(AppAuthenticator.Instance.BaseUrl) };


            var stringContent = JsonConvert.SerializeObject(authInfo);

            AppAuthenticator.AddHeader(client);

            var response = client.PostAsync(resourceUrl, new StringContent(stringContent, Encoding.UTF8, "application/json")).Result;
            ResponseHelper.EnsureSuccess(response);


            return SetUserAuth(response.Content.ReadAsStringAsync().Result, scope,null);
        }

        public static void Logout(AuthTicket authTicket)
        {
            var url = GetLogoutUrl(authTicket);
            var client = new HttpClient { BaseAddress = new Uri(AppAuthenticator.Instance.BaseUrl) };

            AppAuthenticator.AddHeader(client);

            var response = client.DeleteAsync(url).Result;
            ResponseHelper.EnsureSuccess(response);
        }

        private static AuthenticationProfile SetUserAuth(string response, AuthenticationScope scope, int? siteId = null)
        {
            var authenticationProfile = new AuthenticationProfile();

            authenticationProfile.AuthTicket = JsonConvert.DeserializeObject<AuthTicket>(response);
            authenticationProfile.AuthTicket.AuthenticationScope = scope;
            authenticationProfile.AuthTicket.SiteId = siteId;

            switch (scope)
            {
                case AuthenticationScope.Tenant:
                    var tenantAdminUserAuthTicket = JsonConvert.DeserializeObject<TenantAdminUserAuthTicket>(response);
                    authenticationProfile.UserProfile = tenantAdminUserAuthTicket.User;
                    authenticationProfile.AuthorizedScopes = (from t in tenantAdminUserAuthTicket.AvailableTenants select new Scope { Id = t.Id, Name = t.Name }).ToList();
                    if (tenantAdminUserAuthTicket.Tenant != null)
                        authenticationProfile.ActiveScope = new Scope { Id = tenantAdminUserAuthTicket.Tenant.Id, Name = tenantAdminUserAuthTicket.Tenant.Name };
                    break;
                case AuthenticationScope.Developer:
                    var devAccount = JsonConvert.DeserializeObject<DeveloperAdminUserAuthTicket>(response);
                    authenticationProfile.UserProfile = devAccount.User;
                    authenticationProfile.AuthorizedScopes = (from t in devAccount.AvailableAccounts select new Scope { Id = t.Id, Name = t.Name }).ToList();
                    if (devAccount.Account != null)
                        authenticationProfile.ActiveScope = new Scope { Id = devAccount.Account.Id, Name = devAccount.Account.Name };
                    break;
            }

            return authenticationProfile;
        }

        private static string GetResourceRefreshUrl(AuthTicket authTicket, int? id = null)
        {
            switch (authTicket.AuthenticationScope)
            {
                case AuthenticationScope.Tenant:
                    return TenantAdminUserAuthTicketUrl.RefreshAuthTicketUrl(id).Url;
                case AuthenticationScope.Developer:
                    return DeveloperAdminUserAuthTicketUrl.RefreshDeveloperAuthTicketUrl(id).Url;
                default:
                    throw new NotImplementedException();
            }
        }

        private static string GetResourceUrl(AuthenticationScope scope, int? id = null)
        {
            switch (scope)
            {
                case AuthenticationScope.Tenant:
                    return TenantAdminUserAuthTicketUrl.CreateUserAuthTicketUrl(id).Url;
                case AuthenticationScope.Developer:
                    return DeveloperAdminUserAuthTicketUrl.CreateDeveloperUserAuthTicketUrl(id).Url;
                default:
                    throw new NotImplementedException();
            }
        }
        
        private static string GetLogoutUrl(AuthTicket ticket)
        {
            switch (ticket.AuthenticationScope)
            {
                case AuthenticationScope.Tenant:
                    return TenantAdminUserAuthTicketUrl.DeleteUserAuthTicketUrl(ticket.RefreshToken).Url;
                case AuthenticationScope.Developer:
                    return DeveloperAdminUserAuthTicketUrl.DeleteUserAuthTicketUrl(ticket.RefreshToken).Url;
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
