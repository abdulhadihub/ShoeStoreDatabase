using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
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
    /// Interaction logic for customerManagement.xaml
    /// </summary>
    public partial class customerManagement : Window
    {
        public customerManagement()
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
                // static int ID = 3000;
               // static int id = 1400;
                string cname = contname.Text;
                string companyName = custname.Text;
                string cusid = custid.Text;
                string caddress = address.Text;
                string ccity = city.Text;
                string cphone = phone.Text;
                bool validate = ValidateAddress(caddress) && ValidateCityName(ccity) && ValidateUserName(cname) && IsValidPhoneNumber(cphone) && ValidateCompanyName(companyName);
                if (validate)
                {
                    
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "insert into Customers values( @customerID, @ContactName,@CompanyName, @Address, @City,  @Phone)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@customerID", cusid);
                    cmd.Parameters.AddWithValue("@CompanyName", custname.Text);
                    cmd.Parameters.AddWithValue("@ContactName", contname.Text);
                    cmd.Parameters.AddWithValue("@Address", address.Text);
                    cmd.Parameters.AddWithValue("@City", city.Text);

                    cmd.Parameters.AddWithValue("@Phone", phone.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Added!");
                    

                }
                else
                {
                    MessageBox.Show("invalid input");
                }





            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
        private void load_Click(object sender, RoutedEventArgs e)
        {
            datagridcust sec = new datagridcust();
            sec.ShowDialog();
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validate = ValidateAddress(address.Text) && ValidateCityName(city.Text) && ValidateUserName(contname.Text) && IsValidPhoneNumber(phone.Text) && ValidateCompanyName(custname.Text) && ValidateID(custid.Text);

                if (validate)
                {
                    

                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "update Customers set  companyName=@CompanyName, customer_address=@Address, city=@City, contactName=@ContactName,  phone=@Phone where customerID = @CustomerID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CustomerID", custid.Text);
                    cmd.Parameters.AddWithValue("@CompanyName", custname.Text);
                    cmd.Parameters.AddWithValue("@ContactName", contname.Text);
                    cmd.Parameters.AddWithValue("@Address", address.Text);
                    cmd.Parameters.AddWithValue("@City", city.Text);

                    cmd.Parameters.AddWithValue("@Phone", phone.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Updated!");

                }
                else
                {
                    MessageBox.Show("invalid input");
                }

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
                bool validate = ValidateID(custid.Text);
                if (validate)
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "delete Customers where CustomerID = @CustomerID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CustomerID", custid.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Deleted!");
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

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                String clr = "";
                custid.Text = clr;
                custname.Text = clr;
                contname.Text = clr;
                city.Text = clr;
                address.Text = clr;
                phone.Text = clr;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
