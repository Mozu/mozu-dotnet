using Mozu.Api.Contracts.Fulfillment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mozu.Api.Clients.Commerce.Fulfillment
{
    public partial class ShipmentPackagesClient
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="package"></param>
		/// <param name="shipmentNumber"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuClient<Mozu.Api.Contracts.Fulfillment.EntityModelOfShipment> NewPackageClient(int shipmentNumber, Package package, string responseFields = null)
		{
			var url = Mozu.Api.Urls.Commerce.Fulfillment.ShipmentPackagesUrl.NewPackageUrl(shipmentNumber, package, responseFields);
			const string verb = "POST";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Fulfillment.EntityModelOfShipment>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Fulfillment.Package>(package);
			;
			return mozuClient;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="package"></param>
		/// <param name="packageId"></param>
		/// <param name="shipmentNumber"></param>
		/// <param name="responseFields"></param>
		/// <returns></returns>
		public static MozuClient<Mozu.Api.Contracts.Fulfillment.EntityModelOfShipment> UpdatePackageClient(int shipmentNumber, string packageId, Package package, string responseFields = null)
		{
			var url = Mozu.Api.Urls.Commerce.Fulfillment.ShipmentPackagesUrl.UpdatePackageUrl(shipmentNumber, packageId, package,responseFields);
			const string verb = "PUT";
			var mozuClient = new MozuClient<Mozu.Api.Contracts.Fulfillment.EntityModelOfShipment>()
									.WithVerb(verb).WithResourceUrl(url)
									.WithBody<Mozu.Api.Contracts.Fulfillment.Package>(package);
			;
			return mozuClient;
		}
	}
}
