namespace IWMS.Solutions.Server.QRCodeGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shell));
            this.buttonSave = new System.Windows.Forms.Button();
            this.qrCodeGraphicControl = new Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeGraphicControl();
            this.gridControlGarbage = new DevExpress.XtraGrid.GridControl();
            this.gridViewGarbage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dropDownGarbageType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGarbage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGarbage)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(733, 560);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(54, 38);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // qrCodeGraphicControl
            // 
            this.qrCodeGraphicControl.BackColor = System.Drawing.SystemColors.Control;
            this.qrCodeGraphicControl.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M;
            this.qrCodeGraphicControl.Location = new System.Drawing.Point(684, 504);
            this.qrCodeGraphicControl.Name = "qrCodeGraphicControl";
            this.qrCodeGraphicControl.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two;
            this.qrCodeGraphicControl.Size = new System.Drawing.Size(103, 94);
            this.qrCodeGraphicControl.TabIndex = 5;
            this.qrCodeGraphicControl.Visible = false;
            // 
            // gridControlGarbage
            // 
            this.gridControlGarbage.Location = new System.Drawing.Point(12, 12);
            this.gridControlGarbage.MainView = this.gridViewGarbage;
            this.gridControlGarbage.Name = "gridControlGarbage";
            this.gridControlGarbage.Size = new System.Drawing.Size(775, 542);
            this.gridControlGarbage.TabIndex = 6;
            this.gridControlGarbage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGarbage});
            // 
            // gridViewGarbage
            // 
            this.gridViewGarbage.GridControl = this.gridControlGarbage;
            this.gridViewGarbage.Name = "gridViewGarbage";
            this.gridViewGarbage.OptionsSelection.MultiSelect = true;
            // 
            // dropDownGarbageType
            // 
            this.dropDownGarbageType.FormattingEnabled = true;
            this.dropDownGarbageType.Items.AddRange(new object[] {
            "WET",
            "DRY",
            "E-Waste"});
            this.dropDownGarbageType.Location = new System.Drawing.Point(103, 577);
            this.dropDownGarbageType.Name = "dropDownGarbageType";
            this.dropDownGarbageType.Size = new System.Drawing.Size(121, 21);
            this.dropDownGarbageType.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 580);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Garbage Type";
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 610);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropDownGarbageType);
            this.Controls.Add(this.gridControlGarbage);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.qrCodeGraphicControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Shell";
            this.Text = "QR Code Generator Tool";
            this.Load += new System.EventHandler(this.Shell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGarbage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGarbage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeGraphicControl qrCodeGraphicControl;
        private DevExpress.XtraGrid.GridControl gridControlGarbage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGarbage;
        private System.Windows.Forms.ComboBox dropDownGarbageType;
        private System.Windows.Forms.Label label1;
    }
}

