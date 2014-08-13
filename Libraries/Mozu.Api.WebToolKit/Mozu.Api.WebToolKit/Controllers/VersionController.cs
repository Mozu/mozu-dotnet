using System.Linq;
using System.Web.Http;
using Mozu.Api.WebToolKit.Models;

namespace Mozu.Api.WebToolKit.Controllers
{
    [RoutePrefix("api/version")]
    public class VersionController : ApiController
    {

        public IHttpActionResult Get()
        {
            var versions = Helper.GetVersions();
            return Ok(versions);
        }

        [Route("app/{appName}")]
        public IHttpActionResult GetAppVersion(string appName)
        {
            var versions = Helper.GetVersions();
            var appVersion = versions.Assemblies.SingleOrDefault(x => x.Name.Equals(appName));
            if (appVersion != null)
                versions.AppVersion = appVersion.Version;
            return Ok(versions);
            
        }

    }
}
