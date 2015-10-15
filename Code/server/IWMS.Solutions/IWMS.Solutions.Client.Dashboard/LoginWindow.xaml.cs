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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SoftArcs.WPFSmartLibrary.SmartUserControls;

namespace IWMS.Solutions.Client.Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        #region Fields

        public LoginViewModel ViewModel;

        #endregion

        #region Constructor
        public LoginWindow()
        {
            InitializeComponent();

            this.ViewModel = new LoginViewModel();
            this.DataContext = this.ViewModel;
        }
        #endregion

        /// <summary>
        /// btnCollector_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCollector_Click(object sender, RoutedEventArgs e)
        {
            CollectorDashboard dashboard = new CollectorDashboard();
            dashboard.Show();
        }

        /// <summary>
        /// btnRecycler_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecycler_Click(object sender, RoutedEventArgs e)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBBMP_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
