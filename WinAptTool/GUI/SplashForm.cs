using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WinApt.Common;
using PlatformCommon;
namespace WinApt.Client.GUI
{
    public partial class SplashForm : Form
    {
        private string configFile = MainForm.configFile;
        public SplashForm()
        {
            InitializeComponent();
        }
        public void InitApp()
        {
            //
            //TODO: add init code before main form show.
            //
            // 
  
            BackgroundImage = new Bitmap(PlatformCommon.Defaults.Background1);

            this.lbSplash.Text = MainForm.LocRM.GetString("strSplashLabelText");

            if (MainForm.myCmdMgr == null)
                MainForm.myCmdMgr = new CmdMgr();
            
            //if we already build one, no need to check the file.
            if (MainForm.myCmdMgr.Config == null)
            {
                //load config file
                if (File.Exists(configFile))
                {
                    MainForm.myCmdMgr.Config = (AppInfoConfig)WinAptLib.ReadFromFile(typeof(AppInfoConfig), configFile);
                }
                else
                {
                    //no config file, need to builder one
                    throw new Exception("new");
                }
            }
            //download update page.
            string content = "";
            this.lbSplash.Text = MainForm.LocRM.GetString("strSplashLabelLoadDB");
            lbSplash.Update();
            try
            {
                string fileName = MainForm.myCmdMgr.Config.usingDB;
                if (!File.Exists(fileName))
                {
                    this.lbSplash.Text = MainForm.LocRM.GetString("strSplashLabelDownloadDB");
                    lbSplash.Update();
                    progressBar1.Visible = true;
                    if (!WinAptLib.DownloadDbFile(MainForm.myCmdMgr.Config.updateUrl,progressBar1))
                        throw new Exception(string.Format(MainForm.LocRM.GetString("strSplashLabelDownloadError"), MainForm.myCmdMgr.Config.updateUrl));
                }
                content = WinAptLib.GetAppInfoContent(fileName);
            }
            catch (Exception e)
            {
                throw e; 
            }
            finally
            {
                //save the config file, then quit program.
                WinAptLib.WriteToFile(MainForm.myCmdMgr.Config, configFile);
            }
            MainForm.myCmdMgr.UpdateAppDB(content);
        }
    }
}