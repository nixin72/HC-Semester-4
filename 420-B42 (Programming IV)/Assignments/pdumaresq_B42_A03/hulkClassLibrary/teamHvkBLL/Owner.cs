using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace teamHvkBLL {
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

        private List<Reservation> res;
        public List<Reservation> reservations {
            get { return res; }
            set { res = value; }
        }

        public Owner() {
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
            this.reservations = new List<Reservation>();
        }

        public Owner( int num, String first, String last ) {
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
            this.reservations = new List<Reservation>();
        }

        public Owner( int num, String first, String last, String street, String city, String prov,
            String postal, String email, String phone, String emg_F, String emg_L, String emg_P, int vet ) {
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
            this.reservations = new List<Reservation>();
        }

        public Owner( int num, String first, String last, String street, String city, String prov, String postal, String email,
            String phone, String emg_F, String emg_L, String emg_P, int vet, List<Pet> petList, List<Reservation> res ) {
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
            this.reservations = res;
        }

        public List<Owner> ListOwners() {
            OwnerDB ownDB = new OwnerDB();
            DataTable data = ownDB.GetFullOwnerInfo();
            return GetOwners(data).OrderBy(o => o.last).ToList();
        }

        private List<Owner> GetOwners( DataTable data ) {
            List<Owner> list = new List<Owner>();
            foreach ( DataRow row in data.Rows ) {
                try {
                    list.Add(new Owner((int)row["OWNER_NUMBER"],
                        (string)row["OWNER_FIRST_NAME"],
                        (string)row["OWNER_LAST_NAME"],
                        row["OWNER_STREET"] != DBNull.Value ? (string)row["OWNER_STREET"] : "",
                        row["OWNER_CITY"] != DBNull.Value ? (string)row["OWNER_CITY"] : "",
                        row["OWNER_PROVINCE"] != DBNull.Value ? (string)row["OWNER_PROVINCE"] : "",
                        row["OWNER_POSTAL_CODE"] != DBNull.Value ? (string)row["OWNER_POSTAL_CODE"] : "",
                        row["OWNER_EMAIL"] != DBNull.Value ? (string)row["OWNER_EMAIL"] : "",
                        row["OWNER_PHONE"] != DBNull.Value ? (string)row["OWNER_PHONE"] : "",
                        row["EMERGENCY_CONTACT_FIRST_NAME"] != DBNull.Value ? (string)row["EMERGENCY_CONTACT_FIRST_NAME"] : "",
                        row["EMERGENCY_CONTACT_LAST_NAME"] != DBNull.Value ? (string)row["EMERGENCY_CONTACT_LAST_NAME"] : "",
                        row["EMERGENCY_CONTACT_PHONE"] != DBNull.Value ? (string)row["EMERGENCY_CONTACT_PHONE"] : "",
                        row["VET_VET_NUMBER"] != DBNull.Value ? (int)row["VET_VET_NUMBER"] : -1
                    ));
                } catch { }
            }

            return data != null ? list : null;
        }

        public int compareTo( Owner own2 ) {
            return this.ToString().CompareTo(own2.ToString());
        }

        public bool Equals( Owner own2 ) {
            return this.ToString() == own2.ToString();
        }

        public override String ToString() {
            return first + " " + last;
        }
    }
}
