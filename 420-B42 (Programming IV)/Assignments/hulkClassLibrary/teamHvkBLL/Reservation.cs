using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamHvkBLL {
    class Reservation {
        public int number { get; set; }
        public DateTime sDate { get; set; }
        public DateTime eDate { get; set; }
        public int ownerNumber { get; set; }

        public Reservation() {
            this.number = 0;
            this.ownerNumber = 0;
            this.sDate = new DateTime();
            this.eDate = new DateTime();
        }

        public Reservation(int num, DateTime sDate, DateTime eDate, int owner) {
            this.number = num;
            this.ownerNumber = owner;
            this.sDate = sDate;
            this.eDate = eDate;
        }

        public override String ToString() {
            return sDate.ToString("MM/dd/yyyy") + " - " + eDate.ToString("MM/dd/yyyy");
        }

        public override bool Equals(Object res) {
            if (res.GetType() == typeof(Reservation)) {
                Reservation res2 = (Reservation)res;
                return ((this.sDate == res2.sDate)
                    && (this.eDate == res2.eDate));
            }
            else
                return false;
        }

        public List<Reservation> ListReservations() {
            return new List<Reservation>();
        }

        public List<Reservation> ListReservations(int ownerNumber) {
            return ListReservations();
        }

        public List<Reservation> ListActiveReservation() {
            return new List<Reservation>();
        }

        public List<Reservation> ListUpcomingReservation(DateTime date) {
            return new List<Reservation>();
        }
    }
}
