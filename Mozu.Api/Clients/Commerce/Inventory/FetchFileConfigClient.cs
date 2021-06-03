using Mozu.Api.Contracts.Inventory;
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
    public partial class FetchFileConfigClient
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuClient<Mozu.Api.Contracts.Inventory.MFetchFileConfig> GetFetchConfigClient(string responseFields = null)
		{
			var url = Mozu.Api.Urls.Commerce.Inventory.FetchFileConfigUrl.GetFetchConfigUrl(responseFields);
			const string verb = "GET";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Inventory.MFetchFileConfig>()
									.WithVerb(verb).WithResourceUrl(url);
			return mozuClient;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fetchFileConfigRequest"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuClient<Mozu.Api.Contracts.Inventory.BaseResponse> SaveFetchConfigClient(FetchFileConfigRequest fetchFileConfigRequest,string responseFields = null)
		{
			var url = Mozu.Api.Urls.Commerce.Inventory.FetchFileConfigUrl.SaveFetchConfigUrl(fetchFileConfigRequest, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Inventory.BaseResponse>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Inventory.FetchFileConfigRequest>(fetchFileConfigRequest);
			return mozuClient;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fetchFileConfigID"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuClient<Mozu.Api.Contracts.Inventory.DeletedResponse> DeleteFetchConfigClient(long? fetchFileConfigID, string responseFields = null)
		{
			var url = Mozu.Api.Urls.Commerce.Inventory.FetchFileConfigUrl.DeleteFetchConfigUrl(fetchFileConfigID, responseFields);
			const string verb = "DELETE";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Inventory.DeletedResponse>()
									.WithVerb(verb).WithResourceUrl(url);
			
			return mozuClient;
		}
	}
}
