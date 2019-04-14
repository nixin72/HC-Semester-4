using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pdumaresq_B42_L07 {
    [Serializable]
    public class ThePerson {
        public String name { get; set; }
        public String phone { get; set; }
        public String city { get; set; }

        public ThePerson() {
            name = "";
            phone = "";
            city = "";
        }

        public ThePerson(String name, String phone, String city) {
            this.name = name;
            this.phone = phone;
            this.city = city;
        }
    }
}