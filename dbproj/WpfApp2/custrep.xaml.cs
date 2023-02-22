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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for custrep.xaml
    /// </summary>
    public partial class custrep : Page
    {
        public custrep()
        {
            InitializeComponent();
        }
        string connectionString = conString.connectionString;

        private bool IsValidID(string id)
        {
            // Check if the ID is empty or null
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            // Check if the ID is a number
            if (!int.TryParse(id, out int n))
            {
                return false;
            }

            // Check if the ID is positive
            return n > 0;
        }

        private void ViewrepA_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from getCustomersByNumberOfOrders()", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridcusrep.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void ViewrepS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string i = custid.Text;
                if(!IsValidID(i))
                {
                    MessageBox.Show("id is not valid");
                    return;

                }



                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from getSingleCustomer(@i)", con);
                cmd.Parameters.AddWithValue("@i", i);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridcusrep.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }


    }
}
