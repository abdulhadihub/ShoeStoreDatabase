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
using System.Collections;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for productManagementView1.xaml
    /// </summary>
    public partial class productManagementView1 : Window
    {
        public productManagementView1()
        {
            InitializeComponent();
           // showProducts1();
            //showProductDetails();
            showCategories();
        }

        string connectionString = conString.connectionString;
        private void showProducts_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                String query = "select * from vwproducts";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridProducts.ItemsSource = dt.DefaultView;
                ////
               /* query = "select * from [product details]";
                cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridProductDetails.ItemsSource = dt.DefaultView;*/
                ////
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

      /*  private void showProducts1()
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from products", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridProducts.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }*/

       /* private void showProductDetails()
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from [product details]", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridProductDetails.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }*/

        private void searchProducts_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "select * from vwproducts where productID=@ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("ProductID", int.Parse(productNameTB.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridProducts.ItemsSource = dt.DefaultView;
                ////
               /* query = "select * from [product details] where ProductID=@ProductID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("ProductID", int.Parse(productNameTB.Text));
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridProductDetails.ItemsSource = dt.DefaultView;*/
                ////
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void searchCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Categories where catagoryID=@CategoryID", con);
                cmd.Parameters.AddWithValue("@CategoryID", int.Parse(categoryNameTB.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridCategories.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void showCategories()
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Categories", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridCategories.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
