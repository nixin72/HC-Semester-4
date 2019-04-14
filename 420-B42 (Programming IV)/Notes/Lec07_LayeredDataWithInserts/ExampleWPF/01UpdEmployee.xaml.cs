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

namespace ExampleWPF
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee(Convert.ToInt32(txtEmpNum.Text), 
                                        txtLName.Text, 
                                        txtFName.Text, 
                                        Convert.ToInt32(txtSalary.Text), 
                                        Convert.ToInt32(txtCommission.Text));
            emp.updateEmployee();
            Console.Write("Done");
        }
    }
}
