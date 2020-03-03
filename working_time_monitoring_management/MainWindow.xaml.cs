using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

namespace working_time_monitoring_management
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

        private void add_employee(object sender, RoutedEventArgs e)
        {
            Window1 add_employee = new Window1();
            add_employee.Show();
        }

        private void edit_card_number(object sender, RoutedEventArgs e)
        {
            Window2 change_card_number = new Window2();
            change_card_number.Show();
        }

        private void employee_info(object sender, RoutedEventArgs e)
        {
            Window3 employee_info = new Window3();
            employee_info.Show();
        }

        private void test(object sender, RoutedEventArgs e)
        {
            
        }

        private void show_all_employee(object sender, RoutedEventArgs e)
        {
            Window4 show_all = new Window4();
            show_all.Show();
        }
    }
}
