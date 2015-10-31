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
    public partial class EventNotification : Form
    {
        SpotImageService.Provider spotImageProvider = null;
        private string ImagePath;
        private Guid EventId;

        public EventNotification(string imagePath)
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
            spotImageProvider.SendNotification(this.ImagePath);

            MessageBox.Show("Notification send successfully!");

            this.Close();
        }

        /// <summary>
        /// Load Collectors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventNotification_Load(object sender, EventArgs e)
        {
            spotImageProvider = new SpotImageService.Provider();
            EventPoint model = spotImageProvider.RetrieveEvent(this.ImagePath);

            txtName.Text = model.Name;
            txtDate.Text = model.Date.ToString();
            txtUserAddress.Text = model.Address.ToString();
            txtWardName.Text = model.Ward;
            pictureImage.ImageLocation = model.ImagePath;

            this.EventId = model.Id;
        }
    }
}
