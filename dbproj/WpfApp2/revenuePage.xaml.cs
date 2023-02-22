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
    /// Interaction logic for revenuePage.xaml
    /// </summary>
    public partial class revenuePage : Page
    {
        public revenuePage()
        {
            InitializeComponent();
        }

        string connectionString = conString.connectionString;

        private bool IsValidYear(string year)
        {
            // Check if the year is empty or null
            if (string.IsNullOrEmpty(year))
            {
                return false;
            }

            // Check if the year is a 4-digit number
            if (year.Length != 4 || !int.TryParse(year, out int n))
            {
                return false;
            }

            // Check if the year is in the range of 2000 to the current year
            int currentYear = DateTime.Now.Year;
            return n > 2000 && n < currentYear;
        }


        private void searchYear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!IsValidYear(yearTB.Text))
                {
                    MessageBox.Show("invalid year");
                    return;

                }

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from getRevenue(" + int.Parse(yearTB.Text) + ")", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridRevenue.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
    }
}
