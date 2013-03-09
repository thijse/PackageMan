using System;
using System.Collections;
using System.Text;
using WinApt.Common;

namespace WinApt.Parser
{
    public class HTMLParser : IParser
    {

        protected string mainPageUrl = "";
        protected string[] pageUrls = null;
        public string[] PageUrls
        {
            get
            {
                return pageUrls;
            }
            set
            {
                pageUrls = value;
            }
        }
        public string MainPageUrl
        {
            get
            {
                return mainPageUrl;
            }
            set
            {
                mainPageUrl = value;
            }
        }
        protected Hashtable catalogMap;
        protected string content;
        public AppInfoDB myAppInfoDB;

        public AppInfoDB AppInfoDB
        {
            get
            {
                return myAppInfoDB;
            }
        }


        #region IParser Members

        public Hashtable Catalog
        {
            get { return catalogMap; }
        }

        public virtual void Init()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public virtual void UpdateData()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public virtual void Parser(string content)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        public HTMLParser()
        {
            catalogMap = new Hashtable();
            myAppInfoDB = new AppInfoDB();
        }

    }
}
