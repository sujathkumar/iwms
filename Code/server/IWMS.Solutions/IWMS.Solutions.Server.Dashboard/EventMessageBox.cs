using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotImageService = IWMS.Solutions.Server.SpotImageServiceProvider;

namespace IWMS.Solutions.Server.Dashboard
{
    public partial class EventMessageBox : Form
    {
        SpotImageService.Provider spotImageProvider = null;
        private Guid SpotImageId;

        public EventMessageBox(Guid spotImageId)
        {
            InitializeComponent();
            this.SpotImageId = spotImageId;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            spotImageProvider = new SpotImageService.Provider();
            spotImageProvider.InsertEvent(txtEventName.Text, Convert.ToDateTime(dateTimePickerEvent.Value), this.SpotImageId);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
