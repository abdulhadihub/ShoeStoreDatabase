using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class loginform : Window
    {
        public loginform()
        {
            InitializeComponent();
        }
        String connectionString = "Data Source=DESKTOP-9GQ5JFD\\SQLEXPRESS;Initial Catalog=ShoeStore2;Integrated Security=True";
        
        private void usernameleave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "Enter Name";
            }
        }
        private void passwordfield_Leave(object sender, EventArgs e)
        {
            if (password.Password == "")
            {
                password.Password = "password";
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            String username1, password1;
            username1 = username.Text;
            password1 = password.Password;
            if (username.Text == "" || password.Password == "Enter Name")
            {
                username.Text = "Username field can not be empty";
            }
            else if (password.Password == "" || password.Password == "password")
            {
                password.Password = "password field can not be empty";
            }
            else
            {


                try
                {
                    SqlConnection con = new SqlConnection(connectionString);

                    con.Open();

                    SqlCommand command = new SqlCommand("loginProcedure", con);
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the input parameters
                    command.Parameters.AddWithValue("@Username", username.Text);
                    command.Parameters.AddWithValue("@Password", password.Password);

                    // Add the output parameter
                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@Result";
                    outputParameter.SqlDbType = SqlDbType.Bit;
                    outputParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParameter);


                    


                    command.ExecuteNonQuery();

                    // Get the output value
                    bool result = (bool)outputParameter.Value;
                    
                    

                    if (username1== "abdulhadi" && password1 == "abdulhadi")
                    {
                        
                        ManagerScreen ms = new ManagerScreen();
                        ms.ShowDialog();


                    }
                    

                    else if (username1 == "ayanmalik" && password1 == "ayanmalik")
                    {

                        
                        EmployeeScreen ms = new EmployeeScreen();
                        ms.ShowDialog();
                    }
                    else if (result)
                    {
                        MessageBox.Show("username or password is incorrect");
                    }
                    else
                    {
                        MessageBox.Show("password or username is incorrect!");
                    }
                    this.Close();                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
