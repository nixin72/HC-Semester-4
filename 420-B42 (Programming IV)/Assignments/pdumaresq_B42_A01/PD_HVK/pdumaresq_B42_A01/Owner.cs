using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresq_B42_A01 {
    public class Owner {
        public int number { get; set; }
        public String first { get; set; }
        public String last { get; set; }
        public String street { get; set; }
        public String city { get; set; }
        public String province { get; set; }
        public String postal { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String emg_first { get; set; }
        public String emg_last { get; set; }
        public String emg_phone { get; set; }
        public int vet_number { get; set; }

        public List<Pet> pets { get; set; }

        public Owner()
        {
            this.number = 0;
            this.first = "";
            this.last = "";
            this.street = "";
            this.city = "";
            this.province = "";
            this.postal = "";
            this.email = "";
            this.phone = "";
            this.emg_first = "";
            this.emg_last = "";
            this.emg_phone = "";
            this.vet_number = 0;
            this.pets = new List<Pet>();
        }

        public Owner(int num, String first, String last) {
            this.number = num;
            this.first = first;
            this.last = last;
            this.street = "";
            this.city = "";
            this.province = "";
            this.postal = "";
            this.email = "";
            this.phone = "";
            this.emg_first = "";
            this.emg_last = "";
            this.emg_phone = "";
            this.vet_number = 0;
            this.pets = new List<Pet>();
        }

        public Owner(int num, String first, String last, String street, String city, String prov,
            String postal, String email, String phone, String emg_F, String emg_L, String emg_P, int vet)
        {
            this.number = num;
            this.first = first;
            this.last = last;
            this.street = street;
            this.city = city;
            this.province = prov;
            this.postal = postal;
            this.email = email;
            this.phone = phone;
            this.emg_first = emg_F;
            this.emg_last = emg_L;
            this.emg_phone = emg_P;
            this.vet_number = vet;
            this.pets = new List<Pet>();
        }

        public Owner(int num, String first, String last, String street, String city, String prov,
            String postal, String email, String phone, String emg_F, String emg_L, String emg_P, int vet, List<Pet> petList)
        {
            this.number = num;
            this.first = first;
            this.last = last;
            this.street = street;
            this.city = city;
            this.province = prov;
            this.postal = postal;
            this.email = email;
            this.phone = phone;
            this.emg_first = emg_F;
            this.emg_last = emg_L;
            this.emg_phone = emg_P;
            this.vet_number = vet;
            this.pets = petList;
        }

        public int compareTo(Owner own2) {
            return this.ToString().CompareTo(own2.ToString());
        }

        public bool Equals(Owner own2) {
            return this.ToString() == own2.ToString();
        }

        public override String ToString() {
            return first + " " + last;
        }
    }
}
