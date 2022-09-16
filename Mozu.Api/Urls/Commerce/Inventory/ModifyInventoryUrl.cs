using Mozu.Api.Contracts.Inventory;

namespace Mozu.Api.Urls.Commerce.Inventory
{
    public partial class ModifyInventoryUrl
    {
        
        public static MozuUrl RefreshUrl(RefreshRequest refreshRequest, string responseFields = null)
        {
            var url = "/api/commerce/inventory/v5/inventory/refresh/?responseFields={responseFields}";
            var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);			
            mozuUrl.FormatUrl("responseFields", responseFields);
            return mozuUrl;
        }
        
        public static MozuUrl AdjustUrl(AdjustRequest adjustRequest, string responseFields = null)
        {
            var url = "/api/commerce/inventory/v5/inventory/adjust/?responseFields={responseFields}";
            var mozuUrl = new MozuUrl(url, MozuUrl.UrlLocation.TENANT_POD, false);			
            mozuUrl.FormatUrl("responseFields", responseFields);
            return mozuUrl;
        }
        
    }
}