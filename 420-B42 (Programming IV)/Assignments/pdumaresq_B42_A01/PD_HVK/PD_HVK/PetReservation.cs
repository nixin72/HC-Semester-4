using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresq_B42_A01 {
    public class PetReservation {
        public int petResNum { get; set; }
        public int petNum { get; set; }
        public int reservationNum { get; set; }
        public int runNum { get; set; }
        public int PRpetResNum { get; set; }

        //Lists
        public Run run { get; set; }
        public Food food { get; set; }
        public Reservation res { get; set;  }
        public List<Discount> discounts { get; set; }
        public List<Medication> meds { get; set; }
        public List<KennelLog> logs { get; set; }
        public List<Service> services { get; set; }
        
        public PetReservation() {
            this.petResNum = 0;
            this.petNum = 0;
            this.reservationNum = 0;
            this.runNum = 0;
            this.PRpetResNum = 0;
            this.run = new Run();
            this.food = new Food();
            this.res = new Reservation();
            this.discounts = new List<Discount>();
            this.meds = new List<Medication>();
            this.logs = new List<KennelLog>();
            this.services = new List<Service>();
        }

        public PetReservation(int pRn, int pN, int resN) {
            this.petResNum = pRn;
            this.petNum = pN;
            this.reservationNum = resN;
            this.runNum = 0;
            this.PRpetResNum = 0;
            this.run = new Run();
            this.food = new Food();
            this.res = new Reservation();
            this.discounts = new List<Discount>();
            this.meds = new List<Medication>();
            this.logs = new List<KennelLog>();
            this.services = new List<Service>();
        }

        public PetReservation(int pRn, int pN, int resN, int rN, int petResPetResNum) {
            this.petResNum = pRn;
            this.petNum = pN;
            this.reservationNum = resN;
            this.runNum = rN;
            this.PRpetResNum = petResPetResNum;
            this.run = new Run();
            this.food = new Food();
            this.res = new Reservation();
            this.discounts = new List<Discount>();
            this.meds = new List<Medication>();
            this.logs = new List<KennelLog>();
            this.services = new List<Service>();
        }

        public PetReservation(int pRn, int pN, int resN, int rN, int petResPetResNum, 
            Run run, Food food, Reservation res, List<Discount> dis, List<Medication> med, 
            List<KennelLog> log, List<Service> ser) {
            this.petResNum = pRn;
            this.petNum = pN;
            this.reservationNum = resN;
            this.runNum = rN;
            this.PRpetResNum = petResPetResNum;
            this.run = run;
            this.food = food;
            this.res = res;
            this.discounts = dis;
            this.meds = med;
            this.logs = log;
            this.services = ser;
        }
    }
}