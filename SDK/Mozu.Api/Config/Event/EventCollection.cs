using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Mozu.Api.Config.Event
{
    public class EventCollection : ConfigurationElementCollection
    {

        public new EventConfigElement this[string name]
        {
            get
              {
                  if (IndexOf(name) < 0) return null;
  
                  return (EventConfigElement)BaseGet(name);
              }
        }

        public EventConfigElement this[int index]
        {
            get { return (EventConfigElement)BaseGet(index); }
        }

        public int IndexOf(string action)
          {
              action = action.ToLower();
  
              for (int idx = 0; idx < base.Count; idx++)
              {
                  if (this[idx].Action.ToLower() == action)
                      return idx;
              }
              return -1;
          }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new EventConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EventConfigElement)element).Action;
        }

        protected override string ElementName
        {
            get { return "event"; }
        }
    }
}