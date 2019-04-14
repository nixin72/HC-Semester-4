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

namespace pdB42Test2
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

        private void redClick(object sender, RoutedEventArgs e)
        {
            green.IsChecked = false;
            blue.IsChecked = false;

            if (red.IsChecked)
                this.Background = Brushes.Red;
            else
                this.Background = Brushes.White;
        }

        private void greenClick(object sender, RoutedEventArgs e)
        {
            red.IsChecked = false;
            blue.IsChecked = false;

            if (green.IsChecked)
                this.Background = Brushes.Green;
            else
                this.Background = Brushes.White;
        }

        private void blueClick(object sender, RoutedEventArgs e)
        {
            red.IsChecked = false;
            green.IsChecked = false;

            if (blue.IsChecked)
                this.Background = Brushes.Blue;
            else
                this.Background = Brushes.White;
        }
    }
}
