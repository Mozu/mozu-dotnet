using Mozu.Api.Contracts.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mozu.Api.Resources.Commerce.Inventory
{
    public partial class ModifyInventoryResource
    {
        private readonly IApiContext _apiContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiContext"></param>
        public ModifyInventoryResource(IApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextModification"></param>
        /// <returns></returns>
        public ModifyInventoryResource CloneWithApiContext(Action<IApiContext> contextModification)
        {
            return new ModifyInventoryResource(_apiContext.CloneWith(contextModification));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshRequest"></param>
        /// <param name="responseFields"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public virtual async Task<Mozu.Api.Contracts.Inventory.JobIDResponse> RefreshAsync(RefreshRequest refreshRequest, string responseFields = null, CancellationToken ct = default(CancellationToken))
        {
            MozuClient<Mozu.Api.Contracts.Inventory.JobIDResponse> response;
            var client = Mozu.Api.Clients.Commerce.Inventory.ModifyInventoryClient.RefreshClient(refreshRequest, responseFields);
            client.WithContext(_apiContext);
            response = await client.ExecuteAsync(ct).ConfigureAwait(false);
            return await response.ResultAsync();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjustRequest"></param>
        /// <param name="responseFields"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public virtual async Task<Mozu.Api.Contracts.Inventory.JobIDResponse> AdjustAsync(AdjustRequest adjustRequest, string responseFields = null, CancellationToken ct = default(CancellationToken))
        {
            MozuClient<Mozu.Api.Contracts.Inventory.JobIDResponse> response;
            var client = Mozu.Api.Clients.Commerce.Inventory.ModifyInventoryClient.AdjustClient(adjustRequest, responseFields);
            client.WithContext(_apiContext);
            response = await client.ExecuteAsync(ct).ConfigureAwait(false);
            return await response.ResultAsync();
        }
        
        
        
    }
}