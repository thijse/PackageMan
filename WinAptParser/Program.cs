using System;
using System.Collections.Generic;
using System.Text;
using WinApt.Common;

namespace WinApt.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start to download information...");
            WinGetParser myApp = new WinGetParser();
            myApp.UpdateData();
            WinAptLib.WriteToFile(myApp.myAppInfoDB, @"appinfodb_en-US.xml");
        }
    }
}
