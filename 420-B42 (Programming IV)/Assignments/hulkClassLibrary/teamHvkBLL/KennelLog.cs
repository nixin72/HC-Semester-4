using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamHvkBLL {
    class KennelLog {
        public DateTime logDate { get; set; }
        public int seqNum { get; set; }
        public String notes { get; set; }
        public byte video { get; set; }

        private List<PetReservation> pr;

        public List<PetReservation> petRes {
            get { return pr; }
            set { pr = value; }
        }

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

        public KennelLog(DateTime logDate, int seqNum, String notes, byte video, List<PetReservation> pR) {
            this.logDate = logDate;
            this.seqNum = seqNum;
            this.notes = notes;
            this.video = video;
            this.petRes = pR;
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
