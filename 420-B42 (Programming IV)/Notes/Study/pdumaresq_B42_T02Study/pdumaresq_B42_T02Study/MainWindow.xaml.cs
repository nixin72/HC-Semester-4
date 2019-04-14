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

namespace pdumaresq_B42_T02Study {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            pdumaresq_B42_T02Study.dsOwner dsOwner = ((pdumaresq_B42_T02Study.dsOwner)(this.FindResource("dsOwner")));
            // Load data into the table HVK_OWNER. You can modify this code as needed.
            pdumaresq_B42_T02Study.dsOwnerTableAdapters.HVK_OWNERTableAdapter dsOwnerHVK_OWNERTableAdapter = new pdumaresq_B42_T02Study.dsOwnerTableAdapters.HVK_OWNERTableAdapter();
            dsOwnerHVK_OWNERTableAdapter.Fill(dsOwner.HVK_OWNER);
            System.Windows.Data.CollectionViewSource hVK_OWNERViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_OWNERViewSource")));
            hVK_OWNERViewSource.View.MoveCurrentToFirst();
        }
    }
}
