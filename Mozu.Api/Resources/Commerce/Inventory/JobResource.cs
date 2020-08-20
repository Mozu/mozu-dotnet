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
    public partial class JobResource
    {
		///
		/// <see cref="Mozu.Api.ApiContext"/>
		///
		private readonly IApiContext _apiContext;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="apiContext"></param>
		public JobResource(IApiContext apiContext)
		{
			_apiContext = apiContext;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="contextModification"></param>
		/// <returns></returns>
		public JobResource CloneWithApiContext(Action<IApiContext> contextModification)
		{
			return new JobResource(_apiContext.CloneWith(contextModification));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="jobID"></param>
		/// <param name="responseFields"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<Mozu.Api.Contracts.Inventory.JobQueueResponse> GetJobAsync(long? jobID,string responseFields = null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<Mozu.Api.Contracts.Inventory.JobQueueResponse> response;
			var client = Mozu.Api.Clients.Commerce.Inventory.JobClient.GetJobClient(jobID, responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="locationCode"></param>
		/// <param name="limit"></param>
		/// <param name="owner"></param>
		/// <param name="types"></param>
		/// <param name="originalFilename"></param>
		/// <param name="responseFields"></param>
		/// <param name="ct"></param>
		/// <returns></returns>
		public virtual async Task<List<Mozu.Api.Contracts.Inventory.JobQueueResponse>> GetJobsAsync(string locationCode, int? limit, string owner, List<string> types, string originalFilename, string responseFields = null, CancellationToken ct = default(CancellationToken))
		{
			MozuClient<List<Mozu.Api.Contracts.Inventory.JobQueueResponse>> response;
			var client = Mozu.Api.Clients.Commerce.Inventory.JobClient.GetJobsClient(locationCode,limit,owner,types,originalFilename,responseFields);
			client.WithContext(_apiContext);
			response = await client.ExecuteAsync(ct).ConfigureAwait(false);
			return await response.ResultAsync();
		}
	}
}
