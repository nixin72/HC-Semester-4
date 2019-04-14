using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace HulkHvkBLL {
    public class Vaccination {
        public int number { get; set; }
        public String name { get; set; }
        public int petNumber { get; set; }
        public bool checkedStatus { get; set; }
        public DateTime expiryDate { get; set; }

        public Vaccination() {
            this.number = 0;
            this.name = "";
            this.petNumber = 0;
            this.checkedStatus = false;
            this.expiryDate = new DateTime();
        }

        public Vaccination( int num, String name ) {
            this.number = num;
            this.name = name;
            this.petNumber = 0;
            this.expiryDate = new DateTime();
            this.checkedStatus = false;
        }

        public Vaccination( int num, String name, int pet, bool status, DateTime expire ) {
            this.number = num;
            this.name = name;
            this.petNumber = pet;
            this.checkedStatus = status;
            this.expiryDate = expire;
        }

        public override String ToString() {
            return "Number: " + number + " | Name: " + name;
        }

        public List<Vaccination> ListVaccinations() {
            VaccinationDB vaccDB = new VaccinationDB();
            DataTable pv = vaccDB.GetFullPetVaccinationInfo();
            DataTable v = vaccDB.GetFullVaccinationInfo();
            return GetVaccinations(pv, v);
        }

        public List<Vaccination> ListBasicVaccinations() {
            VaccinationDB vaccDB = new VaccinationDB();
            DataTable v = vaccDB.GetFullVaccinationInfo();
            return GetBasicVaccinations(v);
        }

        public List<Vaccination> ListVaccinations( int petNumber ) {
            VaccinationDB vaccDB = new VaccinationDB();
            DataTable pv = vaccDB.GetVaccinationInfoForPet(petNumber);
            DataTable v = vaccDB.GetFullVaccinationInfo();
            return GetVaccinations(pv, v);
        }

        private List<Vaccination> GetVaccinations( DataTable data1, DataTable data2 ) {
            List<Vaccination> list = new List<Vaccination>();
            foreach ( DataRow petVacc in data1.Rows ) {
                try {
                    Vaccination vacc = ListBasicVaccinations().Find(v => v.number == Convert.ToInt16(petVacc[1]));
                    list.Add(new Vaccination(vacc.number,               //Vacc number
                                             vacc.name,                 //vacc name
                                             (int)petVacc[2],           //pet number
                                             (string)petVacc[3] == "Y", //checked status
                                             (DateTime)petVacc[0]));    //exp date
                } catch { }
            }

            return data1 != null ? list.OrderBy(v => v.number).ToList() : null;
        }

        private List<Vaccination> GetBasicVaccinations( DataTable data ) {
            List<Vaccination> list = new List<Vaccination>();
            foreach ( DataRow r in data.Rows ) {
                try {
                    list.Add(new Vaccination(
                        (int)r[0], (String)r[1],
                        r.IsNull(1) ? (int)r[2] : -1,
                        r.IsNull(1) ? (String)r[3] == "N" : false,
                        r.IsNull(1) ? DateTime.Parse((string)r[4]) : new DateTime()
                    ));
                } catch { }
            }

            return data != null ? list.OrderBy(v => v.number).ToList() : null;
        }

        public e Insert(DateTime expirationDate, int vaccinationNum, bool vaccinationChecked)
        {
            e errCode = e.success;
            VaccinationDB vaccDB = new VaccinationDB();
            if (vaccDB.Add(expirationDate, vaccinationNum, vaccinationChecked ? 'Y' : 'N') != 0)
            {
                errCode = e.insertFail;
            }

            return errCode;
        }//add vaccination where pet number isnt specified (for a new pet)

        public e Insert(DateTime expirationDate, int vaccinationNum, int petNum, bool vaccinationChecked) {
            e errCode = e.success;
            VaccinationDB vaccDB = new VaccinationDB();

            if (vaccDB.Add(expirationDate, vaccinationNum, petNum, vaccinationChecked ? 'Y' : 'N') != 0) {
                errCode = e.insertFail;
            }

            return errCode;
        }

        public e Update( DateTime expirationDate, int vaccinationNum, int petNum, bool vaccinationChecked ) {
            e errCode = e.success;
            VaccinationDB vaccDB = new VaccinationDB();
            if (vaccDB.Update(expirationDate, vaccinationNum, petNum, vaccinationChecked ? 'Y' : 'N') == false) {
                errCode = e.updateFail;
            }

            return errCode;
        }
        

        public override bool Equals( Object vac ) {
            if ( vac.GetType() == typeof(Vaccination) ) {
                Vaccination vac2 = (Vaccination)vac;
                return (this.number == vac2.number);
            } else
                return false;
        }
    }
}
