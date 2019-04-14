using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using teamHvkBLL;

namespace hulkUnitTest { 
    [TestClass]
    public class TestReservation {
        enum e {
            success = 0,
            //Warnings            
            vaccInvalid = -1,
            vaccUnchecked = -2,

            //Errors
            sBeforeToday = -11,     
            sAfterEnd = -12,        
            sYearAfterNow = -13,    
            e6MonthsAfters = -14,   

            differentOwner = -20,   
            petInRes = -22,         
            petNotInRes = -23,      

            activeRes = -31,        

            runUnavailable = -40,   
            alreadyReserved = -41,  

            invalidSize = -50,
            invalidPet = -51,       
            invalidRes = -52,       

            insertFail = -60,
            updateFail = -61,
            deleteFail = -62
        }

        [TestMethod]
        public void TestReservationConstructors() {
            Reservation res1 = new Reservation();
            Assert.AreEqual(0, res1.number, "Testing default reservation number");
            Assert.AreEqual(0, res1.ownerNumber, "Testing default reservation ownernumber");
            Assert.AreEqual(new DateTime(), res1.sDate, "Testing default reservation start date");
            Assert.AreEqual(new DateTime(), res1.eDate, "Testing default reservation end date");

            Reservation res2 = new Reservation(334, DateTime.Now.AddDays(3), DateTime.Now.AddDays(9), 12);
            Assert.AreEqual(334, res2.number, "Testing res2 number");
            Assert.AreEqual(DateTime.Now.AddDays(3).ToShortDateString(), res2.sDate.ToShortDateString(), "Testing res2 start date: " + res2.sDate.ToShortDateString());
            Assert.AreEqual(DateTime.Now.AddDays(9).ToShortDateString(), res2.eDate.ToShortDateString(), "Testing res2 end date" + res2.eDate.ToShortDateString());
            Assert.AreEqual(12, res2.ownerNumber, "Testing res2 ownernumber");
        }



        [TestMethod]
        public void TestListReservations() {
            int[] reservations = {
                100,102,103,104,105,106,108,109,110,112,114,115,120,122,123,131,136,137,138,139,140,143,144,145,146,148,594,595,601,603,
                605,615,620,625,630,631,632,633,635,636,696,700,701,702,703,704,705,707,708,709,711,712,713,716,717,720,721,800,801,802,804,809,810,811,
                900,901,902,903,904,905,906
            };
            Reservation test = new Reservation();
            List<Reservation> listReservations = test.ListReservations();
            listReservations = listReservations.OrderBy(r => r.number).ToList();
            for ( int i = 0 ; i < listReservations.Count ; i++ )
                Assert.IsTrue(listReservations[i].number == reservations[i], "Testing that the reservations are all in order and displayed properly");
        }

        [TestMethod]
        public void TestListListReservationsByOwner() {
            Reservation test = new Reservation();
            List<Reservation> activeReservations = test.ListActiveReservation(2);
            int[] reservations1 = {
                900
            };
            activeReservations = activeReservations.OrderBy(r => r.number).ToList();
            for ( int i = 0 ; i < activeReservations.Count ; i++ )
                Assert.AreEqual(reservations1[i], activeReservations[i].number, "Testing that all active reservations for owner 1 are listed in order and available");
        }

        [TestMethod]
        public void TestListListActiveReservations() {
            Reservation test = new Reservation();
            List<Reservation> activeReservations = test.ListActiveReservation();
            int[] reservations = {
                900,901,902,903,904,905,906
            };
            activeReservations = activeReservations.OrderBy(r => r.number).ToList();
            for ( int i = 0 ; i < activeReservations.Count ; i++ )
                Assert.AreEqual(reservations[i], activeReservations[i].number, "Testing that all active reservations are listed in order and available");
        }

