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

namespace working_time_monitoring_management
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void employee_info_show(object sender, RoutedEventArgs e)
        {
            int card_number = int.Parse(card_number_info.Text);
            ShowEmployee.show(card_number);
            name_info.Content = ShowEmployee.name_;
            surname_info.Content = ShowEmployee.surname_;
        }
    }
}
