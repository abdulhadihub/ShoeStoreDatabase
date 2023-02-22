using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for orderManagement.xaml
    /// </summary>
    public partial class orderManagement : Window
    {
        public orderManagement()
        {
            InitializeComponent();
            fillCustomerCB();
            fillEmployeeCB();
            fillProductCB();
            fillColorCB();
            fillSizeCB();
            orderRefresh();
            qtyTB.Text = "0";
        }



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

            // Check if the input is a positive integer
            uint value;
            if (!uint.TryParse(input, out value))
            {
                return false;
            }

            return true;
        }



        string connectionString = conString.connectionString;
        int qty = 0;
        int count = 0;
        int[] products = new int[10];
        int[] colors = new int[10];
        int[] sizes = new int[10];
        int[] quantity = new int[10];
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            qty = 0;
        }

        private void fillProductCB()
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "select * from Products";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object id = dr.GetValue(0);
                    productsCB.Items.Add(id);
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void fillCustomerCB()
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "select * from Customers";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object id = dr.GetValue(0);
                    customerCB.Items.Add(id);
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void fillEmployeeCB()
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "select * from Employees";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object id = dr.GetValue(0);
                    employeeCB.Items.Add(id);
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


        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                String clr = "";
                oidTB.Text = clr;
                customerCB.Text = clr;
                employeeCB.Text = clr;
                odateTB.Text = clr;
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
                bool validate = ValidateID(customerCB.Text) && ValidateID(employeeCB.Text);
                if (validate)
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "insert into Orders values(@CustomerID, @EmployeeID, @OrderDate)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CustomerID", int.Parse(customerCB.Text));
                    cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(employeeCB.Text));
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Parse(odateTB.Text));
                    cmd.ExecuteNonQuery();

                    int oid = 0;
                    query = "select orderID from Orders where orderDate = @OrderDate";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Parse(odateTB.Text));
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        oid = dr.GetInt32(0);
                    }
                    dr.Close();
                    cmd.ExecuteNonQuery();
                    ////
                    for (int i = 0; i < count; i++)
                    {
                        validate = ValidateID(oid.ToString()) && ValidateID(products[i].ToString()) && ValidateID(colors[i].ToString()) && ValidateID(sizes[i].ToString()) && ValidateID(quantity[i].ToString());
                        if (validate)
                        {

                            query = "insert into OrderDetails values(@OrderID, @ProductID, @ColorID, @SizeID, @UnitPrice, @Quantity, @Discount)";
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@OrderID", oid);
                            cmd.Parameters.AddWithValue("@ProductID", products[i]);
                            cmd.Parameters.AddWithValue("@ColorID", colors[i]);
                            cmd.Parameters.AddWithValue("@SizeID", sizes[i]);
                            cmd.Parameters.AddWithValue("@UnitPrice", getUnitPrice(products[i]));
                            cmd.Parameters.AddWithValue("@Quantity", quantity[i]);
                            cmd.Parameters.AddWithValue("@Discount", 0);
                            cmd.ExecuteNonQuery();


                        }
                        else
                        {
                            throw new Exception("invalid inputs");
                        }
                       
                    }
                    con.Close();
                    MessageBox.Show("Successfully Added Order!");
                    orderRefresh();
                    count = 0;

                    ////


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

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validate = ValidateID(customerCB.Text) && ValidateID(employeeCB.Text) &&ValidateID(oidTB.Text);

                if (validate)
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "update Orders set customerID=@CustomerID, employeeID=@EmployeeID, orderDate=@OrderDate where orderID = @OrderID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@OrderID", int.Parse(oidTB.Text));
                    cmd.Parameters.AddWithValue("@CustomerID", int.Parse(customerCB.Text));
                    cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(employeeCB.Text));
                    cmd.Parameters.AddWithValue("@OrderDate", odateTB.Text);
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

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool val = ValidateID(oidTB.Text);
                if (!val)
                {
                    MessageBox.Show("invalid order id");
                    return;

                }
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "delete OrderDetails where OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@OrderID", int.Parse(oidTB.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validate = ValidateID(oidTB.Text);

                if (validate)
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    String query = "select * from Orders where orderID = @OrderID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@OrderID", int.Parse(oidTB.Text));
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        customerCB.Text = (dr.GetValue(1)).ToString();
                        employeeCB.Text = ((int)dr.GetValue(2)).ToString();
                        odateTB.Text = (dr.GetValue(3)).ToString();
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

        private void viewOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ordersView ov = new ordersView();
                ov.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void addProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            
            products[count] = int.Parse(productsCB.Text);
            quantity[count] = int.Parse(qtyTB.Text);

            string query = "select colorID from Colors where colorName = @colorName";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@colorName", colorCB.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                colors[count] = dr.GetInt32(0);
            }
            dr.Close();


            query = "select sizeID from Sizes where sizeName = @sizeNumber";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sizeNumber", int.Parse(sizeCB.Text));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sizes[count] = dr.GetInt32(0);
            }
            dr.Close();
            
            cmd.ExecuteNonQuery();
            con.Close();
            count++;
            MessageBox.Show("Successfully Added Product to Order!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        /*
        private void qtyMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (qty <= 0)
            {
                qty = 0;
                qtyTB.Text = qty.ToString();
            }
            else
            {
                qtyTB.Text = (qty--).ToString();
            }
        }
        */

        /*
        private void qtyPlusBtn_Click(object sender, RoutedEventArgs e)
        {
            int limit = getMaxQuantity(int.Parse(productsCB.Text), getColorID(), getSizeID());
                if (qty >= limit)
                {
                qtyTB.Text = limit.ToString();
                   }
                else
                {
                    qtyTB.Text = (qty++).ToString();
                }
        }
        */

        private int getMaxQuantity(int pid, int cid, int sid)
        {
            int max = 0;
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "select unitInStokes from ProductDetails where productID = @ProductID and colorID = @ColorID and sizeID = @SizeID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", pid);
                cmd.Parameters.AddWithValue("@ColorID", cid);
                cmd.Parameters.AddWithValue("@SizeID", sid);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    max = int.Parse((dr.GetValue(0)).ToString());

                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return max;
        }

            private double getUnitPrice(int pid)
        {
            double price = 0;
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "select unitPriceSALE from Products where productID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", pid);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                  price = double.Parse((dr.GetValue(0)).ToString());
                }
                con.Close();
            }
            catch (Exception err)
            {
                 MessageBox.Show(err.Message);
            }
            return price;
        }

        private int getColorID()
        {
                
            int cid = 0;
            try
            {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select colorID from Colors where colorName = @colorName";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@colorName", colorCB.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cid = dr.GetInt32(0);
            }
            dr.Close();
            con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return cid;
        }

        private int getSizeID()
        {

            int sid = 0;
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "select SizeID from Sizes where sizeName = @sizeNumber";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@sizeNumber", int.Parse(sizeCB.Text));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sid = dr.GetInt32(0);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return sid;
        }
        
        void orderRefresh()
        {
            odateTB.Text = DateTime.Now.ToString();
        }
    }
}
