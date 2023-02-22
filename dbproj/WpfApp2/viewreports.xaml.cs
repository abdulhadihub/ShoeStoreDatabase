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
    /// Interaction logic for viewreports.xaml
    /// </summary>
    public partial class viewreports : Window
    {
        public viewreports()
        {
            InitializeComponent();
        }

        private void exprep_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new exprep();
        }

        private void salesrep_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new salesrep();
        }

        private void profrep_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new profrep();
        }

        private void employeesBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new emprep();
        }

        private void customersBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new custrep();

        }

        private void revrep_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new revenuePage();   
        }

        private void priceHistory_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new viewPriceHistory();
        }
    }
}
