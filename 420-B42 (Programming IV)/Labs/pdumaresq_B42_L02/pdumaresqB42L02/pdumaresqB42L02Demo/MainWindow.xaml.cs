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
using pdumaresqB42L02;

namespace pdumaresqB42L02Demo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnNumbers_Click(object sender, RoutedEventArgs e) {
            Counting count = new Counting();
            String text = txtParam.Text;
            lblResult.Content = count.countNumbers(text);
        }

        private void countNumbersO_Click(object sender, RoutedEventArgs e) {
            Int64 outVar = 0;
            if (Int64.TryParse(txtParam.Text, out outVar)){
                Counting count = new Counting();
                Int64 text = Convert.ToInt64(txtParam.Text);
                lblResult.Content = count.countNumbers(text);
            }
            else {
                lblResult.Content = "Cannot convert String to Int64";
            }
            
        }

        private void CountLetters_Click(object sender, RoutedEventArgs e) {
            Counting count = new Counting();
            String text = txtParam.Text;
            lblResult.Content = count.countLetters(text);
        }
    }
}
