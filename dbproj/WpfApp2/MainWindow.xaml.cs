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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void empScreen_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                EmployeeScreen es = new EmployeeScreen();
                es.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void manScreen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               /* loginform ms = new loginform();
                ms.ShowDialog();*/
               ManagerScreen ms = new ManagerScreen();
                ms.ShowDialog();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        } 
    }
}
