/*
 * Created by SharpDevelop.
 * User: zhou
 * Date: 2007-8-28
 * Time: 14:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WinApt.Client
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvCatalog = new System.Windows.Forms.ListView();
            this.imgList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lvApps = new System.Windows.Forms.ListView();
            this.colApps = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cntxtMenuAppItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.lbType = new System.Windows.Forms.Label();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnProperty = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.cntxtMenuAppItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvCatalog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // lvCatalog
            // 
            this.lvCatalog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lvCatalog, "lvCatalog");
            this.lvCatalog.FullRowSelect = true;
            this.lvCatalog.HideSelection = false;
            this.lvCatalog.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items1"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items2"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items3"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items4"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items5"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items6"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items7"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items8"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items9"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items10"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lvCatalog.Items11")))});
            this.lvCatalog.LargeImageList = this.imgList1;
            this.lvCatalog.MultiSelect = false;
            this.lvCatalog.Name = "lvCatalog";
            this.lvCatalog.SmallImageList = this.imgList1;
            this.lvCatalog.TileSize = new System.Drawing.Size(168, 29);
            this.lvCatalog.UseCompatibleStateImageBehavior = false;
            this.lvCatalog.View = System.Windows.Forms.View.Tile;
            this.lvCatalog.SelectedIndexChanged += new System.EventHandler(this.lvCatalog_SelectedIndexChanged);
            // 
            // imgList1
            // 
            this.imgList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList1.ImageStream")));
            this.imgList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList1.Images.SetKeyName(0, "all.png");
            this.imgList1.Images.SetKeyName(1, "internet.png");
            this.imgList1.Images.SetKeyName(2, "others.png");
            this.imgList1.Images.SetKeyName(3, "office.png");
            this.imgList1.Images.SetKeyName(4, "images.png");
            this.imgList1.Images.SetKeyName(5, "media.png");
            this.imgList1.Images.SetKeyName(6, "education.png");
            this.imgList1.Images.SetKeyName(7, "games.png");
            this.imgList1.Images.SetKeyName(8, "systems.png");
            this.imgList1.Images.SetKeyName(9, "programs.png");
            this.imgList1.Images.SetKeyName(10, "fuzhu.png");
            this.imgList1.Images.SetKeyName(11, "fujian.png");
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvApps);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtDesc);
            // 
            // lvApps
            // 
            this.lvApps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvApps.CheckBoxes = true;
            this.lvApps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colApps,
            this.colVersion,
            this.colPop});
            this.lvApps.ContextMenuStrip = this.cntxtMenuAppItem;
            resources.ApplyResources(this.lvApps, "lvApps");
            this.lvApps.FullRowSelect = true;
            this.lvApps.GridLines = true;
            this.lvApps.HideSelection = false;
            this.lvApps.MultiSelect = false;
            this.lvApps.Name = "lvApps";
            this.lvApps.SmallImageList = this.imgList1;
            this.lvApps.UseCompatibleStateImageBehavior = false;
            this.lvApps.View = System.Windows.Forms.View.Details;
            this.lvApps.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvApps_ItemChecked);
            this.lvApps.SelectedIndexChanged += new System.EventHandler(this.lvApps_SelectedIndexChanged);
            // 
            // colApps
            // 
            resources.ApplyResources(this.colApps, "colApps");
            // 
            // colVersion
            // 
            resources.ApplyResources(this.colVersion, "colVersion");
            // 
            // colPop
            // 
            resources.ApplyResources(this.colPop, "colPop");
            // 
            // cntxtMenuAppItem
            // 
            this.cntxtMenuAppItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemExplore,
            this.MenuItemOpen});
            this.cntxtMenuAppItem.Name = "cntxtMenuAppItem";
            resources.ApplyResources(this.cntxtMenuAppItem, "cntxtMenuAppItem");
            this.cntxtMenuAppItem.Opening += new System.ComponentModel.CancelEventHandler(this.cntxtMenuAppItem_Opening);
            // 
            // MenuItemExplore
            // 
            this.MenuItemExplore.Name = "MenuItemExplore";
            resources.ApplyResources(this.MenuItemExplore, "MenuItemExplore");
            this.MenuItemExplore.Click += new System.EventHandler(this.MenuItemExplore_Click);
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.Name = "MenuItemOpen";
            resources.ApplyResources(this.MenuItemOpen, "MenuItemOpen");
            this.MenuItemOpen.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtDesc, "txtDesc");
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtDesc_LinkClicked);
            // 
            // lbType
            // 
            resources.ApplyResources(this.lbType, "lbType");
            this.lbType.Name = "lbType";
            // 
            // cbTypes
            // 
            this.cbTypes.FormattingEnabled = true;
            resources.ApplyResources(this.cbTypes, "cbTypes");
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.SelectedIndexChanged += new System.EventHandler(this.cbTypes_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnHelp
            // 
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnProperty
            // 
            resources.ApplyResources(this.btnProperty, "btnProperty");
            this.btnProperty.Name = "btnProperty";
            this.btnProperty.UseVisualStyleBackColor = true;
            this.btnProperty.Click += new System.EventHandler(this.btnProperty_Click);
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.TabStop = false;
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabStop = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnProperty);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbTypes);
            this.Controls.Add(this.lbType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cntxtMenuAppItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ColumnHeader colVersion;
		private System.Windows.Forms.ColumnHeader colPop;
		private System.Windows.Forms.ColumnHeader colApps;
		private System.Windows.Forms.ListView lvCatalog;
		private System.Windows.Forms.RichTextBox txtDesc;
		private System.Windows.Forms.ListView lvApps;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ImageList imgList1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnProperty;
		private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ContextMenuStrip cntxtMenuAppItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExplore;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpen;
	}
}
