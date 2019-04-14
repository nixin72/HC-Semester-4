using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresq_B42_A01 {
    public class Vetrinarian {
        public int number { get; set; }
        public String name { get; set; }
        public String phone { get; set; }
        public String street { get; set; }
        public String city { get; set; }
        public String province { get; set; }
        public String postal { get; set; }

        public Vetrinarian() {
            this.number = 0;
            this.name = "";
            this.phone = "";
            this.street = "";
            this.city = "";
            this.province = "";
            this.postal = "";
        }

        public Vetrinarian(int num, String name, String phone) {
            this.number = num;
            this.name = name;
            this.phone = phone;

            this.street = "";
            this.city = "";
            this.province = "";
            this.postal = "";
        }

        public Vetrinarian(int num, String name, String phone, String street, String city, String province, String postal) {
            this.number = num;
            this.name = name;
            this.phone = phone;
            this.street = street;
            this.city = city;
            this.province = province;
            this.postal = postal;
        }

        //TODO : CompateTo, Equals, ToString
    }
}
