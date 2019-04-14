using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresq_B42_A01 {
    public class Vaccination {
        public int number { get; set; }
        public String name { get; set; }

        //Add tests
        public DateTime expiryDate { get; set; }

        public Vaccination() {
            number = 0;
            name = "";
            this.expiryDate = new DateTime();
        }

        public Vaccination(int num, String name) {
            this.number = num;
            this.name = name;
            this.expiryDate = new DateTime();
        }

        public Vaccination(int num, String name, DateTime expire)
        {
            this.number = num;
            this.name = name;
            this.expiryDate = expire;
        }

        //TODO CompareTo
    }
}
