using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PlatformCommon;
using WinApt.Common;

namespace WinApt.Client.GUI
{
    public partial class ChoseForm : Form
    {
        private string basePath = "";
        public ChoseForm()
        {
            InitializeComponent();

        }

        public string TxtPath
        {
            get { return txtPath.Text; }
            set { txtPath.Text = value; }
        }
        public void Config()
        {

            string[] dirs = { "Internet", "Office", "Other", "Graphics", "System", "Media", "Program", "Accessories", "Games", "Accessibility","Education" };
            Directory.CreateDirectory(WinAptLib.ConfigPath);
            basePath = TxtPath;
            string updateUrl = Defaults.RepositoryUrl;
            string usingdb   = WinAptLib.ConfigPath + Defaults.RepositoryDbFile;
            MainForm.myCmdMgr.Config = new AppInfoConfig(basePath, updateUrl,usingdb);
            
            //create directories
            foreach (string str in dirs)
            {
                Directory.CreateDirectory(basePath + "\\" + str);
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            fdDlg.SelectedPath = Environment.CurrentDirectory;
            fdDlg.Description = MainForm.LocRM.GetString("strChoseFormOpenFile");
            this.fdDlg.ShowDialog();
            basePath = fdDlg.SelectedPath;
            txtPath.Text = basePath;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
            {
                btnBrowser_Click(sender,e);
            }
        }
    }
}