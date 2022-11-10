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
using System.Data.SqlClient;
using System.Threading;

namespace Fleet.io_cx_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
        }
        //Login Method
        public static void Wait()
        {
            //Thread variable created for 4 sec.
            Thread.Sleep(4000);
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           

                //Sql Connection created to connect to the database
                SqlConnection connection = new SqlConnection(@"Data Source=RCBF501PC19\SQLEXPRESS;Initial Catalog=FLEET_IO;Integrated Security=True");
                //Sql Command created to store the qurey and connection
                SqlCommand command = new SqlCommand();
                //Object created for Hashing class
                Hashing hashing = new Hashing();
                //MainWindow object created
                MainWindow mainWindow = new MainWindow();

                //Sql Connection object to open the database    
                connection.Open();
                //Sql statement to select all values in USERS table where the USERNAME and PASSWORD are equal to the user inputs

            //string Log = "SELECT * FROM USERS WHERE USERNAME = 'Admin' AND PASSWORD = '123'";
            string Log = "SELECT * FROM USERS WHERE USERNAME = '" + txtUsername.Text + "' AND PASSWORD = '" + txtPassword.Text + "'";
            //Sql command to store select statement and connection
            command = new SqlCommand(Log, connection);
                //Sql Reader for getting values
                SqlDataReader reader = command.ExecuteReader();

            //If statement to check username and password
            if (reader.Read() == true)
            {
                //Sessions method called
                //Sessions.session = reader.GetValue(0).ToString();
                Wait();
                MessageBox.Show("Login Successful");
                ////If correct open Add_Modules wimndow
                ///
                if (reader.GetValue(1).Equals("Trip"))
                {
                    Trip_Manager trip_Manager = new Trip_Manager();
                    trip_Manager.Show();
                    this.Hide();
                }

                else if (reader.GetValue(1).Equals("Admin"))
                {
                    Office_Manager office_Manager = new Office_Manager();
                    office_Manager.Show();
                    this.Hide();
                }

                else if (reader.GetValue(1).Equals("Service"))
                {
                    Service_Manager service_Manager = new Service_Manager();
                    service_Manager.Show();
                    this.Hide();
                }

                else if (reader.GetValue(1).Equals("Timesheet"))
                {
                    TimeSheet timeSheet = new TimeSheet();
                    timeSheet.Show();
                    this.Hide();
                }

                else if (reader.GetValue(1).Equals("Vehicle"))
                {
                    Vehicle_Admin vehicle_Admin = new Vehicle_Admin();
                    vehicle_Admin.Show();
                    this.Hide();
                }

            }
            //else if (reader.GetValue(0).ToString().Equals("Trip"))
            //{
            //Trip_Manager trip_Manager = new Trip_Manager();
            //trip_Manager.Show();
            //this.Hide();



            else
            {
                //Else statement to diplay error message
                MessageBox.Show("Invalid Username and Password, Try again");
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();

            }
            }
    }
}
