﻿namespace IWMS.Solutions.Server.Dashboard
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
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Collectors");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Recyclers");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Spot Images");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Events");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shell));
            this.panelControlCenter = new DevExpress.XtraEditors.PanelControl();
            this.tabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.tabControlCollector = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlCollectors = new DevExpress.XtraGrid.GridControl();
            this.gridViewCollectors = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabControlRecycler = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlRecyclers = new DevExpress.XtraGrid.GridControl();
            this.gridViewRecyclers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabControlSpotImages = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlSpotImages = new DevExpress.XtraGrid.GridControl();
            this.gridViewSpotImages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabControlEvents = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlEvents = new DevExpress.XtraGrid.GridControl();
            this.gridViewEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panelControlLHS = new DevExpress.XtraEditors.PanelControl();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.panelRHS = new System.Windows.Forms.Panel();
            this.linkClearEvent = new System.Windows.Forms.LinkLabel();
            this.linkDelete = new System.Windows.Forms.LinkLabel();
            this.linkRefresh = new System.Windows.Forms.LinkLabel();
            this.linkCreate = new System.Windows.Forms.LinkLabel();
            this.panelControlRHS = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlCenter)).BeginInit();
            this.panelControlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabControlCollector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCollectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCollectors)).BeginInit();
            this.tabControlRecycler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRecyclers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecyclers)).BeginInit();
            this.tabControlSpotImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSpotImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSpotImages)).BeginInit();
            this.tabControlEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEvents)).BeginInit();
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
            this.tabControlCollector,
            this.tabControlRecycler,
            this.tabControlSpotImages,
            this.tabControlEvents});
            this.tabControlMain.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControlMain_SelectedPageChanged);
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
            // tabControlRecycler
            // 
            this.tabControlRecycler.Controls.Add(this.gridControlRecyclers);
            this.tabControlRecycler.Name = "tabControlRecycler";
            this.tabControlRecycler.Size = new System.Drawing.Size(1062, 572);
            this.tabControlRecycler.Text = "Recyclers";
            // 
            // gridControlRecyclers
            // 
            this.gridControlRecyclers.Location = new System.Drawing.Point(4, 4);
            this.gridControlRecyclers.MainView = this.gridViewRecyclers;
            this.gridControlRecyclers.Name = "gridControlRecyclers";
            this.gridControlRecyclers.Size = new System.Drawing.Size(1055, 565);
            this.gridControlRecyclers.TabIndex = 1;
            this.gridControlRecyclers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRecyclers});
            // 
            // gridViewRecyclers
            // 
            this.gridViewRecyclers.GridControl = this.gridControlRecyclers;
            this.gridViewRecyclers.Name = "gridViewRecyclers";
            this.gridViewRecyclers.OptionsSelection.MultiSelect = true;
            // 
            // tabControlSpotImages
            // 
            this.tabControlSpotImages.Controls.Add(this.gridControlSpotImages);
            this.tabControlSpotImages.Name = "tabControlSpotImages";
            this.tabControlSpotImages.Size = new System.Drawing.Size(1062, 572);
            this.tabControlSpotImages.Text = "Spot Images";
            // 
            // gridControlSpotImages
            // 
            this.gridControlSpotImages.Location = new System.Drawing.Point(4, 4);
            this.gridControlSpotImages.MainView = this.gridViewSpotImages;
            this.gridControlSpotImages.Name = "gridControlSpotImages";
            this.gridControlSpotImages.Size = new System.Drawing.Size(1055, 565);
            this.gridControlSpotImages.TabIndex = 1;
            this.gridControlSpotImages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSpotImages});
            // 
            // gridViewSpotImages
            // 
            this.gridViewSpotImages.GridControl = this.gridControlSpotImages;
            this.gridViewSpotImages.Name = "gridViewSpotImages";
            this.gridViewSpotImages.OptionsSelection.MultiSelect = true;
            // 
            // tabControlEvents
            // 
            this.tabControlEvents.Controls.Add(this.gridControlEvents);
            this.tabControlEvents.Name = "tabControlEvents";
            this.tabControlEvents.Size = new System.Drawing.Size(1062, 572);
            this.tabControlEvents.Text = "Events";
            // 
            // gridControlEvents
            // 
            this.gridControlEvents.Location = new System.Drawing.Point(4, 4);
            this.gridControlEvents.MainView = this.gridViewEvents;
            this.gridControlEvents.Name = "gridControlEvents";
            this.gridControlEvents.Size = new System.Drawing.Size(1055, 565);
            this.gridControlEvents.TabIndex = 1;
            this.gridControlEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEvents});
            // 
            // gridViewEvents
            // 
            this.gridViewEvents.GridControl = this.gridControlEvents;
            this.gridViewEvents.Name = "gridViewEvents";
            this.gridViewEvents.OptionsSelection.MultiSelect = true;
            // 
            // lblHeader
            // 
            this.lblHeader.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Maiandra GD", 60F);
            this.lblHeader.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
            treeNode25.Name = "nodeCollectors";
            treeNode25.Text = "Collectors";
            treeNode26.Name = "nodeRecyclers";
            treeNode26.Text = "Recyclers";
            treeNode27.Name = "nodeSpotImages";
            treeNode27.Text = "Spot Images";
            treeNode28.Name = "nodeEvents";
            treeNode28.Text = "Events";
            this.treeViewMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28});
            this.treeViewMain.Size = new System.Drawing.Size(189, 572);
            this.treeViewMain.TabIndex = 0;
            this.treeViewMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMain_AfterSelect);
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
            this.panelRHS.Controls.Add(this.linkClearEvent);
            this.panelRHS.Controls.Add(this.linkDelete);
            this.panelRHS.Controls.Add(this.linkRefresh);
            this.panelRHS.Controls.Add(this.linkCreate);
            this.panelRHS.Location = new System.Drawing.Point(5, 7);
            this.panelRHS.Name = "panelRHS";
            this.panelRHS.Size = new System.Drawing.Size(190, 595);
            this.panelRHS.TabIndex = 2;
            // 
            // linkClearEvent
            // 
            this.linkClearEvent.AutoSize = true;
            this.linkClearEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkClearEvent.Location = new System.Drawing.Point(10, 124);
            this.linkClearEvent.Name = "linkClearEvent";
            this.linkClearEvent.Size = new System.Drawing.Size(81, 17);
            this.linkClearEvent.TabIndex = 3;
            this.linkClearEvent.TabStop = true;
            this.linkClearEvent.Text = "Clear Event";
            this.linkClearEvent.Visible = false;
            this.linkClearEvent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearEvent_LinkClicked);
            // 
            // linkDelete
            // 
            this.linkDelete.AutoSize = true;
            this.linkDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDelete.Location = new System.Drawing.Point(10, 87);
            this.linkDelete.Name = "linkDelete";
            this.linkDelete.Size = new System.Drawing.Size(108, 17);
            this.linkDelete.TabIndex = 2;
            this.linkDelete.TabStop = true;
            this.linkDelete.Text = "Delete Collector";
            this.linkDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDelete_LinkClicked);
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
            // linkCreate
            // 
            this.linkCreate.AutoSize = true;
            this.linkCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCreate.Location = new System.Drawing.Point(10, 49);
            this.linkCreate.Name = "linkCreate";
            this.linkCreate.Size = new System.Drawing.Size(109, 17);
            this.linkCreate.TabIndex = 0;
            this.linkCreate.TabStop = true;
            this.linkCreate.Text = "Create Collector";
            this.linkCreate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCreate_LinkClicked);
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
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::IWMS.Solutions.Server.Dashboard.Properties.Resources.splash_screen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1507, 733);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panelControlRHS);
            this.Controls.Add(this.panelControlCenter);
            this.Controls.Add(this.panelControlLHS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
            this.tabControlRecycler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRecyclers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecyclers)).EndInit();
            this.tabControlSpotImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSpotImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSpotImages)).EndInit();
            this.tabControlEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEvents)).EndInit();
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
        private System.Windows.Forms.LinkLabel linkCreate;
        private DevExpress.XtraEditors.PanelControl panelControlRHS;
        private System.Windows.Forms.LinkLabel linkDelete;
        private DevExpress.XtraTab.XtraTabPage tabControlSpotImages;
        private DevExpress.XtraGrid.GridControl gridControlSpotImages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSpotImages;
        private DevExpress.XtraTab.XtraTabPage tabControlEvents;
        private DevExpress.XtraGrid.GridControl gridControlEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEvents;
        private System.Windows.Forms.LinkLabel linkClearEvent;
        private DevExpress.XtraTab.XtraTabPage tabControlRecycler;
        private DevExpress.XtraGrid.GridControl gridControlRecyclers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRecyclers;

    }
}

