using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWMS.Solutions.Server.SpotImage.Models;
using SpotImageService = IWMS.Solutions.Server.SpotImageServiceProvider;

namespace IWMS.Solutions.Server.Dashboard
{
    public partial class VerifySpotImage : Form
    {
        SpotImageService.Provider spotImageProvider = null;
        private string ImagePath;
        private Guid SpotImageId;

        public VerifySpotImage(string imagePath)
        {
            InitializeComponent();
            this.ImagePath = imagePath;
        }

        /// <summary>
        /// Submit Button Save Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            spotImageProvider = new SpotImageService.Provider();
            spotImageProvider.VerifySpotImage(this.ImagePath);

            DialogResult result = MessageBox.Show("Do you want to create an Event?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                EventMessageBox frmDialog = new EventMessageBox(this.SpotImageId);
                frmDialog.ShowDialog();
            }

            this.Close();
        }

        /// <summary>
        /// Load Collectors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerifySpotImage_Load(object sender, EventArgs e)
        {
            spotImageProvider = new SpotImageService.Provider();
            SpotImagePoint model = spotImageProvider.RetrievSpotImage(this.ImagePath);

            txtLatitude.Text = model.Latitude;
            txtLongitude.Text = model.Longitude;
            txtUploadedTime.Text = model.UploadedTime.ToString();
            txtUserAddress.Text = model.UserAddress;
            txtUserName.Text = model.UserName;
            txtWardName.Text = model.WardName;
            pictureImage.ImageLocation = model.ImagePath;

            this.SpotImageId = model.Id;
        }
    }
}
