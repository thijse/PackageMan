using System;
using System.Collections;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using PlatformCommon;

namespace WinApt.Common
{   
    [XmlRoot("AppInfoDB")]
    public class AppInfoDB
    {

        public AppInfoDB()
        {
            //version = DateTime.Now.ToShortDateString();
            Items = new ArrayList();
            updateUrl = Defaults.RepositoryUrl;
        }
        
        [XmlElement("updateUrl")]
        public string updateUrl = string.Empty;
        
        //[XmlElement("AppInfoBaseList", typeof(AppInfoBaseList))]
        //public AppInfoBaseList appInfoBaseList = null;
        [XmlElement(Type = typeof(AppInfoBase))]
        public ArrayList Items = null;

        private int index = 0;

        /// <summary>
        /// find items in db
        /// </summary>
        /// <param name="type"></param>
        /// <param name="catalog"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public ArrayList FindItems(string type, string catalog, string prefix)
        {
            ArrayList ret = new ArrayList();
            for (int i = 0; i < Items.Count; i++)
            {
                AppInfoBase item = (AppInfoBase)Items[i];

                if (item.type != type) continue;

                if (item.name.IndexOf(prefix) == -1) continue;

                if (catalog == "All" || item.catalog == catalog)
                {
                    ret.Add(item.ToHashtable());
                }
            }
            return ret;
        }

        public void Add(AppInfoBase newItem)
        {
            if (Contains(newItem)!=-1)
                return;
            newItem.setIndex(index++);
            Items.Add(newItem);
        }

        public void Add(AppInfoDB items)
        {
            foreach (AppInfoBase item in items.Items)
            {
                Add(item);
            }
        }
        /// <summary>
        /// check wether it contains the item. useful when merge.
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public int Contains(AppInfoBase newItem)
        {
            foreach (AppInfoBase item in Items)
            {
                if (item.Equals(newItem))
                    return item.getIndex();
            }
            return -1;
        }
        /// <summary>
        /// check wether has older version of that app.
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public int HasOldVersion(AppInfoBase newItem)
        {
            foreach (AppInfoBase item in Items)
            {
                if (item.name == newItem.name && item.version != newItem.version)
                    return item.getIndex();
            }
            return -1;
        }
        public void SetIndex(int i)
        {
            index = i;
        }
        public int GetIndex()
        {
            return index;
        }

    }


    public class AppInfoBase
    {
        [XmlElement("name")]
        public string name = string.Empty;

        [XmlElement("url")]
        public string url = string.Empty;  //eg: www.winrar.com

        [XmlElement("version")]
        public string version = string.Empty;  //eg: 3.5.0

        [XmlElement("description")]
        public string description = string.Empty;  //eg: a archive tools

        [XmlElement("catalog")]
        public string catalog = string.Empty;  //eg: System

        [XmlElement("type")]
        public string type = string.Empty; //eg: Share Software

        [XmlElement("popular")]      //¡ï¡ï¡ï
        public int popular = 0;

        [XmlElement("icon")]
        public string icon = string.Empty; // icon/winrar.ico
        //state: needDownload, needUpdate, etc.
        protected int state = 0;

        public AppInfoBase(string name, string url, string version, string description, string catalog, string type, int popular, string icon)
        {
            this.name = name;
            this.url = url;
            this.version = version;
            this.description = description;
            this.catalog = catalog;
            this.type = type;
            this.popular = popular;
            this.icon = icon;
            this.state = 0;
        }


        public AppInfoBase() { }
        
        private int index;
        
        public override bool Equals(object obj)
        {
            if (obj is AppInfoBase)
            {
                AppInfoBase newItem = (AppInfoBase)obj;
                return newItem.name == name && newItem.version == version;
            }
            return false;
        }

        public int getIndex()
        {
            return index;
        }
        public void setIndex(int value)
        {
            index = value;
        }

        public Hashtable ToHashtable()
        {
            Hashtable ret = new Hashtable();
            ret.Add("name", name);
            ret.Add("version", version);
            ret.Add("url", url);
            ret.Add("description", description);
            ret.Add("catalog", catalog);
            ret.Add("type", type);
            ret.Add("popular", popular);
            ret.Add("icon", icon);
            ret.Add("state", state);
            ret.Add("index", index);
            return ret;
        }

        public int getState()
        {
            return state;
        }
        public void setState(int i)
        {
            state = i;
        }

    }
}
