using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Mozu.Api.Config.Event
{
    public class EventSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public EntityCollection Events
        {
            get
            {
                EntityCollection entityCollection = (EntityCollection)base[""];
                return entityCollection;
            }
        }
    }
}