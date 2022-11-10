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
    /// Interaction logic for Capture_Vehicle_Trip.xaml
    /// </summary>
    public partial class Capture_Vehicle_Trip : Window
    {
        public Capture_Vehicle_Trip()
        {
            InitializeComponent();
            find_list();
            find_listbox();
        }
        String Veh_Name;

        public void find_list()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=RCBF501PC19\SQLEXPRESS;Initial Catalog=FLEET_IO;Integrated Security=True");
            //Sql Command created to store the qurey and connection
            SqlCommand command = new SqlCommand();

            lbVname.Items.Clear();
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select VEHICLES.MAKE FROM VEHICLES";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lbVname.Items.Add(dr["MAKE"].ToString());
            }
            connection.Close();
        }

        public void find_listbox()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=RCBF501PC19\SQLEXPRESS;Initial Catalog=FLEET_IO;Integrated Security=True");
            //Sql Command created to store the qurey and connection
            SqlCommand command = new SqlCommand();

            lbDbame.Items.Clear();
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select DRIVERS.DRIVER_NAME FROM DRIVERS";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lbDbame.Items.Add(dr["DRIVER_NAME"].ToString());
            }
            connection.Close();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
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
                    string Reg = "INSERT INTO[dbo].[VEHICLE_TRIP]([MAKE],[CITY],[FUEL_USAGE])VALUES('" + Veh_Name + "','" + txtCity.Text + "','" +Convert.ToInt32(txtFuelLitres.Text)+ "')";

                    //Sql command to store insert statement and connection
                    command = new SqlCommand(Reg, connection);
                    //ExecuteNonQuery method to access the database
                    command.ExecuteNonQuery();
                    //Close method to clase the database
                    connection.Close();

                    MessageBox.Show("Vehicle Trip Added Successful");
                }

            }
            //Catch statement to store errors
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Trip_Manager trip_Manager = new Trip_Manager();
            trip_Manager.Show();
            this.Hide();
        }

        private void lbVname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            SqlConnection connection = new SqlConnection(@"Data Source=RCBF501PC19\SQLEXPRESS;Initial Catalog=FLEET_IO;Integrated Security=True");
            //Sql Command created to store the qurey and connection
            SqlCommand command = new SqlCommand();


            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select VEHICLES.MAKE FROM VEHICLES WHERE VEHICLES.MAKE ='" + lbVname.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Veh_Name = dr["MAKE"].ToString();
            }
            connection.Close();
        }

    }
}

