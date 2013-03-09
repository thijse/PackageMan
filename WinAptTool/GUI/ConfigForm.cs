using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinApt.Common;
using System.IO;

namespace WinApt.Client.GUI
{
    public partial class ConfigForm : Form
    {
        private MainForm fmMain;
        public ConfigForm(MainForm fmMain)
        {
            InitializeComponent();
            this.fmMain = fmMain;
            cbDbs.Text = ""; //MainForm.myCmdMgr.Config.local;
            btnOK.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //
            //TODO: update db file
            //
            string curDB = WinAptLib.ConfigPath + "appinfodb_" + cbDbs.Text + ".xml";
            if (!File.Exists(curDB))
            {
                //currently there is no such DB file, update DB now?
                string message = MainForm.LocRM.GetString("strConfigFormDownload");
                // Need Update DB
                string caption = MainForm.LocRM.GetString("strConfigFormMessageTitle");
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.No)
                {
                    // restore value
                    cbDbs.Text = ""; // MainForm.myCmdMgr.Config.local;
                    txtUrl.Text = MainForm.myCmdMgr.Config.updateUrl;
                    return;
                }
                else
                {
                    btnOK.Enabled = false;
                   // MainForm.myCmdMgr.Config.local = cbDbs.Text;
                    MainForm.myCmdMgr.Config.updateUrl = txtUrl.Text;
                    MainForm.myCmdMgr.Config.usingDB = WinAptLib.ConfigPath + "appinfodb_" + cbDbs.Text + ".xml";
                    //download db;
                    fmMain.UpdateDB(true);
                    btnOK.Enabled = true;
                }
            }
            //nothing change, just return;
            /*
            if (cbDbs.Text == MainForm.myCmdMgr.Config.local)
            {
                return;
            }
            else
            {
                MainForm.myCmdMgr.Config.local = cbDbs.Text;
                MainForm.myCmdMgr.Config.updateUrl = txtUrl.Text;
                MainForm.myCmdMgr.Config.usingDB = WinAptLib.ConfigPath + "appinfodb_" + cbDbs.Text + ".xml";
                WinAptLib.WriteToFile(MainForm.myCmdMgr.Config, MainForm.configFile);
                fmMain.UpdateDB(false);
            }
             * */
        }

        private void cbDbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            //TODO: change db file.
            //
            string url = MainForm.myCmdMgr.Config.updateUrl;
            txtUrl.Text = url.Substring(0, url.Length - 9) + cbDbs.Text + ".zip";
        }
    }
}