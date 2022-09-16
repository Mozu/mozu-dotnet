using Mozu.Api.Contracts.Inventory;
using System;
using System.Collections.Generic;

namespace Mozu.Api.Clients.Commerce.Inventory
{
    public partial class ModifyInventoryClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshRequest"></param>
        /// <param name="responseFields"></param>
        /// <returns></returns>
        public static MozuClient<Mozu.Api.Contracts.Inventory.JobIDResponse> RefreshClient(RefreshRequest refreshRequest, string responseFields = null)
        {
            var url = Mozu.Api.Urls.Commerce.Inventory.ModifyInventoryUrl.RefreshUrl(refreshRequest, responseFields);
            const string verb = "POST";
            var mozuClient = new MozuClient<Mozu.Api.Contracts.Inventory.JobIDResponse>()
                .WithVerb(verb).WithResourceUrl(url)
                .WithBody<Mozu.Api.Contracts.Inventory.RefreshRequest>(refreshRequest);

            return mozuClient;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjustRequest"></param>
        /// <param name="responseFields"></param>
        /// <returns></returns>
        public static MozuClient<Mozu.Api.Contracts.Inventory.JobIDResponse> AdjustClient(AdjustRequest adjustRequest, string responseFields = null)
        {
            var url = Mozu.Api.Urls.Commerce.Inventory.ModifyInventoryUrl.AdjustUrl(adjustRequest, responseFields);
            const string verb = "POST";
            var mozuClient = new MozuClient<Mozu.Api.Contracts.Inventory.JobIDResponse>()
                .WithVerb(verb).WithResourceUrl(url)
                .WithBody<Mozu.Api.Contracts.Inventory.AdjustRequest>(adjustRequest);

            return mozuClient;
        }
        
    }
}