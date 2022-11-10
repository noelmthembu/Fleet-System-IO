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
using System.Data.SqlClient;

namespace Fleet.io_cx_system
{
    /// <summary>
    /// Interaction logic for Driver_Income.xaml
    /// </summary>
    public partial class Driver_Income : Window
    {
        public Driver_Income()
        {
            InitializeComponent();
        }

        private void btnStore_Click(object sender, RoutedEventArgs e)
        {
            int DriverIncome;


            //Sql Connection created to connect to the database
            SqlConnection connection = new SqlConnection(@"Data Source=RCBF501PC19\SQLEXPRESS;Initial Catalog=FLEET_IO;Integrated Security=True");
            //Sql Command created to store the qurey and connection
            SqlCommand command = new SqlCommand();


            //Try error handling
            try
            {

                {
                    //Sql Connection object to open the database
                    connection.Open();
                    //Sql statement to insert into the database
                    string Reg = "INSERT INTO[dbo].[DRIVER_INCOME]([DRIVER_NAME],[workedHours])VALUES('" + lbxDriver.SelectedItem.ToString() + "','" +  Convert.ToInt32(txtWorkedHrs.Text) + "')";

                    //Sql command to store insert statement and connection
                    command = new SqlCommand(Reg, connection);
                    //ExecuteNonQuery method to access the database
                    command.ExecuteNonQuery();
                    //Close method to clase the database
                    connection.Close();

                    MessageBox.Show("Driver Income Calculated");
                }

            }
            //Catch statement to store errors
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        public double CacDriverIncome(double DriverIncome)
        {

            DriverIncome = (Convert.ToInt32(txtWorkedHrs.Text) * 110);
            return DriverIncome;

        }

        private void btnServM_Click(object sender, RoutedEventArgs e)
        {
            Service_Manager service_Manager = new Service_Manager();
            service_Manager.Show();
            this.Hide();
        }
    }
}
