using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinApt.Common;

namespace WinApt.ConfigTool.GUI
{
    partial class AddItemForm : Form
    {
        private ConfigCmd cmd = null;
        public AddItemForm(ConfigCmd cmdMgr)
        {
            InitializeComponent();
            cmd = cmdMgr;
            if ("" != cmd.CurItem.name)
            {
                txtName.Text = cmd.CurItem.name;
                txtVersion.Text = cmd.CurItem.version;
                txtUrl.Text = cmd.CurItem.url;
                rtxtDesc.Text = cmd.CurItem.description;
                cbPopularity.Text = cmd.CurItem.popular.ToString();
            }
            cbCatalogs.Text = cmd.CurItem.catalog;
            cbTypes.Text = cmd.CurItem.type;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //
            //TODO: add a new item
            //
            if ("" == txtVersion.Text || "" == txtName.Text || "" == txtUrl.Text)
            {
                MessageBox.Show("Please enter need messages.");
                return;
            }
            AppInfoBase item = cmd.CurItem;
            item.version = txtVersion.Text;
            item.name = txtName.Text;
            item.url = txtUrl.Text;
            item.description = rtxtDesc.Text;
            item.popular = int.Parse(cbPopularity.Text);
            item.catalog = cbCatalogs.Text;
            item.type = cbTypes.Text;
            Close();
        }

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    Close();
        //}
    }
}