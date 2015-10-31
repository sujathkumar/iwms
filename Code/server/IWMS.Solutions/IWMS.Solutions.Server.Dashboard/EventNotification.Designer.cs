namespace IWMS.Solutions.Server.Dashboard
{
    partial class EventNotification
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
            this.btnNotify = new System.Windows.Forms.Button();
            this.groupBoxLabelRHS = new System.Windows.Forms.GroupBox();
            this.lblSlotTo2 = new System.Windows.Forms.Label();
            this.lblSlotFrom2 = new System.Windows.Forms.Label();
            this.lblSlotFrom1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxTextRHS = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtWardName = new System.Windows.Forms.TextBox();
            this.txtUserAddress = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.pictureImage = new System.Windows.Forms.PictureBox();
            this.groupBoxLabelRHS.SuspendLayout();
            this.groupBoxTextRHS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNotify
            // 
            this.btnNotify.Location = new System.Drawing.Point(746, 432);
            this.btnNotify.Name = "btnNotify";
            this.btnNotify.Size = new System.Drawing.Size(75, 23);
            this.btnNotify.TabIndex = 3;
            this.btnNotify.Text = "Notify";
            this.btnNotify.UseVisualStyleBackColor = true;
            this.btnNotify.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBoxLabelRHS
            // 
            this.groupBoxLabelRHS.Controls.Add(this.lblSlotTo2);
            this.groupBoxLabelRHS.Controls.Add(this.lblSlotFrom2);
            this.groupBoxLabelRHS.Controls.Add(this.lblSlotFrom1);
            this.groupBoxLabelRHS.Controls.Add(this.label5);
            this.groupBoxLabelRHS.Location = new System.Drawing.Point(414, 13);
            this.groupBoxLabelRHS.Name = "groupBoxLabelRHS";
            this.groupBoxLabelRHS.Size = new System.Drawing.Size(125, 410);
            this.groupBoxLabelRHS.TabIndex = 10;
            this.groupBoxLabelRHS.TabStop = false;
            // 
            // lblSlotTo2
            // 
            this.lblSlotTo2.AutoSize = true;
            this.lblSlotTo2.ForeColor = System.Drawing.Color.White;
            this.lblSlotTo2.Location = new System.Drawing.Point(6, 212);
            this.lblSlotTo2.Name = "lblSlotTo2";
            this.lblSlotTo2.Size = new System.Drawing.Size(61, 13);
            this.lblSlotTo2.TabIndex = 9;
            this.lblSlotTo2.Text = "WardName";
            // 
            // lblSlotFrom2
            // 
            this.lblSlotFrom2.AutoSize = true;
            this.lblSlotFrom2.ForeColor = System.Drawing.Color.White;
            this.lblSlotFrom2.Location = new System.Drawing.Point(6, 91);
            this.lblSlotFrom2.Name = "lblSlotFrom2";
            this.lblSlotFrom2.Size = new System.Drawing.Size(70, 13);
            this.lblSlotFrom2.TabIndex = 8;
            this.lblSlotFrom2.Text = "User Address";
            // 
            // lblSlotFrom1
            // 
            this.lblSlotFrom1.AutoSize = true;
            this.lblSlotFrom1.ForeColor = System.Drawing.Color.White;
            this.lblSlotFrom1.Location = new System.Drawing.Point(6, 54);
            this.lblSlotFrom1.Name = "lblSlotFrom1";
            this.lblSlotFrom1.Size = new System.Drawing.Size(30, 13);
            this.lblSlotFrom1.TabIndex = 6;
            this.lblSlotFrom1.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Name";
            // 
            // groupBoxTextRHS
            // 
            this.groupBoxTextRHS.Controls.Add(this.txtName);
            this.groupBoxTextRHS.Controls.Add(this.txtWardName);
            this.groupBoxTextRHS.Controls.Add(this.txtUserAddress);
            this.groupBoxTextRHS.Controls.Add(this.txtDate);
            this.groupBoxTextRHS.Location = new System.Drawing.Point(545, 13);
            this.groupBoxTextRHS.Name = "groupBoxTextRHS";
            this.groupBoxTextRHS.Size = new System.Drawing.Size(273, 410);
            this.groupBoxTextRHS.TabIndex = 10;
            this.groupBoxTextRHS.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(8, 20);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(259, 20);
            this.txtName.TabIndex = 12;
            // 
            // txtWardName
            // 
            this.txtWardName.Location = new System.Drawing.Point(8, 212);
            this.txtWardName.Name = "txtWardName";
            this.txtWardName.ReadOnly = true;
            this.txtWardName.Size = new System.Drawing.Size(259, 20);
            this.txtWardName.TabIndex = 9;
            // 
            // txtUserAddress
            // 
            this.txtUserAddress.Location = new System.Drawing.Point(8, 91);
            this.txtUserAddress.Multiline = true;
            this.txtUserAddress.Name = "txtUserAddress";
            this.txtUserAddress.ReadOnly = true;
            this.txtUserAddress.Size = new System.Drawing.Size(259, 102);
            this.txtUserAddress.TabIndex = 8;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(8, 54);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(259, 20);
            this.txtDate.TabIndex = 6;
            // 
            // pictureImage
            // 
            this.pictureImage.Location = new System.Drawing.Point(12, 23);
            this.pictureImage.Name = "pictureImage";
            this.pictureImage.Size = new System.Drawing.Size(396, 398);
            this.pictureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureImage.TabIndex = 13;
            this.pictureImage.TabStop = false;
            // 
            // EventNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(833, 477);
            this.Controls.Add(this.pictureImage);
            this.Controls.Add(this.groupBoxTextRHS);
            this.Controls.Add(this.groupBoxLabelRHS);
            this.Controls.Add(this.btnNotify);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(849, 515);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(849, 515);
            this.Name = "EventNotification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verify SpotImage";
            this.Load += new System.EventHandler(this.EventNotification_Load);
            this.groupBoxLabelRHS.ResumeLayout(false);
            this.groupBoxLabelRHS.PerformLayout();
            this.groupBoxTextRHS.ResumeLayout(false);
            this.groupBoxTextRHS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNotify;
        private System.Windows.Forms.GroupBox groupBoxLabelRHS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxTextRHS;
        private System.Windows.Forms.Label lblSlotTo2;
        private System.Windows.Forms.Label lblSlotFrom2;
        private System.Windows.Forms.Label lblSlotFrom1;
        private System.Windows.Forms.TextBox txtWardName;
        private System.Windows.Forms.TextBox txtUserAddress;
        private System.Windows.Forms.PictureBox pictureImage;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDate;
    }
}