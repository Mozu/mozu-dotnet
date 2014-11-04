using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mozu.Api.WebToolKit.Filters;

namespace Mozu.Api.Sample.Web.Controllers
{
    public class HomeController : Controller
    {
        //[HttpPost]
        //[ConfigurationAuthFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}
