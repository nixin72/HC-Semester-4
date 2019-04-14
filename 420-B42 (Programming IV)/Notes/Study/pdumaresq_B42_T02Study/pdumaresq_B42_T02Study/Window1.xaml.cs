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

namespace pdumaresq_B42_T02Study {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            pdumaresq_B42_T02Study.dsPetOwner dsPetOwner = ((pdumaresq_B42_T02Study.dsPetOwner)(this.FindResource("dsPetOwner")));
            // Load data into the table HVK_OWNER. You can modify this code as needed.
            pdumaresq_B42_T02Study.dsPetOwnerTableAdapters.HVK_OWNERTableAdapter dsPetOwnerHVK_OWNERTableAdapter = new pdumaresq_B42_T02Study.dsPetOwnerTableAdapters.HVK_OWNERTableAdapter();
            dsPetOwnerHVK_OWNERTableAdapter.Fill(dsPetOwner.HVK_OWNER);
            System.Windows.Data.CollectionViewSource hVK_OWNERViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_OWNERViewSource")));
            hVK_OWNERViewSource.View.MoveCurrentToFirst();
            // Load data into the table HVK_PET. You can modify this code as needed.
            pdumaresq_B42_T02Study.dsPetOwnerTableAdapters.HVK_PETTableAdapter dsPetOwnerHVK_PETTableAdapter = new pdumaresq_B42_T02Study.dsPetOwnerTableAdapters.HVK_PETTableAdapter();
            dsPetOwnerHVK_PETTableAdapter.Fill(dsPetOwner.HVK_PET);
            System.Windows.Data.CollectionViewSource hVK_PETViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_PETViewSource")));
            hVK_PETViewSource.View.MoveCurrentToFirst();
        }
    }
}
