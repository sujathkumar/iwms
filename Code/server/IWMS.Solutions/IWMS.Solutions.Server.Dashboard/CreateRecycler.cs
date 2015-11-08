using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecyclerService = IWMS.Solutions.Server.RecyclerServiceProvider;

namespace IWMS.Solutions.Server.Dashboard
{
    public partial class CreateRecycler : Form
    {
        RecyclerService.Provider provider = null;

        public CreateRecycler()
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
            txtMobile.Clear();
            txtName.Clear();
            txtPassword.Clear();
            comboBoxWard.SelectedIndex = 0;
            comboBoxGarbageType.SelectedIndex = 0;
        }

        /// <summary>
        /// Submit Button Save Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            provider = new RecyclerService.Provider();
            provider.InsertRecycler(txtName.Text, txtAddress.Text, comboBoxWard.SelectedItem.ToString().Trim(), txtMobile.Text,
                txtPassword.Text, comboBoxGarbageType.SelectedItem.ToString().Trim());

            this.Close();

            MessageBox.Show("Inserted successfully!");

            ClearControls();
        }

        /// <summary>
        /// Load Collectors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateRecycler_Load(object sender, EventArgs e)
        {
            provider = new RecyclerService.Provider();
            comboBoxWard.DataSource = provider.RetrieveWards();
            comboBoxGarbageType.DataSource = provider.RetrieveGarbageTypes();
        }
    }
}
