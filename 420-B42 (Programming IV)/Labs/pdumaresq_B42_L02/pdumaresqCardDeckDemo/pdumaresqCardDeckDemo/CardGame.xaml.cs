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
using pdumaresqCardDeck;

namespace pdumaresqCardDeckDemo {
    /// <summary>
    /// Interaction logic for CardGame.xaml
    /// </summary>
    public partial class CardGame : Window {
        public CardGame() {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            Deck deck = new Deck();
            deck.shuffle();
            sclP1.Content = "";
            sclP2.Content = "";
            sclMid.Content = "";

            while (deck.cardsLeft() != 0) {
                Card c1 = deck.deal();
                Card c2 = deck.deal();

                if (c1.rank > c2.rank) {
                    sclP1.Content += c1.ToString() + "\n";
                    sclP1.Content += c2.ToString() + "\n\n";
                }
                else if (c1.rank < c2.rank) {
                    sclP2.Content += c1.ToString() + "\n";
                    sclP2.Content += c2.ToString() + "\n\n";
                }
                else {
                    sclMid.Content += c1.ToString() + "\n";
                    sclMid.Content += c2.ToString() + "\n\n";
                }
            }
        }
    }
}
