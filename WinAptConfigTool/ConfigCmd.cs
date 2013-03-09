using System;
using System.Collections.Generic;
using System.Text;
using WinApt.Common;

namespace WinApt.ConfigTool
{
    class ConfigCmd
    {
        private AppInfoDB myAppDB = null;
        private AppInfoBase curItem = null;

        public AppInfoDB AppDB
        {
            get
            {
                return myAppDB;
            }
        }

        public AppInfoBase CurItem
        {
            get { return curItem; }
            set { curItem = value;}
        }
        public ConfigCmd()
        {
            myAppDB = new AppInfoDB();
        }

        public void LoadDB(string fileName)
        {
            myAppDB = (AppInfoDB)WinAptLib.ReadFromFile(typeof(AppInfoDB), fileName);
            for (int i = 0; i < myAppDB.Items.Count; i++)
            {
                ((AppInfoBase)myAppDB.Items[i]).setIndex(i);
            }
            myAppDB.SetIndex(myAppDB.Items.Count);
        }
        public void SaveDB(string fileName)
        {
            WinAptLib.WriteToFile(myAppDB, fileName);
        }

        internal System.Collections.ArrayList FindAppInfoList(string type, string catalog, string prefix)
        {
            return myAppDB.FindItems(type, catalog, prefix);
        }

        internal System.Collections.Hashtable FindAppInfo(int index)
        {
            return ((AppInfoBase)myAppDB.Items[index]).ToHashtable();
        }

        internal void MergeDB(string newFile)
        {
            AppInfoDB tmpDB = (AppInfoDB)WinAptLib.ReadFromFile(typeof(AppInfoDB), newFile);
            foreach (AppInfoBase item in tmpDB.Items)
            {
                myAppDB.Add(item);
            }
        }
    }
}
