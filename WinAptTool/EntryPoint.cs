/*
 * Created by SharpDevelop.
 * User: zhou
 * Date: 2007-8-28
 * Time: 14:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using WinApt.Client.GUI;
using WinApt.Common;
using System.Threading;
using System.Resources;
using PlatformCommon;

namespace WinApt.Client
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class EntryPoint
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // load current culture, en-US or zh-CN
            // make be can change to configalbe later.
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            // load resource files
            MainForm.LocRM = new ResourceManager("WinApt.Client.WinAptStrings", typeof(MainForm).Assembly);

            SplashForm mySplash = new SplashForm();
            bool exitFlag = false;
            mySplash.Show();
            try
            {
                //when the fisrt time run this program, exception("new") throws
                mySplash.InitApp();
            }
            catch (Exception e)
            {
                //build new config file.
                if (e.Message == "new")
                {
                    ChoseForm myChoseForm = new ChoseForm();
                    myChoseForm.TxtPath = Defaults.DataPath;
                    myChoseForm.ShowDialog(mySplash);
                    if (myChoseForm.DialogResult == DialogResult.OK)
                    {
                        myChoseForm.Config();
                        mySplash.InitApp();
                    }
                    myChoseForm.Close();
                }
                else
                {
                    MessageBox.Show(e.Message);
                    exitFlag = true;
                }
            }
            finally
            {
                mySplash.Close();
            }
            if (exitFlag)
                return;
            Application.Run(new MainForm());
		}
		
	}
}
