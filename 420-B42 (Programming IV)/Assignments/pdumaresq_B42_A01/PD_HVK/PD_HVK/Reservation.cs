using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresq_B42_A01 {
    public class Reservation {
        public int number { get; set; }
        public DateTime sDate { get; set; }
        public DateTime eDate { get; set; }
        
        public Reservation() {
            this.number = 0;
            this.sDate = new DateTime();
            this.eDate = new DateTime();
        }

        public Reservation(int num, DateTime sDate, DateTime eDate) {
            this.number = 0;
            this.sDate = sDate;
            this.eDate = eDate;
        }

        public override bool Equals(Object res) {
            if (res.GetType() == typeof(Reservation)) {
                Reservation res2 = (Reservation) res;
                return ((this.sDate == res2.sDate)
                    && (this.eDate == res2.eDate));
            }
            else
                return false;
        }
    }
}