/*
 * Created by SharpDevelop.
 * User: zhou
 * Date: 2007-8-29
 * Time: 14:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using WinApt.Common;
using System.Text;
using System.Web;

namespace WinApt.Parser
{
    /// <summary>
    /// Description of winapt_net_Parser.
    /// </summary>
    public class WinGetParser:HTMLParser
    {

        #region define Property
        public WinGetParser()
        {
            Init();
        }
        #endregion

        private string surfix = "?pg=";
        private string content = "";
        public override void Init()
        {
            this.mainPageUrl = @"http://windows-get.sourceforge.net/listapps.php";
            catalogMap.Add("Chat", "Internet");
            catalogMap.Add("Mail", "Internet");
            catalogMap.Add("WWW", "Internet");
            catalogMap.Add("FTP", "Internet");
            catalogMap.Add("Networking", "Internet");
            catalogMap.Add("P2P", "Internet");
            catalogMap.Add("News", "Internet");
            catalogMap.Add("Other", "Other");
            catalogMap.Add("Editors", "Office");
            catalogMap.Add("Graphics", "Graphics");
            catalogMap.Add("Antispy", "System");
            catalogMap.Add("Antivirus", "System");
            catalogMap.Add("Firewall", "System");
            catalogMap.Add("System", "System");
            catalogMap.Add("Lang", "Program");
            catalogMap.Add("Utilities", "Accessories");
            catalogMap.Add("Video", "Media");
            catalogMap.Add("Print", "Office");
            catalogMap.Add("Multimedia", "Media");
            catalogMap.Add("Games", "Games");
            catalogMap.Add("Database", "Program");
            catalogMap.Add("Desktop", "Accessories");
            catalogMap.Add("Archival", "System");
            catalogMap.Add("Audio", "Media");
        }

        /// <summary>
        /// parse application information from the page, it should contains
        /// appname
        /// filelink
        /// version
        /// description
        /// catalog
        /// param
        /// </summary>
        /// <param name="content"></param>
        public void parseAppInfo(string content)
        {
            Regex regAppInfo = new Regex(
                @"<tr>(?:<td.*?>(.+?)</td>)+?</tr>",
                RegexOptions.IgnoreCase
                | RegexOptions.Singleline
                | RegexOptions.CultureInvariant
                | RegexOptions.Compiled
            );

            MatchCollection retlist = regAppInfo.Matches(content);
            for (int i = 1; i < retlist.Count; i++)
            {
                //appname and url
                string str = retlist[i].Groups[1].Captures[0].Value;
                //find name
                int startPos = str.LastIndexOf("'>") + 2;
                int endPos = str.IndexOf("</a>");
                string name = str.Substring(startPos, endPos - startPos);
                //find url
                startPos = str.IndexOf("http");
                if (startPos == -1)
                    startPos = str.IndexOf("ftp");
                endPos = str.LastIndexOf("'>");
                string url = str.Substring(startPos, endPos - startPos);
                //convert unicode to local url
                url = HttpUtility.UrlDecode(url, Encoding.Default);
                //find version
                string version = retlist[i].Groups[1].Captures[1].Value;
                //find description
                string description = retlist[i].Groups[1].Captures[2].Value;
                //find catalog
                str = retlist[i].Groups[1].Captures[3].Value;
                startPos = str.IndexOf("'>") + 2;
                string catalog = str.Substring(startPos);
                //find param
                int popular = 3;
                //if (retlist[i].Groups[1].Captures.Count > 4 )
                //    param = retlist[i].Groups[1].Captures[4].Value;
                this.myAppInfoDB.Add(new AppInfoBase(name, url, version, description, (string)catalogMap[catalog], "Free Software", popular, ""));
            }
        }
        /// <summary>
        /// parse page numbers from the page, then we should anylize each page
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string[] parsePageUrls(string content)
        {
            Regex regex2 = new Regex(
                @"(?:>(\d+)<)",
                RegexOptions.IgnoreCase
                | RegexOptions.Singleline
                | RegexOptions.CultureInvariant
                | RegexOptions.Compiled
            );

            Regex regex1 = new Regex(
                @"<div.*?>.*?</div>",
                RegexOptions.IgnoreCase
                | RegexOptions.Singleline
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                );
            Match ret1 = regex1.Match(content);
            MatchCollection retlist = regex2.Matches(ret1.Value);
            string[] ret = new string[retlist.Count];
            //the last element will be Next, pass it.
            for (int i = 0; i < retlist.Count; i++)
            {
                ret[i] = mainPageUrl + this.surfix + retlist[i].Groups[1].Value;
            }
            return ret;
        }
        /// <summary>
        /// Parse catalogs from the page, general,the catalog will not change.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string[] parseCatalogs(string content)
        {
            Regex regCatalog = new Regex(
                @"(?:>(\w+?)<)",
                RegexOptions.IgnoreCase
                | RegexOptions.Singleline
                | RegexOptions.CultureInvariant
                | RegexOptions.Compiled
            );
            MatchCollection ret = regCatalog.Matches(content);
            string[] retlist = new string[ret.Count];
            for (int i = 0; i < ret.Count; i++)
            {
                retlist[i] = ret[i].Groups[1].Value;
            }
            return retlist;
        }
        public override void Parser(string str)
        {
            Regex regex = new Regex(
                @"<table .*?>(?:(.*?))</table>",
                RegexOptions.IgnoreCase
                | RegexOptions.Singleline
                | RegexOptions.CultureInvariant
                | RegexOptions.Compiled
            );
            MatchCollection ret = null;
            if (str == "")
            {
                ret = regex.Matches(content);
                //parseCatalogs(ret[0].Groups[1].Value);
                this.pageUrls = parsePageUrls(ret[1].Groups[1].Value);
            }
            else
            {
                ret = regex.Matches(str);
            }
            parseAppInfo(ret[1].Groups[1].Value);
        }
        public override void UpdateData()
        {
            content = WinAptLib.getPageContent(this.mainPageUrl);
            Parser("");
            Console.WriteLine("Get {0} pages.", pageUrls.Length);
            foreach (string url in this.pageUrls)
            {
                Console.WriteLine("Parsing page {0}", url);
                content = WinAptLib.getPageContent(url);
                Parser(content);
            }

        }
    }


}
