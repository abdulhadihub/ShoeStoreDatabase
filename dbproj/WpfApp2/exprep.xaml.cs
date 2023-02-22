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
    /// Interaction logic for exprep.xaml
    /// </summary>
    public partial class exprep : Page
    {
        public exprep()
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


        private void mexp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!IsValidYear(year.Text))
                {
                    MessageBox.Show("wrong year");
                    return;
                }
                string yearin = year.Text; // get the value from the year textbox
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from getMonthlyExpenses(@year)", con); // modify the SQL query to filter by year
                cmd.Parameters.AddWithValue("@year", yearin); // bind the parameter to the value entered in the textbox
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridexprep.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

    }
}
