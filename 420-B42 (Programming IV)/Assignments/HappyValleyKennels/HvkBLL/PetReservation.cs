using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace HulkHvkBLL {
    public class PetReservation {
        public int petResNum { get; set; }
        public int petNum { get; set; }
        public int reservationNum { get; set; }
        public int? runNum { get; set; }
        //Lists
        public Run run { get; set; }
        public Reservation res { get; set; }
        public List<Discount> discounts { get; set; }
        public List<Service> services { get; set; }

        public PetReservation() {
            this.petResNum = 0;
            this.petNum = 0;
            this.reservationNum = 0;
            this.runNum = 0;
            this.run = new Run();
            this.res = new Reservation();
            this.discounts = new List<Discount>();
            this.services = new List<Service>();
        }

        public PetReservation( int pRn, int pN, int resN ) {
            this.petResNum = pRn;
            this.petNum = pN;
            this.reservationNum = resN;
            this.runNum = 0;
            this.run = new Run();
            this.res = new Reservation();
            this.discounts = new List<Discount>();
            this.services = new List<Service>();
        }

        public PetReservation( int pRn, int pN, int resN, int? rN = -1 ) {
            this.petResNum = pRn;
            this.petNum = pN;
            this.reservationNum = resN;
            this.runNum = rN;
            this.run = new Run();
            this.res = new Reservation();
            this.discounts = new List<Discount>();
            this.services = new List<Service>();
        }

        public PetReservation( int pRn, int pN, int resN, int? rN,
            Run run, Reservation res, List<Discount> dis, List<Service> ser ) {
            this.petResNum = pRn;
            this.petNum = pN;
            this.reservationNum = resN;
            this.runNum = rN;
            this.run = run;
            this.res = res;
            this.discounts = dis;
            this.services = ser;
        }

        public List<PetReservation> ListPetReservations() {
            PetReservationDB prDB = new PetReservationDB();
            DataTable data = prDB.GetFullPetResInfo();
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
                        !r.IsNull(3) ? (int)r[3] : -1
                    ));
                } catch { }
            }
            return (data != null) ? list : null;
        } 

        public List<int> Add(int petNumber, int reservationNumber) {
            e errCode = e.success;

            int petResNum = -1;
            List<int> retVals = new List<int>();

            PetReservationDB prDB = new PetReservationDB();
            petResNum = prDB.Add(petNumber, reservationNumber);
            if (petResNum < 0) {
                errCode = e.insertFail;
            }

            retVals.Add(Convert.ToInt16(errCode));
            retVals.Add(petResNum);

            return retVals;
        }

        public e Update(int petResNumber, int petNumber, int reservationNumber) {
            e errCode = e.success;
            PetReservationDB prDB = new PetReservationDB();
            if ( !prDB.Update(petResNumber, petNumber, reservationNumber) ) {
                errCode = e.updateFail;
            }     
            return errCode;
        }

        public e RemovePetFromRes(int petNumber, int resNumber) {
            e errCode = e.success;
            PetReservationDB prDB = new PetReservationDB();
            Service ser = new Service();
            ser.Delete(ListPetReservations().Find(pr => pr.petNum == petNumber && pr.reservationNum == resNumber).petResNum);
            if (!prDB.RemovePetFromRes(petNumber, resNumber)) {
                errCode = e.deleteFail;
            }
            return errCode;
        }

        public e RemoveEntireRes(int resNumber) {
            e errCode = e.success;
            PetReservationDB prDB = new PetReservationDB();
            Service serv = new Service();
            foreach (PetReservation pr in ListPetReservations().Where(r => r.reservationNum == resNumber)) {
                if ( serv.Delete(pr.petResNum) < 0 ) {
                    errCode = e.deleteFail;                   
                }
            }

            if ( !prDB.RemoveEntireRes(resNumber) ) {
                errCode = e.deleteFail;
            }

            return errCode;
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
