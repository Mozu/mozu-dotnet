using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using Mozu.Api.Contracts.Tenant;
using Mozu.Api.Security;
using Mozu.Api.Utilities;

namespace Mozu.Api
{
    
	public interface IApiContext
	{
		int TenantId { get; set; }
		int? SiteId { get; set;  }
		string TenantUrl { get; }
		string SiteUrl { get; }
		string CorrelationId { get; set; }
		string HMACSha256 { get; }
        string AppAuthClaim { get; set; }
		int? MasterCatalogId { get; set; }
		int? CatalogId { get; set; }
        Tenant Tenant { get; }
	    string Date { get; }

        AuthTicket UserAuthTicket { get; set; }
	}

    [Serializable]
    public class ApiContext : IApiContext
    {
        public int TenantId {get; set;}
        public int? SiteId { get;  set; }
		public string TenantUrl { get; set; }
		public string SiteUrl { get; protected set; }
		public string CorrelationId { get;  set; }
		public string HMACSha256 { get; protected set; }
		public string AppAuthClaim { get; set; }
        public int? MasterCatalogId{ get; set; }

        public int? CatalogId { get;  set; }
        public Tenant Tenant { get; set; }
        public AuthTicket UserAuthTicket { get; set; }

        public string Date { get; protected set; }

		public ApiContext()
		{
		}

		public ApiContext(int tenantId, int? siteId = null, int? masterCatalogId = null, int? catalogId = null)
		{
			TenantId = tenantId;
			SiteId = siteId;
			MasterCatalogId = masterCatalogId;
			CatalogId = catalogId;
		}

		public ApiContext(Tenant tenant, Site site = null, int? masterCatalogId = null, int? catalogId = null)
		{
            Tenant = tenant;
			TenantId = tenant.Id;
			TenantUrl = tenant.Domain;
			MasterCatalogId = masterCatalogId;
			CatalogId = catalogId;

            SetBySite(site);

            if (!masterCatalogId.HasValue && Tenant.MasterCatalogs.Count == 1)
            {
                MasterCatalogId = Tenant.MasterCatalogs.First().Id;
                if (Tenant.MasterCatalogs[0].Catalogs.Count == 1)
                    CatalogId = Tenant.MasterCatalogs.First().Catalogs.First().Id;
            }

        }

		public ApiContext(Site site, int? masterCatalogId = null, int? catalogId = null)
		{
			TenantId = site.TenantId;
			MasterCatalogId = masterCatalogId;
			CatalogId = catalogId;
		    SetBySite(site);

		}

		public ApiContext(NameValueCollection headers)
		{
			TenantUrl = headers.Get(Headers.X_VOL_TENANT_DOMAIN);
			SiteUrl = headers.Get(Headers.X_VOL_SITE_DOMAIN);
			TenantId = int.Parse(headers.Get(Headers.X_VOL_TENANT));
			SiteId = int.Parse(headers.Get(Headers.X_VOL_SITE));
			CorrelationId = headers.Get(Headers.X_VOL_CORRELATION);
			HMACSha256 = headers.Get(Headers.X_VOL_HMAC_SHA256);
		    Date = headers.Get(Headers.DATE);
			var masterCatalogStr = headers.Get(Headers.X_VOL_MASTER_CATALOG);

			if (masterCatalogStr != null)
			{
				MasterCatalogId = int.Parse(masterCatalogStr);
			}

			var catalogStr = headers.Get(Headers.X_VOL_CATALOG);
			if (catalogStr != null)
			{
				CatalogId = int.Parse(catalogStr);
			}


			if (!String.IsNullOrEmpty(TenantUrl))
			{
				TenantUrl = TenantUrl;
			}

			if (!String.IsNullOrEmpty(SiteUrl))
			{
				SiteUrl = SiteUrl;
			}

		}

		public ApiContext(HttpRequestHeaders headers)
		{
			TenantUrl = HttpHelper.GetHeaderValue(Headers.X_VOL_TENANT_DOMAIN, headers);
            SiteUrl = HttpHelper.GetHeaderValue(Headers.X_VOL_SITE_DOMAIN, headers);
            TenantId = HttpHelper.ParseFirstValue(Headers.X_VOL_TENANT, headers).Value;
            SiteId = HttpHelper.ParseFirstValue(Headers.X_VOL_SITE, headers);
            CorrelationId = HttpHelper.GetHeaderValue(Headers.X_VOL_CORRELATION, headers);
            HMACSha256 = HttpHelper.GetHeaderValue(Headers.X_VOL_HMAC_SHA256, headers);
		    Date = HttpHelper.GetHeaderValue(Headers.DATE, headers);
            MasterCatalogId = HttpHelper.ParseFirstValue(Headers.X_VOL_MASTER_CATALOG, headers);
            CatalogId = HttpHelper.ParseFirstValue(Headers.X_VOL_CATALOG, headers);
			

			if (!String.IsNullOrEmpty(TenantUrl))
			{
				TenantUrl = TenantUrl;
			}

			if (!String.IsNullOrEmpty(SiteUrl))
			{
				SiteUrl = SiteUrl;
			}

		}

       

        private void SetBySite(Site site)
        {
            if (site != null && site.Id >= 0)
            {
                SiteId = site.Id;
                SiteUrl = site.Domain;
            }
        }

    }
}
