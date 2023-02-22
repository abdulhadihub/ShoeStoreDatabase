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
    /// Interaction logic for ManagerScreen.xaml
    /// </summary>
    public partial class ManagerScreen : Window
    {
        public ManagerScreen()
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

        private void employeesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                employeeManagement em = new employeeManagement();
                em.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void suppliersBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                supplierManagement sm = new supplierManagement();
                sm.ShowDialog();
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
        private void viewreport_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                viewreports pm = new viewreports();
                pm.ShowDialog();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
