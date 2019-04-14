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

namespace pdumaresq_B42_L01
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            cbxGuestCost.Items.Add("$20 (Cold Buffet)");
            cbxGuestCost.Items.Add("$30 (Hot Buffet)");
            cbxGuestCost.Items.Add("$40 (One couse meal)");
            cbxGuestCost.Items.Add("$60 (Three course meal)");
            cbxGuestCost.Items.Add("$100 (six course meal)");

            cbxGuestCost.SelectedIndex = 0;
        }

        private Decimal FinalCost(int guests, int gCost, bool openBar, bool music) {
            return barCost(guests, openBar) + entCost(music) + foodCost(guests, gCost);
        }

        private Decimal barCost(int guests, bool openBar) {
            return (openBar) ? guests * 30 : 0;
        }

        private Decimal entCost(bool music) {
            return (music) ? 500 : 0;
        }

        private Decimal foodCost(int guests, int gCost) {
            return guests * gCost;
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e) {
            int guests = Convert.ToInt16(txtGuests.Text);
            String costTemp = Convert.ToString(cbxGuestCost.SelectedValue);
            costTemp = costTemp.Substring(1, costTemp.IndexOf("(")-1);
            int gCost = Convert.ToInt16(costTemp);
            Boolean openBar = chbOpenBar.IsChecked.Value;
            Boolean ent = chbDJ.IsChecked.Value || chbLive.IsChecked.Value;

            Decimal cost = FinalCost(guests, gCost, openBar, ent);

            lblBarR.Content = (chbOpenBar.IsChecked.Value) ? "Yes" : "No";
            lblBarCostR.Content = barCost(guests, openBar).ToString("C2");
            lblEntCostR.Content = entCost(ent).ToString("C2") ;
            lblTotalR1.Content = foodCost(guests, gCost).ToString("C2");
            lblGuestsR.Content = guests;
            lblGCostR.Content = gCost;
            if (chbLive.IsChecked.Value && chbDJ.IsChecked.Value) lblEntTypeR.Content = "Mixed";
            else if (chbDJ.IsChecked.Value) lblEntTypeR.Content = "DJ";
            else if (chbLive.IsChecked.Value) lblEntTypeR.Content = "Live";
            else lblEntTypeR.Content = "None";
            lblTotalCostR.Content = FinalCost(guests, gCost, openBar, ent).ToString("C2");
            lblFinalCost.Content = cost.ToString("C2");
        }
    }
}
