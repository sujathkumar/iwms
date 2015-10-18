namespace IWMS.Solutions.Server.Dashboard
{
    partial class Shell
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Collectors");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Recyclers");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shell));
            this.panelControlCenter = new DevExpress.XtraEditors.PanelControl();
            this.tabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.tabControlCollector = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlCollectors = new DevExpress.XtraGrid.GridControl();
            this.gridViewCollectors = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panelControlLHS = new DevExpress.XtraEditors.PanelControl();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.panelRHS = new System.Windows.Forms.Panel();
            this.linkDeleteCollector = new System.Windows.Forms.LinkLabel();
            this.linkRefresh = new System.Windows.Forms.LinkLabel();
            this.linkCreateCollector = new System.Windows.Forms.LinkLabel();
            this.panelControlRHS = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlCenter)).BeginInit();
            this.panelControlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabControlCollector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCollectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCollectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLHS)).BeginInit();
            this.panelControlLHS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.panelRHS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlRHS)).BeginInit();
            this.panelControlRHS.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControlCenter
            // 
            this.panelControlCenter.Controls.Add(this.tabControlMain);
            this.panelControlCenter.Location = new System.Drawing.Point(210, 111);
            this.panelControlCenter.Name = "panelControlCenter";
            this.panelControlCenter.Size = new System.Drawing.Size(1079, 606);
            this.panelControlCenter.TabIndex = 2;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Location = new System.Drawing.Point(6, 6);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedTabPage = this.tabControlCollector;
            this.tabControlMain.Size = new System.Drawing.Size(1068, 600);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabControlCollector});
            // 
            // tabControlCollector
            // 
            this.tabControlCollector.Controls.Add(this.gridControlCollectors);
            this.tabControlCollector.Name = "tabControlCollector";
            this.tabControlCollector.Size = new System.Drawing.Size(1062, 572);
            this.tabControlCollector.Text = "Collectors";
            // 
            // gridControlCollectors
            // 
            this.gridControlCollectors.Location = new System.Drawing.Point(4, 4);
            this.gridControlCollectors.MainView = this.gridViewCollectors;
            this.gridControlCollectors.Name = "gridControlCollectors";
            this.gridControlCollectors.Size = new System.Drawing.Size(1055, 565);
            this.gridControlCollectors.TabIndex = 0;
            this.gridControlCollectors.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCollectors});
            // 
            // gridViewCollectors
            // 
            this.gridViewCollectors.GridControl = this.gridControlCollectors;
            this.gridViewCollectors.Name = "gridViewCollectors";
            this.gridViewCollectors.OptionsSelection.MultiSelect = true;
            // 
            // lblHeader
            // 
            this.lblHeader.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Maiandra GD", 60F);
            this.lblHeader.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(409, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(377, 96);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Clear Deck";
            // 
            // panelControlLHS
            // 
            this.panelControlLHS.Appearance.BackColor = System.Drawing.Color.Red;
            this.panelControlLHS.Appearance.Options.UseBackColor = true;
            this.panelControlLHS.Controls.Add(this.treeViewMain);
            this.panelControlLHS.Location = new System.Drawing.Point(3, 110);
            this.panelControlLHS.Name = "panelControlLHS";
            this.panelControlLHS.Size = new System.Drawing.Size(200, 607);
            this.panelControlLHS.TabIndex = 1;
            // 
            // treeViewMain
            // 
            this.treeViewMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeViewMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewMain.ForeColor = System.Drawing.Color.White;
            this.treeViewMain.Location = new System.Drawing.Point(6, 30);
            this.treeViewMain.Name = "treeViewMain";
            treeNode1.Name = "collectorsnode";
            treeNode1.Text = "Collectors";
            treeNode2.Name = "nodeRecyclers";
            treeNode2.Text = "Recyclers";
            this.treeViewMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeViewMain.Size = new System.Drawing.Size(189, 572);
            this.treeViewMain.TabIndex = 0;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.InitialImage = null;
            this.pictureLogo.Location = new System.Drawing.Point(53, 12);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(69, 77);
            this.pictureLogo.TabIndex = 3;
            this.pictureLogo.TabStop = false;
            // 
            // panelRHS
            // 
            this.panelRHS.BackColor = System.Drawing.Color.White;
            this.panelRHS.Controls.Add(this.linkDeleteCollector);
            this.panelRHS.Controls.Add(this.linkRefresh);
            this.panelRHS.Controls.Add(this.linkCreateCollector);
            this.panelRHS.Location = new System.Drawing.Point(5, 7);
            this.panelRHS.Name = "panelRHS";
            this.panelRHS.Size = new System.Drawing.Size(190, 595);
            this.panelRHS.TabIndex = 2;
            // 
            // linkDeleteCollector
            // 
            this.linkDeleteCollector.AutoSize = true;
            this.linkDeleteCollector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDeleteCollector.Location = new System.Drawing.Point(10, 87);
            this.linkDeleteCollector.Name = "linkDeleteCollector";
            this.linkDeleteCollector.Size = new System.Drawing.Size(108, 17);
            this.linkDeleteCollector.TabIndex = 2;
            this.linkDeleteCollector.TabStop = true;
            this.linkDeleteCollector.Text = "Delete Collector";
            this.linkDeleteCollector.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteCollector_LinkClicked);
            // 
            // linkRefresh
            // 
            this.linkRefresh.AutoSize = true;
            this.linkRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkRefresh.Location = new System.Drawing.Point(10, 17);
            this.linkRefresh.Name = "linkRefresh";
            this.linkRefresh.Size = new System.Drawing.Size(58, 17);
            this.linkRefresh.TabIndex = 1;
            this.linkRefresh.TabStop = true;
            this.linkRefresh.Text = "Refresh";
            this.linkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRefresh_LinkClicked);
            // 
            // linkCreateCollector
            // 
            this.linkCreateCollector.AutoSize = true;
            this.linkCreateCollector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCreateCollector.Location = new System.Drawing.Point(10, 49);
            this.linkCreateCollector.Name = "linkCreateCollector";
            this.linkCreateCollector.Size = new System.Drawing.Size(109, 17);
            this.linkCreateCollector.TabIndex = 0;
            this.linkCreateCollector.TabStop = true;
            this.linkCreateCollector.Text = "Create Collector";
            this.linkCreateCollector.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCreateCollector_LinkClicked);
            // 
            // panelControlRHS
            // 
            this.panelControlRHS.Controls.Add(this.panelRHS);
            this.panelControlRHS.Location = new System.Drawing.Point(1295, 110);
            this.panelControlRHS.Name = "panelControlRHS";
            this.panelControlRHS.Size = new System.Drawing.Size(200, 607);
            this.panelControlRHS.TabIndex = 2;
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1507, 729);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panelControlRHS);
            this.Controls.Add(this.panelControlCenter);
            this.Controls.Add(this.panelControlLHS);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1523, 767);
            this.MinimumSize = new System.Drawing.Size(1523, 767);
            this.Name = "Shell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clear Deck";
            this.Load += new System.EventHandler(this.Shell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlCenter)).EndInit();
            this.panelControlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabControlCollector.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCollectors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCollectors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLHS)).EndInit();
            this.panelControlLHS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.panelRHS.ResumeLayout(false);
            this.panelRHS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlRHS)).EndInit();
            this.panelControlRHS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlCenter;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.PanelControl panelControlLHS;
        private DevExpress.XtraTab.XtraTabControl tabControlMain;
        private DevExpress.XtraTab.XtraTabPage tabControlCollector;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.TreeView treeViewMain;
        private DevExpress.XtraGrid.GridControl gridControlCollectors;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCollectors;
        private System.Windows.Forms.Panel panelRHS;
        private System.Windows.Forms.LinkLabel linkRefresh;
        private System.Windows.Forms.LinkLabel linkCreateCollector;
        private DevExpress.XtraEditors.PanelControl panelControlRHS;
        private System.Windows.Forms.LinkLabel linkDeleteCollector;

    }
}

