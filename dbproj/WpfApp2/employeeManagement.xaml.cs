using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for employeeManagement.xaml
    /// </summary>
    public partial class employeeManagement : Window
    {
        public employeeManagement()
        {
            InitializeComponent();
            
        }
        string connectionString = conString.connectionString;

        public bool IsValidBirthDate(string dateOfBirth)
        {
            // Get the current date and time
            DateTime now = DateTime.Now;


            if (DateTime.TryParse(dateOfBirth, out DateTime date))
            {

                int age = now.Year - date.Year;
                if (now.Month < date.Month || (now.Month == date.Month && now.Day < date.Day))
                {
                    age--;
                }


                return age >= 18;
            }
            else
            {

                return false;
            }
        }

        public static bool IsValidHireDate(string hireDate)
        {
            // Check if the hire date string is empty
            if (string.IsNullOrEmpty(hireDate))
            {
                return false;
            }

            // Check if the hire date string has more than 10 characters (dd/mm/yyyy)
            if (hireDate.Length > 10)
            {
                return false;
            }

            // Get the current date and time
            DateTime now = DateTime.Now;

            // Try to parse the hire date string into a DateTime object
            if (DateTime.TryParse(hireDate, out DateTime date))
            {
                // Check if the hire date is in the future
                if (date > now)
                {
                    return false;
                }

                // If the hire date is in the past, it is considered valid
                return true;
            }
            else
            {
                // Hire date string could not be parsed into a DateTime object
                return false;
            }
        }


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
        public bool IsValidEmail(string email)
        {
            // Define a regex pattern for a valid email address
            string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" +
                             "@" +
                             @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

            // Check if the email string matches the regex pattern
            return Regex.IsMatch(email, pattern);
        }

        public bool IsValidUserName(string userName)
        {
            // Check if the user name string has a length greater than 3
            return userName.Length > 3;
        }

        public bool IsValidPassword(string password)
        {
            // Define the rules for a strong password:
            // - At least 8 characters long
            // - Contains at least one lowercase letter
            // - Contains at least one uppercase letter
            // - Contains at least one digit
            // - Contains at least one special character
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

            // Check if the password string matches the regex pattern
            return Regex.IsMatch(password, pattern);
        }


        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //for salary and position
                string input =pos.Text ;

                // Split the input string by the "/" character
                string[] parts = input.Split('/');

                // The parts array will now contain two elements:
               

                string position = parts[0];
                string salary = parts[1];

                bool validate = ValidateID(empid2.Text) && ValidateCityName(lname.Text) && ValidateCityName(fname.Text);
                validate = validate && IsValidPhoneNumber(Phone.Text) && IsValidHireDate(hiredate.Text) && IsValidBirthDate(birthdate.Text);
                validate = validate && ValidateAddress(address.Text) && ValidateCityName(city.Text) && ValidateCityName(country.Text);
                validate = validate && IsValidEmail(email.Text) && ValidateCityName(position) && ValidateID(salary);
                validate = validate && IsValidUserName(username.Text) && IsValidPassword(password.Text);

                if (validate)
                {
                    SqlConnection con = new SqlConnection(connectionString);

                    con.Open();
                    String query = "insert into Employees values(@emid, @fname, @lname, @gender,@dob, @emAddress, @city, @country, @phone, @email,@pos, @salary, @hiredate, @username, HASHBYTES('SHA2_256', @password) )";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@emid", empid2.Text);
                    cmd.Parameters.AddWithValue("@lname", lname.Text);
                    cmd.Parameters.AddWithValue("@fname", fname.Text);
                    cmd.Parameters.AddWithValue("@phone", Phone.Text);

                    cmd.Parameters.AddWithValue("@gender", "M");
                    cmd.Parameters.AddWithValue("@emAddress", address.Text);
                    cmd.Parameters.AddWithValue("@city", city.Text);
                    cmd.Parameters.AddWithValue("@country", country.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@pos", position);
                    cmd.Parameters.AddWithValue("@salary", salary);

                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", password.Text + Phone.Text);

                    cmd.Parameters.AddWithValue("@hiredate", DateTime.Parse(hiredate.Text));
                    cmd.Parameters.AddWithValue("@dob", DateTime.Parse(birthdate.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Added!");

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
            datagrigempMan emp = new datagrigempMan();
            emp.ShowDialog();
           
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = pos.Text;

                // Split the input string by the "/" character
                string[] parts = input.Split('/');

                // The parts array will now contain two elements:


                string position = parts[0];
                string salary = parts[1];

                //perform validation

                bool validate = ValidateID(empid2.Text) && ValidateCityName(lname.Text) && ValidateCityName(fname.Text);
                validate = validate && IsValidPhoneNumber(Phone.Text) && IsValidHireDate(hiredate.Text) && IsValidBirthDate(birthdate.Text);
                validate = validate && ValidateAddress(address.Text) && ValidateCityName(city.Text) && ValidateCityName(country.Text);
                validate = validate && IsValidEmail(email.Text) && ValidateCityName(position) && ValidateID(salary);
                validate = validate && IsValidUserName(username.Text) && IsValidPassword(password.Text);

                if(validate)
                {

                    SqlConnection con = new SqlConnection(connectionString);

                    con.Open();
                    String query = "UPDATE Employees SET fname = @fname, lname = @lname, phone = @phone, gender = @gender, emAddress = @emAddress, city = @city, country = @country, email = @email, pos = @pos, salary = @salary, hiredate = @hiredate, username = @username, password = HASHBYTES('SHA2_256', @password), dob = @dob WHERE emid = @emid";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@emid", empid2.Text);
                    cmd.Parameters.AddWithValue("@lname", lname.Text);
                    cmd.Parameters.AddWithValue("@fname", fname.Text);
                    cmd.Parameters.AddWithValue("@phone", Phone.Text);

                    cmd.Parameters.AddWithValue("@gender", "Male");
                    cmd.Parameters.AddWithValue("@emAddress", address.Text);
                    cmd.Parameters.AddWithValue("@city", city.Text);
                    cmd.Parameters.AddWithValue("@country", country.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@pos", position);
                    cmd.Parameters.AddWithValue("@salary", salary);

                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", password.Text);

                    cmd.Parameters.AddWithValue("@hiredate", DateTime.Parse(hiredate.Text));
                    cmd.Parameters.AddWithValue("@dob", DateTime.Parse(birthdate.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Updated!");

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

        /*
         private void btndel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "delete Employees where EmployeeID = @EmployeeID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(empid2.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
        */

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                String clr = "";
                
                lname.Text = clr;
                fname.Text = clr;
                birthdate.Text = clr;
                hiredate.Text = clr;
                Phone.Text = clr;



            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

       
       

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
