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
using ExampleBLL;

namespace Lec06_LayeredDataSources
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

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> myList = emp.getCustomerInfo();
            Console.WriteLine("Here I am");
            this.dgEmployees.ItemsSource = myList;
        }

        private void btnSalary_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            int total = emp.getTotalSalary();
            lblTotal.Content = String.Format("{0:C}", total);
        }
    }
}
