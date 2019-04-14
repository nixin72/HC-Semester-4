using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace HulkHvkBLL {

    public class Reservation {
        public int number { get; set; }
        public DateTime sDate { get; set; }
        public DateTime eDate { get; set; }
        public int? ownerNumber { get; set; }

        public Reservation() {
            this.number = 0;
            this.ownerNumber = null;
            this.sDate = new DateTime();
            this.eDate = new DateTime();
        }

        public Reservation( int num, DateTime sDate, DateTime eDate ) {
            this.number = num;
            this.ownerNumber = null;
            this.sDate = sDate;
            this.eDate = eDate;
        }

        public Reservation( int num, DateTime sDate, DateTime eDate, int owner ) {
            this.number = num;
            this.sDate = sDate;
            this.eDate = eDate;
            this.ownerNumber = owner;
        }

        public int getOwner() {
            List<Pet> findPet = Pet.listPetsDir();
            List<PetReservation> findPetRes = PetReservation.ListPetReservationsDir();
            int owner;
            if (ownerNumber == null) {
                owner = Pet.listPetsDir().Find(p =>
                    p.number == findPetRes.Find(pr =>
                        pr.reservationNum == this.number).petNum).ownerNumber;
            }
            else {
                owner = -1;
            }

            return owner;
        }

        public List<Reservation> ListReservations() {
            ReservationDB resDB = new ReservationDB();
            DataTable data = resDB.GetReservationWithOwnerNumbers();
            return GetReservations(data);
        }

        private List<Reservation> GetReservations( DataTable data ) {
            List<Reservation> list = new List<Reservation>();

            foreach ( DataRow x in data.Rows ) {
                try {
                    Reservation temp = new Reservation();
                    temp.number = (int)x[0];
                    temp.sDate = (DateTime)x[1];
                    temp.eDate = (DateTime)x[2];
                    temp.ownerNumber = x[3] != DBNull.Value ? (int)x[3] : -1;
                    list.Add(temp);
                } catch { }
            }

            return data != null ? list : null;
        }

        public List<Reservation> ListReservations( int ownerNumber ) {
            return ListReservations().FindAll(r => r.ownerNumber == ownerNumber);
        }

        public List<Reservation> ListActiveReservation() {
            return ListReservations().FindAll(r => (r.sDate < DateTime.Now) && (r.eDate > DateTime.Now));
        }

        public List<Reservation> ListActiveReservation( int ownerNumber ) {
            return ListActiveReservation().FindAll(r => r.ownerNumber == ownerNumber);
        }

        public List<Reservation> ListUpcomingReservation( DateTime date ) {
            return ListReservations().FindAll(r => r.sDate > date);
        }

        public List<Run> ListAvailableRuns( DateTime startDate, DateTime endDate, char runSize ) {
            Run run = new Run();
            List<Run> allRuns = run.ListRuns().Where(r => runSize == 'L' ? r.size == 'L' : true).ToList();
            List<Run> runsAvailable = allRuns;

            Reservation allRes = new Reservation();
            //All reservations overlapping on a timeline
            /*
                         Start --------------------------------------- End
                    s-------------e        s---------------e    s----------------e 
                    s < start e > start    s > start e < end    s < end e > end
                    s------------------------------------------------------------e  
                                           s < start e > end
             */
            List<Reservation> resInRange = allRes.ListReservations().Where(r =>
                       (r.sDate <= startDate && r.eDate >= startDate)
                    || (r.sDate >= startDate && r.eDate <= endDate)
                    || (r.sDate <= endDate && r.eDate >= endDate)
                    || (r.sDate <= startDate && r.eDate >= endDate)).ToList();
            List<PetReservation> allPetRes = PetReservation.ListPetReservationsDir().Where(pr =>
                resInRange.Any(r => r.number == pr.reservationNum)).ToList();
            List<Pet> allPets = Pet.listPetsDir();

            Func<List<Run>, List<PetReservation>, List<Run>> FindAssignedRuns = ( runs, petRes ) => {
                List<Run> retVal = runs.FindAll(r =>
                    (petRes.Any(pr => (pr.runNum != -1) ? pr.runNum == r.number : false)
                        && ((runSize == 'L') ? r.size == 'L' : r.size != '~')));
                return retVal;
            };

            Func<List<Run>, List<PetReservation>, List<Pet>, List<Run>> FindUnavailableUnbookedRuns = ( runs, petRes, pets ) => {
                List<Run> pseudoAssign = new List<Run>();
                List<Run> unassigned = runs;
                foreach ( PetReservation pr in petRes ) {
                    if ( unassigned.Count > 0 ) {
                        Pet pp = pets.Find(p => p.number == pr.petNum);
                        Run rr = unassigned[0];
                        if ( pp.size == 'L' ) {
                            rr = unassigned.Find(r => r.size == 'L');
                            if ( rr == null ) {
                                pseudoAssign.AddRange(unassigned);
                                break;
                            }
                        } else {
                            rr = unassigned.Find(r => r.size == 'R');
                            if ( rr == null )
                                rr = unassigned[0];
                        }

                        if ( rr != null ) {
                            pseudoAssign.Add(rr);
                            unassigned.Remove(rr);
                        } else {

                        }
                    } else {
                        break;
                    }
                }
                return pseudoAssign;
            };

            List<Run> runToRemove1 = FindAssignedRuns(allRuns, allPetRes.FindAll(pr => pr.runNum != -1));
            runsAvailable.RemoveAll(r => runToRemove1.Any(rr => rr.number == r.number));

            List<PetReservation> unassigned2 = allPetRes.FindAll(rr => rr.runNum == -1);
            List<Run> runToRemove2 = FindUnavailableUnbookedRuns(runsAvailable, unassigned2, allPets);
            runsAvailable.RemoveAll(r => runToRemove2.Any(rr => rr.number == r.number));

            return runsAvailable;
        }

        public List<Vaccination> ListExpOrMissVaccs( int petNumber, DateTime byDate ) {
            Vaccination vac = new Vaccination();
            List<Vaccination> list = vac.ListVaccinations(petNumber);
            List<Vaccination> vaccs = new List<Vaccination>();
            List<Vaccination> totalList = vac.ListBasicVaccinations();

            foreach ( Vaccination v in list ) {
                if ( v.expiryDate <= byDate )
                    vaccs.Add(v);
                Vaccination vacc = totalList.Find(vv =>
                    vv.number == v.number);
                totalList.Remove(vacc);
            }

            vaccs.AddRange(totalList);
            return vaccs;
        }



        //resCancaled
        //Makes a reservation for a dog alone in a run
        public List<int> AddReservation( int petNumber, DateTime startDate, DateTime endDate ) {
            e errCode = e.success;
            int resNumber = -1;
            List<int> retVals = new List<int>();
            if ( Validation.sBeforeToday(startDate) )
                errCode = e.sBeforeToday;
            else if ( Validation.sAfterEnd(startDate, endDate) )
                errCode = e.sAfterEnd;
            else if ( Validation.invalidPet(petNumber) )
                errCode = e.invalidPet;
            else if ( Validation.runUnavailable(startDate, endDate, petNumber) )
                errCode = e.runUnavailable;
            else if ( Validation.alreadyReserved(startDate, endDate, petNumber) )
                errCode = e.alreadyReserved;
            else {
                ReservationDB resDB = new ReservationDB();
                resNumber = resDB.Add(startDate, endDate);

                if ( resNumber < 0 )
                    errCode = e.insertFail;
                else {
                    if ( AddToReservation(resNumber, petNumber) < -10 ) {
                        errCode = e.insertFail;
                    }
                    else {
                        if ( ListExpOrMissVaccs(petNumber, endDate).Count != 0 ) {
                            errCode = e.vaccInvalid;
                        }
                    }
                }
            }
            retVals.Add(Convert.ToInt16(errCode));
            retVals.Add(resNumber);
            
            return retVals;
        }

        //Adds a new dog to an existing reservation
        public int AddToReservation( int reservationNumber, int petNumber ) {
            e errCode = e.success;

            if ( Validation.invalidRes(reservationNumber) )
                errCode = e.invalidRes;
            else if ( Validation.invalidPet(petNumber) )
                errCode = e.invalidPet;
            else if ( Validation.differentOwner(petNumber, reservationNumber) )
                errCode = e.differentOwner;
            else if ( Validation.petInRes(petNumber, reservationNumber) )
                errCode = e.petInRes;
            else if ( Validation.runUnavailable(petNumber, reservationNumber) )
                errCode = e.runUnavailable;
            else {
                PetReservationDB resDB = new PetReservationDB();
                if ( resDB.Add(petNumber, reservationNumber) < 0 )
                    errCode = e.insertFail;
                else {
                    if ( CheckVaccinations(petNumber, ListReservations().Find(r => r.number == reservationNumber).eDate) != 0 ) {
                        errCode = e.vaccInvalid;
                    }
                }
            }

            return Convert.ToInt16(errCode);
        }

        //Cancels a reservation
        public int CancelReservation( int reservationNumber ) {
            e errCode = e.success;

            if ( Validation.invalidRes(reservationNumber) )
                errCode = e.invalidRes;
            if ( Validation.activeRes(reservationNumber) )
                errCode = e.activeRes;
            else {
                ReservationDB resDB = new ReservationDB();
                PetReservation pr = new PetReservation();
                Discount d = new Discount();
                d.removeDiscount(reservationNumber);
                pr.RemoveEntireRes(reservationNumber);                
                if ( !resDB.Delete(reservationNumber) )
                    errCode = e.deleteFail;
            }

            return Convert.ToInt16(errCode);
        }

        //Changes the start or end date of a reservation
        public int ChangeReservation( int reservationNumber, DateTime startDate, DateTime endDate ) {
            e errCode = e.success;

            if ( Validation.invalidRes(reservationNumber) )
                errCode = e.invalidRes;
            else if ( Validation.activeRes(reservationNumber) )
                errCode = e.activeRes;
            else if ( Validation.sBeforeToday(startDate) )
                errCode = e.sBeforeToday;
            else if ( Validation.sAfterEnd(startDate, endDate) )
                errCode = e.sAfterEnd;
            else {
                ReservationDB resDB = new ReservationDB();
                if ( !resDB.Update(reservationNumber, startDate, endDate) )
                    errCode = e.updateFail;
            }

            return Convert.ToInt16(errCode);
        }

        //Deletes one dog and all the related services for that dog from a reservation. 
        //If there is only one dog in the reservation, the reservation is cancelled.
        public int DeleteDogFromReservation( int reservationNumber, int petNumber ) {
            e errCode = e.success;
            if ( Validation.invalidRes(reservationNumber) )
                errCode = e.invalidRes;
            else if ( Validation.invalidPet(petNumber) )
                errCode = e.invalidPet;
            else if ( Validation.petNotInRes(petNumber, reservationNumber) )
                errCode = e.petNotInRes;
            else {
                PetReservation petRes = new PetReservation();
                Service serv = new Service();
                foreach (PetReservation pr in petRes.ListPetReservations().Where(pr => pr.reservationNum == reservationNumber)) {
                    serv.Delete(pr.petResNum);
                }
                petRes.RemovePetFromRes(petNumber, reservationNumber);
            }
            return Convert.ToInt16(errCode);
        }

        //Ensures that the vaccinations for a dog will all be completed and up-to-date on a specified date
        public int CheckVaccinations( int petNumber, DateTime byDate ) {
            e errCode = e.success;

            if ( Validation.invalidPet(petNumber) )
                errCode = e.invalidPet;
            else if ( Validation.sBeforeToday(byDate) )
                errCode = e.sBeforeToday;
            else {
                if ( ListExpOrMissVaccs(petNumber, byDate).Count > 0 )
                    errCode = e.vaccInvalid;
                else if ( Validation.vaccUnchecked(petNumber) )
                    errCode = e.vaccUnchecked;
            }

            return Convert.ToInt16(errCode);
        }

        //Returns true if one or more runs of a given size are available during a given time period and false otherwise
        public int CheckRunAvailability( DateTime startDate, DateTime endDate, char runSize ) {
            e errCode = e.success;
            if ( Validation.sAfterEnd(startDate, endDate) )
                errCode = e.sAfterEnd;
            else if ( Validation.invalidSize(runSize) )
                errCode = e.invalidSize;
            else {
                if ( ListAvailableRuns(startDate, endDate, runSize).Count == 0 )
                    errCode = e.runUnavailable;
            }
            return Convert.ToInt16(errCode);
        }

        public override bool Equals( Object res ) {
            if ( res.GetType() == typeof(Reservation) ) {
                Reservation res2 = (Reservation)res;
                return (this.number == res2.number);
            } else
                return false;
        }
    }
}
