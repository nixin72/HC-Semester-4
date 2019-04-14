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
    /// Interaction logic for GetOwnerPet.xaml
    /// </summary>
    public partial class GetOwnerPet : Window {
        public GetOwnerPet() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        private void button_Click(object sender, RoutedEventArgs e) {
            dsPetOwner dsPetOwner = ((dsPetOwner)(this.FindResource("dsOwnerPet")));

            // Load data into the table HVK_OWNER. You can modify this code as needed.
            dsPetOwnerTableAdapters.HVK_OWNERTableAdapter dsPetOwnerHVK_OWNERTableAdapter = new dsPetOwnerTableAdapters.HVK_OWNERTableAdapter();
            dsPetOwnerHVK_OWNERTableAdapter.Fill(dsPetOwner.HVK_OWNER);
            CollectionViewSource hVK_OWNERViewSource = ((CollectionViewSource)(this.FindResource("hVK_OWNERViewSource")));
            hVK_OWNERViewSource.View.MoveCurrentToFirst();
            
            // Load data into the table HVK_PET. You can modify this code as needed.
            dsPetOwnerTableAdapters.HVK_PETTableAdapter dsPetOwnerHVK_PETTableAdapter = new dsPetOwnerTableAdapters.HVK_PETTableAdapter();
            dsPetOwnerHVK_OWNERTableAdapter.FillByLastName(dsPetOwner.HVK_OWNER, textBox.Text);
            CollectionViewSource hVK_OWNERHVK_PETViewSource = ((CollectionViewSource)(this.FindResource("hVK_OWNERHVK_PETViewSource")));
            hVK_OWNERHVK_PETViewSource.View.MoveCurrentToFirst();
        }
    }
}
