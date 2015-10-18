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
    public partial class Shell : Form
    {
        CollectorService.Provider provider = null;

        public Shell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// linkCreateCollector_LinkClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkCreateCollector_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateCollector frm = new CreateCollector();
            frm.ShowDialog();

            LoadCollectors();
            gridControlCollectors.Refresh();
        }

        /// <summary>
        /// Shell_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Shell_Load(object sender, EventArgs e)
        {
            LoadCollectors();
        }

        private void LoadCollectors()
        {
            IList<CollectorModel> model = new List<CollectorModel>();
            provider = new CollectorService.Provider();

            var collectors = provider.RetrieveCollectors();

            foreach (var collector in collectors)
            {
                var frequency = provider.RetrieveFrequency(collector.Id);

                model.Add(new CollectorModel
                {
                    Name = collector.Name,
                    Address = collector.Address,
                    Mobile = collector.Mobile,
                    Ward = collector.Ward,
                    PickupFrequency = frequency.PickupFrequency,
                    FrequencyType = frequency.FrequencyType,
                    SlotFrom1 = frequency.SlotFrom1,
                    SlotTo1 = frequency.SlotTo1,
                    SlotFrom2 = frequency.SlotFrom2,
                    SlotTo2 = frequency.SlotTo2,
                    SlotFrom3 = frequency.SlotFrom3,
                    SlotTo3 = frequency.SlotTo3,
                    Capacity = frequency.Capacity,
                    LastUpdateDate = frequency.LastUpdateDate
                });
            }

            gridControlCollectors.DataSource = model;
        }

        /// <summary>
        /// linkRefresh_LinkClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadCollectors();
            gridControlCollectors.Refresh();
        }

        /// <summary>
        /// linkDeleteCollector_LinkClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkDeleteCollector_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int[] selectedRows = gridViewCollectors.GetSelectedRows();

            foreach(var row in selectedRows)
            {
                var collector = gridViewCollectors.GetRow(row);
                provider = new CollectorService.Provider();
                provider.DeleteCollector(((CollectorModel)collector).Mobile);
            }           

            LoadCollectors();
            gridControlCollectors.Refresh();

            MessageBox.Show("Deleted successfully!");
        }
    }
}
