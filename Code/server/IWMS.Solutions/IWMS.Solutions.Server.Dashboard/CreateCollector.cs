using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CollectorService = IWMS.Solutions.Server.CollectorServiceProvider;

namespace IWMS.Solutions.Server.Dashboard
{
    public partial class CreateCollector : Form
    {
        CollectorService.Provider provider = null;

        public CreateCollector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clear Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        /// <summary>
        /// Clear Controls
        /// </summary>
        private void ClearControls()
        {
            txtAddress.Clear();
            txtCapacity.Clear();
            txtFrequencyType.Clear();
            txtMobile.Clear();
            txtName.Clear();
            txtPassword.Clear();
            comboBoxWard.SelectedIndex = 0;
            comboBoxGarbageType.SelectedIndex = 0;
            comboBoxPickupFrequency.SelectedIndex = 0;
            txtSlotFrom1.Clear();
            txtSlotFrom2.Clear();
            txtSlotFrom3.Clear();
            txtSlotTo1.Clear();
            txtSlotTo2.Clear();
            txtSlotTo3.Clear();
        }

        /// <summary>
        /// Submit Button Save Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int pickupFrequency = 1;

            if (comboBoxPickupFrequency.SelectedItem.ToString() == "Once in a day")
            {
                pickupFrequency = 1;
            }
            else if (comboBoxPickupFrequency.SelectedItem.ToString() == "Twice in a day")
            {
                pickupFrequency = 2;
            }
            else if (comboBoxPickupFrequency.SelectedItem.ToString() == "Thrice in a day")
            {
                pickupFrequency = 3;
            }

            provider = new CollectorService.Provider();
            provider.InsertCollector(txtName.Text, txtAddress.Text, comboBoxWard.SelectedItem.ToString().Trim(), txtMobile.Text,
                txtPassword.Text, pickupFrequency, Convert.ToInt32(txtFrequencyType.Text), Convert.ToInt32(txtCapacity.Text),
                txtSlotFrom1.Text + "|" + txtSlotFrom2.Text + "|" + txtSlotFrom3.Text,
                txtSlotTo1.Text + "|" + txtSlotTo2.Text + "|" + txtSlotTo3.Text, comboBoxGarbageType.SelectedItem.ToString().Trim(), dateTimeLastCollection.Value);

            this.Close();

            MessageBox.Show("Inserted successfully!");

            ClearControls();
        }

        /// <summary>
        /// Load Collectors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCollector_Load(object sender, EventArgs e)
        {
            comboBoxPickupFrequency.SelectedIndex = 0;

            provider = new CollectorService.Provider();
            comboBoxWard.DataSource = provider.RetrieveWards();
            comboBoxGarbageType.DataSource = provider.RetrieveGarbageTypes();
        }
    }
}
