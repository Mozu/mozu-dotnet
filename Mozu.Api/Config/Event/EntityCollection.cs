using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
//using System.Web;
//using System.Configuration;

namespace Mozu.Api.Config.Event
{
    //public class EntityCollection : ConfigurationElementCollection
    //{
    //    public EntityCollection()
    //    {
    //        EntityConfigElement details = (EntityConfigElement)CreateNewElement();
    //        if (details.Name != "")
    //        {
    //            Add(details);
    //        }
    //    }

    //    public override ConfigurationElementCollectionType CollectionType
    //    {
    //        get
    //        {
    //            return ConfigurationElementCollectionType.BasicMap;
    //        }
    //    }

    //    protected override ConfigurationElement CreateNewElement()
    //    {
    //        return new EntityConfigElement();
    //    }

    //    protected override Object GetElementKey(ConfigurationElement element)
    //    {
    //        return ((EntityConfigElement)element).Name;
    //    }

    //    public EntityConfigElement this[int index]
    //    {
    //        get
    //        {
    //            return (EntityConfigElement)BaseGet(index);
    //        }
    //        set
    //        {
    //            if (BaseGet(index) != null)
    //            {
    //                BaseRemoveAt(index);
    //            }
    //            BaseAdd(index, value);
    //        }
    //    }

    //    new public EntityConfigElement this[string name]
    //    {
    //        get
    //        {
    //            return (EntityConfigElement)BaseGet(name);
    //        }
    //    }

    //    public int IndexOf(EntityConfigElement details)
    //    {
    //        return BaseIndexOf(details);
    //    }

    //    public void Add(EntityConfigElement details)
    //    {
    //        BaseAdd(details);
    //    }
    //    protected override void BaseAdd(ConfigurationElement element)
    //    {
    //        BaseAdd(element, false);
    //    }

    //    public void Remove(EntityConfigElement details)
    //    {
    //        if (BaseIndexOf(details) >= 0)
    //            BaseRemove(details.Name);
    //    }

    //    public void RemoveAt(int index)
    //    {
    //        BaseRemoveAt(index);
    //    }

    //    public void Remove(string name)
    //    {
    //        BaseRemove(name);
    //    }

    //    public void Clear()
    //    {
    //        BaseClear();
    //    }

    //    protected override string ElementName
    //    {
    //        get { return "entity"; }
    //    }
    //}

    public class EntityCollection //: ConfigurationElementCollection
    {
        private IList<EntityConfigElement> _entityConfigElements;
        public EntityCollection(List<EntityConfigElement>  entityConfigElements)
        {
            EntityConfigElement details = (EntityConfigElement)CreateNewElement();
            if (details.Name != "")
            {
                Add(details);
            }
            _entityConfigElements = entityConfigElements;
        }

        //Yet to find the equivalent of it
        //public override ConfigurationElementCollectionType CollectionType
        //{
        //    get
        //    {
        //        return ConfigurationElementCollectionType.BasicMap;
        //    }
        //}

        protected EntityConfigElement CreateNewElement()
        {
            return new EntityConfigElement();
        }

        protected  Object GetElementKey(EntityConfigElement element)
        {
            return element.Name;
        }

        public EntityConfigElement this[int index]
        {
            get
            {
                return _entityConfigElements[index];
            }
            set
            {
                if (_entityConfigElements[index] != null)
                {
                    _entityConfigElements.RemoveAt(index);
                }
                _entityConfigElements.Insert(index, value);
            }
        }

        new public EntityConfigElement this[string name]
        {
            get
            {
                return _entityConfigElements.Where(x => x.Name.Equals(name)).First();//(EntityConfigElement)BaseGet(name);
            }
        }

        public int IndexOf(EntityConfigElement details)
        {
            return _entityConfigElements.IndexOf(details);//BaseIndexOf(details);
        }

        public void Add(EntityConfigElement details)
        {
            //BaseAdd(details);
            _entityConfigElements.Add(details);
        }
        protected void BaseAdd(EntityConfigElement element)
        {
            _entityConfigElements.Add(element);
        }

        public void Remove(EntityConfigElement details)
        {
            if (_entityConfigElements.IndexOf(details) >= 0)
                _entityConfigElements.Remove(details);
        }

        public void RemoveAt(int index)
        {
            //BaseRemoveAt(index);
            _entityConfigElements.RemoveAt(index);
        }

        public void Remove(string name)
        {
            _entityConfigElements.Remove(_entityConfigElements.Where(x => x.Name.Equals(name)).First());
        }

        public void Clear()
        {
            _entityConfigElements.Clear();
        }

        protected string ElementName
        {
            get { return "entity"; }
        }
    }
}