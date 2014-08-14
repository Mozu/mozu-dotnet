using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Mozu.Api.Config.Event
{
         public class EntityConfigElement: ConfigurationElement
      {
  
          [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
          public string Name
          {
              get { return (string)this["name"]; }
              set { this["name"] = value; }
          }
    
         [ConfigurationProperty("assemblyName", IsRequired = false)]
          public string AssemblyName
          {
              get { return (string)this["assemblyName"]; }
              set { this["assemblyName"] = value; }
          }

         [ConfigurationProperty("type", IsRequired = false)]
         public string Type
         {
             get { return (string)this["type"]; }
             set { this["type"] = value; }
         }
            
          [ConfigurationProperty("events", IsDefaultCollection = false)]
          public EventCollection Events
          {
              get { return (EventCollection)base["events"]; }
          }
      }
}