using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Mozu.Api.ToolKit.Config;

namespace Mozu.Api.ToolKit.Test
{
    public class BaseTest
    {

        public IContainer Container;
        protected int TenantId;
        public BaseTest()
        {
            Container = new Bootstrapper().Bootstrap().Container;
            var appSetting = Container.Resolve<IAppSetting>();
            TenantId = int.Parse(appSetting.Settings["TenantId"].ToString());
        }
    }
}
