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
    /// Interaction logic for Capture_Vehicle_Service.xaml
    /// </summary>
    public partial class Capture_Vehicle_Service : Window
    {
        public Capture_Vehicle_Service()
        {
            InitializeComponent();
            //find_list();
            find_listbox();
        }

        //public void find_list()
        //{
        //    SqlConnection connection = new SqlConnection(@"Data Source=RCBF501PC19\SQLEXPRESS;Initial Catalog=FLEET_IO;Integrated Security=True");
        //    //Sql Command created to store the qurey and connection
        //    SqlCommand command = new SqlCommand();

        //    lbxType.Items.Clear();
        //    connection.Open();
        //    SqlCommand cmd = connection.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "Select VEHICLE_SERVICES.ServiceType FROM VEHICLE_SERVICES";
        //    cmd.ExecuteNonQuery();
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        lbxType.Items.Add(dr["ServiceType"].ToString());
        //    }
        //    connection.Close();
        //}

        public void find_listbox()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=RCBF501PC19\SQLEXPRESS;Initial Catalog=FLEET_IO;Integrated Security=True");
            //Sql Command created to store the qurey and connection
            SqlCommand command = new SqlCommand();

            lbxVehicle.Items.Clear();
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
                lbxVehicle.Items.Add(dr["MAKE"].ToString());
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
                    string Reg = "INSERT INTO[dbo].[VEHICLE_SERVICES]([ServiceDate],[Mileage],[ServiceType],[MechanicName],[Warrantly],[LaborCost],[WorkedHours])VALUES('" + dtDate.ToString() + "','" + Convert.ToInt32(txtMileage.Text) + "','" +cbType.Text+ "','" + txtMechanic.Text + "','" +Convert.ToInt32(txtWarranty.Text) + "','" +Convert.ToInt32(txtLaborCost.Text) + "','"+Convert.ToInt32(txtWorkedHrs.Text)+"')";

                    //Sql command to store insert statement and connection
                    command = new SqlCommand(Reg, connection);
                    //ExecuteNonQuery method to access the database
                    command.ExecuteNonQuery();
                    //Close method to clase the database
                    connection.Close();

                    MessageBox.Show("Supplier Added Successful");
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
            Service_Manager service_Manager = new Service_Manager();
            service_Manager.Show();
            this.Hide();
        }

        private void lv_ServiceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
