namespace WinApt.Client.GUI
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.cbDbs = new System.Windows.Forms.ComboBox();
            this.lbChoseDB = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbDbs
            // 
            this.cbDbs.FormattingEnabled = true;
            this.cbDbs.Items.AddRange(new object[] {
            resources.GetString("cbDbs.Items"),
            resources.GetString("cbDbs.Items1")});
            resources.ApplyResources(this.cbDbs, "cbDbs");
            this.cbDbs.Name = "cbDbs";
            this.cbDbs.SelectedIndexChanged += new System.EventHandler(this.cbDbs_SelectedIndexChanged);
            // 
            // lbChoseDB
            // 
            resources.ApplyResources(this.lbChoseDB, "lbChoseDB");
            this.lbChoseDB.Name = "lbChoseDB";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbUrl
            // 
            resources.ApplyResources(this.lbUrl, "lbUrl");
            this.lbUrl.Name = "lbUrl";
            // 
            // txtUrl
            // 
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtUrl, "txtUrl");
            this.txtUrl.Name = "txtUrl";
            // 
            // ConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lbUrl);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbChoseDB);
            this.Controls.Add(this.cbDbs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDbs;
        private System.Windows.Forms.Label lbChoseDB;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.TextBox txtUrl;
    }
}