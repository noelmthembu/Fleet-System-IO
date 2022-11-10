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
    /// Interaction logic for Vehicle_Admin.xaml
    /// </summary>
    public partial class Vehicle_Admin : Window
    {
        public Vehicle_Admin()
        {
            InitializeComponent();
        }

        private void btnVehMain_Click(object sender, RoutedEventArgs e)
        {
            Vehicle_Maintenance vehicle_Maintenance = new Vehicle_Maintenance();
            vehicle_Maintenance.Show();
            this.Hide();
        }

        private void btnViewMaintain_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
