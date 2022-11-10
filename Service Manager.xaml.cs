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

namespace Fleet.io_cx_system
{
    /// <summary>
    /// Interaction logic for Service_Manager.xaml
    /// </summary>
    public partial class Service_Manager : Window
    {
        public Service_Manager()
        {
            InitializeComponent();
        }

        private void btnCalDriverIncome_Click(object sender, RoutedEventArgs e)
        {
            Driver_Income driver_Income = new Driver_Income();
            driver_Income.Show();
            this.Hide();
        }

        private void btnCapSup_Click(object sender, RoutedEventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.Show();
            this.Hide();
        }

        private void btnVehSer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewSup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVehRep_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCapVehService_Click(object sender, RoutedEventArgs e)
        {
            Capture_Vehicle_Service capture_Vehicle_Service = new Capture_Vehicle_Service();
            capture_Vehicle_Service.Show();
            this.Hide();
        }

    }
}
