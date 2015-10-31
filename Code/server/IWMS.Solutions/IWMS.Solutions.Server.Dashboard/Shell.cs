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
using SpotImageService = IWMS.Solutions.Server.SpotImageServiceProvider;

namespace IWMS.Solutions.Server.Dashboard
{
    public partial class Shell : Form
    {
        CollectorService.Provider collectorProvider = null;
        SpotImageService.Provider spotImageProvider = null;

        public Shell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// linkCreateCollector_LinkClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tabControlMain.SelectedTabPage == tabControlCollector)
            {
                CreateCollector frm = new CreateCollector();
                frm.ShowDialog();

                LoadCollectors();
                gridControlCollectors.Refresh();
            }
            else if (tabControlMain.SelectedTabPage == tabControlSpotImages)
            {
                int[] selectedRows = gridViewSpotImages.GetSelectedRows();
                SpotImageModel spotImage = null;

                foreach (var row in selectedRows)
                {
                    spotImage = (SpotImageModel)gridViewSpotImages.GetRow(row);
                }

                VerifySpotImage frm = new VerifySpotImage(spotImage.ImagePath);
                frm.ShowDialog();

                LoadSpotImages();
                gridControlSpotImages.Refresh();
            }
            else if (tabControlMain.SelectedTabPage == tabControlEvents)
            {
                int[] selectedRows = gridViewEvents.GetSelectedRows();
                EventModel ev = null;

                foreach (var row in selectedRows)
                {
                    ev = (EventModel)gridViewEvents.GetRow(row);
                }

                EventNotification frm = new EventNotification(ev.ImagePath);
                frm.ShowDialog();

                LoadEvents();
                gridControlEvents.Refresh();
            }
        }

        /// <summary>
        /// Shell_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Shell_Load(object sender, EventArgs e)
        {
            LoadCollectors();
            LoadSpotImages();
            LoadEvents();
        }

        /// <summary>
        /// LoadCollectors
        /// </summary>
        private void LoadCollectors()
        {
            IList<CollectorModel> model = new List<CollectorModel>();
            collectorProvider = new CollectorService.Provider();

            var collectors = collectorProvider.RetrieveCollectors();

            foreach (var collector in collectors)
            {
                var frequency = collectorProvider.RetrieveFrequency(collector.Id);

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
        /// LoadSpotImages
        /// </summary>
        private void LoadSpotImages()
        {
            IList<SpotImageModel> model = new List<SpotImageModel>();
            spotImageProvider = new SpotImageService.Provider();

            var spotImages = spotImageProvider.RetrieveSpotImages();

            foreach (var spotImage in spotImages)
            {
                model.Add(new SpotImageModel
                {
                    Ward = spotImage.WardName,
                    UploadedTime = spotImage.UploadedTime,
                    Verified = spotImage.Verified,
                    ImagePath = spotImage.ImagePath.Substring(spotImage.ImagePath.LastIndexOf("\\") + 1)
                });
            }

            gridControlSpotImages.DataSource = model;
        }

        /// <summary>
        /// LoadEvents
        /// </summary>
        private void LoadEvents()
        {
            IList<EventModel> model = new List<EventModel>();
            spotImageProvider = new SpotImageService.Provider();

            var events = spotImageProvider.RetrieveEvents();

            foreach (var ev in events)
            {
                model.Add(new EventModel
                {
                    Name = ev.Name,
                    Date = ev.Date,
                    Address = ev.Address,
                    Ward = ev.Ward,
                    ImagePath = ev.ImagePath.Substring(ev.ImagePath.LastIndexOf("\\") + 1)
                });
            }

            gridControlEvents.DataSource = model;
        }

        /// <summary>
        /// linkRefresh_LinkClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tabControlMain.SelectedTabPage == tabControlCollector)
            {
                LoadCollectors();
                gridControlCollectors.Refresh();
            }
            else if (tabControlMain.SelectedTabPage == tabControlSpotImages)
            {
                LoadSpotImages();
                gridControlSpotImages.Refresh();
            }
            else if (tabControlMain.SelectedTabPage == tabControlEvents)
            {
                LoadEvents();
                gridControlEvents.Refresh();
            }
        }

        /// <summary>
        /// linkDeleteCollector_LinkClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tabControlMain.SelectedTabPage == tabControlCollector)
            {
                int[] selectedRows = gridViewCollectors.GetSelectedRows();

                foreach (var row in selectedRows)
                {
                    var collector = gridViewCollectors.GetRow(row);
                    collectorProvider = new CollectorService.Provider();
                    collectorProvider.DeleteCollector(((CollectorModel)collector).Mobile);
                }

                LoadCollectors();
                gridControlCollectors.Refresh();
            }
            else if (tabControlMain.SelectedTabPage == tabControlSpotImages)
            {
                int[] selectedRows = gridViewSpotImages.GetSelectedRows();

                foreach (var row in selectedRows)
                {
                    var spotImage = gridViewSpotImages.GetRow(row);
                    spotImageProvider = new SpotImageService.Provider();
                    spotImageProvider.DeleteSpotImage(((SpotImageModel)spotImage).ImagePath);
                }

                LoadSpotImages();
                gridControlSpotImages.Refresh();
            }
            else if (tabControlMain.SelectedTabPage == tabControlEvents)
            {
                int[] selectedRows = gridViewEvents.GetSelectedRows();

                foreach (var row in selectedRows)
                {
                    var ev = gridViewEvents.GetRow(row);
                    spotImageProvider = new SpotImageService.Provider();
                    spotImageProvider.DeleteEvent(((EventModel)ev).Name);
                }

                LoadEvents();
                gridControlEvents.Refresh();
            }

            MessageBox.Show("Deleted successfully!");
        }

        /// <summary>
        /// treeViewMain_AfterSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectTabs(e.Node.Text);
        }

        private void tabControlMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            SelectTabs(e.Page.Text);
        }

        private void SelectTabs(string selection)
        {
            linkClearEvent.Visible = false;
            switch (selection)
            {
                case "Collectors": tabControlMain.SelectedTabPage = tabControlCollector;
                    linkCreate.Text = "Create Collector";
                    linkDelete.Text = "Delete Collector";
                    break;
                case "Spot Images": tabControlMain.SelectedTabPage = tabControlSpotImages;
                    linkCreate.Text = "Verify Spot Image";
                    linkDelete.Text = "Delete Spot Image";
                    break;
                case "Events": tabControlMain.SelectedTabPage = tabControlEvents;
                    linkCreate.Text = "Send Notification";
                    linkDelete.Text = "Delete Event";
                    linkClearEvent.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// linkClearEvent_LinkClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkClearEvent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int[] selectedRows = gridViewEvents.GetSelectedRows();
            EventModel ev = null;

            foreach (var row in selectedRows)
            {
                ev = (EventModel)gridViewEvents.GetRow(row);
            }

            spotImageProvider.ClearEvent(ev.ImagePath);

            MessageBox.Show("Event Cleared successfully!");

            LoadEvents();
            gridControlEvents.Refresh();
        }
    }
}
