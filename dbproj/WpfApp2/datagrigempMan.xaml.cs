using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for datagrigempMan.xaml
    /// </summary>
    public partial class datagrigempMan : Window
    {
        public datagrigempMan()
        {
            InitializeComponent();
           
        }
        string connectionString = conString.connectionString;
        //validate inputs
        public bool ValidateID(string input)
        {
            // Check if the input is empty
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // Check if the input contains only numeric characters
            if (!input.All(char.IsNumber))
            {
                return false;
            }

            // Check if the input is within the range of the int data type
            int value;
            if (!int.TryParse(input, out value) || value < int.MinValue || value > int.MaxValue)
            {
                return false;
            }

            return true;
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateID(empid2.Text))
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Employees where employeeID=@EmployeeID", con);
                    cmd.Parameters.AddWithValue("EmployeeID", int.Parse(empid2.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    datagrid.ItemsSource = dt.DefaultView;
                    con.Close();

                }
                else
                {
                    MessageBox.Show("invalid inputs");
                }


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void load_Click(object sender, RoutedEventArgs e)

        {
            
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Employees", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagrid.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
