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

namespace pdumaresq_B42_L05 {
    /// <summary>
    /// Interaction logic for PartB.xaml
    /// </summary>
    public partial class PartB : Window {
        public PartB() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            pdumaresq_B42_L05.dsOwnerPet dsOwnerPet = ((pdumaresq_B42_L05.dsOwnerPet)(this.FindResource("dsOwnerPet")));
            // Load data into the table HVK_OWNER. You can modify this code as needed.
            pdumaresq_B42_L05.dsOwnerPetTableAdapters.HVK_OWNERTableAdapter dsOwnerPetHVK_OWNERTableAdapter = new pdumaresq_B42_L05.dsOwnerPetTableAdapters.HVK_OWNERTableAdapter();
            dsOwnerPetHVK_OWNERTableAdapter.Fill(dsOwnerPet.HVK_OWNER);
            System.Windows.Data.CollectionViewSource hVK_OWNERViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_OWNERViewSource")));
            hVK_OWNERViewSource.View.MoveCurrentToFirst();
            // Load data into the table HVK_PET. You can modify this code as needed.
            pdumaresq_B42_L05.dsOwnerPetTableAdapters.HVK_PETTableAdapter dsOwnerPetHVK_PETTableAdapter = new pdumaresq_B42_L05.dsOwnerPetTableAdapters.HVK_PETTableAdapter();
            dsOwnerPetHVK_PETTableAdapter.Fill(dsOwnerPet.HVK_PET);
            System.Windows.Data.CollectionViewSource hVK_PETViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_PETViewSource")));
            hVK_PETViewSource.View.MoveCurrentToFirst();
        }
    }
}
