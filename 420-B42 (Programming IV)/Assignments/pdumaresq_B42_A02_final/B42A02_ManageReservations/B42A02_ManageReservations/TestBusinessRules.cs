using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using B42A04_BusinessRules;
using pdumaresq_B42_A01;
using B42A02_ManageReservations;
using stubMethods;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B42A02_ManageReservations {
    [TestClass]
    public class TestBusinessRules {
        //  Successfull return int = 100
        //  Error 101 End date is before start date
        //  Error 102 Run is not available
        //  Error 103 Run is not available for specific dog size
        //  Error 104 Run is not available for specific accomadation(Barking, Climbing)
        //  Error 105 cant modify reservation in progress
        //  Error 106 Reservation could not be found
        //  Error 107 Dog could not be found in specified run
        //  Error 108 One of the dogs is already sharing
        //  Error 109 One of the dogs is not part of the reservation
        //  Error 110 One of the dogs does not belong to the same owner
        //  Error 111 One of the dogs is already solo
        //  Error 112 one or more Vaccinations will expiry before the reservation end date
        //  Error 113 Not all vaccinations are available
        //  Error 114 Pet doesn't exist

        [TestMethod]
        public void testAddReservation() {
            //  Test Method         Makes sure correct dog is added
            //  Input Parameters:   petNumber - 1
            //                      startDate - DateTime.now.addDays(4)
            //                      endDate - DateTime.now.addDays(8)
            //  Expected Result:    Correct dog has been added to reservation
            ControlMethods testControl = new ControlMethods();
            GetData testData = new GetData();
            List<Reservation> resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(1, DateTime.Now.AddDays(4), DateTime.Now.AddDays(8)), 100);
            Assert.AreEqual(testData.reservations.Count, 91);
            Assert.AreEqual(testData.pets.Find(p => p.ownerNumber == testData.reservations.Find(r => !resBefore.Contains(r)).ownerNumber).number, 1);

            //  Test Method         Makes sure correct start date is added
            //  Input Parameters:   petNumber - 3
            //                      startDate - DateTime.now.addDays(5)
            //                      endDate - DateTime.now.addDays(7)
            //  Expected Result:    Correct startDate has been given to reservation
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(3, DateTime.Now.AddDays(5), DateTime.Now.AddDays(7)), 100);
            Assert.AreEqual(testData.reservations.Count, 91);
            Assert.AreEqual(testData.reservations.Find(r => !resBefore.Contains(r)).sDate, DateTime.Now.AddDays(5));

            //  Test Method         Makes sure correct end date is added
            //  Input Parameters:   petNumber - 5
            //                      startDate - DateTime.now.addDays(50)
            //                      endDate - DateTime.now.addDays(57)
            //  Expected Result:    correct endDate has been given to reservation
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(5, DateTime.Now.AddDays(50), DateTime.Now.AddDays(57)), 100);
            Assert.AreEqual(testData.reservations.Count, 91);
            Assert.AreEqual(testData.reservations.Find(r => !resBefore.Contains(r)).sDate, DateTime.Now.AddDays(57));

            //  Test Method         Pet doesn't exist
            //  Input Parameters:   petNumber - 5
            //                      startDate - DateTime.now.addDays(50)
            //                      endDate - DateTime.now.addDays(57)
            //  Expected Result:    Error 104
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(99, DateTime.Now.AddDays(50), DateTime.Now.AddDays(57)), 114);
            Assert.AreEqual(testData.reservations.Count, 90);

            //  Test Method         Test Makes sure end date is not before end date
            //  Input Parameters:   petNumber - 5
            //                      startDate - DateTime.now.addDays(58)
            //                      endDate - DateTime.now.addDays(57)
            //  Expected Result:    Exception 101 start date must be before end date
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(5, DateTime.Now.AddDays(50), DateTime.Now.AddDays(57)), 100);
            Assert.AreEqual(testData.reservations.Count, 91);
            Assert.IsTrue(testData.reservations
                .Find(r => !resBefore.Contains(r)).sDate < testData.reservations.Find(r => !resBefore.Contains(r)).eDate);
        }

        [TestMethod]
        public void testAddReservationOverride() {
            //  Test Method         Makes sure correct first dog is added
            //  Input Parameters:   petNumber - 45
            //                      petNumber - 13
            //                      startDate - DateTime.now.addDays(12)
            //                      endDate - DateTime.now.addDays(15)
            //  Expected Result:    pet number is 45
            ControlMethods testControl = new ControlMethods();
            GetData testData = new GetData();
            List<Reservation> resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(43, 13, DateTime.Now.AddDays(12), DateTime.Now.AddDays(15)), 100);
            Assert.AreEqual(testData.reservations.Count, 91);
            Assert.IsNull(testData.pets
                .FindAll(p => p.ownerNumber == testData.reservations
                .Find(r => !resBefore.Contains(r)).ownerNumber)[0].number == 43);

            //  Test Method         Makes sure correct second dog is added
            //  Input Parameters:   petNumber - 45
            //                      petNumber - 13
            //                      startDate - DateTime.now.addDays(4)
            //                      endDate - DateTime.now.addDays(8)
            //  Expected Result:    pet number is 13
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(43, 13, DateTime.Now.AddDays(4), DateTime.Now.AddDays(8)), 100);
            Assert.AreEqual(testData.reservations.Count, 91);
            Assert.IsNull(testData.pets.FindAll(p => p.ownerNumber == testData.reservations.Find(r => !resBefore.Contains(r)).ownerNumber)[1].number == 13);

            //  Test Method         Makes sure correct start date is added
            //  Input Parameters:   petNumber - 3
            //                      petNumber - 13
            //                      startDate - DateTime.now.addDays(5)
            //                      endDate - DateTime.now.addDays(7)
            //  Expected Result:    startdate is DateTime.now.addDays(5)
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(3, 13, DateTime.Now.AddDays(5), DateTime.Now.AddDays(7)), 100);
            Assert.AreEqual(testData.reservations.Count, 91);
            Assert.AreEqual(testData.reservations.Find(r => !resBefore.Contains(r)).sDate, DateTime.Now.AddDays(5));

            //  Test Method         Makes sure correct end date is added
            //  Input Parameters:   petNumber - 5
            //                      petNumber - 13
            //                      startDate - DateTime.now.addDays(50)
            //                      endDate - DateTime.now.addDays(57)
            //  Expected Result:    enddate is DateTime.now.addDays(57)
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(5, 13, DateTime.Now.AddDays(50), DateTime.Now.AddDays(57)), 100);
            Assert.AreEqual(testData.reservations.Count, 91);
            Assert.AreEqual(testData.reservations.Find(r => !resBefore.Contains(r)).eDate, DateTime.Now.AddDays(57));

            //  Test Method         Pet 1 doesn't exist
            //  Input Parameters:   petNumber - 99
            //                      petNumber - 13
            //                      startDate - DateTime.now.addDays(50)
            //                      endDate - DateTime.now.addDays(57)
            //  Expected Result:    Error: 114 - Pet doesn't exist
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(99, 13, DateTime.Now.AddDays(50), DateTime.Now.AddDays(57)), 114);
            Assert.AreEqual(testData.reservations.Count, 90);

            //  Test Method         Pet 2 doesn't exist
            //  Input Parameters:   petNumber - 5
            //                      petNumber - 99
            //                      startDate - DateTime.now.addDays(50)
            //                      endDate - DateTime.now.addDays(57)
            //  Expected Result:    Error: 114 - Pet doesn't exist
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(5, 99, DateTime.Now.AddDays(50), DateTime.Now.AddDays(57)), 114);
            Assert.AreEqual(testData.reservations.Count, 90);

            //  Test Method         Test Makes sure end date is not before end date
            //  Input Parameters:   petNumber - 5
            //                      petNumber - 13
            //                      startDate - DateTime.now.addDays(50)
            //                      endDate - DateTime.now.addDays(57)
            //  Expected Result:    enddate is DateTime.now.addDays(57)
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = testData.reservations;
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(5, 13, DateTime.Now.AddDays(50), DateTime.Now.AddDays(57)), 100);
            Assert.AreEqual(testData.reservations.Count, 91);
            Assert.IsTrue(testData.reservations.Find(r => !resBefore.Contains(r)).sDate < testData.reservations.Find(r => !resBefore.Contains(r)).eDate);
        }

        [TestMethod]
        public void testAddToReservation() {
            //  Test Method         Test if correct dog is added
            //  Input Parameters:   reservationNumber - 1
            //                      Petnumber - 5
            //  Expected Result:    petnumber is 5
            ControlMethods testControl = new ControlMethods();
            GetData testData = new GetData();
            List<Reservation> resBefore = new List<Reservation>();
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addReservation(5, DateTime.Now.AddDays(50), DateTime.Now.AddDays(57)), 100);
            Assert.AreEqual(testControl.addToReservation(1, 5), 100);
            Assert.IsTrue(testData.pets
                .Find(p => p.number == testData.owners
                .Find(o => o.number == testData.reservations
                .Find(r => r.number == 1).ownerNumber).number).number == 5);

            //  Test Method         Pet doesn't exist
            //  Input Parameters:   reservationNumber - 1
            //                      Petnumber - 99
            //  Expected Result:    Pet isn't added to reservation
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = new List<Reservation>();
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addToReservation(1, 99), 114);
            Assert.IsTrue(testData.pets
                .Find(p => p.number == testData.owners
                .Find(o => o.number == testData.reservations
                .Find(r => r.number == 1).ownerNumber).number) == null);

            //  Test Method         Reservation doesn't exist
            //  Input Parameters:   reservationNumber - 99
            //                      Petnumber - 5
            //  Expected Result:    petnumber is 5
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = new List<Reservation>();
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addToReservation(1, 99), 106);
        }

        [TestMethod]
        public void testAddToReservationOverride() {
            //  Test Method         Test if correct first dog is added to that run
            //  Input Parameters:   reservationNumber - 100
            //                      Petnumber1 - 5
            //                      Petnumber2 - 6
            //  Expected Result:    petnumber1 is 5
            ControlMethods testControl = new ControlMethods();
            GetData testData = new GetData();
            List<Reservation> resBefore = new List<Reservation>();
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addToReservation(100, 5), 100);
            Assert.IsTrue(testData.pets
                .Find(p => p.number == testData.owners
                .Find(o => o.number == testData.reservations
                .Find(r => r.number == 1).ownerNumber).number).number == 5);

            //  Test Method         Test if correct second dog is added to that run
            //  Input Parameters:   reservationNumber - 100
            //                      Petnumber1 - 5
            //                      Petnumber2 - 7
            //  Expected Result:    petnumber2 is 7
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = new List<Reservation>();
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addToReservation(100, 5, 7), 100);
            Assert.IsTrue(testData.pets
                .FindAll(p => p.number == testData.owners
                .Find(o => o.number == testData.reservations
                .Find(r => r.number == 1).ownerNumber).number)[0].number == 5);

            //  Test Method         Make sure an existing run is available when added for first dog
            //  Input Parameters:   reservationNumber - 100
            //                      Petnumber1 - 5
            //                      Petnumber2 - 6
            //  Expected Result:    (Success - 100) run is available and pet is added to that run
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = new List<Reservation>();
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addToReservation(100, 5, 6), 100);
            Assert.IsTrue(testData.pets
                .FindAll(p => p.number == testData.owners
                .Find(o => o.number == testData.reservations
                .Find(r => r.number == 1).ownerNumber).number)[1].number == 6);


            //  Test Method         Make sure both dogs are sharing a run
            //  Input Parameters:   reservationNumber - 100
            //                      Petnumber1 - 5
            //                      Petnumber2 - 6
            //  Expected Result:    (Success - 100) both dogs are sharing a run
            testControl = new ControlMethods();
            testData = new GetData();
            resBefore = new List<Reservation>();
            Assert.AreEqual(resBefore.Count, 90);
            Assert.AreEqual(testControl.addToReservation(100, 5, 7), 100);
            Assert.IsTrue(
                testData.petReservations.Find(pr => pr.reservationNum == 1 && pr.petNum == 5).run == 
                testData.petReservations.Find(pr => pr.reservationNum == 1 && pr.petNum == 7).run);
            Assert.IsTrue(
                testData.petReservations.Find(pr => pr.reservationNum == 1 && pr.petNum == 5).PRpetResNum ==
                testData.petReservations.Find(pr => pr.reservationNum == 1 && pr.petNum == 7).petResNum);
            Assert.IsTrue(
                testData.petReservations.Find(pr => pr.reservationNum == 1 && pr.petNum == 7).PRpetResNum ==
                testData.petReservations.Find(pr => pr.reservationNum == 1 && pr.petNum == 5).petResNum);

            // Test Method          Test reservation does not exist
            // Input Parameters:    reservationNumber - 100000
            //                      petNumber1 - 5
            //                      petNumber2 - 6
            //Excpected Result      (Error - 106) Reservation not found
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testData.reservations.Count, 90);
            Assert.AreEqual(testControl.addToReservation(10000, 5, 7), 106);
            Assert.AreEqual(testData.reservations.Count, 90);

            // Test Method          Pet 1 does not exist
            // Input Parameters:    reservationNumber - 100
            //                      petNumber1 - 99
            //                      petNumber2 - 6
            //Excpected Result      (Error - 106) Reservation not found
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testData.reservations.Count, 90);
            Assert.AreEqual(testControl.addToReservation(100, 99, 7), 114);
            Assert.AreEqual(testData.reservations.Count, 90);
        }

        [TestMethod]
        public void testCancelReservation() {
            //  Test Method         Make sure reservation is successfully cancelled
            //  Input Parameters:   reservationNumber - 123
            //  Expected Result:    100 - reservation cancelled
            ControlMethods testControl = new ControlMethods();
            GetData testData = new GetData();
            List<Reservation> testRes = testData.reservations;
            Assert.AreEqual(testData.reservations.Count, 90);
            Assert.AreEqual(testControl.cancelReservation(123), 100);
            Assert.AreEqual(testData.reservations.Count, 89);

            //  Test Method         cant cancel while reservation is in progress
            //  Input Parameters:   reservationNumber - 123
            //  Expected Result:    (Error 105) - Cant cancel reservation while in progress
            testControl = new ControlMethods();
            testData = new GetData();
            testRes = testData.reservations;
            Assert.AreEqual(testControl.cancelReservation(123), 105);

            //  Test Method         cant cancel reservation that doesnt exist
            //  Input Parameters:   reservationNumber - 999
            //  Expected Result:    (Error 106) - Reservation does not exist
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testData.reservations.Count, 90);
            Assert.AreEqual(testControl.cancelReservation(999), 105);
            Assert.AreEqual(testData.reservations.Count, 90);

            //  Test Method         make sure dogs are removed from their runs after deleting reservation
            //  Input Parameters:   reservationNumber - 101
            //  Expected Result:    (Error - 107) The runs no longer contain the dogs specified
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testData.reservations.Count, 90);
            Assert.AreEqual(testControl.cancelReservation(123), 100);
            Assert.AreEqual(testData.reservations.Count, 89);

            // Test Method          Make sure associated data is removed
            // Input Parameters:    reservationNumber - 123
            // Expected result      No petReservation with reservationNumber 123
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testData.reservations.Count, 90);
            Assert.AreEqual(testControl.cancelReservation(123), 100);
            Assert.AreEqual(testData.reservations.Count, 89);
            Assert.IsFalse(testData.petReservations.Any(pr => pr.reservationNum == 123));
            Assert.IsFalse(testData.owners.Any(o => o.reservations.Any(r => r.number == 123)));
                                    
        }

        [TestMethod]
        public void testChangeReservation() {
            //  Test Method         check if startdate is after or on current date
            //  Input Parameters:   reservationNumber - 804
            //                      startDate - "17-08-20"
            //                      endDate - "17-08-27"
            //  Expected Result:    (Success - 100) DateTime is greater than or equal than today 
            ControlMethods testControl = new ControlMethods();
            GetData testData = new GetData();
            Assert.AreEqual(testControl.changeReservation(804, DateTime.Parse("17-08-20"), DateTime.Parse("17-08-27")), 100);

            //  Test Method         check if end is after or on start date
            //  Input Parameters:   reservationNumber - 804
            //                      startDate - Datetime.Now.addDays(5)
            //                      endDate - Datetime.Now.addDays(7)
            //  Expected Result:    (Success - 100) end date is greater than or equal than startdate
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.changeReservation(804, DateTime.Parse("17-08-20"), DateTime.Parse("17-08-27")), 100);

            //  Test Method         check if startdate is no greater than one year from current date
            //  Input Parameters:   reservationNumber - 344
            //                      startDate - Datetime.Now.addDays(134)
            //                      endDate - Datetime.Now.addDays(146)
            //  Expected Result:    (Success - 100) startdate is no greater than one year from current date
            testControl = new ControlMethods();
            testData = new GetData();

        }

        [TestMethod]
        public void testChangeToSharing() {
            //  Test Method         Make sure happy path works
            //  Input Parameters:   reservationNumber - 601
            //                      petNumber1 - 26
            //                      petNumner2 - 27
            //  Expected Result:    100 ok
            ControlMethods testControl = new ControlMethods();
            GetData testData = new GetData();
            Assert.AreEqual(testControl.changeToSharing(601, 26, 27), 100);
            Assert.AreEqual(
                testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 26).run.number,
                testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 27).run.number);
            Assert.IsTrue(
               testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 26).PRpetResNum ==
               testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 27).petResNum);
            Assert.IsTrue(
                testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 27).PRpetResNum ==
                testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 26).petResNum);

            //  Test Method         test change while reservation is in progress
            //  Input Parameters:   reservationNumber - 123
            //                      petNumber1 - 12
            //                      petNumner2 - 13
            //  Expected Result:    Cannot change to sharing for reservation in progress
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.changeToSharing(123, 12, 13), 105);
            Assert.AreNotEqual(testData.petReservations.Find(pr => pr.reservationNum == 123 && pr.petNum == 12).run.number, 
                               testData.petReservations.Find(pr => pr.reservationNum == 123 && pr.petNum == 13).run.number);

            //  Test Method         test change if one pet is already sharing
            //  Input Parameters:   reservationNumber - 110
            //                      petNumber1 - 2
            //                      petNumner2 - 12
            //  Expected Result:    (Error - 108) - one of the dogs is already sharing a run
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.changeToSharing(110, 10, 12), 108);
            Assert.AreNotEqual(testData.petReservations.Find(pr => pr.reservationNum == 110 && pr.petNum == 10).run.number,
                               testData.petReservations.Find(pr => pr.reservationNum == 110 && pr.petNum == 12).run.number);

            //  Test Method         test change if one of the pets is not part of the reservation
            //  Input Parameters:   reservationNumber - 102
            //                      petNumber1 - 13
            //                      petNumner2 - 21
            //  Expected Result:    (Error - 109) - one of the dogs in not part of the reservation
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.changeToSharing(102, 13, 21), 109);
            Assert.IsFalse(testData.petReservations.Any(pr => pr.reservationNum == 102 && pr.petNum == 21));

            //  Test Method         test change if one of the pets does not belong to the same owner
            //  Input Parameters:   reservationNumber - 102
            //                      petNumber1 - 32
            //                      petNumner2 - 22
            //  Expected Result:    (Error - 110) - one of the dogs does not belong to the same owner
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.changeToSharing(102, 13, 1), 110);
            Assert.IsFalse(testData.petReservations.Any(pr => pr.reservationNum == 102 && pr.petNum == 1));
        }

        [TestMethod]
        public void testChangeToSolo() {
            //  Test Method         Make sure happy path works
            //  Input Parameters:   reservationNumber - 100
            //                      petNumber1 - 1
            //                      petNumner2 - 2
            //  Expected Result:    100 ok
            ControlMethods testControl = new ControlMethods();
            GetData testData = new GetData();
            Assert.AreEqual(testControl.changeToSolo(100, 1, 2), 100);
            Assert.AreNotEqual(
                testData.petReservations.Find(pr => pr.reservationNum == 100 && pr.petNum == 26).run.number,
                testData.petReservations.Find(pr => pr.reservationNum == 100 && pr.petNum == 27).run.number);
            Assert.IsTrue(
               testData.petReservations.Find(pr => pr.reservationNum == 100 && pr.petNum == 26).PRpetResNum !=
               testData.petReservations.Find(pr => pr.reservationNum == 100 && pr.petNum == 27).petResNum);
            Assert.IsTrue(
                testData.petReservations.Find(pr => pr.reservationNum == 100 && pr.petNum == 27).PRpetResNum !=
                testData.petReservations.Find(pr => pr.reservationNum == 100 && pr.petNum == 26).petResNum);

            //  Test Method         test that you cant change while reservation is in progress
            //  Input Parameters:   reservationNumber - 717
            //                      petNumber1 - 30
            //                      petNumner2 - 31
            //  Expected Result:    (Error - 105) - cant change an in progress reservation
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.changeToSolo(717, 30, 31), 105);
            Assert.AreNotEqual(
                testData.petReservations.Find(pr => pr.reservationNum == 717 && pr.petNum == 30).run.number,
                testData.petReservations.Find(pr => pr.reservationNum == 717 && pr.petNum == 31).run.number);
            Assert.IsTrue(
               testData.petReservations.Find(pr => pr.reservationNum == 717 && pr.petNum == 30).PRpetResNum ==
               testData.petReservations.Find(pr => pr.reservationNum == 717 && pr.petNum == 31).petResNum);
            Assert.IsTrue(
                testData.petReservations.Find(pr => pr.reservationNum == 717 && pr.petNum == 30).PRpetResNum ==
                testData.petReservations.Find(pr => pr.reservationNum == 717 && pr.petNum == 31).petResNum);

            //  Test Method         test change if one pet is already solo
            //  Input Parameters:   reservationNumber - 601
            //                      petNumber1 - 26
            //                      petNumner2 - 27
            //  Expected Result:    (Error - 111) - one of the dogs is already solo
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.changeToSolo(601, 26, 27), 100);
            Assert.AreNotEqual(
                testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 26).run.number,
                testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 27).run.number);
            Assert.IsTrue(
               testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 26).PRpetResNum !=
               testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 27).petResNum);
            Assert.IsTrue(
                testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 27).PRpetResNum !=
                testData.petReservations.Find(pr => pr.reservationNum == 601 && pr.petNum == 26).petResNum);

            //  Test Method         test change if one of the pets is not part of the reservation
            //  Input Parameters:   reservationNumber - 102
            //                      petNumber1 - 13
            //                      petNumner2 - 21
            //  Expected Result:    (Error - 109) - one of the dogs is not part of the reservation
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.changeToSharing(102, 13, 21), 109);
            Assert.IsFalse(testData.petReservations.Any(pr => pr.reservationNum == 102 && pr.petNum == 21));

            //  Test Method         test change if one of the pets does not belong to the same owner
            //  Input Parameters:   reservationNumber - 102
            //                      petNumber1 - 13
            //                      petNumner2 - 1
            //  Expected Result:    (Error - 110) - one of the dogs does not belong to the same owner
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.changeToSharing(102, 13, 1), 110);
            Assert.IsFalse(testData.petReservations.Any(pr => pr.reservationNum == 102 && pr.petNum == 1));
        }

        [TestMethod]
        public void testDeleteDogFromReservation() {
            //  Test Method         Check if reservation exists when it does not exist
            //  Input Parameters:   ReservationNumber - 601
            //                      PetNumber - 27
            //  Expected Result:    Dog is deleted from reservation : 100
            ControlMethods testControl = new ControlMethods();
            GetData testData = new GetData();
            Assert.AreEqual(testControl.deleteDogFromReservation(601, 27), 100);

            //  Test Method         Delete from non-existant reservation
            //  Input Parameters:   ReservationNumber - 999
            //                      PetNumber - 27
            //  Expected Result:    (Error - 106) - reservation could not be found
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.deleteDogFromReservation(999, 27), 106);

            //  Test Method         Dog isn't in reservation
            //  Input Parameters:   ReservationNumber - 100
            //                      PetNumber - 16
            //  Expected Result:    (Error - 109) - one of the dogs is not part of the reservation
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.deleteDogFromReservation(100, 27), 109);

            //  Test Method         check that reservation is canceled if there is only one dog
            //  Input Parameters:   ReservationNumber - 110
            //                      PetNumber - 10
            //  Expected Result:    (Success - 100) Reservation is removed
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testData.reservations.Count, 90);
            Assert.AreEqual(testControl.deleteDogFromReservation(100, 10), 100);
            Assert.AreEqual(testData.reservations.Count, 89);
            Assert.IsFalse(testData.reservations.Any(r => r.number == 100));

            //  Test Method         Make sure that the dog is removed from the reserved run and the reserved run is made available
            //  Input Parameters:   ReservationNumber - 110
            //                      PetNumber - 10
            //  Expected Result:    (Success - 100) dog is removed nd run is made available
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testData.reservations.Count, 90);
            Run run = testData.runs.Find(rn => rn.number == testData.petReservations.Find(p => p.petNum == 10 && p.reservationNum == 100).run.number);
            Assert.AreEqual(testControl.deleteDogFromReservation(100, 10), 100);
            Assert.AreEqual(testData.reservations.Count, 89);
            Assert.IsFalse(testData.reservations.Any(r => r.number == 100));
            Assert.AreEqual(testData.runs.Find(r => r.number == run.number).status, 1); //assuming 1 means available

            //  Test Method         Make sure that the dog services and daily rates are removed from the reservation
            //  Input Parameters:   ReservationNumber - 213
            //                      PetNumber - 33
            //  Expected Result:    (Success - 100) dog services are removed from the reservation for the dog
            testControl = new ControlMethods();
            testData = new GetData();
            PetReservation petRes = testData.petReservations.Find(pr => pr.petNum == 10 && pr.reservationNum == 100);
            Assert.AreEqual(testControl.deleteDogFromReservation(100, 10), 100);
            Assert.IsFalse(testData.services.Any(s => s.petResNumber == petRes.petResNum));
        }

        [TestMethod]
        public void testCheckVaccination() {
            //  Test Method         test to check if all vaccinations are valid
            //  Input Parameters:   petNumber - 12
            //                      byDate - "17-09-04"
            //  Expected Result:    (Success - 100) vaccinations are valid
            ControlMethods testControl = new ControlMethods();
            GetData testData = new GetData();
            Assert.AreEqual(testControl.checkVaccinations(12, DateTime.Parse("17-09-04")), 100);

            //  Test Method         test to check if all any vaccinations are invalid by the end date
            //  Input Parameters:   petNumber - 12
            //                      byDate - "18-09-06"
            //  Expected Result:    (Error - 112) - vaccinations will expire before the end date
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.checkVaccinations(12, DateTime.Parse("18-09-06")), 100);

            //  Test Method         test to check that all vaccinations are available
            //  Input Parameters:   petNumber - 1
            //                      byDate - "17-09-04"
            //  Expected Result:    (Success - 100) all vaccinations are available
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.checkVaccinations(1, DateTime.Parse("17-09-04")), 100);
            Assert.AreEqual(testData.vaccinations.FindAll(v => v.petNumber == 1).Count, 6);

            //  Test Method         test to check that all vaccinations are not available
            //  Input Parameters:   petNumber - 7
            //                      byDate - "17-09-04"
            //  Expected Result:    (Error - 113) not all vaccinations are available            
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.checkVaccinations(7, DateTime.Parse("17-09-04")), 113);
            Assert.AreNotEqual(testData.vaccinations.FindAll(v => v.petNumber == 7).Count, 6);
        }

        [TestMethod]
        public void checkRunAvailability() {
            //  Test Method         test to check if run is available for large dog
            //  Input Parameters:   startDate - DateTime.now.addDays(1)
            //                      endDate - DateTime.now.addDays(6)
            //                      runSize - 'L'
            //  Expected Result:    (Success - 100) Available run from start date to end date for dog
            ControlMethods testControl = new ControlMethods();
            GetData testData = new GetData();
            Assert.AreEqual(testControl.checkRunAvailability(DateTime.Now.AddDays(1), DateTime.Now.AddDays(6), 'L'), true);

            //  Test Method         test to check that the run will be available from  the beggining of the reservation to the end
            //  Input Parameters:   startDate - DateTime.now.addDays(1)
            //                      endDate - DateTime.now.addDays(4)
            //                      runSize - 'L'
            //  Expected Result:    (Success - 100) Available run from start date to end date for dog

            //  Test Method         test to check that the start date is not before today
            //  Input Parameters:   startDate - DateTime.now.addDays(-11)
            //                      endDate - DateTime.now.addDays(-5)
            //                      runSize - 'S'
            //  Expected Result:    (Success - 100) Available run from start date to end date for dog
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.checkRunAvailability(DateTime.Now.AddDays(-11), DateTime.Now.AddDays(-5), 'S'), true);

            //  Test Method         test to check that the end date is not before startdate
            //  Input Parameters:   startDate - DateTime.now.addDays(14)
            //                      endDate - DateTime.now.addDays(1)
            //                      runSize - 'S'
            //  Expected Result:    (Success - 100) start date is before end date
            testControl = new ControlMethods();
            testData = new GetData();
            Assert.AreEqual(testControl.checkRunAvailability(DateTime.Now.AddDays(14), DateTime.Now.AddDays(1), 'S'), false);
        }
    }
}