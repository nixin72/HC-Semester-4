using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkBLL {
    public enum e {
        success = 0,
        //Warnings            
        vaccInvalid = -1,
        vaccUnchecked = -2,

        //Errors
        sBeforeToday = -11,     //
        sAfterEnd = -12,        //
        sYearAfterNow = -13,    //
        e6MonthsAfters = -14,   //

        differentOwner = -20,   //
        petInRes = -22,         //
        petNotInRes = -23,      //

        activeRes = -31,        //

        runUnavailable = -40,   //
        alreadyReserved = -41,  //

        invalidSize = -50,
        invalidPet = -51,       //
        invalidRes = -52,       // 

        insertFail = -60,
        updateFail = -61,
        deleteFail = -62
    }

    class Validation {
        //Warning functions
        public static bool vaccUnchecked( int petNum ) {
            Vaccination vacc = new Vaccination();
            return !vacc.ListVaccinations()
                    .FindAll(v => v.petNumber == petNum)
                    .All(v => v.checkedStatus == true);
        }

        //10-19
        public static bool sBeforeToday( DateTime start ) {
            return start <= DateTime.Now;
        }

        public static bool sAfterEnd( DateTime start, DateTime end ) {
            return start >= end;
        }

        public static bool sYearAfterNow( DateTime start ) {
            return start > DateTime.Now.AddMonths(12);
        }

        public static bool e6MonthsAfters( DateTime start, DateTime end ) {
            return end > start.AddMonths(6);
        }

        //20-29
        public static bool differentOwner( int petNum, int resNum ) {
            List<Pet> pets = Pet.listPetsDir();
            List<PetReservation> petRes = PetReservation.ListPetReservationsDir();
            petRes.RemoveAll(pr => pr.reservationNum != resNum);

            return petRes.Count == 0 ? false : pets.FindAll(p => petRes.Any(pr => 
                    pr.reservationNum == resNum)).All(p =>
                        p.ownerNumber == pets.Find(pp => 
                            pp.number == petNum).ownerNumber);
        }

        public static bool petInRes( int petNum, int resNum ) {
            return PetReservation.ListPetReservationsDir().Any(pr =>
                pr.reservationNum == resNum && pr.petNum == petNum);
        }

        public static bool petNotInRes( int petNum, int resNum ) {
            return !petInRes(petNum, resNum);
        }

        //30-39
        public static bool activeRes( int resNum ) {
            Reservation res = new Reservation();
            return res.ListActiveReservation()
                .Any(r => r.number == resNum);
        }

        //40-49
        public static bool runUnavailable( DateTime start, DateTime end, int petNum ) {
            Reservation res = new Reservation();
            //CHANGE THIS SHIT
            return res.ListAvailableRuns(start, end, Pet.listPetsDir()
                .Find(p => p.number == petNum).size ?? 'R').Count == 0;
        }

        public static bool runUnavailable( int petNum, int resNum ) {
            Reservation res = new Reservation();
            return runUnavailable(res.ListReservations().Find(r => r.number == resNum).sDate,
                res.ListReservations().Find(r => r.number == resNum).eDate, petNum);
        }

        public static bool alreadyReserved( DateTime start, DateTime end, int petNum ) {
            Reservation res = new Reservation();
            //CAAAAAAAAHNNNNNGE THIS SHIIIIIIIIT
            return res.ListReservations().Any(r =>
                r.ownerNumber == Pet.listPetsDir().Find(p =>
                    p.number == petNum).ownerNumber && r.sDate >= start && r.eDate <= end);
        }

        //50-59
        public static bool invalidSize( char size ) {
            size = (size == 'R') ? 'M' : size;
            return (size != 'S' ^ size != 'M' ^ size != 'L');
        }

        public static bool invalidPet( int petNumber ) {
            return !Pet.listPetsDir()
                .Any(p => p.number == petNumber);
        }

        public static bool invalidRes( int resNum ) {
            Reservation res = new Reservation();
            return !res.ListReservations()
                .Any(r => r.number == resNum);
        }
    }
}
