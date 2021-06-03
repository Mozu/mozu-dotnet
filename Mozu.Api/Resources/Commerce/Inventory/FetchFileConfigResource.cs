using Mozu.Api.Contracts.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mozu.Api.Resources.Commerce.Inventory
{
	/// <summary>
	/// 
	/// </summary>
    public partial class FetchFileConfigResource
    {
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="apiContext"></param>
		public FetchFileConfigResource(IApiContext apiContext)
		{
			_apiContext = apiContext;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="contextModification"></param>
		/// <returns></returns>
		public FetchFileConfigResource CloneWithApiContext(Action<IApiContext> contextModification)
		{
			return new FetchFileConfigResource(_apiContext.CloneWith(contextModification));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<Mozu.Api.Contracts.Inventory.MFetchFileConfig> GetFetchConfigAsync(string responseFields = null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Inventory.MFetchFileConfig> response;
			var client = Mozu.Api.Clients.Commerce.Inventory.FetchFileConfigClient.GetFetchConfigClient(responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fetchFileConfigRequest"></param>
		/// <param name="responseFields"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<Mozu.Api.Contracts.Inventory.BaseResponse> SaveFetchConfigAsync(FetchFileConfigRequest fetchFileConfigRequest, string responseFields = null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Inventory.BaseResponse> response;
			var client = Mozu.Api.Clients.Commerce.Inventory.FetchFileConfigClient.SaveFetchConfigClient(fetchFileConfigRequest,responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fetchFileConfigID"></param>
		/// <param name="responseFields"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<Mozu.Api.Contracts.Inventory.DeletedResponse> DeleteFetchConfigAsync(long? fetchFileConfigID,string responseFields = null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Inventory.DeletedResponse> response;
			var client = Mozu.Api.Clients.Commerce.Inventory.FetchFileConfigClient.DeleteFetchConfigClient(fetchFileConfigID,responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}
	}
}
