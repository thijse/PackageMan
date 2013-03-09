namespace WinApt.ConfigTool
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstCatalog = new System.Windows.Forms.ListBox();
            this.rtxtDesc = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lvApp = new System.Windows.Forms.ListView();
            this.Applications = new System.Windows.Forms.ColumnHeader();
            this.Version = new System.Windows.Forms.ColumnHeader();
            this.Popularity = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openDlg = new System.Windows.Forms.OpenFileDialog();
            this.btnEdit = new System.Windows.Forms.Button();
            this.saveDlg = new System.Windows.Forms.SaveFileDialog();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(12, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(202, 21);
            this.txtSearch.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Free Software",
            "Green Software",
            "Share Software"});
            this.cbType.Location = new System.Drawing.Point(384, 10);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(181, 20);
            this.cbType.TabIndex = 3;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 36);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstCatalog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtxtDesc);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.lvApp);
            this.splitContainer1.Size = new System.Drawing.Size(620, 330);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 4;
            // 
            // lstCatalog
            // 
            this.lstCatalog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCatalog.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCatalog.FormattingEnabled = true;
            this.lstCatalog.ItemHeight = 23;
            this.lstCatalog.Items.AddRange(new object[] {
            "All",
            "Internet",
            "Other",
            "Office",
            "Graphics",
            "Media",
            "Education",
            "Games",
            "System",
            "Program",
            "Accessibility",
            "Accessories"});
            this.lstCatalog.Location = new System.Drawing.Point(0, 0);
            this.lstCatalog.Name = "lstCatalog";
            this.lstCatalog.Size = new System.Drawing.Size(210, 324);
            this.lstCatalog.TabIndex = 0;
            this.lstCatalog.SelectedIndexChanged += new System.EventHandler(this.lstCatalog_SelectedIndexChanged);
            // 
            // rtxtDesc
            // 
            this.rtxtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDesc.Location = new System.Drawing.Point(0, 177);
            this.rtxtDesc.Name = "rtxtDesc";
            this.rtxtDesc.Size = new System.Drawing.Size(406, 153);
            this.rtxtDesc.TabIndex = 2;
            this.rtxtDesc.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 174);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(406, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // lvApp
            // 
            this.lvApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvApp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Applications,
            this.Version,
            this.Popularity});
            this.lvApp.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvApp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvApp.FullRowSelect = true;
            this.lvApp.GridLines = true;
            this.lvApp.HideSelection = false;
            this.lvApp.Location = new System.Drawing.Point(0, 0);
            this.lvApp.MultiSelect = false;
            this.lvApp.Name = "lvApp";
            this.lvApp.Size = new System.Drawing.Size(406, 174);
            this.lvApp.TabIndex = 0;
            this.lvApp.UseCompatibleStateImageBehavior = false;
            this.lvApp.View = System.Windows.Forms.View.Details;
            this.lvApp.SelectedIndexChanged += new System.EventHandler(this.lvApp_SelectedIndexChanged);
            // 
            // Applications
            // 
            this.Applications.Text = "Applications";
            this.Applications.Width = 130;
            // 
            // Version
            // 
            this.Version.Text = "Version";
            this.Version.Width = 100;
            // 
            // Popularity
            // 
            this.Popularity.Text = "Popularity";
            this.Popularity.Width = 97;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(372, 380);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 21);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(557, 380);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 21);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(180, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 21);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(14, 380);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(61, 21);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openDlg
            // 
            this.openDlg.DefaultExt = "xml";
            this.openDlg.Title = "Open AppInfo DB file";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(464, 380);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 21);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // saveDlg
            // 
            this.saveDlg.DefaultExt = "xml";
            this.saveDlg.Title = "Save the AppInfo DB fle";
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(97, 378);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(61, 23);
            this.btnMerge.TabIndex = 10;
            this.btnMerge.Text = "Merge...";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(226, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 413);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinApt Config Tool";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ListBox lstCatalog;
        private System.Windows.Forms.RichTextBox rtxtDesc;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView lvApp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader Applications;
        private System.Windows.Forms.ColumnHeader Version;
        private System.Windows.Forms.ColumnHeader Popularity;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openDlg;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.SaveFileDialog saveDlg;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnSearch;
    }
}