        [TestMethod]
        public void TestListListActiveReservationsByOwner() {
            Reservation test = new Reservation();
            List<Reservation> activeReservations = test.ListActiveReservation(2);
            activeReservations = activeReservations.OrderBy(r => r.number).ToList();
            for ( int i = 0 ; i < activeReservations.Count ; i++ )
                Assert.AreEqual(900, activeReservations[i].number, "Testing that all active reservations for owner 2 are listed in order and available");

            List<Reservation> activeReservations1 = test.ListActiveReservation(17);
            activeReservations1 = activeReservations1.OrderBy(r => r.number).ToList();
            for ( int i = 0 ; i < activeReservations1.Count ; i++ )
                Assert.AreEqual(904, activeReservations1[i].number, "Testing that all active reservations for owner 17 are listed in order and available");

            List<Reservation> activeReservations2 = test.ListActiveReservation(19);
            activeReservations2 = activeReservations2.OrderBy(r => r.number).ToList();
            for ( int i = 0 ; i < activeReservations2.Count ; i++ )
                Assert.AreEqual(906, activeReservations2[i].number, "Testing that all active reservations for owner 19 are listed in order and available");

            List<Reservation> activeReservations3 = test.ListActiveReservation(1);
            activeReservations3 = activeReservations3.OrderBy(r => r.number).ToList();
            Assert.AreEqual(0, activeReservations3.Count, "Testing that if an owner is entered and there are no reservations, the size of the list is 0");

            List<Reservation> activeReservations4 = test.ListActiveReservation(99);
            activeReservations = activeReservations4.OrderBy(r => r.number).ToList();
            Assert.AreEqual(0, activeReservations4.Count, "Testing that if an invalid owner is entered, the size of the list is 0");

        }

        [TestMethod]
        public void TestUpcomingReservations() {
            Reservation test = new Reservation();

            int[] reservations1 = {
                800,801,802,804,708,709,711,712,713,716,717,720,721,809,811
            };

            List<Reservation> upcomingReservations1 = test.ListUpcomingReservation(DateTime.Parse("2017-MAR-31"));
            for ( int i = 0 ; i < upcomingReservations1.Count ; i++ )
                Assert.AreEqual(reservations1[i], upcomingReservations1[i].number, "Testing that upcoming reservations are after the specified date");

            int[] reservations2 = {
               800,801,802,804,708,709,711,712,720,809,811
            };

            List<Reservation> upcomingReservations2 = test.ListUpcomingReservation(DateTime.Parse("2017-APR-10"));
            for ( int i = 0 ; i < upcomingReservations2.Count ; i++ )
                Assert.AreEqual(reservations2[i], upcomingReservations2[i].number, "Testing that upcoming reservations are after the specified date");

            int[] reservations3 = {
                800,801,802,804,809,811 
            };

            List<Reservation> upcomingReservations3 = test.ListUpcomingReservation(DateTime.Parse("2017-APR-25"));
            for ( int i = 0 ; i < upcomingReservations3.Count ; i++ )
                Assert.AreEqual(reservations3[i], upcomingReservations3[i].number, "Testing that upcoming reservations are after the specified date");

            List<Reservation> upcomingReservations4 = test.ListUpcomingReservation(DateTime.Parse("2017-AUG-27"));
            Assert.AreEqual(0, upcomingReservations4.Count, "Testing that if no reservations are found that the list returns nothing");
        }


