using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B42A04_BusinessRules
{
    public class ControlMethods
    {
        //Makes a reservation for a dog alone in a run
        public int addReservation(int petNumber, DateTime startDate, DateTime endDate) {
            return 0;
        }

        //Makes a reservation for two dogs sharing a run
        public int addReservation(int petNumber1, int petNumber2, DateTime startDate, DateTime endDate) {
            return 0;
        }

        //Adds a new dog to an existing reservation
        public int addToReservation(int reservationNumber, int petNumber) {
            return 0;
        }

        //Adds two dogs sharing to an existing reservation. 
        //If one of the dogs is already included in the reservation, the other dog will share with it.
        public int addToReservation(int reservationNumber, int petNumber1, int petNumber2) {
            return 0;
        }

        //Cancels a reservation
        public int cancelReservation(int reservationNumber) {
            return 0;
        }

        //Changes the start or end date of a reservation
        public int changeReservation(int reservationNumber, DateTime startDate, DateTime endDate) {
            return 0;
        }

        //Changes two dogs in the same reservation who were not sharing to sharing
        public int changeToSharing(int reservationNumber, int petNumber1, int petNumber2) {
            return 0;
        }

        //Changes two dogs who were sharing to have separate runs
        public int changeToSolo(int reservationNumber, int petNumber1, int petNumber2) {
            return 0;
        }

        //Deletes one dog and all the related services for that dog from a reservation. 
        //If there is only one dog in the reservation, the reservation is cancelled.
        public int deleteDogFromReservation(int reservationNumber, int petNumber) {
            return 0;
        }

        //Ensures that the vaccinations for a dog will all be completed and up-to-date on a specified date
        public int checkVaccinations(int petNumber, DateTime byDate) {
            return 0;
        }

        //Returns true if one or more runs of a given size are available during a given time period and false otherwise
        public bool checkRunAvailability(DateTime startDate, DateTime endDate, char runSize) {
            return true;
        }
    }
}
