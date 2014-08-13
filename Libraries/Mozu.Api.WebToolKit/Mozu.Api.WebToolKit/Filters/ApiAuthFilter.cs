using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Mozu.Api.WebToolKit.Filters
{
    public class ApiAuthFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            var cookieToken = string.Empty;
            var formToken = string.Empty;

            IEnumerable<string> values;
            actionContext.Request.Headers.TryGetValues("cookieToken", out values);
            if (values != null) cookieToken = values.First();

            actionContext.Request.Headers.TryGetValues("formToken", out values);
            if (values != null) formToken = values.First();

            if (String.IsNullOrEmpty(formToken) || string.IsNullOrEmpty(cookieToken))
            {
                var content = actionContext.Request.Content.ReadAsFormDataAsync().Result;
                formToken = content["formToken"];
                cookieToken = content["cookieToken"];
            }

            try
            {
                AntiForgery.Validate(cookieToken, formToken);
            }
            catch (Exception)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

        }
    }
}
