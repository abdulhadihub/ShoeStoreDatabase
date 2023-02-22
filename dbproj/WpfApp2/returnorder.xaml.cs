using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for returnorder.xaml
    /// </summary>
    public partial class returnorder : Window
    {
        public returnorder()
        {
            InitializeComponent();
            
        }

        string connectionString = conString.connectionString;

        //validation
        private bool ValidateInput(string input)
        {
            // Check if the input is empty
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // Check if the input is a valid integer
            if (!int.TryParse(input, out int value))
            {
                return false;
            }

            // Check if the input value is greater than 0
            if (value <= 0)
            {
                return false;
            }

            

            return true;
        }





        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool val = ValidateInput(odid.Text) && ValidateInput(proid.Text) && ValidateInput(sizeid.Text);
                 val = val && ValidateInput(colid.Text) && ValidateInput(retqty.Text);

                if(!val)
                {
                    MessageBox.Show("invalid inputs");
                    return;
                }

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                
               

                SqlCommand command = new SqlCommand("AddReturnOrderDetail", con);
                
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@orderID", int.Parse(odid.Text));
                    command.Parameters.AddWithValue("@productID", int.Parse(proid.Text));
                    command.Parameters.AddWithValue("@sizeID", int.Parse(sizeid.Text));
                    command.Parameters.AddWithValue("@colorID", int.Parse(colid.Text));
                    command.Parameters.AddWithValue("@quantity", int.Parse(retqty.Text));

                    SqlParameter resultParameter = new SqlParameter();
                    resultParameter.ParameterName = "@result";
                    resultParameter.SqlDbType = SqlDbType.Int;
                    resultParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(resultParameter);

                    command.ExecuteNonQuery();
                    con.Close();

                int result = (int)resultParameter.Value;
                    if (result == 1)
                    {
                    MessageBox.Show("Successfully Added!");

                }
                else
                    {
                        MessageBox.Show("Order details are incorrect");
                    }
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
        private void load_Click(object sender, RoutedEventArgs e)
        {
            datagridretod sec = new datagridretod();
            sec.ShowDialog();
            this.Hide();
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool val = ValidateInput(odid.Text) && ValidateInput(proid.Text) && ValidateInput(sizeid.Text);
                val = val && ValidateInput(colid.Text) && ValidateInput(retqty.Text);

                if (!val)
                {
                    MessageBox.Show("invalid inputs");
                    return;
                }

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
        
                SqlCommand command = new SqlCommand("UpdateReturnOrderDetail", con);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@orderID", int.Parse(odid.Text));
                command.Parameters.AddWithValue("@productID", int.Parse(proid.Text));
                command.Parameters.AddWithValue("@sizeID", int.Parse(sizeid.Text));
                command.Parameters.AddWithValue("@colorID", int.Parse(colid.Text));
                command.Parameters.AddWithValue("@quantity", int.Parse(retqty.Text));


                SqlParameter resultParameter = command.Parameters.Add("@result", SqlDbType.Int);
                    resultParameter.Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                con.Close();

                int result = (int)resultParameter.Value;

                    if (result == 1)
                    {
                        MessageBox.Show("Return order updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update return order");
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
                colid.Text = clr;
                sizeid.Text = clr;

                proid.Text = clr;
                odid.Text = clr;

                retqty.Text = clr;
                date.Text = clr;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
