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
    /// Interaction logic for profrep.xaml
    /// </summary>
    public partial class profrep : Page
    {
        public profrep()
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




        private void sprod_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string proidd = proid.Text; // get the value from the proid textbox
                if (!IsValidID(proidd))
                {
                    MessageBox.Show("Invalid parameter");
                    return;
                }
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM getProfitBySingleProduct(@proid)", con);
                cmd.Parameters.AddWithValue("@proid", proidd); 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridprep.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void mprod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string proidd = year.Text; // get the value from the proid textbox
                if(!IsValidID(proidd))
                {
                    MessageBox.Show("Invalid parameter");
                    return;
                }
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from getMonthlyProfit(@proid) order by month asc", con); 
                cmd.Parameters.AddWithValue("@proid", proidd); // bind the proid parameter to the value entered in the textbox
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridprep.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        private void annprof_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                
                
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from getProfitByYear()", con);
                 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridprep.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void tprod_Click(object sender, RoutedEventArgs e)
        {

            try
            {



                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from getTotalProfit()", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridprep.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void allprod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select* from getProfitByProduct() order by Total_profit desc", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridprep.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


    }
}
