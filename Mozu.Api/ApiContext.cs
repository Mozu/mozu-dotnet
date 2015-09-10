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
        string UserId { get; set; }
		string Locale { get; set; }
		string Currency { get; set; }

        AuthTicket UserAuthTicket { get; set; }

		IApiContext CloneWith(Action<IApiContext> contextModification);
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
        public string UserId { get; set; }

		public string Locale { get; set; }
		public string Currency { get; set; }

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
		    var tenantIdStr = headers.Get(Headers.X_VOL_TENANT);
            if (!String.IsNullOrEmpty(tenantIdStr))
	    		TenantId = int.Parse(tenantIdStr);
			CorrelationId = headers.Get(Headers.X_VOL_CORRELATION);
			HMACSha256 = headers.Get(Headers.X_VOL_HMAC_SHA256);
		    Date = headers.Get(Headers.DATE);
		    UserId = headers.Get(Headers.USERID);

		    var siteIdStr = headers.Get(Headers.X_VOL_SITE);
            if (!String.IsNullOrEmpty(siteIdStr))
                SiteId = int.Parse(siteIdStr);

   			var masterCatalogStr = headers.Get(Headers.X_VOL_MASTER_CATALOG);
			if (!String.IsNullOrEmpty(masterCatalogStr))
                MasterCatalogId = int.Parse(masterCatalogStr);

			var catalogStr = headers.Get(Headers.X_VOL_CATALOG);
			if (!String.IsNullOrEmpty(catalogStr))
				CatalogId = int.Parse(catalogStr);

			if (!String.IsNullOrEmpty(TenantUrl))
				TenantUrl = TenantUrl;

			if (!String.IsNullOrEmpty(SiteUrl))
				SiteUrl = SiteUrl;

		}

		public ApiContext(HttpRequestHeaders headers)
		{
			TenantUrl = HttpHelper.GetHeaderValue(Headers.X_VOL_TENANT_DOMAIN, headers);
            SiteUrl = HttpHelper.GetHeaderValue(Headers.X_VOL_SITE_DOMAIN, headers);
            TenantId = HttpHelper.ParseFirstValue(Headers.X_VOL_TENANT, headers).GetValueOrDefault(0);
            SiteId = HttpHelper.ParseFirstValue(Headers.X_VOL_SITE, headers);
            CorrelationId = HttpHelper.GetHeaderValue(Headers.X_VOL_CORRELATION, headers);
            HMACSha256 = HttpHelper.GetHeaderValue(Headers.X_VOL_HMAC_SHA256, headers);
		    Date = HttpHelper.GetHeaderValue(Headers.DATE, headers);
            MasterCatalogId = HttpHelper.ParseFirstValue(Headers.X_VOL_MASTER_CATALOG, headers);
			CatalogId = HttpHelper.ParseFirstValue(Headers.X_VOL_CATALOG, headers);
			Locale = HttpHelper.GetHeaderValue(Headers.X_VOL_LOCALE, headers);
			Currency = HttpHelper.GetHeaderValue(Headers.X_VOL_CURRENCY, headers);
		    UserId = HttpHelper.GetHeaderValue(Headers.USERID, headers);

			if (!String.IsNullOrEmpty(TenantUrl))
			{
				TenantUrl = TenantUrl;
			}

			if (!String.IsNullOrEmpty(SiteUrl))
			{
				SiteUrl = SiteUrl;
			}

		}

		public IApiContext CloneWith(Action<IApiContext> contextModification)
		{
			var cloned = new ApiContext()
			{
				AppAuthClaim = (!String.IsNullOrEmpty(this.AppAuthClaim) ? (string)this.AppAuthClaim.Clone() : null),
				CatalogId = this.CatalogId,
				CorrelationId = this.CorrelationId,
				Currency =  ( !String.IsNullOrEmpty(this.Currency) ? (string)this.Currency.Clone() : null),
				Date = ( !String.IsNullOrEmpty(this.Date) ?  (string)this.Date.Clone() : null),
				HMACSha256 =( !String.IsNullOrEmpty(this.HMACSha256)  ? (string)this.HMACSha256.Clone() : null),
				Locale =  (!String.IsNullOrEmpty(this.Locale) ?  (string)this.Locale.Clone() : null),
				MasterCatalogId = this.MasterCatalogId,
				SiteId = this.SiteId,
				SiteUrl = (!String.IsNullOrEmpty(this.SiteUrl) ?  (string)this.SiteUrl.Clone() : null),
				Tenant = this.Tenant,
				TenantId = this.TenantId,
				TenantUrl = (!String.IsNullOrEmpty(this.TenantUrl) ? (string)this.TenantUrl.Clone() : null),
				UserAuthTicket = this.UserAuthTicket
			};

			contextModification(cloned);
			return cloned;
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
