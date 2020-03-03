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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void add_new_employee(object sender, RoutedEventArgs e)
        {
            string name = name_box.Text;
            string surname = surname_box.Text;
            int card_number = int.Parse(card_number_box.Text);
            AddToDatabase.add(name, surname, card_number);
            MessageBox.Show("Dodano Pracownika");
        }
    }
}
