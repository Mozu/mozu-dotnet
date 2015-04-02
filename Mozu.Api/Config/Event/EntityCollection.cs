using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Mozu.Api.Config.Event
{
    public class EntityCollection : ConfigurationElementCollection
    {
        public EntityCollection()
        {
            EntityConfigElement details = (EntityConfigElement)CreateNewElement();
            if (details.Name != "")
            {
                Add(details);
            }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new EntityConfigElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((EntityConfigElement)element).Name;
        }

        public EntityConfigElement this[int index]
        {
            get
            {
                return (EntityConfigElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public EntityConfigElement this[string name]
        {
            get
            {
                return (EntityConfigElement)BaseGet(name);
            }
        }

        public int IndexOf(EntityConfigElement details)
        {
            return BaseIndexOf(details);
        }

        public void Add(EntityConfigElement details)
        {
            BaseAdd(details);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(EntityConfigElement details)
        {
            if (BaseIndexOf(details) >= 0)
                BaseRemove(details.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override string ElementName
        {
            get { return "entity"; }
        }
    }
}