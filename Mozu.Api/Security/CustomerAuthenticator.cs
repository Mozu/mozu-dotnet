using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.Customer;
using Mozu.Api.Resources.Platform;
using Mozu.Api.Urls.Commerce.Customer;
using Mozu.Api.Utilities;
using Newtonsoft.Json;

namespace Mozu.Api.Security
{
    public class CustomerAuthenticationProfile
    {
        public AuthTicket AuthTicket { get; set; }
        public CustomerAccount CustomerAccount { get; set; }
    }

    public class CustomerAuthenticator
    {
        public static async Task<AuthTicket> EnsureAuthTicket(AuthTicket authTicket)
        {

            if (DateTime.UtcNow >= authTicket.AccessTokenExpiration.AddSeconds(-180))
                return (await RefreshUserAuthTicket(authTicket).ConfigureAwait(false)).AuthTicket;

            return null;
        }

        private static async Task<string> GetAuthUrl(int tenantId)
        {
            var tenantResource = new TenantResource();
            var tenant = await tenantResource.GetTenantAsync(tenantId).ConfigureAwait(false);
            return HttpHelper.GetUrl(tenant.Domain);

           
        }

        public static async Task<CustomerAuthenticationProfile> RefreshUserAuthTicket(AuthTicket authTicket)
        {

            var resourceUrl = CustomerAuthTicketUrl.RefreshUserAuthTicketUrl(authTicket.RefreshToken).Url;

            var authUrl = await GetAuthUrl(authTicket.TenantId.Value).ConfigureAwait(false);
            var client = new HttpClient { BaseAddress = new Uri(authUrl) };
            AppAuthenticator.AddHeader(client);

            if (authTicket.SiteId.HasValue)
                client.DefaultRequestHeaders.Add(Headers.X_VOL_SITE, authTicket.SiteId.Value.ToString());

            var stringContent = JsonConvert.SerializeObject(authTicket);
            var response = client.PutAsync(resourceUrl, new StringContent(stringContent, Encoding.UTF8, "application/json")).Result;
            ResponseHelper.EnsureSuccess(response);

            var userInfo = SetUserAuth(response.Content.ReadAsStringAsync().Result, authTicket.AuthenticationScope, authTicket.TenantId.Value, authTicket.SiteId.Value);

            return userInfo;
        }



        public static async Task<CustomerAuthenticationProfile> Authenticate(CustomerUserAuthInfo customerUserAuthInfo,
                                                                int tenantId, int siteId)
        {
            var resourceUrl = CustomerAuthTicketUrl.CreateUserAuthTicketUrl().Url;

            var authUrl = await GetAuthUrl(tenantId).ConfigureAwait(false);
            var client = new HttpClient { BaseAddress = new Uri(authUrl) };

            client.DefaultRequestHeaders.Add(Headers.X_VOL_SITE, siteId.ToString());

            var stringContent = JsonConvert.SerializeObject(customerUserAuthInfo);

            AppAuthenticator.AddHeader(client);

            var response = client.PostAsync(resourceUrl, new StringContent(stringContent, Encoding.UTF8, "application/json")).Result;
            ResponseHelper.EnsureSuccess(response);


            return SetUserAuth(response.Content.ReadAsStringAsync().Result, AuthenticationScope.Customer,tenantId, siteId);
        }

        private static CustomerAuthenticationProfile SetUserAuth(string response, AuthenticationScope scope,int tenantId, int siteId)
        {
            var customerAuthenticationProfile = new CustomerAuthenticationProfile();

            customerAuthenticationProfile.AuthTicket = JsonConvert.DeserializeObject<AuthTicket>(response);
            customerAuthenticationProfile.AuthTicket.AuthenticationScope = scope;
            customerAuthenticationProfile.AuthTicket.SiteId = siteId;
            customerAuthenticationProfile.AuthTicket.TenantId = tenantId;

            var userAccount = JsonConvert.DeserializeObject<CustomerAuthTicket>(response);
            customerAuthenticationProfile.CustomerAccount = userAccount.CustomerAccount;

            return customerAuthenticationProfile;
        }

    }
}
