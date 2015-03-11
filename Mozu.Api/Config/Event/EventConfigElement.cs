using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Mozu.Api.Config.Event
{
      public class EventConfigElement : ConfigurationElement
      {        
  
          public EventConfigElement()
      {
      }
  
          public EventConfigElement(string action, string method)
          {             
              this.Action = action;
              this.Method = method;
          }

          [ConfigurationProperty("action", IsRequired = true, IsKey = true, DefaultValue = "")]
          public string Action
          {
              get { return (string)this["action"]; }
              set { this["action"] = value; }
          }

          [ConfigurationProperty("method", IsRequired = true, IsKey = true, DefaultValue = "")]
          public string Method
          {
              get { return (string)this["method"]; }
              set { this["mehod"] = value; }
          }        
  
  
      } 
}