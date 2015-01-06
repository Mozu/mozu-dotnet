using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Mozu.Api.ToolKit.Config;
using Mozu.Api.WebToolKit.Filters;

namespace Mozu.Api.WebToolKit.Controllers
{
    [ApiAuthFilter]
    [RoutePrefix("api/application")]
    public class ApplicationController : ApiController
    {
        private readonly IAppSetting _appSetting;

        public ApplicationController(IAppSetting appSetting)
        {
            _appSetting = appSetting;
        }


        [Route("info")]
        [HttpGet]
        public AppInfo GetAppInfo()
        {
            return new AppInfo
            {
                NameSpace = _appSetting.Namespace,
                Version = _appSetting.Version,
                Package = _appSetting.PackageName
            };
        }
    }

    public class AppInfo
    {
        public string NameSpace;
        public string Version;
        public string Package;
    }
}
