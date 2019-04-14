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
using pdumaresqCardDeck;

namespace pdumaresqCardDeckDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e) {
            Deck deck = new Deck();
            sclViewDeck.Content = "";
            for (int x = 0; x < deck.deck.Length; x++) {
                sclViewDeck.Content += deck.deck[x].ToString() + "\n";
            }
        }

        private void btnShuffled_Click(object sender, RoutedEventArgs e) {
            Deck deck = new Deck();
            deck.shuffle();
            sclShuffled.Content = "";
            for (int x = 0; x < deck.deck.Length; x++) {
                sclShuffled.Content += deck.deck[x].ToString() + "\n";
            }
        }
    }
}
