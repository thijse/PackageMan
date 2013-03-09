using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinApt.ConfigTool.GUI;
using WinApt.Common;

namespace WinApt.ConfigTool
{
    public partial class ConfigForm : Form
    {
        private string configFileName = "";
        private string[] chars = { "¡ï", "¡ï¡ï", "¡ï¡ï¡ï", "¡ï¡ï¡ï¡ï", "¡ï¡ï¡ï¡ï¡ï" };
        private ConfigCmd myCmd = new ConfigCmd();
        public ConfigForm()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;
            lstCatalog.SelectedIndex = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                configFileName = openDlg.FileName;
            }
            if ("" != configFileName)
                myCmd.LoadDB(configFileName);
            UpdateAppList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ("" == configFileName)
            {
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    configFileName = saveDlg.FileName;
                }
            }
            if ("" != configFileName)
                myCmd.SaveDB(configFileName);
        }
        
        private void UpdateAppList()
        {

            if (myCmd.AppDB.Items.Count == 0)
                return;
            lvApp.Items.Clear();
            rtxtDesc.Clear();

            string catalog = lstCatalog.SelectedItem.ToString();

            ArrayList items = myCmd.FindAppInfoList(cbType.Text, catalog, txtSearch.Text);
            foreach (Hashtable item in items)
            {
                ListViewItem lvitem = new ListViewItem();
                int state = (int)item["state"];
                lvitem.Text = (string)item["name"];
                lvitem.SubItems.Add((string)item["version"]);
                lvitem.SubItems.Add(chars[(int)item["popular"]-1]);
                lvitem.Tag = (int)item["index"];
                lvApp.Items.Add(lvitem);
            }
            if (lvApp.Items.Count > 0)
                lvApp.Items[0].Selected = true;
        }

        private void lstCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAppList();
        }

        private void lvApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvApp.SelectedItems.Count == 0)
                return;
            rtxtDesc.Clear();
            Hashtable item = myCmd.FindAppInfo((int)lvApp.SelectedItems[0].Tag);
            int state = (int)item["state"];
            rtxtDesc.Text = (string)item["description"];
            rtxtDesc.AppendText("\n\nDownload Url:\n" + (string)item["url"]);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAppList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //
            //TODO: add new item
            //
            myCmd.CurItem = new AppInfoBase();
            myCmd.CurItem.type = cbType.Text;
            myCmd.CurItem.catalog = lstCatalog.SelectedItem.ToString();
            AddItemForm addForm = new AddItemForm(myCmd);
            addForm.ShowDialog();
            if (addForm.DialogResult != DialogResult.Cancel)
            {
                myCmd.AppDB.Add(myCmd.CurItem);
                UpdateAppList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //
            //TODO: Edit current item
            //
            if (lvApp.SelectedItems.Count == 0)
                return;
            myCmd.CurItem = (AppInfoBase)myCmd.AppDB.Items[(int)lvApp.SelectedItems[0].Tag];
            AddItemForm edtForm = new AddItemForm(myCmd);
            edtForm.ShowDialog();
            if (edtForm.DialogResult != DialogResult.Cancel)
            {
                myCmd.AppDB.Items[(int)lvApp.SelectedItems[0].Tag] = myCmd.CurItem;
                UpdateAppList();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //
            //TODO: delete current item
            //
            if (lvApp.SelectedItems.Count == 0)
                return;
            myCmd.AppDB.Items.RemoveAt((int)lvApp.SelectedItems[0].Tag);
            lvApp.Items.Remove(lvApp.SelectedItems[0]);
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            //
            //TODO: Merge info with current one.
            //
            if (myCmd.AppDB.Items.Count == 0)
            {
                MessageBox.Show("Load first, then merge!");
                return;
            }
            string newFile = "";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                newFile = openDlg.FileName;
            }
            if ("" != newFile)
                myCmd.MergeDB(newFile);
            UpdateAppList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateAppList();
        }
    }
}