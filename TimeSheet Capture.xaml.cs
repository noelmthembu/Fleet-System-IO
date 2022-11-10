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
using System.Diagnostics;

namespace Fleet.io_cx_system
{
    /// <summary>
    /// Interaction logic for TimeSheet_Capture.xaml
    /// </summary>
    public partial class TimeSheet_Capture : Window
    {
        public TimeSheet_Capture()
        {
            InitializeComponent();
            find_list();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            TimeSheet timeSheet = new TimeSheet();
            timeSheet.Show();
            this.Hide();
        }

        public void find_list()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=RCBF501PC19\SQLEXPRESS;Initial Catalog=FLEET_IO;Integrated Security=True");
            //Sql Command created to store the qurey and connection
            SqlCommand command = new SqlCommand();

            lbxDriver.Items.Clear();
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
                lbxDriver.Items.Add(dr["DRIVER_NAME"].ToString());
            }
            connection.Close();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Sql Connection created to connect to the database
            SqlConnection connection = new SqlConnection(@"Data Source=RCBF501PC19\SQLEXPRESS;Initial Catalog=FLEET_IO;Integrated Security=True");
            //Sql Command created to store the qurey and connection
            SqlCommand command = new SqlCommand();
            //Object created for Hashing class
            Hashing hashing = new Hashing();
            string output = "";

            SqlDataReader dataReader;

            //Try error handling
            try
            {

                {
                    //Sql Connection object to open the database
                    connection.Open();
                    //Sql statement to insert into the database
                    string Reg = "SELECT DRIVERS.DRIVER_NAME FROM DRIVERS";

                    //Sql command to store insert statement and connection
                    command = new SqlCommand(Reg, connection);

                    //ExecuteNonQuery method to access the database
                    command.ExecuteNonQuery();
                    //Close method to clase the database

                    dataReader = command.ExecuteReader();

                    while (dataReader.Read()) {

                        output = dataReader.GetValue(0).ToString();
                    
                    }

                    output = lbxDriver.ItemsSource.ToString();
                 //   ListBox listBox = new ListBox();
                 //   lbxDriver.Items.Add(Reg);

                    connection.Close();

                   // lvDriver.Items.Add(Reg);

                    MessageBox.Show("Supplier Added Successful");
                }

            }
            //Catch statement to store errors
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
    }
}
