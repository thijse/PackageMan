/*
 * Created by SharpDevelop.
 * User: zhou
 * Date: 2007-8-28
 * Time: 14:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using WinApt.Common;
using WinApt.Client.GUI;
using System.Globalization;
using System.Resources;

namespace WinApt.Client
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
        public static string configFile = @"config\base.xml";
        private string[] chars = { "★", "★★", "★★★", "★★★★", "★★★★★" };
        public static CmdMgr myCmdMgr = null;
        private bool initTag = true;
        public static ResourceManager LocRM;

        public MainForm()
		{
            //
            //TDDO: here to select different UI of users system.
            //

            //
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
            Icon = PlatformCommon.Defaults.Icon1;
            Text = PlatformCommon.Defaults.AppName;

            cbTypes.Items.Add(LocRM.GetString("strTypeFree"));
            cbTypes.Items.Add(LocRM.GetString("strTypeGreen"));
            cbTypes.Items.Add(LocRM.GetString("strTypeShare"));
		}

		
		void MainFormLoad(object sender, EventArgs e)
		{
            cbTypes.SelectedIndex = 0;
            lvCatalog.Items[0].Selected = true;
		}

        private void lvCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateLvApp();
        }

        private void updateLvApp()
        {
            if (lvCatalog.SelectedItems.Count == 0)
            {
                return;
            }
            lvApps.Items.Clear();
            txtDesc.Clear();

            string catalog = WinAptLib.Catalogs[lvCatalog.SelectedItems[0].Index];

            ArrayList items = myCmdMgr.FindAppInfoList(WinAptLib.Types[cbTypes.SelectedIndex], catalog, txtSearch.Text);
            initTag = true;
            foreach (Hashtable item in items)
            {
                // 
                //TODO:now there is no icon, we will add later
                //
                ListViewItem lvitem = new ListViewItem();
                int state = (int)item["state"];
                lvitem.Checked = !(state == WinAptLib.NoFile);
                if (state == WinAptLib.NewVersion)
                    lvitem.ForeColor = Color.Red;
                lvitem.Text = (string)item["name"];
                lvitem.SubItems.Add((string)item["version"]);
                lvitem.SubItems.Add(chars[(int)item["popular"]-1]);
                lvitem.Tag = (int)item["index"];
                lvApps.Items.Add(lvitem);
            }
            initTag = false;
            if (lvApps.Items.Count > 0)
                lvApps.Items[0].Selected = true;

        }

        private void lvApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvApps.SelectedItems.Count == 0)
            {
                return;
            }
            txtDesc.Clear();
            Hashtable item = myCmdMgr.FindAppInfo((int)lvApps.SelectedItems[0].Tag);
            int state = (int)item["state"];
            txtDesc.Text = (string)item["description"];
            txtDesc.AppendText("\n\n");
            txtDesc.AppendText(LocRM.GetString("strMainFormDownloadUrl") + "\n" + (string)item["url"]);
            if (state == WinAptLib.NewVersion)
            {
                txtDesc.AppendText("\nnew version: " + (string)item["version"] + "    " + (string)item["url"]);
            }
        }

        private void cbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateLvApp();
        }

        private void txtDesc_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            //
            //TODO: download info
            //
            //MessageBox.Show("down load it!" + e.LinkText);
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void lvApps_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (initTag)
                return;
            AppInfoBase i=(AppInfoBase)myCmdMgr.InfoDB.Items[(int)e.Item.Tag];
            if (e.Item.Checked)
            {
                if (myCmdMgr.DelectItems.Contains(e.Item.Tag))
                    myCmdMgr.DelectItems.Remove(e.Item.Tag);
                else
                {
                    myCmdMgr.SelectItems.Add(e.Item.Tag);
                }
                i.setState(WinAptLib.Downloaded);
            }
            else
            {
                if (myCmdMgr.SelectItems.Contains(e.Item.Tag))
                    myCmdMgr.SelectItems.Remove(e.Item.Tag);
                else
                {
                    myCmdMgr.DelectItems.Add(e.Item.Tag);
                }
                i.setState(WinAptLib.NoFile);
            }
            e.Item.Selected = true;
            btnApply.Enabled = true;
        }
        /// <summary>
        /// apply the changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (myCmdMgr.SelectItems.Count + myCmdMgr.DelectItems.Count == 0)
            {
                return;
            }
            ExecuteForm exeForm = new ExecuteForm(myCmdMgr);
            exeForm.ShowDialog();
            //exeForm.Dispose();
            btnApply.Enabled = false;
            updateLvApp();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (btnApply.Enabled)
            {
                btnApply_Click(sender, e);
                //exeForm.Dispose();
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProperty_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Nothing implement yet!");
            ConfigForm fmConfig = new ConfigForm(this);
            fmConfig.ShowDialog();
            fmConfig.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            AboutForm aboutFm = new AboutForm();
            aboutFm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateDB(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            updateLvApp();
        }
        public void UpdateDB(bool isDownload)
        {
            if (isDownload)
            {
                btnUpdate.Enabled = false;
                UpdateForm upForm = new UpdateForm(myCmdMgr.Config.updateUrl);
                this.Enabled = false;
                upForm.ShowDialog();
                this.Enabled = true;
                
            }
            string fileName = myCmdMgr.Config.usingDB;
            string content = WinAptLib.GetAppInfoContent(fileName);
            if (content == "")
                return;
            myCmdMgr.UpdateAppDB(content);
            updateLvApp();
        }
        //explore file that contains
        private void MenuItemExplore_Click(object sender, EventArgs e)
        {
            if (!myCmdMgr.ExploreFile((int)lvApps.SelectedItems[0].Tag))
            {
                MessageBox.Show(LocRM.GetString("strMainFormOpenItem"));
            }
        }

        private void cntxtMenuAppItem_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!lvApps.SelectedItems[0].Checked)
            {
                e.Cancel = true;
            }
        }

        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            if (!myCmdMgr.OpenFile((int)lvApps.SelectedItems[0].Tag))
            {
                MessageBox.Show(LocRM.GetString("strMainFormOpenItem"));
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSearch_Click(sender, e);
            }
        }
	}
}