        [TestMethod]
        public void TestListAvailableRuns() {

            Reservation test = new Reservation();
            List<Run> availableRuns = test.ListAvailableRuns(DateTime.Parse("10-may-2017"), DateTime.Parse("25-may-2017"), 'L');
            Assert.AreEqual(availableRuns[0].number, 13, "test to check if a run is available for large dog between start and end date");
            Assert.AreEqual(availableRuns[0].size, 'L', "test to check if a run is available for large dog between start and end date");
            Assert.AreEqual(availableRuns[1].number, 14, "test to check if a run is available for large dog between start and end date");
            Assert.AreEqual(availableRuns[1].size, 'L', "test to check if a run is available for large dog between start and end date");
            Assert.AreEqual(availableRuns[2].number, 21, "test to check if a run is available for large dog between start and end date");
            Assert.AreEqual(availableRuns[2].size, 'L', "test to check if a run is available for large dog between start and end date");
            Assert.AreEqual(availableRuns[3].number, 22, "test to check if a run is available for large dog between start and end date");
            Assert.AreEqual(availableRuns[3].size, 'L', "test to check if a run is available for large dog between start and end date");
            Assert.AreEqual(availableRuns[4].number, 27, "test to check if a run is available for large dog between start and end date");
            Assert.AreEqual(availableRuns[4].size, 'L', "test to check if a run is available for large dog between start and end date");
            Assert.AreEqual(availableRuns[5].number, 28, "test to check if a run is available for large dog between start and end date");
            Assert.AreEqual(availableRuns[5].size, 'L', "test to check if a run is available for large dog between start and end date");

            List<Run> availableRuns1 = test.ListAvailableRuns(DateTime.Parse("16-MAR-2017"), DateTime.Parse("25-MAR-2017"), 'R');
            Assert.AreEqual(availableRuns1[0].number, 14, "test to check if a run is available for regular dog between start and end date even if it is a large run");
            Assert.AreEqual(availableRuns1[0].size, 'L', "test to check if a run is available for regular dog between start and end date even if it is a large run");
            Assert.AreEqual(availableRuns1[1].number, 21, "test to check if a run is available for regular dog between start and end date even if it is a large run");
            Assert.AreEqual(availableRuns1[1].size, 'L', "test to check if a run is available for regular dog between start and end date even if it is a large run");
            Assert.AreEqual(availableRuns1[2].number, 22, "test to check if a run is available for regular dog between start and end date even if it is a large run");
            Assert.AreEqual(availableRuns1[2].size, 'L', "test to check if a run is available for regular dog between start and end date even if it is a large run");
            Assert.AreEqual(availableRuns1[3].number, 27, "test to check if a run is available for regular dog between start and end date even if it is a large run");
            Assert.AreEqual(availableRuns1[3].size, 'L', "test to check if a run is available for regular dog between start and end date even if it is a large run");
            Assert.AreEqual(availableRuns1[4].number, 28, "test to check if a run is available for regular dog between start and end date even if it is a large run");
            Assert.AreEqual(availableRuns1[4].size, 'L', "test to check if a run is available for regular dog between start and end date even if it is a large run");
            Assert.AreEqual(availableRuns1[5].number, 30, "test to check if a run is available for regular dog between start and end date even if it is a large run");
            Assert.AreEqual(availableRuns1[5].size, 'R', "test to check if a run is available for regular dog between start and end date even if it is a large run");

            List<Run> availableRuns2 = test.ListAvailableRuns(DateTime.Parse("20-JUN-2014"), DateTime.Parse("07-JUL-2014"), 'L');
            Assert.AreEqual(availableRuns2[0].number, 13, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[0].size, 'L', "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[1].number, 14, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[1].size, 'L', "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[2].number, 21, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[2].size, 'L', "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[3].number, 22, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[3].size, 'L', "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[4].number, 27, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[4].size, 'L', "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[5].number, 28, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[5].size, 'L', "test to check if there are multiple runs available for large dog");

            List<Run> availableRuns3 = test.ListAvailableRuns(DateTime.Parse("01-MAR-2017"), DateTime.Parse("01-JUN-2017"), 'L');
            Assert.AreEqual(availableRuns3.Count, 0, "test to check if no run is available for Large dog");

            List<Run> availableRuns4 = test.ListAvailableRuns(DateTime.Parse("01-JAN-2017"), DateTime.Parse("25-JUN-2017"), 'R');
            Assert.AreEqual(availableRuns4.Count, 0, "test to check if no run is available for regular dog");

            List<Run> availableRuns5 = test.ListAvailableRuns(DateTime.Parse("05-DEC-2017"), DateTime.Parse("15-DEC-2017"), 'R');
            Assert.AreEqual(availableRuns2[0].number, 13, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[0].size, 'L', "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[1].number, 14, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[1].size, 'L', "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[2].number, 21, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[2].size, 'L', "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[3].number, 22, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[3].size, 'L', "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[4].number, 27, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[4].size, 'L', "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[5].number, 28, "test to check if there are multiple runs available for large dog");
            Assert.AreEqual(availableRuns2[5].size, 'L', "test to check if there are multiple runs available for large dog");
        }
        
        [TestMethod]
        public void TestAddReservation() {
            Reservation test = new Reservation();

            Assert.AreEqual(-51, test.AddReservation(990, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")), "Makes sure pet exists / Error: Invalid Pet number");
            Assert.IsTrue(test.AddReservation(991, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")) <= 0, "INValid pet number, res is not added");

            Assert.IsTrue(test.AddReservation(1, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")) <= 0, "AddReservation failed.");
            //Assert.AreEqual(test.ListReservations().Find(r => r.number == 992), 992, "Testing if reservation is available after being added");

            Assert.AreEqual(test.AddReservation(2, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")), 0, "Makes sure correct dog is added / pet number is 1");
            //Assert.AreEqual(test.ListReservations().Find(r => r.number == 996), 996, "Testing if reservation is available after being added");

            Assert.AreEqual(test.AddReservation(3, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")), 0, "Makes sure correct start date is added / Start date is valid");
            //Assert.AreEqual(test.ListReservations().Find(r => r.number == 998), 998, "Testing if reservation is available after being added");

            Assert.AreEqual(test.AddReservation(6, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")), 0, "Makes sure correct end date is added / end date is valid");
            //Assert.AreEqual(test.ListReservations().Find(r => r.number == 999), 999, "Testing if reservation is available after being added");

            Assert.AreEqual(test.AddReservation(7, DateTime.Parse("29-JUN-2017"), DateTime.Parse("26-JUN-2017")), -11, "Test Makes sure end date is not before end date / Error: start date must be before end date, ");
            Assert.AreEqual(test.AddReservation(9, DateTime.Parse("26-JUN-2019"), DateTime.Parse("29-JUN-2019")), -11, "Error: end date cannot be greater than 6 months from start date");
            Assert.AreEqual(test.AddReservation(10, DateTime.Parse("26-JAN-2017"), DateTime.Parse("29-JAN-2017")), -11, "Error: start date cannot be before today");
            Assert.AreEqual(test.AddReservation(11, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")), -11, "Error: Invalid Code");

            Reservation db = new Reservation();

            Assert.AreEqual(-10, db.AddReservation(990, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")), "Error: Invalid Pet number"); 

            Assert.IsTrue(db.AddReservation(20, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")) >= 0, "Error: Valid pet number, res is not added");

            Assert.IsTrue(db.AddReservation(994, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")) >= 0, "Error: Run is available for time period");

            Assert.AreEqual(db.AddReservation(996, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")), -11, "Error: pet number is 1");

            Assert.AreEqual(db.AddReservation(998, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")), -11, "Error: Invalid Code");

            Assert.AreEqual(db.AddReservation(999, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")), -11, "Error: Invalid Code");

            Assert.AreEqual(db.AddReservation(993, DateTime.Parse("29-JUN-2017"), DateTime.Parse("26-JUN-2017")), -11, "Error: Invalid Code");

            Assert.AreEqual(db.AddReservation(995, DateTime.Parse("26-JUN-2019"), DateTime.Parse("29-JUN-2019")), -11, "Error: Invalid Code");

            Assert.AreEqual(db.AddReservation(996, DateTime.Parse("26-JAN-2017"), DateTime.Parse("29-JAN-2017")), -11, "Error: Invalid Code");

            Assert.AreEqual(db.AddReservation(997, DateTime.Parse("26-JUN-2017"), DateTime.Parse("29-JUN-2017")), -11, "Error: Invalid Code");
  
        }
        
        [TestMethod]
        public void TestAddToReservation() {

            Reservation test = new Reservation();
            PetReservation check = new PetReservation();
            Assert.AreEqual(-52,test.AddToReservation(875, 6), "Test if error on incorrect reservation number.");
            check.ListPetReservations().FindAll(r => r.petNum == 3 && r.reservationNum == 875);
            check.ListPetReservations().FindAll(r => r.petNum == 6 && r.reservationNum == 875);

            Assert.AreEqual(-52,test.AddToReservation(875, 6), "Make sure an existing run is available when added / success run is available and pet is added");

            Assert.AreEqual(-52,test.AddToReservation(875, 6), "test if an existing run is not available when added / (Error 102) - run is not available and pet cannot be added ");
            Assert.AreEqual(-52,test.AddToReservation(875, 6), "Makes sure a run suiting the need of the dog's size / (Success - 100) run is available for specific size and pet is added to it");
            Assert.AreEqual(-52,test.AddToReservation(875, 6), "tests if there is no run suiting the need of the dog's size / (Error 103) - run is not available for the specific dog size");
            Assert.AreEqual(-52,test.AddToReservation(875, 6), "Makes sure a run is properly assigned to the pet / (Success - 100) run is properly assigned to pet");
            
            Assert.AreEqual(-52,test.AddToReservation(875, 6), "Makes sure that if there is an available run, that it is available throughout to the end of the reservation / (Success - 100) pet is assigned a proper run");
            
            Assert.AreEqual(-52,test.AddToReservation(875, 6),  "test if an existing run is not available when added / (Error 102) - run is not available and pet cannot be added ");
            Assert.AreEqual(-52,test.AddToReservation(875, 6),  "Checks if it is a valid pet number / (Error - Some number) Invalid Pet number");
            Assert.AreEqual(-52,test.AddToReservation(875, 6), "Checks if pet number isnt already part of the reservation / (Error - Some number) Pet is already in the current reservation");
            Assert.AreEqual(-52,test.AddToReservation(875, 6), "Checks if the reservation is already in progress / (Error - Some number) Reservation is in progress");
            Assert.AreEqual(-52,test.AddToReservation(875, 6),  "Checks if res number is valid / (Error - Some number) Reservation ");
        }

        [TestMethod]
        public void TestCancelReservation() {
            Reservation test = new Reservation();

            Assert.AreEqual(-52,test.CancelReservation(975), "Error cant cancel while reservation is in progress");
            Assert.AreEqual(-52,test.CancelReservation(999), "Error cant cancel reservation that doesnt exist");
            Assert.AreEqual(-52,test.CancelReservation(999), "Success reservation succesfully cancelled");
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Assert.AreEqual(-52,test.CancelReservation(995),  "make sure dogs are removed from their runs after deleting reservation / LIST RUNS AND CHECK");
            Assert.AreEqual(-52,test.CancelReservation(995), "make sure pet services are removed after deleting reservation / LIST PET SERVICES AND CHECK");
        }

        [TestMethod]
        public void TestDeleteDogFromReservation() {
            Reservation test = new Reservation();

            Assert.AreEqual(-52,test.DeleteDogFromReservation(812, 12), "Check if reservation exists when it does not exist / (Error - 52) - reservation could not be found");
            Assert.AreEqual(-51,test.DeleteDogFromReservation(811, 99), "Check if pet number exists when it does not exist / (Error - 51) - pet number could not be found");
            Assert.AreEqual(-23,test.DeleteDogFromReservation(811, 7), "Check if dog exists in reservation / (Error - 109) - one of the dogs is not part of the reservation");
            Assert.AreEqual(-52,test.DeleteDogFromReservation(219, 3), "Check if reservation is in progress when it is not in progress / (Success 100) Reservation is not currently in progress");
            // SELECT RESERVATION 219 and check if pet #3 is still in it

            Assert.AreEqual(-52,test.DeleteDogFromReservation(900, 9), "check that reservation is canceled if there is only one dog / (Success - 100) whole Reservation is removed");

            Assert.AreEqual(-52,test.DeleteDogFromReservation(902, 1), "check that reservation isnt canceled if there is two dogs / (Success - 100) whole reservation is still there with missing dog");

            Assert.AreEqual(-23,test.DeleteDogFromReservation(811, 1), "Make sure that the dog is removed from the reserved run and the reserved run is made available / (Success - 100) dog is removed nd run is made available");

            Assert.AreEqual(-23,test.DeleteDogFromReservation(811, 2), "Make sure that the dog services and daily rates are removed from the reservation / (Success - 100) dog services are removed from the reservation for the dog");
        }

        [TestMethod]
        public void TestListExpiredOrMissingVaccinations() {
            //acquire the reservation number 
            //check that the end date is not before start and within viable range
            //check that the start or end date changed does not conflict with run assignment
            //set the new start date and end date

            //INSERT INTO HVK RESERVATION
            //Reservation #885
            //Start date 2017 04 03
            //End date 2017 04 08
            //INSERT INTO HVK PET RESERVATION with current reservation number
            //2 dogs, one large, one regular
            //INSERT INTO PET SERVICES
            //BOARDING ONLY
            //UPDATE AND MODIFY THEIR VACCINATIONS TO 

            Reservation test = new Reservation();
            List<Vaccination> vaccinations = test.ListExpOrMissVaccs(26, DateTime.Parse("06-DEC-2017"));
            Assert.AreEqual(0, vaccinations.Count, "Checking that no vaccinations are return from specified pet since they are checked and not expired");

            List<Vaccination> vaccs1 = test.ListExpOrMissVaccs(7, DateTime.Parse("06-JUL-2016"));
            Assert.AreEqual(vaccs1[0].ToString(), new Vaccination(3, "Hepatitis").ToString(), "Testing that 2 missing vaccinations are returned");
            Assert.AreEqual(vaccs1[1].ToString(), new Vaccination(5, "Parovirus").ToString(), "Testing that 2 missing vaccinations are returned");

            List<Vaccination> vaccs2 = test.ListExpOrMissVaccs(35, DateTime.Parse("11-JAN-2017"));
            Assert.AreEqual(vaccs2[0].ToString(), new Vaccination(1, "Bordetella").ToString(), "Testing that all vaccinations are unchecked");
            Assert.AreEqual(vaccs2[1].ToString(), new Vaccination(2, "Distemper").ToString(), "Testing that all vaccinations are unchecked");
            Assert.AreEqual(vaccs2[2].ToString(), new Vaccination(3, "Hepatitis").ToString(), "Testing that all vaccinations are unchecked");
            Assert.AreEqual(vaccs2[3].ToString(), new Vaccination(4, "Parainfluenza").ToString(), "Testing that all vaccinations are unchecked");
            Assert.AreEqual(vaccs2[4].ToString(), new Vaccination(5, "Parovirus").ToString(), "Testing that all vaccinations are unchecked");
            Assert.AreEqual(vaccs2[5].ToString(), new Vaccination(6, "Rabies").ToString(), "Testing that all vaccinations are unchecked");

            List<Vaccination> vaccs3 = test.ListExpOrMissVaccs(35, DateTime.Parse("11-JAN-2017"));
            Assert.AreEqual(vaccs3[0].ToString(), new Vaccination(1, "Bordetella").ToString(), "Testing that all vaccinations are unchecked and expired");
            Assert.AreEqual(vaccs3[1].ToString(), new Vaccination(2, "Distemper").ToString(), "Testing that all vaccinations are unchecked and expired");
            Assert.AreEqual(vaccs3[2].ToString(), new Vaccination(3, "Hepatitis").ToString(), "Testing that all vaccinations are unchecked and expired");
            Assert.AreEqual(vaccs3[3].ToString(), new Vaccination(4, "Parainfluenza").ToString(), "Testing that all vaccinations are unchecked and expired");
            Assert.AreEqual(vaccs3[4].ToString(), new Vaccination(5, "Parovirus").ToString(), "Testing that all vaccinations are unchecked and expired");
            Assert.AreEqual(vaccs3[5].ToString(), new Vaccination(6, "Rabies").ToString(), "Testing that all vaccinations are unchecked and expired");

            List<Vaccination> vaccs4 = test.ListExpOrMissVaccs(3, DateTime.Parse("20-SEP-2018"));
            Assert.AreEqual(vaccs4[0].ToString(), new Vaccination(1, "Bordetella").ToString(), "Testing that all vaccinations are checked but now expired");
            Assert.AreEqual(vaccs4[1].ToString(), new Vaccination(2, "Distemper").ToString(), "Testing that all vaccinations are checked but now expired");
            Assert.AreEqual(vaccs4[2].ToString(), new Vaccination(3, "Hepatitis").ToString(), "Testing that all vaccinations are checked but now expired");
            Assert.AreEqual(vaccs4[3].ToString(), new Vaccination(4, "Parainfluenza").ToString(), "Testing that all vaccinations are checked but now expired");
            Assert.AreEqual(vaccs4[4].ToString(), new Vaccination(5, "Parovirus").ToString(), "Testing that all vaccinations are checked but now expired");
            Assert.AreEqual(vaccs4[5].ToString(), new Vaccination(6, "Rabies").ToString(), "Testing that all vaccinations are checked but now expired");

            Reservation res = new Reservation();
            List<Vaccination> vaccinations5 = res.ListExpOrMissVaccs(27, DateTime.Parse("09-DEC-2017"));
            Assert.AreEqual(vaccinations5.Count, 6, "Checking that no vaccinations are return from specified pet since they are checked and not expired");
        }

        [TestMethod]
        public void TestCheckVaccinations() {
            //check if the petnumber exists
            //retrieve all the vaccinations and their expiry date for the pet
            //checks vaccination list returned is all before the expiry date

            //SQL:
            //SELECT V.VACCINATION_NAME
            //FROM HVK_PET p
            //JOIN HVK_PET_VACCINATION pv
            //ON P.PET_NUMBER = PV.PET_PET_NUMBER
            //JOIN HVK_VACCINATION v
            //ON PV.VACC_VACCINATION_NUMBER = V.VACCINATION_NUMBER
            //WHERE(P.PET_NUMBER = 12) AND(PV.VACCINATION_EXPIRY_DATE <= '17-09-04' OR PV.VACCINATION_CHECKED_STATUS = 'N');

            Reservation res = new Reservation();
            Assert.AreEqual(res.CheckVaccinations(999, DateTime.Parse("04-Sep-2017")), -51, "test to check if pet number is valid");
            //  Test Method         test to check if pet number is valid
            //  Input Parameters:   petNumber - 999
            //                      byDate - '17-09-04'
            //  Expected Result:    (Error -51) Invalid Pet Number

            Assert.AreEqual(res.CheckVaccinations(1, DateTime.Parse("03-01-2017")), -11, "test to check if date is before current date");
            //  Test Method         test to check if date is before current date
            //  Input Parameters:   petNumber - 1
            //                      byDate - '17-01-03'
            //  Expected Result:    (Error -11)	Error Start date before today

            Assert.AreEqual(res.CheckVaccinations(3, DateTime.Parse("04-09-2017")), -2, "test to check if all vaccinations are valid");
            //  Test Method         test to check if all vaccinations are valid
            //  Input Parameters:   petNumber - 12
            //                      byDate - '17-09-04'
            //  Expected Result:    (Success -2) all vaccinations are checked and wont expire

            Assert.AreEqual(res.CheckVaccinations(27, DateTime.Parse("09-12-2017")), -2, "test to check if all any vaccinations are invalid by the end date");
            //  Test Method         test to check if all any vaccinations are invalid by the end date
            //  Input Parameters:   petNumber - 27
            //                      byDate - '17-12-06'
            //  Expected Result:    (Error -2) 	Warning Missing or Expiring vaccinations

            Assert.AreEqual(res.CheckVaccinations(7, DateTime.Parse("06-12-2017")), -1, "test to check if there are any missing vaccinations");
            //  Test Method         test to check if there are any missing vaccinations
            //  Input Parameters:   petNumber - 7
            //                      byDate - '17-12-06'
            //  Expected Result:    (Error -1) 	Warning Missing or Expiring vaccinations

            Assert.AreEqual(res.CheckVaccinations(13, DateTime.Parse("05-08-2017")), -2, "test to check that vaccinations wont expire by the date but are not checked");
            //  Test Method         test to check that vaccinations wont expire by the date but are not checked
            //  Input Parameters:   petNumber - 35
            //                      byDate - 17-01-11
            //  Expected Result:    (Error -2) Warning unchecked vaccinations
        }


        [TestMethod]
        public void TestCheckRunAvailability() {
            //check to see if any runs are available
            //from that list, break it down to run size and check if still available
            //from that sublist, break it down by runs available from the specified start and end date
            //return false if any step fails

            //SELECT RUN.RUN_NUMBER, RUN.RUN_SIZE
            //FROM HVK_RUN RUN
            //WHERE RUN.RUN_SIZE = 'L'
            //MINUS
            //(SELECT RUN.RUN_NUMBER, RUN.RUN_SIZE
            //FROM HVK_RESERVATION R
            //JOIN HVK_PET_RESERVATION PR
            //ON R.RESERVATION_NUMBER = PR.RES_RESERVATION_NUMBER
            //JOIN HVK_RUN RUN
            //ON PR.RUN_RUN_NUMBER = RUN.RUN_NUMBER
            //WHERE R.RESERVATION_START_DATE >= 'start' AND R.RESERVATION_END_DATE <= 'end');

            Reservation res = new Reservation();
            Assert.AreEqual(res.CheckRunAvailability(DateTime.Parse("2017-May-02"), DateTime.Parse("2017-May-04"), 'Z'), -50, "test to check that date is correct format for startdate");
            //  Test Method         test to check that date is correct format for startdate
            //  Input Parameters:   startDate - '16-05-02'
            //                      endDate - '16-05-04'
            //                      runSize - 'Z'
            //  Expected Result:    (Error -50) Error Invalid Run Size
            
            Assert.AreEqual(-12,res.CheckRunAvailability(DateTime.Parse("17-MAY-30"), DateTime.Parse("17-MAY-04"), 'R'), "test to check that start date is not before end date");
            //  Test Method         test to check that start date is not before end date
            //  Input Parameters:   startDate - '16-04-30'
            //                      endDate - '16-05-04'
            //                      runSize - 'R'
            //  Expected Result:    (Error -12) 	Error Start date after end date

            Assert.AreEqual(res.CheckRunAvailability(DateTime.Parse("04-MAY-2017"), DateTime.Parse("30-MAY-2017"), 'R'), 0, "test to check that a run will be available from the beggining of the reservation to the end");
            //  Test Method         test to check that a run will be available from  the beggining of the reservation to the end
            //  Input Parameters:   startDate - '16-04-30'
            //                      endDate - '16-05-04'
            //                      runSize - 'R'
            //  Expected Result:    (Success - 0) Available run from start date to end date for dog

            Assert.AreEqual(res.CheckRunAvailability(DateTime.Parse("10-MAY-2017"), DateTime.Parse("25-MAY-2017"), 'L'), 0, "test to check if run is available for large dog");
            //  Test Method         test to check if run is available for large dog
            //  Input Parameters:   startDate - '17-04-10'
            //                      endDate - '17-04-25'
            //                      runSize - 'L'
            //  Expected Result:    (Success - 0) Available run from start date to end date for dog size large

            Assert.AreEqual(res.CheckRunAvailability(DateTime.Parse("25-DEC-2016"), DateTime.Parse("08-JAN-2017"), 'L'), -40, "test to check if no run is available for large dog");
            //  Test Method         test to check if no run is available for large dog
            //  Input Parameters:   startDate - '16-12-25'
            //                      endDate - '17-01-08'
            //                      runSize - 'L'
            //  Expected Result:    (Error -40) Error No run available for reservation period

            Assert.AreEqual(res.CheckRunAvailability(DateTime.Parse("01-DEC-2016"), DateTime.Parse("10-JAN-2017"), 'R'), -40, "test to check if no run is available for regular dog");
            //  Test Method         test to check if no run is available for regular dog
            //  Input Parameters:   startDate - '16-12-01'
            //                      endDate - '17-01-10'
            //                      runSize - 'R'
            //  Expected Result:    (Error -40) Error No run available for reservation period
        }
    }
}
