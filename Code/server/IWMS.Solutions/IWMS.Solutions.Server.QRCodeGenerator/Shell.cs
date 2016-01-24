using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using IWMS.Solutions.Server.BinServiceProvider.Models;
using BinService = IWMS.Solutions.Server.BinServiceProvider;

namespace IWMS.Solutions.Server.QRCodeGenerator
{
    public partial class Shell : Form
    {
        BinService.Provider provider;
        string fileName = ":";

        public Shell()
        {
            InitializeComponent();
            provider = new BinService.Provider();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            IList<Order> orders = new List<Order>();
            int[] selectedRows = gridViewGarbage.GetSelectedRows();

            foreach (var row in selectedRows)
            {
                var garbage = (GarbagePoint)gridViewGarbage.GetRow(row);

                string data = garbage.Tag;
                string folderName = garbage.GeneratedDate.ToString().Substring(0, garbage.GeneratedDate.ToString().IndexOf(" ")).Replace("/", "");
                string fileFolderName = folderName + "\\" + Path.GetFileName(GetFileNameProposal(data));

                if (!Directory.Exists(fileFolderName))
                {
                    Directory.CreateDirectory(fileFolderName);
                }

                //GenerateAddress(fileFolderName, data, garbage.Address);

                if (garbage.GarbageType == "NEWKIT")
                {
                    Order orderWet = GenerateOrder(garbage.Tag, "WET");
                    orders.Add(orderWet);

                    Order orderDry = GenerateOrder(garbage.Tag, "DRY");
                    orders.Add(orderDry);

                    qrCodeGraphicControl.Text = data;
                    SaveQRCode(fileFolderName, data, "NEWKIT", garbage.Quantity);

                    PrintQRCode printQRCode = new PrintQRCode();
                    printQRCode.ShowDialog();
                }
                else
                {
                    Order order = GenerateOrder(garbage.Tag, garbage.GarbageType);
                    orders.Add(order);

                    qrCodeGraphicControl.Text = data;
                    SaveQRCode(fileFolderName, data, "TOPUP", garbage.Quantity);
                }
            }

            //provider.InsertOrders(orders);
            LoadOrders();

            //MessageBox.Show("Garbage Tag and Address generated successfully!");
        }

        private Order GenerateOrder(string tag, string garbageType)
        {
            return provider.GenerateOrder(tag, garbageType);
        }

        private void GenerateAddress(string fileName, string data, string address)
        {
            string file = fileName + "\\" + data + ".txt";
            File.WriteAllText(file, address);
        }

        private void SaveQRCode(string folderName, string data, string orderType, int? quantity)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = @"PNG (*.png)|*.png|Bitmap (*.bmp)|*.bmp|Encapsuled PostScript (*.eps)|*.eps|SVG (*.svg)|*.svg";
            //saveFileDialog.FileName = Path.GetFileName(GetFileNameProposal(data));
            //saveFileDialog.DefaultExt = "png";

            //if (saveFileDialog.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}

            fileName = folderName + "\\" + Path.GetFileName(GetFileNameProposal(data)) + ".png";

            if (fileName.EndsWith("eps"))
            {
                BitMatrix matrix = qrCodeGraphicControl.GetQrMatrix();

                // Initialize the EPS renderer
                var renderer = new EncapsulatedPostScriptRenderer(
                    new FixedModuleSize(6, QuietZoneModules.Two), // Modules size is 6/72th inch (72 points = 1 inch)
                    new FormColor(Color.Black), new FormColor(Color.White));

                using (var file = File.Open(fileName, FileMode.CreateNew))
                {
                    renderer.WriteToStream(matrix, file);
                }
            }
            else if (fileName.EndsWith("svg"))
            {
                BitMatrix matrix = qrCodeGraphicControl.GetQrMatrix();

                // Initialize the EPS renderer
                var renderer = new SVGRenderer(
                    new FixedModuleSize(6, QuietZoneModules.Two), // Modules size is 6/72th inch (72 points = 1 inch)
                    new FormColor(Color.FromArgb(150, 200, 200, 210)), new FormColor(Color.FromArgb(200, 255, 155, 0)));

                using (var file = File.OpenWrite(fileName))
                {
                    renderer.WriteToStream(matrix, file, false);
                }
            }
            else
            {
                GraphicsRenderer gRender = new GraphicsRenderer(new FixedModuleSize(4, QuietZoneModules.Four));
                BitMatrix matrix = qrCodeGraphicControl.GetQrMatrix();
                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    gRender.WriteToStream(matrix, ImageFormat.Png, stream, new System.Drawing.Point(100, 100));
                }
            }
        }

        private string GetFileNameProposal(string qrData)
        {
            return qrData.Length > 10 ? qrData.Substring(0, 10) : qrData;
        }

        private void Shell_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = provider.RetrieveOrders();
            gridControlGarbage.DataSource = orders;
        }
    }
}
