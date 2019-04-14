using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresq_B42_A01 {
    public class DailyRate {
        public int number { get; set; }
        public int rate { get; set; }
        public char dogSize { get; set; }
        public int serviceNumber { get; set; }

        public DailyRate() {
            this.number = 0;
            this.rate = 0;
            this.dogSize = 's';
            this.serviceNumber = 0;
        }

        public DailyRate(int num, int rate) {
            this.number = num;
            this.rate = rate;
            this.dogSize = 's';
            this.serviceNumber = 0;
        }

        public DailyRate(int num, int rate, char size, int servNum) {
            this.number = num;
            this.rate = rate;
            this.dogSize = size;
            this.serviceNumber = servNum;
        }

        public int compareTo(DailyRate rate2) {
            if (rate > rate2.rate) {
                return 1;
            }
            else if (rate < rate2.rate) {
                return -1;
            }
            else {
                return 0;
            }
        }

        public override bool Equals(Object rate2) {
            if (rate2.GetType() == typeof(DailyRate)) {
                DailyRate rateTest = (DailyRate)rate2;
                return ((this.dogSize == rateTest.dogSize)
                    && (this.rate == rateTest.rate));
            }
            else
                return false;            
        }

        public String toString() {
            //TODO
            return "";
        }
    }
}