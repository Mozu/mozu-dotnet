using System;
using System.Web.Mvc;
using Mozu.Api.Logging;
using Mozu.Api.Security;

namespace Mozu.Api.WebToolKit.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ConfigurationAuthFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger = LogManager.GetLogger(typeof(ConfigurationAuthFilter));

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!ConfigurationAuth.IsRequestValid(filterContext.HttpContext.Request))
                throw new UnauthorizedAccessException();
        }
    }
}
