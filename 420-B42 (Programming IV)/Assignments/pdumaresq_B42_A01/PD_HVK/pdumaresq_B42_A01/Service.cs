using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresq_B42_A01 {
    public class Service {
        //Service
        public int number { get; set; }
        public String desc { get; set; }

        public int frequency { get; set; }
        public int petResNumber { get; set; }

        public DailyRate rate { get; set; }

        public Service() {
            this.number = 0;
            this.desc = "";
            this.frequency = 0;
            this.petResNumber = 0;
            this.rate = new DailyRate();
        }

        public Service(int num, String desc, int pRNum) {
            this.number = num;
            this.desc = desc;
            this.petResNumber = pRNum;
            this.frequency = 0;
            this.rate = new DailyRate();
        }

        public Service(int num, String desc, int pRNum, int frequency) {
            this.number = num;
            this.desc = desc;
            this.petResNumber = pRNum;
            this.frequency = frequency;
            this.rate = new DailyRate();
        }

        public Service(int num, String desc, int pRNum, int frequency, DailyRate rate) {
            this.number = num;
            this.desc = desc;
            this.petResNumber = pRNum;
            this.frequency = frequency;
            this.rate = rate;
        }

        public bool Equal(Service ser) {
            return this.desc == ser.desc && this.frequency == ser.frequency;
        }

        public int CompareTo(Service ser) {
            return this.desc.CompareTo(ser.desc);
        }
    }
}
