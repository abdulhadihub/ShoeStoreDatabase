using System;
using System.Collections.Generic;
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
    /// Interaction logic for EmployeeScreen.xaml
    /// </summary>
    public partial class EmployeeScreen : Window
    {
        public EmployeeScreen()
        {
            InitializeComponent();
        }
        private void PmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                productManagement pm = new productManagement();
                pm.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void ordersBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                orderManagement om = new orderManagement();
                om.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void customersBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                customerManagement cm = new customerManagement();
                cm.ShowDialog();
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

        private void viewcus_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                customerview ov = new customerview();
                ov.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void viewodret_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                returnorder pm = new returnorder();
                pm.ShowDialog();
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void viewexpense_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                expansesManagement pm = new expansesManagement();
                pm.ShowDialog();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
