using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Mozu.Api.Resources.Platform;
using Mozu.Api.WebToolKit.Filters;

namespace Mozu.Api.Sample.Web.Controllers
{
    public class HomeController : Controller
    {
        //[HttpPost]
        //[ConfigurationAuthFilter]
        public async Task<ActionResult> Index(int? tenantId)
        {

            if (tenantId.HasValue)
            {
                var tenantResource = new TenantResource();
                var tenant = await tenantResource.GetTenantAsync(tenantId.Value);
            }

            string cookieToken;
            string formToken;

            AntiForgery.GetTokens(null, out cookieToken, out formToken);
            ViewBag.cookieToken = cookieToken;
            ViewBag.formToken = formToken;
            return View();
        }
    }
}
