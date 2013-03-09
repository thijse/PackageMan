using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinApt.Common;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Resources;

namespace WinApt.Client.GUI
{
    public partial class ExecuteForm : Form
    {

        delegate void SetLabelCallback(string text);
        delegate void SetTextCallback(string text);
        delegate void SetOKCallback();
        private bool _stop = false;
        private bool needStart = false;
        private CmdMgr cmdMgr = null;
        private Thread t = null;
        public ExecuteForm(CmdMgr cmdMgr)
        {
            InitializeComponent();
            this.cmdMgr = cmdMgr;
            //We will take follow changes:
            lbAction.Text = MainForm.LocRM.GetString("strExecuteFormLabelText");

            if (cmdMgr.SelectItems.Count > 0)
            {
                needStart = true;
                //We are going to download:\n
                txtConsole.Text = MainForm.LocRM.GetString("strExecuteFormGoDownload");
                txtConsole.AppendText("\n");
                foreach (object item in cmdMgr.SelectItems)
                {
                    AppInfoBase it = (AppInfoBase)cmdMgr.InfoDB.Items[(int)item];
                    txtConsole.AppendText(it.url + "\n");
                }
                txtConsole.AppendText("\n\n");
            }
            if (cmdMgr.DelectItems.Count > 0)
            {
                needStart = true;
                //We are going to delete:\n
                txtConsole.AppendText(MainForm.LocRM.GetString("strExecuteFormGoDel"));
                txtConsole.AppendText("\n");
                foreach (object item in cmdMgr.DelectItems)
                {
                    AppInfoBase it = (AppInfoBase)cmdMgr.InfoDB.Items[(int)item];
                    string filename = it.url;
                    filename = filename.Substring(filename.LastIndexOf('/') + 1);
                    string cmd = cmdMgr.Config.basePath + @"\" + it.catalog + @"\" + filename;
                    txtConsole.AppendText(cmd + "\n");
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_stop || t == null)
            {
                CancelChange(true);
                Close();
            }
            if(!_stop)
                //User Cancel...
                txtConsole.AppendText(MainForm.LocRM.GetString("strExecuteFormUserCancel"));
            _stop = true;
        }
        public void Execute()
        {
            for (int i = 0; i < cmdMgr.SelectItems.Count; i++)
            {
                if (_stop)
                    break;
                
                //We are downloading {0}/{1}
                string format = MainForm.LocRM.GetString("strExecuteFormDownloading");
                string newStr = string.Format(format, i, cmdMgr.SelectItems.Count);
                UpdateLabel(newStr);
                AppInfoBase it = (AppInfoBase)cmdMgr.InfoDB.Items[(int)cmdMgr.SelectItems[i]];
                string fname = cmdMgr.GetFilePath((int)cmdMgr.SelectItems[i]);
                string url = it.url;
                if (ExecuteCmd(fname,url))
                    cmdMgr.Config.Items.Add(cmdMgr.InfoDB.Items[(int)cmdMgr.SelectItems[i]]);
            }
            for (int i = 0; i < cmdMgr.DelectItems.Count; i++)
            {
                if (_stop)
                    break;
                //Deleting files.
                UpdateLabel(MainForm.LocRM.GetString("strExecuteFormDeleting"));
                string cmd = cmdMgr.GetFilePath((int)cmdMgr.DelectItems[i]);
                //no exception if file doesnot exists.
                File.Delete(cmd);
                cmdMgr.Config.Items.Remove(cmdMgr.InfoDB.Items[(int)cmdMgr.DelectItems[i]]);
            }
            //Done.
            UpdateText(MainForm.LocRM.GetString("strExecuteFormDone"));
            CancelChange(_stop);
            WinAptLib.WriteToFile(cmdMgr.Config, MainForm.configFile);
            _stop = true;
            SetOKEnable();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // if thread stopped or not start, quit
            if (_stop || !needStart)
                Close();
            else
            {
                btnOK.Enabled = false;
                txtConsole.Clear();
                t = new Thread(new ThreadStart(Execute));
                t.Start();
            }
        }
        #region delegate
        private void UpdateLabel(string text)
        {
            if (this.lbAction.InvokeRequired)
            {
                SetLabelCallback d = new SetLabelCallback(UpdateLabel);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lbAction.Text = text;
            }
        }
        private void UpdateText(string text)
        {
            if (this.txtConsole.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(UpdateText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                txtConsole.AppendText(text + "\n");
            }
        }
        private void SetOKEnable()
        {
            if (this.btnOK.InvokeRequired)
            {
                SetOKCallback d = new SetOKCallback(SetOKEnable);
                this.Invoke(d);
            }
            else
            {
                btnOK.Enabled = true;
            }
        }
        #endregion
        public bool ExecuteCmd(string fileName,string url)
        {
            ProcessStartInfo start = new ProcessStartInfo("wget.exe");
            //set params
            start.Arguments = "-O \"" + fileName + "\" " + url;
            //no dos window
            start.CreateNoWindow = true;
            //start.RedirectStandardOutput = true;//
            start.RedirectStandardInput = true;//
            start.RedirectStandardError = true;
            start.UseShellExecute = false;
            Process p = Process.Start(start);
            //get output stream
            StreamReader reader = p.StandardError;
            //StreamReader rdOutput = p.StandardOutput;
            //one line per time
            string errLine = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                UpdateText(errLine);
                errLine = reader.ReadLine();
                if (_stop)
                    break;
            }
            if (_stop)
            {
                p.Kill();
                p.WaitForExit();
                //Waiting for cancal...
                UpdateText(MainForm.LocRM.GetString("strExecuteFormWaiting"));
                //if cancal, delete the file.
                File.Delete(fileName);
            }
            else
                p.WaitForExit();
            p.Close();
            reader.Close();
            return !_stop;
        }
        private void CancelChange(bool flag)
        {
            if (flag)
            {
                foreach (int i in cmdMgr.SelectItems)
                {
                    AppInfoBase item = (AppInfoBase)cmdMgr.InfoDB.Items[i];
                    item.setState(WinAptLib.NoFile);
                }
                
                foreach (int i in cmdMgr.DelectItems)
                {
                    AppInfoBase item = (AppInfoBase)cmdMgr.InfoDB.Items[i];
                    item.setState(WinAptLib.Downloaded);
                }
            }
            cmdMgr.SelectItems.Clear();
            cmdMgr.DelectItems.Clear();
        }
    }
}