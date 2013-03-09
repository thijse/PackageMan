using System;
using System.Collections;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WinApt.Common;

namespace WinApt.Client
{
    /// <summary>
    /// class to descript local config files.
    /// it should contains:
    /// local info: en_us, zh_cn, etc.
    /// app that has already downloaded
    /// local dirs
    /// </summary>
    [XmlRoot("AppInfoConfig")]
    public class AppInfoConfig
    {
        //update url: default is defined in Defaults.RepositoryUrl
        [XmlElement("updateUrl")]
        public string updateUrl = string.Empty;

        [XmlElement("UsingDB")]
        public string usingDB = string.Empty;

        [XmlElement("basePath")]
        public string basePath = string.Empty;

        [XmlElement(Type = typeof(AppInfoBase))]
        public ArrayList Items = null;

        public AppInfoConfig()
        {
            updateUrl = "";
            basePath = "";
            usingDB = "";
            Items = new ArrayList();
        }

        public AppInfoConfig(string basepath, string updateurl,string usingDB)
        {
            this.basePath = basepath;
            this.updateUrl = updateurl;
            this.usingDB = usingDB;
            Items = new ArrayList();
        }
    }
}
