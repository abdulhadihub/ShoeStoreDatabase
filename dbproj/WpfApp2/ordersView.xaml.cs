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
    /// Interaction logic for ordersView.xaml
    /// </summary>
    public partial class ordersView : Window
    {
        public ordersView()
        {
            InitializeComponent();
            showOrders1();
           /* showOrdersDetails();*/
        }
        
        string connectionString = conString.connectionString;

      /*  private void showOrdersDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "SELECT * FROM [order details]";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridOrdersDetails.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }*/
        private void showOrders_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                string query = "select * from vworders";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridOrders.ItemsSource = dt.DefaultView;

                ////
             /*   query = "select * from [order details]";
                cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridOrdersDetails.ItemsSource = dt.DefaultView;*/
                ////

                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void showOrders1()
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from vworders", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridOrders.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void searchOrders_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "select * from vworders where OrderID=@OrderID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("OrderID", int.Parse(orderIDTB.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridOrders.ItemsSource = dt.DefaultView;
                
                ////
              /*  query = "select * from [order details] where OrderID=@OrderID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("OrderID", int.Parse(orderIDTB.Text));
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridOrdersDetails.ItemsSource = dt.DefaultView;*/
                ////

                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
