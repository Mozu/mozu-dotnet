using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Mozu.Api.WebToolKit;

namespace Mozu.Api.Sample.Web
{
    public class Bootstrapper : AbstractWebApiBootstrapper
    {

        public override void InitializeContainer(ContainerBuilder containerBuilder)
        {
            base.InitializeContainer(containerBuilder);
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            base.PostInitialize();

        }


    }
}