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

namespace pdumaresq_B42_L01 { 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void Lab_1_Loaded(object sender, RoutedEventArgs e) {
            for (int k = 50; k <= 500; k+=50) {
                cbxInvestment.Items.Add(k);
            }
            cbxInvestment.SelectedIndex = 0;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) {
            cbxInvestment.SelectedIndex = 0;
            txtInterest.Text = "";
            txtYears.Text = "";
        }

        private Decimal FutureValue(int months, Decimal interestRate, Decimal monthlyInvestment) {
            Decimal calcValue = 0;
            for (int x = 1; x <= months; x++) {
                calcValue = (calcValue + monthlyInvestment) * (1 + interestRate);
            }
            return calcValue;
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e) {
            int months = Convert.ToInt16(txtYears.Text) * 12;
            Decimal interest = Convert.ToDecimal(txtInterest.Text) / 12 / 100;
            Decimal monthly = Convert.ToDecimal(cbxInvestment.SelectedValue);

            lblResult.Content = FutureValue(months, interest, monthly).ToString("C");
        }
    }
}
