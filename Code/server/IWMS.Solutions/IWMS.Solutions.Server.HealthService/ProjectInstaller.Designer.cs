namespace IWMS.Solutions.Server.HealthService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.healthserviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.healthServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // healthserviceProcessInstaller
            // 
            this.healthserviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.healthserviceProcessInstaller.Password = null;
            this.healthserviceProcessInstaller.Username = null;
            // 
            // healthServiceInstaller
            // 
            this.healthServiceInstaller.DisplayName = "IWMS Health Service";
            this.healthServiceInstaller.ServiceName = "IWMSHealthService";
            this.healthServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.healthserviceProcessInstaller,
            this.healthServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller healthserviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller healthServiceInstaller;
    }
}