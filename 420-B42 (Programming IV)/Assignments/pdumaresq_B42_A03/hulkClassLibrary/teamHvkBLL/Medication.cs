using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace teamHvkBLL {
    public class Medication {
        public int number { get; set; }
        public String name { get; set; }
        public String dosage { get; set; }
        public String instructions { get; set; }
        public DateTime endDate { get; set; }
        public int pet_res_num { get; set; }

        public Medication() {
            this.number = 0;
            this.name = "";
            this.dosage = "";
            this.instructions = "";
            this.endDate = new DateTime();
            this.pet_res_num = 0;
        }

        public Medication( int num, String name ) {
            this.number = num;
            this.name = name;
            this.dosage = "";
            this.instructions = "";
            this.endDate = new DateTime();
            this.pet_res_num = 0;
        }

        public Medication( int num, String name, String dosage, String instructions, DateTime endDate, int petresnum ) {
            this.number = num;
            this.name = name;
            this.dosage = dosage;
            this.instructions = instructions;
            this.endDate = endDate;
            this.pet_res_num = petresnum;
        }

        public int compareTo( Medication med2 ) {
            if ( name == med2.name ) {
                return 0;
            } else {
                return 0;
            }
        }

        public bool equals( Medication med2 ) {
            if ( name == med2.name && dosage == med2.dosage && endDate == med2.endDate ) {
                return true;
            } else {
                return false;
            }
        }

        public String toString() {
            //TODO
            return "";
        }

        public List<Medication> ListMedications() {
            MedicationDB medDB = new MedicationDB();
            DataTable data = medDB.GetFullMedicationInfo();
            return GetMedications(data);
        }

        private List<Medication> GetMedications( DataTable data ) {
            List<Medication> list = new List<Medication>();
            foreach ( DataRow r in data.Rows ) {
                try {
                    list.Add(new Medication(
                        (int)r["MEDICATION_NUMBER"],
                        (string)r["MEDICATION_NAME"],
                        r.IsNull("MEDICATION_DOSAGE") ? (string)r["MEDICATION_DOSAGE"] : "",
                        r.IsNull("MEDICATION_SPECIAL_INSTRUCT") ? (string)r["MEDICATION_SPECIAL_INSTRUCT"] : "",
                        r.IsNull("MEDICATION_END_DATE") ? DateTime.Parse((string)r["MEDICATION_END_DATE"]) : new DateTime(),
                        (int)r["PR_PET_RES_NUMBER"]
                    ));
                } catch { }
            };

            return data != null ? list : null;
        }
    }
}
