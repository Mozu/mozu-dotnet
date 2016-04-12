using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Contracts.CommerceRuntime.Products;
using Category = Mozu.Api.Contracts.ProductAdmin.Category;
using Mozu.Api.Contracts.Tenant;
using Mozu.Api.Resources.Platform;

namespace Mozu.Api
{
	public class MozuUrl
	{
		public enum UrlLocation
		{
			HOME_POD,
			TENANT_POD,
			PCI_POD
		}

       
        
		public string Url { get; set; }
		public UrlLocation Location { get; set; }
        public bool UseSSL { get; set; }

		public MozuUrl(string url, UrlLocation location, bool useSSL)
		{
			Url = url.ToLower();
			Location = location;
            UseSSL = useSSL;
		}

		public void FormatUrl(string paramName, object value)
		{
		    paramName = paramName.ToLower();
           
            Url = Url.Replace("{" + paramName + "}", value == null ? "" : value.ToString());
            Url = Url.Replace("{*" + paramName + "}", value == null ? "" : value.ToString());
			var removeString = "&" + paramName + "=";
            if (value == null && Url.Contains(removeString)) Url = Url.Replace(removeString, "");

			removeString = paramName + "=";
            if (value == null && Url.Contains(removeString)) Url = Url.Replace(removeString, "");

			removeString = "/?";
            if (Url.EndsWith(removeString)) Url = Url.Replace(removeString, "");
            if (Url.EndsWith(removeString + "&")) Url = Url.Replace(removeString + "&", "");
            if (Url.EndsWith("&")) Url = Url.Substring(0, Url.Length - 1);

            if (Url.Contains("/?&")) Url = Url.Replace("/?&", "/?");

            if (Url.EndsWith("?")) Url = Url.Replace("?", "");
		}

	    public static string GetProductUrl(int tenantId, int siteId, string productCode)
	    {
	        var site = GetSite(tenantId, siteId);
	        return GetProductUrl(site, productCode);
	    }

	    public static string GetProductUrl(Site site, string productCode)
	    {
            var domain = GetSiteDomain(site);
            return string.Format("https://{0}/p/{1}", domain, productCode);
	    }

	    public static string GetCategoryUrl(Site site, Category category)
	    {
	        var domain = GetSiteDomain(site);

	        return String.IsNullOrEmpty(category.Content.Slug) ? 
                string.Format("https://{0}/c/{1}", domain, category.Id) : 
                string.Format("https://{0}/{1}/c/{2}", domain,category.Content.Slug, category.Id);
	    }

        public static string GetCategoryUrl(int tenantId, int siteId, Category category)
        {
            var site = GetSite(tenantId, siteId);
            return GetCategoryUrl(site, category);
        }

	    public static string GetSiteDomain(Site site)
	    {
            return !String.IsNullOrEmpty(site.PrimaryCustomDomain) ? site.PrimaryCustomDomain : site.Domain;
	    }

	    private static Site GetSite(int tenantId, int siteId)
	    {
            var tenantResource = new TenantResource();
            var tenant = tenantResource.GetTenant(tenantId);
            var site = tenant.Sites.SingleOrDefault(x => x.Id.Equals(siteId));

            if (site == null) throw new Exception(string.Format("{0} not found for tenant {1}", siteId, tenantId));
	        return site;
	    }

	}
}
