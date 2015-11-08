namespace IWMS.Solutions.Server.Dashboard
{
    partial class CreateRecycler
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
            this.groupBoxTextLHS = new System.Windows.Forms.GroupBox();
            this.comboBoxGarbageType = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.comboBoxWard = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblRecyclerName = new System.Windows.Forms.Label();
            this.lblRecyclerAddress = new System.Windows.Forms.Label();
            this.lblWard = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.groupBoxLabelLHS = new System.Windows.Forms.GroupBox();
            this.lblGarbageType = new System.Windows.Forms.Label();
            this.groupBoxTextRHS = new System.Windows.Forms.GroupBox();
            this.groupBoxLabelRHS = new System.Windows.Forms.GroupBox();
            this.groupBoxTextLHS.SuspendLayout();
            this.groupBoxLabelLHS.SuspendLayout();
            this.groupBoxTextRHS.SuspendLayout();
            this.groupBoxLabelRHS.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTextLHS
            // 
            this.groupBoxTextLHS.Controls.Add(this.txtPassword);
            this.groupBoxTextLHS.Controls.Add(this.txtMobile);
            this.groupBoxTextLHS.Controls.Add(this.comboBoxWard);
            this.groupBoxTextLHS.Controls.Add(this.txtAddress);
            this.groupBoxTextLHS.Controls.Add(this.txtName);
            this.groupBoxTextLHS.Location = new System.Drawing.Point(135, 13);
            this.groupBoxTextLHS.Name = "groupBoxTextLHS";
            this.groupBoxTextLHS.Size = new System.Drawing.Size(273, 410);
            this.groupBoxTextLHS.TabIndex = 1;
            this.groupBoxTextLHS.TabStop = false;
            // 
            // comboBoxGarbageType
            // 
            this.comboBoxGarbageType.FormattingEnabled = true;
            this.comboBoxGarbageType.Location = new System.Drawing.Point(11, 19);
            this.comboBoxGarbageType.Name = "comboBoxGarbageType";
            this.comboBoxGarbageType.Size = new System.Drawing.Size(246, 21);
            this.comboBoxGarbageType.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(7, 191);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(246, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(7, 157);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(246, 20);
            this.txtMobile.TabIndex = 3;
            // 
            // comboBoxWard
            // 
            this.comboBoxWard.FormattingEnabled = true;
            this.comboBoxWard.Location = new System.Drawing.Point(7, 122);
            this.comboBoxWard.Name = "comboBoxWard";
            this.comboBoxWard.Size = new System.Drawing.Size(246, 21);
            this.comboBoxWard.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(7, 54);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(246, 54);
            this.txtAddress.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(7, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 20);
            this.txtName.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(665, 432);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(746, 432);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblCollectorName
            // 
            this.lblRecyclerName.AutoSize = true;
            this.lblRecyclerName.ForeColor = System.Drawing.Color.White;
            this.lblRecyclerName.Location = new System.Drawing.Point(9, 20);
            this.lblRecyclerName.Name = "lblCollectorName";
            this.lblRecyclerName.Size = new System.Drawing.Size(35, 13);
            this.lblRecyclerName.TabIndex = 0;
            this.lblRecyclerName.Text = "Name";
            // 
            // lblCollectorAddress
            // 
            this.lblRecyclerAddress.AutoSize = true;
            this.lblRecyclerAddress.ForeColor = System.Drawing.Color.White;
            this.lblRecyclerAddress.Location = new System.Drawing.Point(9, 54);
            this.lblRecyclerAddress.Name = "lblCollectorAddress";
            this.lblRecyclerAddress.Size = new System.Drawing.Size(45, 13);
            this.lblRecyclerAddress.TabIndex = 1;
            this.lblRecyclerAddress.Text = "Address";
            // 
            // lblWard
            // 
            this.lblWard.AutoSize = true;
            this.lblWard.ForeColor = System.Drawing.Color.White;
            this.lblWard.Location = new System.Drawing.Point(9, 122);
            this.lblWard.Name = "lblWard";
            this.lblWard.Size = new System.Drawing.Size(33, 13);
            this.lblWard.TabIndex = 2;
            this.lblWard.Text = "Ward";
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.ForeColor = System.Drawing.Color.White;
            this.lblMobile.Location = new System.Drawing.Point(9, 156);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(38, 13);
            this.lblMobile.TabIndex = 3;
            this.lblMobile.Text = "Mobile";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(9, 190);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // groupBoxLabelLHS
            // 
            this.groupBoxLabelLHS.Controls.Add(this.lblPassword);
            this.groupBoxLabelLHS.Controls.Add(this.lblMobile);
            this.groupBoxLabelLHS.Controls.Add(this.lblWard);
            this.groupBoxLabelLHS.Controls.Add(this.lblRecyclerAddress);
            this.groupBoxLabelLHS.Controls.Add(this.lblRecyclerName);
            this.groupBoxLabelLHS.Location = new System.Drawing.Point(4, 13);
            this.groupBoxLabelLHS.Name = "groupBoxLabelLHS";
            this.groupBoxLabelLHS.Size = new System.Drawing.Size(125, 410);
            this.groupBoxLabelLHS.TabIndex = 0;
            this.groupBoxLabelLHS.TabStop = false;
            // 
            // lblGarbageType
            // 
            this.lblGarbageType.AutoSize = true;
            this.lblGarbageType.ForeColor = System.Drawing.Color.White;
            this.lblGarbageType.Location = new System.Drawing.Point(9, 23);
            this.lblGarbageType.Name = "lblGarbageType";
            this.lblGarbageType.Size = new System.Drawing.Size(75, 13);
            this.lblGarbageType.TabIndex = 8;
            this.lblGarbageType.Text = "Garbage Type";
            // 
            // groupBoxTextRHS
            // 
            this.groupBoxTextRHS.Controls.Add(this.comboBoxGarbageType);
            this.groupBoxTextRHS.Location = new System.Drawing.Point(545, 13);
            this.groupBoxTextRHS.Name = "groupBoxTextRHS";
            this.groupBoxTextRHS.Size = new System.Drawing.Size(273, 410);
            this.groupBoxTextRHS.TabIndex = 10;
            this.groupBoxTextRHS.TabStop = false;
            // 
            // groupBoxLabelRHS
            // 
            this.groupBoxLabelRHS.Controls.Add(this.lblGarbageType);
            this.groupBoxLabelRHS.Location = new System.Drawing.Point(414, 13);
            this.groupBoxLabelRHS.Name = "groupBoxLabelRHS";
            this.groupBoxLabelRHS.Size = new System.Drawing.Size(125, 410);
            this.groupBoxLabelRHS.TabIndex = 10;
            this.groupBoxLabelRHS.TabStop = false;
            // 
            // CreateRecycler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(833, 477);
            this.Controls.Add(this.groupBoxTextRHS);
            this.Controls.Add(this.groupBoxLabelRHS);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBoxTextLHS);
            this.Controls.Add(this.groupBoxLabelLHS);
            this.Name = "CreateRecycler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Collector";
            this.Load += new System.EventHandler(this.CreateRecycler_Load);
            this.groupBoxTextLHS.ResumeLayout(false);
            this.groupBoxTextLHS.PerformLayout();
            this.groupBoxLabelLHS.ResumeLayout(false);
            this.groupBoxLabelLHS.PerformLayout();
            this.groupBoxTextRHS.ResumeLayout(false);
            this.groupBoxLabelRHS.ResumeLayout(false);
            this.groupBoxLabelRHS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTextLHS;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox comboBoxWard;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblRecyclerName;
        private System.Windows.Forms.Label lblRecyclerAddress;
        private System.Windows.Forms.Label lblWard;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.GroupBox groupBoxLabelLHS;
        private System.Windows.Forms.Label lblGarbageType;
        private System.Windows.Forms.ComboBox comboBoxGarbageType;
        private System.Windows.Forms.GroupBox groupBoxTextRHS;
        private System.Windows.Forms.GroupBox groupBoxLabelRHS;
    }
}