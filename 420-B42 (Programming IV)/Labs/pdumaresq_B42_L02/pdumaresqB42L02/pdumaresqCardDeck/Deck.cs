using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresqCardDeck {
    public class Deck {
        public Card[] deck { get; }
        int cardsUsed;

        public Deck() {
            deck = new Card[52];
            int curr = 0;
            for (int suit = 0; suit <= 3; suit++) {
                for (int rank = 1; rank <= 13; rank++) {
                    deck[curr] = new Card(suit, rank);
                    curr++;
                }
            }
            cardsUsed = 0;
        }

        public void shuffle() {
            Random rnd = new Random();
            for (int x = deck.Length - 1; x > 0; x--) {
                int rand = rnd.Next(1, x + 1);
                Card temp = deck[x];
                deck[x] = deck[rand];
                deck[rand] = temp;
            }
            cardsUsed = 0;
        }

        public int cardsLeft() {
            return 52 - cardsUsed;
        }

        public Card deal() {
            cardsUsed++;
            return deck[cardsUsed - 1];
        }
    }
}
