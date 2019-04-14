using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hulkUnitTest
{
    [TestClass]
    public class UpdatedTestReservation
    {
        enum e
        {
            success = 0,
            vaccInvalid = -1,
            invalidPet = -10,
            sBeforeToday = -11,
            sBeforeEnd = -12,
            alreadyReserved = -13,
            runUnavailable = -14,
            insertFail = -15,
            petNotInRes = -16,
            invalidRes = -17,
            resCancelled = -18,
            petInRes = -19,
            differentOwner = -20,
            sAfterOneYear = -21,
            eOneYearAfterStart = -22,
            resInProgress = -23
        };

        [TestMethod]
        public void TestPetReservationConstructors()
        {
            PetReservation petRes1 = new PetReservation();
            Assert.AreEqual(0, petRes1.petResNum, "Testing petRes1 petResNum");
            Assert.AreEqual(0, petRes1.petNum, "Testing petRes1 petNum");
            Assert.AreEqual(0, petRes1.reservationNum, "Testing petRes1 reservationNum");
            Assert.AreEqual(0, petRes1.runNum, "Testing petRes1 runNum");
            Assert.AreEqual(0, petRes1.PRpetResNum, "Testing petRes1 PRpetResNum");
            Assert.AreEqual(new Run(), petRes1.run, "Testing petRes1 run");
            Assert.AreEqual(new Food(), petRes1.food, "Testing petRes1 food");
            Assert.AreEqual(new Reservation(), petRes1.res, "Testing petRes1 res");
            Assert.AreEqual(0, petRes1.dis.Count, "Testing petRes1 discounts");
            Assert.AreEqual(0, petRes1.med.Count, "Testing petRes1 medications");
            Assert.AreEqual(0, petRes1.ser.Count, "Testing petRes1 services");

            PetReservation petRes2 = new PetReservation(3, 5, 100);
            Assert.AreEqual(3, petRes2.petResNum, "Testing petRes2 petResNum");
            Assert.AreEqual(5, petRes2.petNum, "Testing petRes2 petNum");
            Assert.AreEqual(100, petRes2.reservationNum, "Testing petRes2 reservationNum");
            Assert.AreEqual(0, petRes2.runNum, "Testing petRes2 runNum");
            Assert.AreEqual(0, petRes2.PRpetResNum, "Testing petRes2 PRpetResNum");
            Assert.AreEqual(new Run(), petRes2.run, "Testing petRes2 run");
            Assert.AreEqual(new Food(), petRes2.food, "Testing petRes2 food");
            Assert.AreEqual(new Reservation(), petRes2.res, "Testing petRes2 res");
            Assert.AreEqual(0, petRes2.dis.Count, "Testing petRes2 discounts");
            Assert.AreEqual(0, petRes2.med.Count, "Testing petRes2 medications");
            Assert.AreEqual(0, petRes2.ser.Count, "Testing petRes2 services");

            PetReservation petRes3 = new PetReservation(3, 5, 100, 27, 166);
            Assert.AreEqual(3, petRes3.petResNum, "Testing petRes3 petResNum");
            Assert.AreEqual(5, petRes3.petNum, "Testing petRes3 petNum");
            Assert.AreEqual(100, petRes3.reservationNum, "Testing petRes3 reservationNum");
            Assert.AreEqual(27, petRes3.runNum, "Testing petRes3 runNum");
            Assert.AreEqual(166, petRes3.PRpetResNum, "Testing petRes3 PRpetResNum");
            Assert.AreEqual(new Run(), petRes3.run, "Testing petRes3 run");
            Assert.AreEqual(new Food(), petRes3.food, "Testing petRes3 food");
            Assert.AreEqual(new Reservation(), petRes3.res, "Testing petRes3 res");
            Assert.AreEqual(0, petRes3.dis.Count, "Testing petRes3 discounts");
            Assert.AreEqual(0, petRes3.med.Count, "Testing petRes3 medications");
            Assert.AreEqual(0, petRes3.ser.Count, "Testing petRes3 services");

            List<Discount> discounts = new List<Discount>();
            discounts.Add(new Discount(1, "Shared Run", 0.1f, 'D'));
            discounts.Add(new Discount(2, "Multiple Pets", 0.07f, 'T'));
            discounts.Add(new Discount(3, "Own food", 0.1f, 'D'));


            List<Medication> meds = new List<Medication>();
            meds.Add(new Medication(1, "Tylenol"));
            meds.Add(new Medication(2, "Medicam"));
            meds.Add(new Medication(3, "Tapzole"));
            meds.Add(new Medication(4, "Prednisone"));

            List<Service> services = new List<Service>();
            services.Add(new Service(1, "Boarding", 13));
            services.Add(new Service(2, "Walk", 13));
            services.Add(new Service(3, "Grooming", 13));
            services.Add(new Service(4, "Playtime", 13));


            PetReservation petRes4 = new PetReservation(3, 5, 100, 27, 166, new Run(), new Food(),
                new Reservation(), discounts, meds, services);
            Assert.AreEqual(3, petRes4.petResNum, "Testing petRes4 petResNum");
            Assert.AreEqual(5, petRes4.petNum, "Testing petRes4 petNum");
            Assert.AreEqual(100, petRes4.reservationNum, "Testing petRes4 reservationNum");
            Assert.AreEqual(27, petRes4.runNum, "Testing petRes4 runNum");
            Assert.AreEqual(166, petRes4.PRpetResNum, "Testing petRes4 PRpetResNum");
            Assert.AreEqual(new Run(), petRes4.run, "Testing petRes4 run");
            Assert.AreEqual(new Food(), petRes4.food, "Testing petRes4 food");
            Assert.AreEqual(new Reservation(), petRes4.res, "Testing petRes4 res");
            Assert.AreEqual(5, petRes4.dis.Count, "Testing petRes4 discounts");
            Assert.AreEqual(4, petRes4.med.Count, "Testing petRes4 medications");
            Assert.AreEqual(4, petRes4.ser.Count, "Testing petRes4 services");
        }

        [TestMethod]
        public void TestReservationConstructors()
        {
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
        public void TestListReservations()
        {
            int[] reservations =
            {
                100,102,103,104,105,106,108,109,110,112,114,115,120,122,123,131,136,137,138,139,140,143,144,145,146,148,594,595,601,603,
                605,615,620,625,630,631,632,633,635,636,696,700,701,702,703,704,705,707,708,709,711,712,713,716,717,720,721,800,801,802,804,809,810,811,
                900,901,902,903,904,905,906
            };
            Reservation test = new Reservation();
            List<Reservation> listReservations = test.ListReservations();
            listReservations = listReservations.OrderBy(r => r.number).ToList();
            for (int i = 0; i < listReservations.Count; i++)
                Assert.IsTrue(listReservations[i].number == reservations[i],"Testing that the reservations are all in order and displayed properly");
        }

        [TestMethod]
        public void TestListListReservationsByOwner()
        {
            Reservation test = new Reservation();
            List<Reservation> activeReservations = test.ListActiveReservationsByOwner(2);
            int[] reservations1 =
            {
                900
            };
            activeReservations = activeReservations.OrderBy(r => r.number).ToList();
            for (int i = 0; i < listReservations.Count; i++)
                Assert.AreEqual(reservations1[i], activeReservations[i].number, "Testing that all active reservations for owner 1 are listed in order and available");
        }

        [TestMethod]
        public void TestListListActiveReservations()
        {
            Reservation test = new Reservation();
            List<Reservation> activeReservations = test.ListActiveReservation();
            int[] reservations =
            {
                900,901,902,903,904,905,906
            };
            activeReservations = activeReservations.OrderBy(r => r.number).ToList();
            for (int i = 0; i < listReservations.Count; i++)
                Assert.AreEqual(reservations[i], activeReservations[i].number, "Testing that all active reservations are listed in order and available");
        }

        [TestMethod]
        public void TestListListActiveReservationsByOwner()
        {
            Reservation test = new Reservation();
            List<Reservation> activeReservations = test.ListActiveReservationsByOwner(2);

            activeReservations = activeReservations.OrderBy(r => r.number).ToList();
            for (int i = 0; i < listReservations.Count; i++)
                Assert.AreEqual(900, activeReservations[i].number, "Testing that all active reservations for owner 2 are listed in order and available");

            List<Reservation> activeReservations = test.ListActiveReservationsByOwner(17);

            activeReservations = activeReservations.OrderBy(r => r.number).ToList();
            for (int i = 0; i < listReservations.Count; i++)
                Assert.AreEqual(904, activeReservations[i].number, "Testing that all active reservations for owner 17 are listed in order and available");

            List<Reservation> activeReservations = test.ListActiveReservationsByOwner(19);

            activeReservations = activeReservations.OrderBy(r => r.number).ToList();
            for (int i = 0; i < listReservations.Count; i++)
                Assert.AreEqual(906, activeReservations[i].number, "Testing that all active reservations for owner 19 are listed in order and available");

            

            List<Reservation> activeReservations = test.ListActiveReservationsByOwner(1);

            activeReservations = activeReservations.OrderBy(r => r.number).ToList();
            for (int i = 0; i < listReservations.Count; i++)
                Assert.AreEqual(0, activeReservations[i].Count, "Testing that if an owner is entered and there are no reservations, the size of the list is 0");

            List<Reservation> activeReservations = test.ListActiveReservationsByOwner(99);

            activeReservations = activeReservations.OrderBy(r => r.number).ToList();
            for (int i = 0; i < listReservations.Count; i++)
                Assert.AreEqual(0, activeReservations[i].Count, "Testing that if an invalid owner is entered, the size of the list is 0");

        }

        [TestMethod]
        public void TestUpcomingReservations()
        {
            Reservation test = new Reservation();

            int[] reservations1 =
            {
                901,906,900,902,721,717,713,716,712,711,709,708,720,802,800,801,811,809,804
            };

            List<Reservation> upcomingReservations1 = test.ListUpcomingReservation(DateTime.Parse("2017-MAR-31"));
            for (int i = 0; i < upcomingReservations1.Count; i++)
                Assert.AreEqual(reservations1[i], upcomingReservations1[i].number, "Testing that upcoming reservations are after the specified date");

            int[] reservations2 =
            {
               712,711,709,708,720,802,800,801,811,809,804
            };

            List<Reservation> upcomingReservations2 = test.ListUpcomingReservation(DateTime.Parse("2017-APR-10"));
            for (int i = 0; i < upcomingReservations2.Count; i++)
                Assert.AreEqual(reservations2[i], upcomingReservations2[i].number, "Testing that upcoming reservations are after the specified date");

            int[] reservations3 =
            {
                802,800,801,811,809,804
            };

            List<Reservation> upcomingReservations3 = test.ListUpcomingReservation(DateTime.Parse("2017-APR-25"));
            for (int i = 0; i < upcomingReservations3.Count; i++)
                Assert.AreEqual(reservations3[i], upcomingReservations3[i].number, "Testing that upcoming reservations are after the specified date");

            List<Reservation> upcomingReservations4 = test.ListUpcomingReservation(DateTime.Parse("2017-AUG-27"));
            Assert.AreEqual(0, upcomingReservations4.Count, "Testing that if no reservations are found that the list returns nothing");
        }

    [TestMethod]
    public void TestAddReservation()
    {
        //AddReservation will:
        //Make sure a run is available for the time period
        //Add a new reservation to the HVK_RESERVATION
        //Add a new pet reservation to the HVK_PET_RESERVATION With RESERVATION_RESERVATION_NUMBER
        //Add the available Run number to the HVK_PET_RESERVATION
        //Add a new service to the HVK_PET_RESERVATION_SERVICE with PET_RES_PET_RES_NUMBER
        Reservation test = new Reservation();

        Assert.AreEqual(-10, test.AddReservation(990, DateTime.Parse("2017-JUN-26"), DateTime.Parse("2017-JUN-29")), "Makes sure pet exists / Error: Invalid Pet number");
        Assert.IsTrue(test.AddReservation(991, DateTime.Parse("2017-JUN-26"), DateTime.Parse("2017-JUN-29")) >= 0, "INValid pet number, res is not added");

        Assert.IsTrue(test.AddReservation(1, DateTime.Parse("2017-JUN-26"), DateTime.Parse("2017-JUN-29")) >= 0, "Success: Run is available for time period");
        Assert.AreEqual(test.ListReservations().Find(r => r.number == 992),992,"Testing if reservation is available after being added");

        Assert.AreEqual(test.AddReservation(2, DateTime.Parse("2017-JUN-26"), DateTime.Parse("2017-JUN-29")), 0, "Makes sure correct dog is added / pet number is 1");
        Assert.AreEqual(test.ListReservations().Find(r => r.number == 996), 996, "Testing if reservation is available after being added");

        Assert.AreEqual(test.AddReservation(3, DateTime.Parse("2017-JUN-26"), DateTime.Parse("2017-JUN-29")), 0, "Makes sure correct start date is added / Start date is valid");
        Assert.AreEqual(test.ListReservations().Find(r => r.number == 998), 998, "Testing if reservation is available after being added");

        Assert.AreEqual(test.AddReservation(6, DateTime.Parse("2017-JUN-26"), DateTime.Parse("2017-JUN-29")), 0, "Makes sure correct end date is added / end date is valid");
        Assert.AreEqual(test.ListReservations().Find(r => r.number == 999), 999, "Testing if reservation is available after being added");

        Assert.AreEqual(test.AddReservation(7, DateTime.Parse("2017-JUN-29"), DateTime.Parse("2017-JUN-26")), -11, "Test Makes sure end date is not before end date / Error: start date must be before end date, ");
        Assert.AreEqual(test.AddReservation(9, DateTime.Parse("2019-JUN-26"), DateTime.Parse("2019-JUN-29")), -11, "Error: end date cannot be greater than 6 months from start date");
        Assert.AreEqual(test.AddReservation(10, DateTime.Parse("2017-JAN-26"), DateTime.Parse("2017-JAN-29")), -11, "Error: start date cannot be before today");
        Assert.AreEqual(test.AddReservation(11, DateTime.Parse("2017-JUN-26"), DateTime.Parse("2017-JUN-29")), -11, "Error: Invalid Code");
        //  Test Method         Makes sure that run is available - Will call check run availability
        //  Input Parameters:   PetNumber - 997
        //                      startDate - "17-01-26"
        //                      endDate - "17-01-29"
        //  Expected Result:    
    }

    [TestMethod]
    public void TestAddToReservation()
    {
        //Acquire the Reservation number
        //Make sure a run is available for the time period
        //(THIS INCLUDES SEARCHING OTHER RUNS ABOUT TO BE ASSIGNED BEFORE THE END OF THE RESERVATION)
        //Add a new pet reservation to the HVK_PET_RESERVATION With RESERVATION_RESERVATION_NUMBER
        //Add a new service to the HVK_PET_RESERVATION_SERVICE with PET_RES_PET_RES_NUMBER
        //Add a new food to the HVK_PET_FOOD with PET_RES_PET_RES_NUMBER
        //Add a new medication to the HVK_MEDICATION with PET_RES_PET_RES_NUMBER

        //Insert into hvk reservation table a new reservation #875
        //Insert into hvk pet reservation table a new pet reservation with pet number 3

        Reservation test = new Reservation();

        PetReservation check = new PetReservation();

        Assert.AreEqual(test.AddToReservation(875, 6), e.success, "Test if correct dog is added / success reservation with petnumber 5 and 6");
        Assert.AreEqual(test.ListReservations().Find(r => r.number == 999).number, 999, "Testing if reservation is available after being added");
            check.ListPetReservations().Find(r => r.petNum = 3).Find(r => r.reservationNum = 875);
            check.ListPetReservations().Find(r => r.petNum = 6).Find(r => r.reservationNum = 875);

        Assert.AreEqual(test.AddToReservation(875, 6), e.success, "Make sure an existing run is available when added / success run is available and pet is added");



        Assert.AreEqual(test.AddToReservation(875, 6), e.runUnavailable, "test if an existing run is not available when added / (Error 102) - run is not available and pet cannot be added ");



        Assert.AreEqual(test.AddToReservation(875, 6), e.success, "Makes sure a run suiting the need of the dog's size / (Success - 100) run is available for specific size and pet is added to it");


        Assert.AreEqual(test.AddToReservation(875, 6), e.runUnavailable, "tests if there is no run suiting the need of the dog's size / (Error 103) - run is not available for the specific dog size");
        //Assert.AreEqual(test.AddToReservation(875, 6), 0, "Makes sure a run suiting the need of the dog if it is a barker / (Success - 100) a run is available for a barker and pet is added to it");
        //Assert.AreEqual(test.AddToReservation(875, 6), 0, "tests if a run suiting the need of the dog if it is a barker is not available / (Error 104) - run is not available for a barking dog");
        //Assert.AreEqual(test.AddToReservation(875, 6), 0, "Makes sure a run suiting the need of the dog if it is a climber / (Success - 100) a run is available for a climber and pet is added to it");
        Assert.AreEqual(test.AddToReservation(875, 6), e.success, "Makes sure a run is properly assigned to the pet / (Success - 100) run is properly assigned to pet");
        

        Assert.AreEqual(test.AddToReservation(875, 6), e.success, "Makes sure that if there is an available run, that it is available throughout to the end of the reservation / (Success - 100) pet is assigned a proper run");


        Assert.AreEqual(test.AddToReservation(875, 6), e.runUnavailable, "test if an existing run is not available when added / (Error 102) - run is not available and pet cannot be added ");
        Assert.AreEqual(test.AddToReservation(875, 6), e.invalidPet, "Checks if it is a valid pet number / (Error - Some number) Invalid Pet number");
        Assert.AreEqual(test.AddToReservation(875, 6), e.petInRes, "Checks if pet number isnt already part of the reservation / (Error - Some number) Pet is already in the current reservation");
        Assert.AreEqual(test.AddToReservation(875, 6), e.resInProgess, "Checks if the reservation is already in progress / (Error - Some number) Reservation is in progress");
        Assert.AreEqual(test.AddToReservation(875, 6), e.invalidRes, "Checks if res number is valid / (Error - Some number) Reservation ");
    }

    [TestMethod]
    public void TestCancelReservation()
    {
        Reservation test = new Reservation();

        Assert.AreEqual(test.CancelReservation(975), e.resInProgess, "Error cant cancel while reservation is in progress");
        Assert.AreEqual(test.CancelReservation(999), e.invalidRes, "Error cant cancel reservation that doesnt exist");
        Assert.AreEqual(test.CancelReservation(999), e.success, "Success reservation succesfully cancelled");
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Assert.AreEqual(test.CancelReservation(995), 0, "make sure dogs are removed from their runs after deleting reservation / LIST RUNS AND CHECK");
        Assert.AreEqual(test.CancelReservation(995), 0, "make sure pet services are removed after deleting reservation / LIST PET SERVICES AND CHECK");
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    [TestMethod]
    public void TestChangeReservation()
    {
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

        test.ChangeReservation(885, DateTime.Parse("03-APR-2017"), DateTime.Parse("09-APR-2017"), "check if startdate is greater than or equal than today / (Success - 100 NO ERROR) DateTime is greater than or equal than today ");
        test.ChangeReservation(885, DateTime.Parse("23-APR-2017"), DateTime.Parse("23-APR-2017"), "check if end is greater than or equal than startdate on same day / (Success - 100 NO ERROR) end date is greater than or equal than startdate");
        test.ChangeReservation(885, DateTime.Parse("23-NOV-2017"), DateTime.Parse("27-NOV-2017"), "check if startdate is no greater than one year from current date / (Success - 100 NO ERROR) startdate is no greater than one year from current date");
        test.ChangeReservation(885, DateTime.Parse("23-NOV-2017"), DateTime.Parse("27-JAN-2018"), "check if end date is no greater than 6 months from start date / (Success - 100 NO ERROR) end date is no greater than 6 months from start date");
        test.ChangeReservation(885, DateTime.Parse("23-NOV-2017"), DateTime.Parse("27-JAN-2018"), "check if runs are available for medium and large dogs / (Success - 100 NO ERROR) runs are available for modified dates");
        test.ChangeReservation(885, DateTime.Parse("23-NOV-2017"), DateTime.Parse("27-JAN-2018"), "check if validations are still valid after the reservation has been modified(dates) / (Success - 100 NO ERROR) vaccinations are still valid after reservation has been modified dates");
    }

        [TestMethod]
        public void TestDeleteDogFromReservation()
        {
            //check to see if the pet reservation exists
            //make sure the reservation isnt already in progress
            //check to see if it is only one dog
            //remove all related services for the dog
            //if it is the only dog delete the reservation altogether from the DB

            //INSERT INTO HVK RESERVATION
            //INSERT INTO HVK PET RESERVATION pet number 1 and 2
            //INSERT SERVICES
            //RESERVATION NUMBER IS 811

            Reservation test = new Reservation();

            Assert.AreEqual(test.DeleteDogFromReservation(812, 12), "Check if reservation exists when it does not exist / (Error - 106) - reservation could not be found");
            Assert.AreEqual(test.DeleteDogFromReservation(811, 99), "Check if pet number exists when it does not exist / (Error - Some error code) - pet number could not be found");
            Assert.AreEqual(test.DeleteDogFromReservation(811, 7), "Check if dog exists in reservation / (Error - 109) - one of the dogs is not part of the reservation");
            Assert.AreEqual(test.DeleteDogFromReservation(219, 3), "Check if reservation is in progress when it is not in progress / (Success 100) Reservation is not currently in progress");
            // SELECT RESERVATION 219 and check if pet #3 is still in it

            Assert.AreEqual(test.DeleteDogFromReservation(900, 9), "check that reservation is canceled if there is only one dog / (Success - 100) whole Reservation is removed");
            //  Test Method         check that reservation is canceled if there is only one dog
            //  SELECT RESERVATION 811 and CHECK RESERVATION NO LONGER HAS AN ENTRY

            Assert.AreEqual(test.DeleteDogFromReservation(902, 1), "check that reservation isnt canceled if there is two dogs / (Success - 100) whole reservation is still there with missing dog");
            //  Test Method         check that reservation is canceled if there is only one dog
            //  SELECT RESERVATION 811 CHECK RESERVATION NO LONGER HAS AN ENTRY


            Assert.AreEqual(test.DeleteDogFromReservation(811, 1), "Make sure that the dog is removed from the reserved run and the reserved run is made available / (Success - 100) dog is removed nd run is made available");
            //  Test Method         Make sure that the dog is removed from the reserved run and the reserved run is made available
            //  SELECT AND CHECK RUN IS NO LONGER ASSOCIATED WITH PET RESERVATION

            Assert.AreEqual(test.DeleteDogFromReservation(811, 2), "Make sure that the dog services and daily rates are removed from the reservation / (Success - 100) dog services are removed from the reservation for the dog");
            //  Test Method         Make sure that the dog services and daily rates are removed from the reservation
            //  SELECT AND CHECK SERVICES ARE NO LONGER ASSOCIATED WITH RESERVATION
        }

    [TestMethod]
    public void TestCheckRunAvailability()
    {
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



        Assert.AreEqual(CheckRunAvailability(DateTime.Parse("30-MAY-2016"), DateTime.Parse("04-MAY-2016"), 'R'), -12, "test to check that start date is not before end date");

        List<Run> availableRuns = CheckRunAvailability(DateTime.Parse("10-may-2017"), DateTime.Parse("25-may-2017"), 'L');
        Assert.AreEqual(availableRuns[0], new Run(13, 'L'), "test to check if a run is available for large dog between start and end date");
        Assert.AreEqual(availableRuns[1], new Run(14, 'L'), "test to check if a run is available for large dog between start and end date");
        Assert.AreEqual(availableRuns[2], new Run(21, 'L'), "test to check if a run is available for large dog between start and end date");
        Assert.AreEqual(availableRuns[3], new Run(22, 'L'), "test to check if a run is available for large dog between start and end date");
        Assert.AreEqual(availableRuns[4], new Run(27, 'L'), "test to check if a run is available for large dog between start and end date");
        Assert.AreEqual(availableRuns[5], new Run(28, 'L'), "test to check if a run is available for large dog between start and end date");

        List<Run> availableRuns1 = CheckRunAvailability(DateTime.Parse("10-04-2017"), DateTime.Parse("25-APR-2017"), 'R');
        Assert.AreEqual(availableRuns1[0], new Run(1, 'R'), "test to check if a run is available for regular dog between start and end date");
        Assert.AreEqual(availableRuns1[1], new Run(2, 'R'), "test to check if a run is available for regular dog between start and end date");
        Assert.AreEqual(availableRuns1[2], new Run(29, 'R'), "test to check if a run is available for regular dog between start and end date");
        Assert.AreEqual(availableRuns1[3], new Run(30, 'R'), "test to check if a run is available for regular dog between start and end date");
        Assert.AreEqual(availableRuns1[4], new Run(35, 'R'), "test to check if a run is available for regular dog between start and end date");
        Assert.AreEqual(availableRuns1[5], new Run(36, 'R'), "test to check if a run is available for regular dog between start and end date");

        List<Run> availableRuns2 = CheckRunAvailability(DateTime.Parse("16-12-25"), DateTime.Parse("08-JAN-2017"), 'L');
        Assert.AreEqual(availableRuns[0], new Run(14, 'L'), "test to check if there are multiple runs available for large dog");
        Assert.AreEqual(availableRuns[1], new Run(21, 'L'), "test to check if there are multiple runs available for large dog");
        Assert.AreEqual(availableRuns[2], new Run(22, 'L'), "test to check if there are multiple runs available for large dog");
        Assert.AreEqual(availableRuns[3], new Run(28, 'L'), "test to check if there are multiple runs available for large dog");

        List<Run> availableRuns3 = CheckRunAvailability(DateTime.Parse("10-MAY-2016"), DateTime.Parse("25-MAY-2016"), 'L');
        Assert.AreEqual(availableRuns3.Count, 0, "test to check if no run is available for Large dog");

        List<Run> availableRuns4 = CheckRunAvailability(DateTime.Parse("10-MAY-2016"), DateTime.Parse("25-MAY-2016"), 'R');
        Assert.AreEqual(availableRuns4.Count, 0, "test to check if no run is available for regular dog");

    }

        [TestMethod]
        public void TestCheckVaccinations()
        {
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

            //                      Assert.AreEqual(CheckVaccinations(999, '17-09-04'), -51, test to check if pet number is valid);
            //  Test Method         test to check if pet number is valid
            //  Input Parameters:   petNumber - 999
            //                      byDate - '17-09-04'
            //  Expected Result:    (Error -51) Invalid Pet Number

            //                      Assert.AreEqual(CheckVaccinations(1,'17-01-03'), -11, test to check if date is before current date);
            //  Test Method         test to check if date is before current date
            //  Input Parameters:   petNumber - 1
            //                      byDate - '17-01-03'
            //  Expected Result:    (Error -11)	Error Start date before today



            List<Vaccination> vaccinations = CheckVaccinations(27, DateTime.Parse("06-DEC-2017"));
            Assert.AreEqual(vaccinations.Count, 0, "Checking that no vaccinations are return from specified pet since they are checked and not expired");


            List<Vaccination> vaccinations1 = CheckVaccinations(7, DateTime.Parse("06-JUL-2016"));
            Assert.AreEqual(vaccinations1[0], new Vaccination(3, "Hepatitis"), "Testing that 2 missing or expired vaccinations are returned");
            Assert.AreEqual(vaccinations1[1], new Vaccination(5, "Parovirus"), "Testing that 2 missing or expired vaccinations are returned");

            List<Vaccination> vaccinations2 = CheckVaccinations(35, DateTime.Parse("11-JAN-2017"));
            Assert.AreEqual(vaccinations2[0], new Vaccination(1, "Bordetella"), "Testing that all vaccinations are unchecked");
            Assert.AreEqual(vaccinations2[1], new Vaccination(2, "Distemper"), "Testing that all vaccinations are unchecked");
            Assert.AreEqual(vaccinations2[0], new Vaccination(3, "Hepatitis"), "Testing that all vaccinations are unchecked");
            Assert.AreEqual(vaccinations2[1], new Vaccination(4, "Parainfluenza"), "Testing that all vaccinations are unchecked");
            Assert.AreEqual(vaccinations2[0], new Vaccination(5, "Parovirus"), "Testing that all vaccinations are unchecked");
            Assert.AreEqual(vaccinations2[1], new Vaccination(6, "Rabies"), "Testing that all vaccinations are unchecked");

            List<Vaccination> vaccinations3 = CheckVaccinations(35, DateTime.Parse("11-JAN-2017"));
            Assert.AreEqual(vaccinations3[0], new Vaccination(1, "Bordetella"), "Testing that all vaccinations are unchecked and expired");
            Assert.AreEqual(vaccinations3[1], new Vaccination(2, "Distemper"), "Testing that all vaccinations are unchecked and expired");
            Assert.AreEqual(vaccinations3[2], new Vaccination(3, "Hepatitis"), "Testing that all vaccinations are unchecked and expired");
            Assert.AreEqual(vaccinations3[3], new Vaccination(4, "Parainfluenza"), "Testing that all vaccinations are unchecked and expired");
            Assert.AreEqual(vaccinations3[4], new Vaccination(5, "Parovirus"), "Testing that all vaccinations are unchecked and expired");
            Assert.AreEqual(vaccinations3[5], new Vaccination(6, "Rabies"), "Testing that all vaccinations are unchecked and expired");

            List<Vaccination> vaccinations4 = CheckVaccinations(3, DateTime.Parse("20-SEP-2018"));
            Assert.AreEqual(vaccinations4[0], new Vaccination(1, "Bordetella"), "Testing that all vaccinations are checked but now expired");
            Assert.AreEqual(vaccinations4[1], new Vaccination(2, "Distemper"), "Testing that all vaccinations are checked but now expired");
            Assert.AreEqual(vaccinations4[2], new Vaccination(3, "Hepatitis"), "Testing that all vaccinations are checked but now expired");
            Assert.AreEqual(vaccinations4[3], new Vaccination(4, "Parainfluenza"), "Testing that all vaccinations are checked but now expired");
            Assert.AreEqual(vaccinations4[4], new Vaccination(5, "Parovirus"), "Testing that all vaccinations are checked but now expired");
            Assert.AreEqual(vaccinations4[5], new Vaccination(6, "Rabies"), "Testing that all vaccinations are checked but now expired");
        }


    }



}
