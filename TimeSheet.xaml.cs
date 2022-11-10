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
    /// Interaction logic for TimeSheet.xaml
    /// </summary>
    public partial class TimeSheet : Window
    {
        public TimeSheet()
        {
            InitializeComponent();
        }

        private void btnCapSche_Click(object sender, RoutedEventArgs e)
        {
            TimeSheet_Capture timeSheet_Capture = new TimeSheet_Capture();
            timeSheet_Capture.Show();
            this.Hide();
        }

        private void btnViewSche_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
