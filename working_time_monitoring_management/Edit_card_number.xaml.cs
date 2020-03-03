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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void change_card_number(object sender, RoutedEventArgs e)
        {
            string name = name_box_change.Text;
            string surname = surname_box_change.Text;
            int new_card_number = int.Parse(card_number_box_change.Text);
            UpdateDatabase.change_card_number(name, surname, new_card_number);
            MessageBox.Show("Numer karty został zmieniony");
        }
    }
}
