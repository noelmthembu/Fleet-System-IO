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
    /// Interaction logic for Supplier.xaml
    /// </summary>
    public partial class Supplier : Window
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Office_Manager office_Manager = new Office_Manager();
            office_Manager.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Sql Connection created to connect to the database
            SqlConnection connection = new SqlConnection(@"Data Source=RCBF501PC19\SQLEXPRESS;Initial Catalog=FLEET_IO;Integrated Security=True");
            //Sql Command created to store the qurey and connection
            SqlCommand command = new SqlCommand();
            //Object created for Hashing class
            Hashing hashing = new Hashing();

            //Try error handling
            try
            {

                {
                    //Sql Connection object to open the database
                    connection.Open();
                    //Sql statement to insert into the database
                    string Reg = "INSERT INTO[dbo].[SUPPLIER]([SUPPLIER_NAME],[QUANTITY],[PRODUCT],[PRICE])VALUES('" + txtSupplierName.Text + "','" + txtQuantity.Text + "','" + txtProduct.Text + "','" + Convert.ToInt32(txtSupplierPrice.Text) + "')";
                                 
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

        
    }
    
}
