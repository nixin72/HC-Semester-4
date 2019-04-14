using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresq_B42_A01 {
    public class KennelLog {
        public DateTime logDate { get; set; }
        public int seqNum { get; set; }
        public String notes { get; set; }
        public byte video { get; set; }

        public KennelLog() {
            this.logDate = new DateTime();
            this.seqNum = 0;
            this.notes = "";
            this.video = 0;
        }

        public KennelLog(DateTime logDate, int seqNum, String notes) {
            this.logDate = logDate;
            this.seqNum = seqNum;
            this.notes = notes;
            this.video = 0;
        }

        public KennelLog(DateTime logDate, int seqNum, String notes, byte video) {
            this.logDate = logDate;
            this.seqNum = seqNum;
            this.notes = notes;
            this.video = video;
        }

        public int compareTo(KennelLog log2) {
            if (logDate > log2.logDate) {
                return 1;
            }
            else if (logDate > log2.logDate) {
                return -1;
            }
            else {
                return 0;
            }
        }

        public bool equals(KennelLog log2) {
            if (logDate == log2.logDate && seqNum == log2.seqNum) {
                return true;
            }
            else {
                return false;
            }
        }

        /*
            TODO: WRITE A TOSTRING METHOD
         */
    }
}