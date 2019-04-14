using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace teamHvkBLL {
    public class PetReservation {
        public int petResNum { get; set; }
        public int petNum { get; set; }
        public int reservationNum { get; set; }
        public int? runNum { get; set; }
        public int? PRpetResNum { get; set; }
        //Lists
        public Run run { get; set; }
        public Food food { get; set; }
        public Reservation res { get; set; }
        public List<Discount> discounts { get; set; }
        public List<Medication> meds { get; set; }
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
            this.services = new List<Service>();
        }

        public PetReservation( int pRn, int pN, int resN ) {
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
            this.services = new List<Service>();
        }

        public PetReservation( int pRn, int pN, int resN, int? rN = -1, int? petResPetResNum = -1 ) {
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
            this.services = new List<Service>();
        }

        public PetReservation( int pRn, int pN, int resN, int? rN, int? petResPetResNum, Run run,
            Food food, Reservation res, List<Discount> dis, List<Medication> med, List<Service> ser ) {
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
            this.services = ser;
        }

        public List<PetReservation> ListPetReservations() {
            PetReservationDB petResDB = new PetReservationDB();
            DataTable data = petResDB.GetFullPetResInfo();
            return GetPetReservations(data);
        }

        public static List<PetReservation> ListPetReservationsDir() {
            PetReservation pr = new PetReservation();
            return pr.ListPetReservations();
        }

        private List<PetReservation> GetPetReservations( DataTable data ) {
            List<PetReservation> list = new List<PetReservation>();
            foreach ( DataRow r in data.Rows ) {
                try {
                    list.Add(new PetReservation((int)r[0],
                        (int)r[1], (int)r[2],
                        !r.IsNull(3) ? (int)r[3] : -1,
                        !r.IsNull(4) ? (int)r[4] : -1));
                } catch { }
            }
            return (data != null) ? list : null;
        }
        public override bool Equals( Object pr ) {
            if ( pr.GetType() == typeof(PetReservation) ) {
                PetReservation pr2 = (PetReservation)pr;
                return (this.petResNum == pr2.petResNum);
            } else
                return false;
        }
    }
}
