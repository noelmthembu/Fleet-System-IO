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
    /// Interaction logic for Vehicle_Maintenance.xaml
    /// </summary>
    public partial class Vehicle_Maintenance : Window
    {
        public Vehicle_Maintenance()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Vehicle_Admin vehicle_Admin = new Vehicle_Admin();
            vehicle_Admin.Show();
            this.Hide();
        }
    }
}
