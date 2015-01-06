using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Mozu.Api.ToolKit.Test
{
    public class Bootstrapper : AbstractBootstrapper
    {
        public override void InitializeContainer(ContainerBuilder containerBuilder)
        {
            base.InitializeContainer(containerBuilder);
        }

        public override void PostInitialize()
        {
            base.PostInitialize();

        }
    }
}
