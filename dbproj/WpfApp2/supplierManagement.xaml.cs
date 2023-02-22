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
using System.Runtime.ConstrainedExecution;
using System.Data.SqlTypes;



namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for supplierManagement.xaml
    /// </summary>
    public partial class supplierManagement : Window
    {
        public supplierManagement()
        {
            InitializeComponent();
        }
        string connectionString = conString.connectionString;


        //validation
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

        //validate company name
        public bool ValidateCompanyName(string input)
        {
            // Check if the input is empty
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // Check if the input contains only alphabetic or numeric characters or certain special characters
            if (!input.All(c => char.IsLetterOrDigit(c) || c == ' ' || c == '.' || c == ',' || c == '-'))
            {
                return false;
            }

            return true;
        }


        //validate contact name
        public bool ValidateUserName(string input)
        {
            // Check if the input is empty
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // Check if the input contains only alphabetic characters and spaces
            if (!input.All(c => char.IsLetter(c) || c == ' '))
            {
                return false;
            }

            return true;
        }


        //validate address
        public bool ValidateAddress(string input)
        {
            // Check if the input is empty
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // Check if the input contains only alphabetic or numeric characters, spaces, periods, commas, and hyphens
            if (!input.All(c => char.IsLetterOrDigit(c) || c == ' ' || c == '.' || c == ',' || c == '-'))
            {
                return false;
            }

            return true;
        }
        //validate city name

        public bool ValidateCityName(string input)
        {
            // Check if the input is empty
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // Check if the input contains only alphabetic characters and spaces
            if (!input.All(c => char.IsLetter(c) || c == ' '))
            {
                return false;
            }

            return true;
        }

        //validate phone number
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }
            // Check that the phone number starts with '092'
            if (!phoneNumber.StartsWith("092"))
            {
                return false;
            }

            // Check that the length of the phone number is between 11 and 19
            if (phoneNumber.Length < 11 || phoneNumber.Length > 19)
            {
                return false;
            }

            // Check that the phone number only contains numeric and space characters
            foreach (char c in phoneNumber)
            {
                if (!char.IsNumber(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }

            return true;
        }







        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validate1 = ValidateCompanyName(compname.Text) && ValidateCityName(city.Text) && ValidateAddress(address.Text) && ValidateCityName(country.Text) && IsValidPhoneNumber(phone.Text);
                if (validate1)
                {
                    MessageBox.Show("validated");
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "insert into Suppliers values(@supplierID, @CompanyNAme, @Address, @City,  @Country, @Phone)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@supplierID", supid2.Text);
                    cmd.Parameters.AddWithValue("@CompanyName", compname.Text);

                    cmd.Parameters.AddWithValue("@Address", address.Text);
                    cmd.Parameters.AddWithValue("@City", city.Text);

                    cmd.Parameters.AddWithValue("@Country", country.Text);
                    cmd.Parameters.AddWithValue("@Phone", phone.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Added!");
                    supid2.Text = "";
                    compname.Text = "";
                    address.Text = "";
                    city.Text = "";
                    country.Text = "";
                    phone.Text = "";

                }
                else
                {
                    MessageBox.Show("Invalid inputs");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
        private void load_Click(object sender, RoutedEventArgs e)
        {
            datagridSuppier sec = new datagridSuppier();
            sec.ShowDialog();
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "update Suppliers set  companyName=@CompanyName,  supplierAddress=@Address, city=@City, country=@Country, phone=@Phone where supplierID = @SupplierID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SupplierID", int.Parse(supid2.Text));
                cmd.Parameters.AddWithValue("@CompanyName", compname.Text);

                cmd.Parameters.AddWithValue("@Address", address.Text);
                cmd.Parameters.AddWithValue("@City", city.Text);

                cmd.Parameters.AddWithValue("@Country", country.Text);
                cmd.Parameters.AddWithValue("@Phone", phone.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated!");
                supid2.Text = "";
                compname.Text = "";
                address.Text = "";
                city.Text = "";
                country.Text = "";
                phone.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btndel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "delete Suppliers where supplierID = @SupplierID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SupplierID", int.Parse(supid2.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted!");
                supid2.Text = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                String clr = "";
                supid2.Text = clr;
                compname.Text = clr;

                city.Text = clr;
                address.Text = clr;

                phone.Text = clr;
                country.Text = clr;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
