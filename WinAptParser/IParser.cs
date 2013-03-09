using System;
using System.Collections;
using System.Text;
using WinApt.Common;

namespace WinApt.Parser
{
    public interface IParser
    {
        /// <summary>
        /// the parser has a appinfo list, contains appinfo parsed by itself. later for merge to appinfobase.
        /// </summary>
        AppInfoDB AppInfoDB
        {
            get;
        }
        /// <summary>
        /// if the page has it's own catalog, we have to map it to our catalog.
        /// </summary>
        Hashtable Catalog
        {
            get;
        }
        void Init();
        void UpdateData();
        void Parser(string content);
    }
}
