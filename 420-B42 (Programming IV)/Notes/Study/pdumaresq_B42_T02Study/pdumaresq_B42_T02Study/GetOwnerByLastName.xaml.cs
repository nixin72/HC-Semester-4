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
    /// Interaction logic for GetOwnerByLastName.xaml
    /// </summary>
    public partial class GetOwnerByLastName : Window {
        public GetOwnerByLastName() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            //pdumaresq_B42_T02Study.dsOwner dsOwner = ((pdumaresq_B42_T02Study.dsOwner)(this.FindResource("dsOwner")));
            //// Load data into the table HVK_OWNER. You can modify this code as needed.
            //pdumaresq_B42_T02Study.dsOwnerTableAdapters.HVK_OWNERTableAdapter dsOwnerHVK_OWNERTableAdapter = new pdumaresq_B42_T02Study.dsOwnerTableAdapters.HVK_OWNERTableAdapter();
            //dsOwnerHVK_OWNERTableAdapter.Fill(dsOwner.HVK_OWNER);
            //System.Windows.Data.CollectionViewSource hVK_OWNERViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_OWNERViewSource")));
            //hVK_OWNERViewSource.View.MoveCurrentToFirst();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e) {
            pdumaresq_B42_T02Study.dsOwner owner = (dsOwner)(this.FindResource("dsOwner"));
            pdumaresq_B42_T02Study.dsOwnerTableAdapters.HVK_OWNERTableAdapter adapter = new pdumaresq_B42_T02Study.dsOwnerTableAdapters.HVK_OWNERTableAdapter();
            adapter.FillByLastName(owner.HVK_OWNER, txtLast.Text);
            System.Windows.Data.CollectionViewSource owners = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hVK_OWNERViewSource")));
            owners.View.MoveCurrentToFirst();
        }
    }
}
