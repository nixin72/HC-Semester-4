using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamHvkBLL {
    class Vaccination {
        public int number { get; set; }
        public String name { get; set; }

        public int petNumber { get; set; }

        public bool checkedStatus { get; set; }

        //Add tests
        public DateTime expiryDate { get; set; }

        public Vaccination() {
            this.number = 0;
            this.name = "";
            this.petNumber = 0;
            this.checkedStatus = false;
            this.expiryDate = new DateTime();
        }

        public Vaccination(int num, String name) {
            this.number = num;
            this.name = name;
            this.petNumber = 0;
            this.expiryDate = new DateTime();
            this.checkedStatus = false;
        }

        public Vaccination(int num, String name, int pet, bool status, DateTime expire) {
            this.number = num;
            this.name = name;
            this.petNumber = pet;
            this.checkedStatus = status;
            this.expiryDate = expire;
        }

        //TODO CompareTo

        public List<Vaccination> ListVaccinations(int petNumber) {
            return new List<Vaccination>();
        }
    }
}
