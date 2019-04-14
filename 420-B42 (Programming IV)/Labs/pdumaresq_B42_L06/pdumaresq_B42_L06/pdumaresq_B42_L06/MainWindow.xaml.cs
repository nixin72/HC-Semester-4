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
using System.Windows.Navigation;
using System.Windows.Shapes;
using B42L06BLL;

namespace pdumaresq_B42_L06 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();


        }

        private void button_Click(object sender, RoutedEventArgs e) {
            Employee emp = new Employee();
            List<Employee> list = emp.getEmployeesByDept(textBox.Text);
            this.dgEmployees.ItemsSource = list;
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            Employee emp = new Employee();
            List<Employee> list = emp.getEmployeesByDept(textBox.Text);
            this.dgEmployees.ItemsSource = list;
        }
    }
}
