using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
    /// Interaction logic for expansesManagement.xaml
    /// </summary>
    public partial class expansesManagement : Window
    {
        public expansesManagement()
        {
            InitializeComponent();
            
        }
        string connectionString = conString.connectionString;


        private bool ValidateInteger(string input)
        {
            // Check if the input is empty
            if (string.IsNullOrEmpty(input))
            {

                MessageBox.Show("input ID");
                return false;
            }

            // Check if the input is a valid integer
            if (!int.TryParse(input, out int value))
            {
                MessageBox.Show("input ID");

                return false;
            }

            // Check if the input value is greater than 0
            if (value <= 0)
            {
                MessageBox.Show("input ID");

                return false;
            }

            // Add additional validation checks here, if needed

            return true;
        }

        //validate expense date
        private bool ValidateExpenseDate(string expenseDate)
        {
            // First, check if the input string is empty
            if (string.IsNullOrEmpty(expenseDate))
            {
                MessageBox.Show("Expense date cannot be empty");
                return false;
            }

            // Try to parse the input string as a date
            if (!DateTime.TryParseExact(expenseDate, "dd-mm-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                MessageBox.Show("Invalid expense date format. Please enter a valid date in the format dd-mm-yyyy");
                return false;
            }

            // Check if the date is in the future
            if (date > DateTime.Now)
            {
                MessageBox.Show("Expense date cannot be in the future");
                return false;
            }

            // If all checks pass, the expense date is valid
            return true;
        }



        private bool ValidateExpenseType(string expenseType)
        {
            // First, check if the input string is empty
            if (string.IsNullOrEmpty(expenseType))
            {
                MessageBox.Show("Expense type cannot be empty");
                return false;
            }

            // Check if the input string is longer than 50 characterss
            if (expenseType.Length > 29)
            {
                MessageBox.Show("Expense type cannot be more than 50 characters long");
                return false;
            }

            // Check if the input string contains any invalid characters or potential SQL injection attacks
            if (!Regex.IsMatch(expenseType, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("Expense type can only contain alphanumeric characters and spaces");
                return false;
            }

            // If all checks pass, the expense type is valid
            return true;
        }

        private bool Validatedes(string des)
        {
            // First, check if the input string is empty
            if (string.IsNullOrEmpty(des))
            {
                MessageBox.Show("Description type cannot be empty");
                return false;
            }

            // Check if the input string is longer than 50 characters
            if (des.Length > 29)
            {
                MessageBox.Show("Description type cannot be more than 50 characters long");
                return false;
            }

            // Check if the input string contains any invalid characters or potential SQL injection attacks
            if (!Regex.IsMatch(des, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("Description type can only contain alphanumeric characters and spaces");
                return false;
            }

            // If all checks pass, the expense type is valid
            return true;
        }


        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            // Validate the input fields
            bool isValid = ValidateInteger(empid.Text) && ValidateInteger(amnt.Text);
            isValid = isValid && Validatedes(desc.Text) && ValidateInteger(expid.Text);

            if (!isValid)
            {
                MessageBox.Show("i");
                return;
            }

            try
            {
                // Open a connection to the database
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                // Construct the INSERT INTO statement
                String query = "INSERT INTO Expenses (expenseID,EmployeeID, expenseDate, expenseType, amount, _description) VALUES (@id,@EmployeeID, GETDATE(), @expenseType, @amount, @_description)";
                SqlCommand cmd = new SqlCommand(query, con);

                // Add the parameters to the command
                cmd.Parameters.AddWithValue("@id", int.Parse(expid.Text));
                cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(empid.Text));
                
                cmd.Parameters.AddWithValue("@expenseType", exptype.Text);
                cmd.Parameters.AddWithValue("@amount", int.Parse(amnt.Text));
                cmd.Parameters.AddWithValue("@_description", desc.Text);

                // Execute the INSERT INTO statement
                cmd.ExecuteNonQuery();

                // Close the connection to the database
                con.Close();

                // Show a success message
                MessageBox.Show("Successfully Added!");
            }
            catch (Exception err)
            {
                // Show an error message
                MessageBox.Show(err.Message);
            }
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            datagridexpense sec = new datagridexpense();
            sec.ShowDialog();
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool val = ValidateInteger(empid.Text) && ValidateInteger(amnt.Text) && ValidateInteger(expid.Text);
                val = val && Validatedes(desc.Text);

                if (!val)
                {
                    return;

                }



                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "UPDATE Expenses SET employeeID = @EmployeeID, expenseDate = GETDATE(), expenseType = @expenseType, amount = @amount, _description = @_description WHERE expenseID = @expenseID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@expenseID", int.Parse(expid.Text));
                cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(empid.Text));
                cmd.Parameters.AddWithValue("@expenseType", exptype.Text);
                cmd.Parameters.AddWithValue("@amount", int.Parse(amnt.Text));
                cmd.Parameters.AddWithValue("@_description", desc.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

       /* private void btndel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "delete Expenses where expenseID = @expenseID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@expenseID", int.Parse(expid.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }*/

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                String clr = "";
                expid.Text = clr;
                empid.Text = clr;

                exptype.Text = clr;
                

                desc.Text = clr;
                amnt.Text = clr;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
