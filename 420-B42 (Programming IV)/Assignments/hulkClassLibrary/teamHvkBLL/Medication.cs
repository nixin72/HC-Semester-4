using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamHvkBLL {
    class Medication {
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

        public Medication(int num, String name) {
            this.number = num;
            this.name = name;
            this.dosage = "";
            this.instructions = "";
            this.endDate = new DateTime();
            this.pet_res_num = 0;
        }

        public Medication(int num, String name, String dosage, String instructions, DateTime endDate, int petresnum) {
            this.number = num;
            this.name = name;
            this.dosage = dosage;
            this.instructions = instructions;
            this.endDate = endDate;
            this.pet_res_num = petresnum;
        }

        public int compareTo(Medication med2) {
            if (name == med2.name) {
                return 0;
            }
            else {
                return 0;
            }
        }

        public bool equals(Medication med2) {
            if (name == med2.name && dosage == med2.dosage && endDate == med2.endDate) {
                return true;
            }
            else {
                return false;
            }
        }

        public String toString() {
            //TODO
            return "";
        }
    }
}
