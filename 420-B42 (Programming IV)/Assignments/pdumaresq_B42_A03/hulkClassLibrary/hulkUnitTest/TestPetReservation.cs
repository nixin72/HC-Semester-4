using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HulkHvkDB;
using teamHvkBLL;
using System.Collections.Generic;

namespace hulkUnitTest {
    [TestClass]
    public class TestPetReservation {
        [TestMethod]
        public void TestPetReservationConstructors() {
            PetReservation petRes1 = new PetReservation();
            Assert.AreEqual(0, petRes1.petResNum, "Testing petRes1 petResNum");
            Assert.AreEqual(0, petRes1.petNum, "Testing petRes1 petNum");
            Assert.AreEqual(0, petRes1.reservationNum, "Testing petRes1 reservationNum");
            Assert.AreEqual(0, petRes1.runNum, "Testing petRes1 runNum");
            Assert.AreEqual(0, petRes1.PRpetResNum, "Testing petRes1 PRpetResNum");
            Assert.AreEqual(new Run(), petRes1.run, "Testing petRes1 run");
            Assert.AreEqual(new Food(), petRes1.food, "Testing petRes1 food");
            Assert.AreEqual(new Reservation(), petRes1.res, "Testing petRes1 res");
            Assert.AreEqual(0, petRes1.discounts.Count, "Testing petRes1 discounts");
            Assert.AreEqual(0, petRes1.meds.Count, "Testing petRes1 medications");
            Assert.AreEqual(0, petRes1.services.Count, "Testing petRes1 services");

            PetReservation petRes2 = new PetReservation(3, 5, 100);
            Assert.AreEqual(3, petRes2.petResNum, "Testing petRes2 petResNum");
            Assert.AreEqual(5, petRes2.petNum, "Testing petRes2 petNum");
            Assert.AreEqual(100, petRes2.reservationNum, "Testing petRes2 reservationNum");
            Assert.AreEqual(0, petRes2.runNum, "Testing petRes2 runNum");
            Assert.AreEqual(0, petRes2.PRpetResNum, "Testing petRes2 PRpetResNum");
            Assert.AreEqual(new Run(), petRes2.run, "Testing petRes2 run");
            Assert.AreEqual(new Food(), petRes2.food, "Testing petRes2 food");
            Assert.AreEqual(new Reservation(), petRes2.res, "Testing petRes2 res");
            Assert.AreEqual(0, petRes2.discounts.Count, "Testing petRes2 discounts");
            Assert.AreEqual(0, petRes2.meds.Count, "Testing petRes2 medications");
            Assert.AreEqual(0, petRes2.services.Count, "Testing petRes2 services");

            PetReservation petRes3 = new PetReservation(3, 5, 100, 27, 166);
            Assert.AreEqual(3, petRes3.petResNum, "Testing petRes3 petResNum");
            Assert.AreEqual(5, petRes3.petNum, "Testing petRes3 petNum");
            Assert.AreEqual(100, petRes3.reservationNum, "Testing petRes3 reservationNum");
            Assert.AreEqual(27, petRes3.runNum, "Testing petRes3 runNum");
            Assert.AreEqual(166, petRes3.PRpetResNum, "Testing petRes3 PRpetResNum");
            Assert.AreEqual(new Run(), petRes3.run, "Testing petRes3 run");
            Assert.AreEqual(new Food(), petRes3.food, "Testing petRes3 food");
            Assert.AreEqual(new Reservation(), petRes3.res, "Testing petRes3 res");
            Assert.AreEqual(0, petRes3.discounts.Count, "Testing petRes3 discounts");
            Assert.AreEqual(0, petRes3.meds.Count, "Testing petRes3 medications");
            Assert.AreEqual(0, petRes3.services.Count, "Testing petRes3 services");

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
            Assert.AreEqual(3, petRes4.discounts.Count, "Testing petRes4 discounts");
            Assert.AreEqual(4, petRes4.meds.Count, "Testing petRes4 medications");
            Assert.AreEqual(4, petRes4.services.Count, "Testing petRes4 services");
        }
    }
}
