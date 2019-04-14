using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresqCardDeck { 
    public class Card {
        public int suit { get; set; }
        public int rank { get; set; }

        public Card() {
            this.suit = 0;
            this.rank = 0;
        }

        public Card(int suit, int rank) {
            this.suit = suit;
            this.rank = rank;
        }

        public String getSuiteAsString() {
            switch (suit) {
                case 0: return "Spades";
                case 1: return "Hearts";
                case 2: return "Diamonds";
                case 3: return "Clubs";
                default: return "Not found";
            }
        }

        public String getRankAsString() {
            switch (rank) {
                case 1: return "Ace";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
                case 10: return "Ten";
                case 11: return "Jack";
                case 12: return "Queen";
                case 13: return "King";
                default: return "Not found";
            }
        }
        public override String ToString() {
            return getRankAsString() + " of " + getSuiteAsString();
        }
    }
}
