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
using System.Windows.Media.Media3D;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for productManagement.xaml
    /// </summary>
    public partial class productManagement : Window
    {
        public productManagement()
        {
            InitializeComponent();
            fillSupplierCB();
            fillCategoryCB();
            fillColorCB();
            fillSizeCB();
        }

        string connectionString = conString.connectionString;


        //for clearing the fiels
        private void clearFuntion()
        {
            try
            {

                String clr = "";
                pidTB.Text = clr;
                pnameTB.Text = clr;
                colorCB.Text = clr;
                sizeCB.Text = clr;
                supplierCB.Text = clr;
                categoryCB.Text = clr;
                unitPriceTB.Text = clr;
                unitStockTB.Text = clr;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        // validation
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
            if (!int.TryParse(input, out value) || value < int.MinValue || value > int.MaxValue || value<1)
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






        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }




        private void fillSupplierCB()
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "select * from Suppliers";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object id = dr.GetValue(0);
                    supplierCB.Items.Add(id);
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void fillCategoryCB()
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "select * from Categories";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object id = dr.GetValue(0);
                    categoryCB.Items.Add(id);
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void fillColorCB()
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "select * from Colors";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object id = dr.GetValue(1);
                    colorCB.Items.Add(id);
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void fillSizeCB()
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "select * from Sizes";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object id = dr.GetValue(1);
                    sizeCB.Items.Add(id);
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validate = ValidateID(unitStockTB.Text) && ValidateUserName(pnameTB.Text) && ValidateID(supplierCB.Text) && ValidateID(categoryCB.Text) && ValidateID(unitPriceTB.Text) && ValidateID(salePrice.Text);
                if (validate)
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "insert into Products values(@productID,@ProductName, @SupplierID, @CatagoryID, @UnitPriceBuy,@unitPriceSale, @discontinued)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@productID", pidTB.Text);
                    cmd.Parameters.AddWithValue("@ProductName", pnameTB.Text);
                    cmd.Parameters.AddWithValue("@SupplierID", int.Parse(supplierCB.Text));
                    cmd.Parameters.AddWithValue("@CatagoryID", int.Parse(categoryCB.Text));
                    cmd.Parameters.AddWithValue("@UnitPriceBuy", Double.Parse(unitPriceTB.Text));
                    cmd.Parameters.AddWithValue("@UnitPriceSale", Double.Parse(salePrice.Text));

                    cmd.Parameters.AddWithValue("@Discontinued", 0);
                    cmd.ExecuteNonQuery();
                    /////
                    int pid = 0;
                    int sid = 0;
                    int cid = 0;

                    query = "select productID from Products where productName = @ProductName";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ProductName", pnameTB.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        pid = dr.GetInt32(0);
                    }
                    dr.Close();

                    query = "select colorID from Colors where colorName = @colorName";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@colorName", colorCB.Text);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cid = dr.GetInt32(0);
                    }
                    dr.Close();


                    query = "select sizeID from sizes where sizeName = @sizeNumber";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@sizeNumber", int.Parse(sizeCB.Text));
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        sid = dr.GetInt32(0);
                    }
                    dr.Close();


                    query = "insert into ProductDetails values(@ProductID, @ColorID, @SizeID, @UnitsInStock)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ProductID", pid);
                    cmd.Parameters.AddWithValue("@ColorID", cid);
                    cmd.Parameters.AddWithValue("@SizeID", sid);
                    cmd.Parameters.AddWithValue("@UnitsInStock", int.Parse(unitStockTB.Text));
                
                    cmd.ExecuteNonQuery();
                    //////
                    con.Close();
                    MessageBox.Show("Successfully Added!");
                    clearFuntion();

                }
                else
                {
                    MessageBox.Show("invalid values");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /*
        private int searchInfo(string reqInfo, string paramInfo, string tableName)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "select " + reqInfo + " from " + tableName + " where " + paramInfo + " = @" + paramInfo;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@" + paramInfo, )

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        */

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validate = ValidateID(pidTB.Text) && ValidateUserName(pnameTB.Text) && ValidateID(supplierCB.Text) && ValidateID(categoryCB.Text) && ValidateID(unitPriceTB.Text);
                if (validate)
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "update products set productName=@ProductName, supplierID=@SupplierID, catagoryID=@CategoryID, unitPriceBuy=@UnitPrice,unitPriceSALE = @unitPriceSale, discontinued=@Discontinued where productID = @ProductID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@unitPriceSale", Double.Parse(salePrice.Text));
                    cmd.Parameters.AddWithValue("@ProductID", int.Parse(pidTB.Text));
                    cmd.Parameters.AddWithValue("@ProductName", pnameTB.Text);
                    cmd.Parameters.AddWithValue("@SupplierID", int.Parse(supplierCB.Text));
                    cmd.Parameters.AddWithValue("@CategoryID", int.Parse(categoryCB.Text));
                    cmd.Parameters.AddWithValue("@UnitPrice", Double.Parse(unitPriceTB.Text));
                    cmd.Parameters.AddWithValue("@Discontinued", 1);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Updated!");
                    clearFuntion();
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

    
        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearFuntion();
            
        }

        

        private void CatclearBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                String clr = "";
                catidTB.Text = clr;
                catnameTB.Text = clr;
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void CataddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validate = ValidateUserName(catnameTB.Text);

                if (validate)
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "insert into Categories values(@catagoryID,@CatagoryName)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@catagoryID", catidTB.Text);
                    cmd.Parameters.AddWithValue("@CatagoryName", catnameTB.Text);
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

        private void CatupdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validate = ValidateUserName(catnameTB.Text) && ValidateID(catidTB.Text);
                if (validate)
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "update Categories set catagoryName=@CategoryName where catagoryID = @CategoryID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CategoryID", int.Parse(catidTB.Text));
                    cmd.Parameters.AddWithValue("@CategoryName", catnameTB.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Updated!");
                    catidTB.Text = "";
                    catnameTB.Text = "";

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

        private void CatsearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validate = ValidateID(catidTB.Text);
                if (validate)
                {
                    
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "select * from Categories where catagoryID = @CategoryID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CategoryID", int.Parse(catidTB.Text));
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        catnameTB.Text = dr.GetString(1);
                    }
                    con.Close();
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

        private void viewPmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                productManagementView1 pmv = new productManagementView1();
                pmv.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        
    }
}


