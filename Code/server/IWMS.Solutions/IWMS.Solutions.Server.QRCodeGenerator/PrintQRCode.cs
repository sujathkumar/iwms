using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace IWMS.Solutions.Server.QRCodeGenerator
{
    public partial class PrintQRCode : Form
    {
        public PrintQRCode()
        {
            InitializeComponent();
        }

        private void PrintQRCode_Load(object sender, EventArgs e)
        {
            try
            {
                this.qrReportViewer.Refresh();
                this.qrReportViewer.Reset();
                this.qrReportViewer.LocalReport.EnableExternalImages = true;
                string FilePath = @"file:\" + Application.StartupPath + "\\" + "10202015\\Z5-W56-1\\Z5-W56-1.png";
                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("rpt_image", FilePath);
                this.qrReportViewer.ProcessingMode = ProcessingMode.Local;
                LocalReport rep = qrReportViewer.LocalReport;
                rep.ReportPath = @"C:\Users\nairs6\documents\visual studio 2013\Projects\IWMS.Solutions\IWMS.Solutions.Server.QRCodeGenerator\NKQRReport.rdlc";
                rep.SetParameters(param);
                this.qrReportViewer.RefreshReport();
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
