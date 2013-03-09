/*
 * Created by SharpDevelop.
 * User: zhou
 * Date: 2007-8-29
 * Time: 14:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using WinApt.Client.GUI;
using WinApt.Common;
using System.Diagnostics;


namespace WinApt.Client
{
    /// <summary>
    /// Description of CmdMgr.
    /// </summary>
    public class CmdMgr
    {
        
        private AppInfoConfig myConfig = null;
        private AppInfoDB myAppDB = null;
        private ArrayList selItems = null;
        private ArrayList delItems = null;

        #region define property
        public CmdMgr() 
        {
            selItems = new ArrayList();
            delItems = new ArrayList();
        }

        public AppInfoConfig Config
        {
            get
            {
                return myConfig;
            }
            set
            {
                myConfig = value;
            }
        }

        public AppInfoDB InfoDB
        {
            get
            {
                return myAppDB;
            }
            set
            {
                myAppDB = value;
            }
        }
        public ArrayList SelectItems
        {
            get
            {
                return selItems;
            }
            set
            {
                selItems = value;
            }
        }
        public ArrayList DelectItems
        {
            get
            {
                return delItems;
            }
            set
            {
                delItems = value;
            }
        }
        #endregion
        /// <summary>
        /// find appinfo of database
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="isSearch"></param>
        /// <returns></returns>
        public ArrayList FindAppInfoList(string type, string catalog, string prefix)
        {
            return myAppDB.FindItems(type, catalog, prefix);
        }

        /// <summary>
        /// give an index, return an appinfo, used when user select a appinfo.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Hashtable FindAppInfo(int index)
        {
            return ((AppInfoBase)myAppDB.Items[index]).ToHashtable();
        }

        /// <summary>
        /// explore the file
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ExploreFile(int index)
        {
            string fileName = GetFilePath(index);
            if (File.Exists(fileName))
            {
                Process.Start("Explorer.exe","/select, " + fileName);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Open a file
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool OpenFile(int index)
        {
            string fileName = GetFilePath(index);
            if (File.Exists(fileName))
            {
                System.Diagnostics.Process.Start(fileName);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// get the local file path of certain item.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetFilePath(int index)
        {
            AppInfoBase it = (AppInfoBase)this.myAppDB.Items[index];
            string filename = it.url;
            filename = filename.Substring(filename.LastIndexOf('/') + 1);
            filename = this.myConfig.basePath + @"\" + it.catalog + @"\" + filename;
            return filename;
        }

        public void UpdateAppDB(string content)
        {
            //load data from remote db.
            this.myAppDB = (AppInfoDB)WinAptLib.ReadFromStream(typeof(AppInfoDB), content);

            for (int i = 0; i < myAppDB.Items.Count; i++)
            {
                ((AppInfoBase)myAppDB.Items[i]).setIndex(i);
            }

            //compare with local data
            foreach (AppInfoBase item in this.myConfig.Items)
            {
                int index = 0;
                //already contains, mark as needDownload
                if ((index = myAppDB.Contains(item)) != -1)
                {
                    ((AppInfoBase)myAppDB.Items[index]).setState(WinAptLib.Downloaded);
                }
                //has older version, mark as needUpdate
                if ((index = myAppDB.HasOldVersion(item)) != -1)
                {
                    ((AppInfoBase)myAppDB.Items[index]).setState(WinAptLib.NewVersion);
                    ((AppInfoBase)myAppDB.Items[index]).version = ((AppInfoBase)item).version;
                }
            }
        }
    }
}
