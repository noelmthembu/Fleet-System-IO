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
using System.Data;

namespace Fleet.io_cx_system
{
    /// <summary>
    /// Interaction logic for Trip_Manager.xaml
    /// </summary>
    public partial class Trip_Manager : Window
    {
        public Trip_Manager()
        {
            InitializeComponent();
        }

       

        private void btnDailySer_Click(object sender, RoutedEventArgs e)
        {
            //Sql Connection created to connect to the database
            SqlConnection connection = new SqlConnection(@"Data Source=RCBF501PC19\SQLEXPRESS;Initial Catalog=FLEET_IO;Integrated Security=True");
            //Sql Command created to store the qurey and connection
            SqlCommand command = new SqlCommand();

            //Try error handling
            try
            {
                //Sql Connection object to open the database
                connection.Open();
                //Sql statement to check for foriegn key
                string query = "SELECT * FROM VEHICLE_TRIP";
                //Sql command to store insert statement and connection
                command = new SqlCommand(query, connection);
                //ExecuteNonQuery method to access the database
                command.ExecuteNonQuery();

                //Sql Adapter for storing command
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                //Database table name
                DataTable dataTable = new DataTable("VEHICLE_TRIP");
                //Using adapter to access table values
                adapter.Fill(dataTable);

                //Using Datagrid to insert
                dbGrid.ItemsSource = dataTable.DefaultView;
                //Using adapter to update table
                adapter.Update(dataTable);
                //Close database
                connection.Close();

            }
            //Catch statement to store errors
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnCapVehSerSch_Click_1(object sender, RoutedEventArgs e)
        {
            Capture_Vehicle_Trip capture_Vehicle_Trip = new Capture_Vehicle_Trip();
            capture_Vehicle_Trip.Show();
            this.Hide();
        }
    }
}
