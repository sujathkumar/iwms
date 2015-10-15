using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CollectorService = IWMS.Solutions.Server.CollectorServiceProvider;

namespace IWMS.Solutions.Client.Dashboard
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class CollectorDashboard : Window
    {
        CollectorService.Provider provider;
        public CollectorDashboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window_Loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            provider = new CollectorService.Provider();
            dgCollectors.ItemsSource = provider.RetrieveCollectors();
        }

        /// <summary>
        /// btnCollector_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertCollector_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
