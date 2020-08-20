using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Clients.Commerce.Inventory
{
	/// <summary>
	/// 
	/// </summary>
    public partial class JobClient
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="jobID"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuClient<Mozu.Api.Contracts.Inventory.JobQueueResponse> GetJobClient(long? jobID, string responseFields = null)
		{
			var url = Mozu.Api.Urls.Commerce.Inventory.JobUrl.GetJobUrl(jobID, responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Inventory.JobQueueResponse>()
									.WithVerb(verb).WithResourceUrl(url);

			return mozuClient;
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
		/// <returns></returns>
		public static MozuClient<List<Mozu.Api.Contracts.Inventory.JobQueueResponse>> GetJobsClient(string locationCode, int? limit, string owner, List<string> types, string originalFilename, string responseFields = null)
		{
			var url = Mozu.Api.Urls.Commerce.Inventory.JobUrl.GetJobsUrl(locationCode,limit,owner,types,originalFilename,responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<List<Mozu.Api.Contracts.Inventory.JobQueueResponse>>()
									.WithVerb(verb).WithResourceUrl(url);

			return mozuClient;
		}
	}
}
