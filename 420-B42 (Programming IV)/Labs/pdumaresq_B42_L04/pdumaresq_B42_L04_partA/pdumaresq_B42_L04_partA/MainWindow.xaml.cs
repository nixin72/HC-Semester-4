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

namespace pdumaresq_B42_L04_partA {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        
        private void mitm1_Click(object sender, RoutedEventArgs e) {
            if (mitm1.IsChecked)
                grdOne.Visibility = Visibility.Visible;
            else 
                grdOne.Visibility = Visibility.Hidden;
        }

        private void mitm2_Click(object sender, RoutedEventArgs e) {
            if (mitm2.IsChecked)
                grdTwo.Visibility = Visibility.Visible;
            else
                grdTwo.Visibility = Visibility.Hidden;
        }

        private void mitm3_Click(object sender, RoutedEventArgs e) {
            if (mitm3.IsChecked)
                grdThree.Visibility = Visibility.Visible;
            else
                grdThree.Visibility = Visibility.Hidden;
        }
    }
}
