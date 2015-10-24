namespace IWMS.Solutions.Server.Dashboard
{
    partial class VerifySpotImage
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
            this.btnVerify = new System.Windows.Forms.Button();
            this.groupBoxLabelRHS = new System.Windows.Forms.GroupBox();
            this.lblSlotFrom3 = new System.Windows.Forms.Label();
            this.lblSlotTo2 = new System.Windows.Forms.Label();
            this.lblSlotFrom2 = new System.Windows.Forms.Label();
            this.lblSlotTo1 = new System.Windows.Forms.Label();
            this.lblSlotFrom1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxTextRHS = new System.Windows.Forms.GroupBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.txtUploadedTime = new System.Windows.Forms.TextBox();
            this.txtWardName = new System.Windows.Forms.TextBox();
            this.txtUserAddress = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.pictureImage = new System.Windows.Forms.PictureBox();
            this.groupBoxLabelRHS.SuspendLayout();
            this.groupBoxTextRHS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(746, 432);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 3;
            this.btnVerify.Text = "Approve";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBoxLabelRHS
            // 
            this.groupBoxLabelRHS.Controls.Add(this.lblSlotFrom3);
            this.groupBoxLabelRHS.Controls.Add(this.lblSlotTo2);
            this.groupBoxLabelRHS.Controls.Add(this.lblSlotFrom2);
            this.groupBoxLabelRHS.Controls.Add(this.lblSlotTo1);
            this.groupBoxLabelRHS.Controls.Add(this.lblSlotFrom1);
            this.groupBoxLabelRHS.Controls.Add(this.label5);
            this.groupBoxLabelRHS.Location = new System.Drawing.Point(414, 13);
            this.groupBoxLabelRHS.Name = "groupBoxLabelRHS";
            this.groupBoxLabelRHS.Size = new System.Drawing.Size(125, 410);
            this.groupBoxLabelRHS.TabIndex = 10;
            this.groupBoxLabelRHS.TabStop = false;
            // 
            // lblSlotFrom3
            // 
            this.lblSlotFrom3.AutoSize = true;
            this.lblSlotFrom3.ForeColor = System.Drawing.Color.White;
            this.lblSlotFrom3.Location = new System.Drawing.Point(6, 270);
            this.lblSlotFrom3.Name = "lblSlotFrom3";
            this.lblSlotFrom3.Size = new System.Drawing.Size(79, 13);
            this.lblSlotFrom3.TabIndex = 10;
            this.lblSlotFrom3.Text = "Uploaded Time";
            // 
            // lblSlotTo2
            // 
            this.lblSlotTo2.AutoSize = true;
            this.lblSlotTo2.ForeColor = System.Drawing.Color.White;
            this.lblSlotTo2.Location = new System.Drawing.Point(6, 236);
            this.lblSlotTo2.Name = "lblSlotTo2";
            this.lblSlotTo2.Size = new System.Drawing.Size(61, 13);
            this.lblSlotTo2.TabIndex = 9;
            this.lblSlotTo2.Text = "WardName";
            // 
            // lblSlotFrom2
            // 
            this.lblSlotFrom2.AutoSize = true;
            this.lblSlotFrom2.ForeColor = System.Drawing.Color.White;
            this.lblSlotFrom2.Location = new System.Drawing.Point(6, 122);
            this.lblSlotFrom2.Name = "lblSlotFrom2";
            this.lblSlotFrom2.Size = new System.Drawing.Size(70, 13);
            this.lblSlotFrom2.TabIndex = 8;
            this.lblSlotFrom2.Text = "User Address";
            // 
            // lblSlotTo1
            // 
            this.lblSlotTo1.AutoSize = true;
            this.lblSlotTo1.ForeColor = System.Drawing.Color.White;
            this.lblSlotTo1.Location = new System.Drawing.Point(6, 88);
            this.lblSlotTo1.Name = "lblSlotTo1";
            this.lblSlotTo1.Size = new System.Drawing.Size(57, 13);
            this.lblSlotTo1.TabIndex = 7;
            this.lblSlotTo1.Text = "UserName";
            // 
            // lblSlotFrom1
            // 
            this.lblSlotFrom1.AutoSize = true;
            this.lblSlotFrom1.ForeColor = System.Drawing.Color.White;
            this.lblSlotFrom1.Location = new System.Drawing.Point(6, 54);
            this.lblSlotFrom1.Name = "lblSlotFrom1";
            this.lblSlotFrom1.Size = new System.Drawing.Size(54, 13);
            this.lblSlotFrom1.TabIndex = 6;
            this.lblSlotFrom1.Text = "Longitude";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Latitude";
            // 
            // groupBoxTextRHS
            // 
            this.groupBoxTextRHS.Controls.Add(this.txtLatitude);
            this.groupBoxTextRHS.Controls.Add(this.txtUploadedTime);
            this.groupBoxTextRHS.Controls.Add(this.txtWardName);
            this.groupBoxTextRHS.Controls.Add(this.txtUserAddress);
            this.groupBoxTextRHS.Controls.Add(this.txtUserName);
            this.groupBoxTextRHS.Controls.Add(this.txtLongitude);
            this.groupBoxTextRHS.Location = new System.Drawing.Point(545, 13);
            this.groupBoxTextRHS.Name = "groupBoxTextRHS";
            this.groupBoxTextRHS.Size = new System.Drawing.Size(273, 410);
            this.groupBoxTextRHS.TabIndex = 10;
            this.groupBoxTextRHS.TabStop = false;
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(8, 20);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.ReadOnly = true;
            this.txtLatitude.Size = new System.Drawing.Size(259, 20);
            this.txtLatitude.TabIndex = 12;
            // 
            // txtUploadedTime
            // 
            this.txtUploadedTime.Location = new System.Drawing.Point(8, 270);
            this.txtUploadedTime.Name = "txtUploadedTime";
            this.txtUploadedTime.ReadOnly = true;
            this.txtUploadedTime.Size = new System.Drawing.Size(259, 20);
            this.txtUploadedTime.TabIndex = 10;
            // 
            // txtWardName
            // 
            this.txtWardName.Location = new System.Drawing.Point(8, 236);
            this.txtWardName.Name = "txtWardName";
            this.txtWardName.ReadOnly = true;
            this.txtWardName.Size = new System.Drawing.Size(259, 20);
            this.txtWardName.TabIndex = 9;
            // 
            // txtUserAddress
            // 
            this.txtUserAddress.Location = new System.Drawing.Point(8, 122);
            this.txtUserAddress.Multiline = true;
            this.txtUserAddress.Name = "txtUserAddress";
            this.txtUserAddress.ReadOnly = true;
            this.txtUserAddress.Size = new System.Drawing.Size(259, 102);
            this.txtUserAddress.TabIndex = 8;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(8, 88);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(259, 20);
            this.txtUserName.TabIndex = 7;
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(8, 54);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.ReadOnly = true;
            this.txtLongitude.Size = new System.Drawing.Size(259, 20);
            this.txtLongitude.TabIndex = 6;
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
            // VerifySpotImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(833, 477);
            this.Controls.Add(this.pictureImage);
            this.Controls.Add(this.groupBoxTextRHS);
            this.Controls.Add(this.groupBoxLabelRHS);
            this.Controls.Add(this.btnVerify);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(849, 515);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(849, 515);
            this.Name = "VerifySpotImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verify SpotImage";
            this.Load += new System.EventHandler(this.VerifySpotImage_Load);
            this.groupBoxLabelRHS.ResumeLayout(false);
            this.groupBoxLabelRHS.PerformLayout();
            this.groupBoxTextRHS.ResumeLayout(false);
            this.groupBoxTextRHS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.GroupBox groupBoxLabelRHS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxTextRHS;
        private System.Windows.Forms.Label lblSlotFrom3;
        private System.Windows.Forms.Label lblSlotTo2;
        private System.Windows.Forms.Label lblSlotFrom2;
        private System.Windows.Forms.Label lblSlotTo1;
        private System.Windows.Forms.Label lblSlotFrom1;
        private System.Windows.Forms.TextBox txtUploadedTime;
        private System.Windows.Forms.TextBox txtWardName;
        private System.Windows.Forms.TextBox txtUserAddress;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.PictureBox pictureImage;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.TextBox txtLongitude;
    }
}