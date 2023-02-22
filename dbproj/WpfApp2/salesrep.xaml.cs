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
    /// Interaction logic for salesrep.xaml
    /// </summary>
    public partial class salesrep : Page
    {
        public salesrep()
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

        //validate date
        // Validate start and end dates that are passed as strings
        public bool ValidateDates(DateTime startDate, DateTime endDate)
        {
            // Check if start date is null
            if (startDate == null)
            {
                
                return false;
            }
            // Check if end date is null
            if (endDate == null)
            {
                
                return false;
            }

            // Check if start date is after end date
            if (startDate > endDate)
            {
                
                return false;
            }
            // Check if start date or end date is in the future
            if (startDate > DateTime.Now || endDate > DateTime.Now)
            {
                
                return false;
            }
         

            // Return true if start and end dates are valid
            return true;
        }

        public bool ValidateMonth(string month)
        {
            // Check if month string is empty
            if (string.IsNullOrEmpty(month))
            {
                
                return false;
            }

            // Check if month string can be parsed to an integer
            int monthInt;
            if (!int.TryParse(month, out monthInt))
            {
                
                return false;
            }

           
            if (monthInt < 1 || monthInt > 12)
            {
                
                return false;
            }

            
            return true;
        }

        public bool ValidateYear(string year)
        {
           
            if (string.IsNullOrEmpty(year))
            {
           
                return false;
            }

            
            int yearInt;
            if (!int.TryParse(year, out yearInt))
            {
                
                return false;
            }

            // Check if year integer is in the future
            if (yearInt > DateTime.Now.Year)
            {
                
                return false;
            }
            if (yearInt < 2000)
            {
                return false;
            }

           

           
            return true;
        }








        private void sprod_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string proidd = proid.Text; 
                if (!IsValidID(proidd))
                {
                    MessageBox.Show("Invalid parameter");
                    return;
                }
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select dbo.getTotalSalesForProduct(@proid) as [Total Sale]", con);
                cmd.Parameters.AddWithValue("@proid", proidd);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridsrep.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dprod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (startdate.SelectedDate.HasValue && enddate.SelectedDate.HasValue)
                {
                    DateTime Startdate = startdate.SelectedDate.Value;
                    DateTime Enddate = enddate.SelectedDate.Value;
                    if(!ValidateDates(Startdate, Enddate))
                    {
                        MessageBox.Show("invalid dates");
                        return;

                    }
                   
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM getTotalSalesBetweenDates(@st, @end)", con);
                    cmd.Parameters.AddWithValue("@st", Startdate.ToString("u"));
                    cmd.Parameters.AddWithValue("@end", Enddate.ToString("u"));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    datagridsrep.ItemsSource = dt.DefaultView;
                    con.Close();

                }
                else
                {
                    MessageBox.Show("invalid dates");

                }

               
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
                string y = year.Text.Trim();
                string m = month.Text.Trim();

                if(!(ValidateMonth(m) && ValidateYear(y))) {
                    MessageBox.Show("invalid year or month");
                    return;
                }

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM getTotalSales(@m,@y)", con);
                cmd.Parameters.AddWithValue("@m", int.Parse(m));
                cmd.Parameters.AddWithValue("@y", int.Parse(y));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridsrep.ItemsSource = dt.DefaultView;
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM getTotalSalesAllProducts() ORDER BY totalSales desc", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridsrep.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
