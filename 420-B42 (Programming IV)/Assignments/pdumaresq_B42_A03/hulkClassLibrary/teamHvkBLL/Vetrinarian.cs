using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace teamHvkBLL {
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

        public Vetrinarian( int num, String name, String phone ) {
            this.number = num;
            this.name = name;
            this.phone = phone;

            this.street = "";
            this.city = "";
            this.province = "";
            this.postal = "";
        }

        public Vetrinarian( int num, String name, String phone, String street, String city, String province, String postal ) {
            this.number = num;
            this.name = name;
            this.phone = phone;
            this.street = street;
            this.city = city;
            this.province = province;
            this.postal = postal;
        }

        public List<Vetrinarian> ListVets() {
            VetrinarianDB vetDb = new VetrinarianDB();
            DataTable data = new dsHvk.HVK_VETERINARIANDataTable();
            return GetVets(data);
        }

        private List<Vetrinarian> GetVets( DataTable data ) {
            List<Vetrinarian> list = new List<Vetrinarian>();
            foreach ( DataRow v in data.Rows ) {
                try {
                    list.Add(new Vetrinarian(
                        v.IsNull("VET_NUMBER") ? (int)v["VET_NUMBER"] : -1,
                        v.IsNull("VET_NAME") ? (string)v["VET_NAME"] : "",
                        v.IsNull("VET_PHONE") ? (string)v["VET_PHONE"] : "",
                        v.IsNull("VET_STREET") ? (string)v["VET_STREET"] : "",
                        v.IsNull("VET_CITY") ? (string)v["VET_CITY"] : "",
                        v.IsNull("VET_PROVINCE") ? (string)v["VET_PROVINCE"] : "",
                        v.IsNull("VET_POSTAL_CODE") ? (string)v["VET_POSTAL_CODE"] : ""));
                } catch { }
            }

            return data != null ? list : null;
        }
    }
}
